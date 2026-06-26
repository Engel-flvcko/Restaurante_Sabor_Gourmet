using Restaurante_Sabor_Gourmet.Engel.clases;
using Restaurante_Sabor_Gourmet.Engel.consultasSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Engel.formularios
{
    public partial class frmSupervision : Form
    {
        int idSupervisor;

        // Instancia de validaciones
        ValidacionesCaja val = new ValidacionesCaja();

        public frmSupervision(int idSupervisor)
        {
            InitializeComponent();
            this.idSupervisor = idSupervisor;
        }

        private void frmSupervision_Load(object sender, EventArgs e)
        {
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            CargarOrdenesSinDescuento();
            CargarDescuentosDelDia();
            CargarPromociones();
            CargarArqueosConDiferencias();
        }

        // ── DESCUENTOS ────────────────────────────────────────────────────────

        private void CargarOrdenesSinDescuento()
        {
            SQLDescuentoAutorizado sql = new SQLDescuentoAutorizado();
            DataTable dt = sql.MostrarOrdenesSinDescuento();

            dgvOrdenes.AutoGenerateColumns = false;
            colOrdenOrd.DataPropertyName = "id_orden";
            colMesaOrd.DataPropertyName = "numero_mesa";
            colMeseroOrd.DataPropertyName = "mesero";
            colEstadoOrd.DataPropertyName = "estado_orden";
            colSubtotalOrd.DataPropertyName = "subtotal";
            dgvOrdenes.DataSource = dt;
        }

        private void CargarDescuentosDelDia()
        {
            SQLDescuentoAutorizado sql = new SQLDescuentoAutorizado();
            DataTable dt = sql.MostrarDescuentosDelDia();

            dgvDescuentosHoy.AutoGenerateColumns = false;
            colOrdenHoy.DataPropertyName = "id_descuento";
            colMesaHoy.DataPropertyName = "numero_mesa";
            colSupervisorHoy.DataPropertyName = "supervisor";
            colCajeroHoy.DataPropertyName = "cajero";
            colPorcentajeHoy.DataPropertyName = "porcentaje_descuento";
            colMotivoHoy.DataPropertyName = "motivo_descuento";
            colHoraHoy.DataPropertyName = "fecha_descuento";
            dgvDescuentosHoy.DataSource = dt;

            lblBadgeNum.Text = dt.Rows.Count.ToString();
        }

        private void CargarPromociones()
        {
            SQLPromocion sql = new SQLPromocion();
            DataTable dt = sql.MostrarPromociones();

            dgvPromociones.AutoGenerateColumns = false;
            colNombrePromo.DataPropertyName = "nombre_promocion";
            colPorcentajePromo.DataPropertyName = "porcentaje_promocion";
            colInicioPromo.DataPropertyName = "fecha_inicio_promocion";
            colFinPromo.DataPropertyName = "fecha_fin_promocion";
            colEstadoPromo.DataPropertyName = "estado";
            dgvPromociones.DataSource = dt;
        }

        private void CargarArqueosConDiferencias()
        {
            SQLArqueo sql = new SQLArqueo();
            DataTable dt = sql.MostrarArqueosConDiferencias();

            dgvDiferencias.AutoGenerateColumns = false;
            colCajeroDif.DataPropertyName = "nombre_cajero";
            colAperturaDif.DataPropertyName = "fecha_apertura_arqueo";
            colEsperadoDif.DataPropertyName = "total_esperado_arqueo";
            colContadoDif.DataPropertyName = "total_contado_arqueo";
            colDiferenciaDif.DataPropertyName = "diferencia_arqueo";
            dgvDiferencias.DataSource = dt;
        }

        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvOrdenes.SelectedRows[0];
            object idOrden = fila.Cells["colOrdenOrd"].Value;
            object mesa = fila.Cells["colMesaOrd"].Value;

            if (idOrden == null || mesa == null) return;

            txtOrdenSelec.Text = $"#{idOrden}  —  Mesa {mesa}";
        }

        private void btnAutorizarDescuento_Click(object sender, EventArgs e)
        {
            // ── Validaciones usando la clase ──────────────────────────────────
            if (!val.ValidarOrdenSeleccionadaDescuento(dgvOrdenes)) return;
            if (!val.ValidarMotivoDescuento(txtMotivo.Text)) return;

            DataGridViewRow fila = dgvOrdenes.SelectedRows[0];

            DescuentoAutorizado descuento = new DescuentoAutorizado();
            descuento.IdOrden = Convert.ToInt32(fila.Cells["colOrdenOrd"].Value);
            descuento.IdSupervisor = idSupervisor;
            descuento.IdCajero = 0;
            descuento.PorcentajeDescuento = nudPorcentaje.Value;
            descuento.MotivoDescuento = txtMotivo.Text.Trim();

            SQLDescuentoAutorizado sql = new SQLDescuentoAutorizado();

            if (sql.GuardarDescuento(descuento))
            {
                MessageBox.Show("Descuento autorizado.");
                txtMotivo.Text = "";
                txtOrdenSelec.Text = "";
                CargarOrdenesSinDescuento();
                CargarDescuentosDelDia();
            }
            else
            {
                MessageBox.Show("Error al autorizar el descuento.");
            }
        }

        // ── PROMOCIONES ───────────────────────────────────────────────────────


        private void btnGuardarPromocion_Click(object sender, EventArgs e)
        {
            // ── Validaciones usando la clase ──────────────────────────────────
            if (!val.ValidarNombrePromocion(txtNombrePromo.Text.Trim())) return;
            if (!val.ValidarFechasPromocion(dtpInicio.Value.Date, dtpFin.Value.Date)) return;

            Promocion promocion = new Promocion();
            promocion.NombrePromocion = txtNombrePromo.Text.Trim();
            promocion.PorcentajePromocion = nudPorcentajePromo.Value;
            promocion.FechaInicio = dtpInicio.Value.Date;
            promocion.FechaFin = dtpFin.Value.Date;

            SQLPromocion sql = new SQLPromocion();

            if (sql.GuardarPromocion(promocion))
            {
                MessageBox.Show("Promoción guardada.");
                txtNombrePromo.Text = "";
                CargarPromociones();
            }
            else
            {
                MessageBox.Show("Error al guardar la promoción.");
            }
        }

        private void btnEliminarPromocion_Click(object sender, EventArgs e)
        {
            // ── Validación usando la clase ────────────────────────────────────
            if (!val.ValidarPromocionSeleccionada(dgvPromociones)) return;

            int idPromocion = Convert.ToInt32(
                dgvPromociones.SelectedRows[0].Cells["id_promocion"].Value);

            SQLPromocion sql = new SQLPromocion();

            if (sql.EliminarPromocion(idPromocion))
            {
                MessageBox.Show("Promoción eliminada.");
                CargarPromociones();
            }
            else
            {
                MessageBox.Show("Error al eliminar la promoción.");
            }
        }

        // ── ARQUEOS CON DIFERENCIAS ───────────────────────────────────────────


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    CargarOrdenesSinDescuento();
                    CargarDescuentosDelDia();
                    break;
                case 1:
                    CargarPromociones();
                    break;
                case 2:
                    CargarArqueosConDiferencias();
                    break;
            }
        }
    }
}