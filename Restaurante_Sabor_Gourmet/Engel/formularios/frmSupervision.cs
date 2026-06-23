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
            dgvOrdenes.DataSource = sql.MostrarOrdenesSinDescuento();
        }

        private void CargarDescuentosDelDia()
        {
            SQLDescuentoAutorizado sql = new SQLDescuentoAutorizado();
            var dt = sql.MostrarDescuentosDelDia();
            dgvDescuentosHoy.DataSource = dt;
            lblBadgeNum.Text = dt.Rows.Count.ToString();
        }

        private void btnAutorizarDescuento_Click(object sender, EventArgs e)
        {
            // ── Validaciones usando la clase ──────────────────────────────────
            if (!val.ValidarOrdenSeleccionadaDescuento(dgvOrdenes)) return;
            if (!val.ValidarMotivoDescuento(txtMotivo.Text)) return;

            DataGridViewRow fila = dgvOrdenes.SelectedRows[0];

            DescuentoAutorizado descuento = new DescuentoAutorizado();
            descuento.IdOrden = Convert.ToInt32(fila.Cells["id_orden"].Value);
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

        private void CargarPromociones()
        {
            SQLPromocion sql = new SQLPromocion();
            dgvPromociones.DataSource = sql.MostrarPromociones();
        }

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

        private void CargarArqueosConDiferencias()
        {
            SQLArqueo sql = new SQLArqueo();
            dgvDiferencias.DataSource = sql.MostrarArqueosConDiferencias();
        }

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

        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvOrdenes.SelectedRows[0];
            string idOrden = fila.Cells["id_orden"].Value.ToString();
            string mesa = fila.Cells["numero_mesa"].Value.ToString();

            txtOrdenSelec.Text = $"#{idOrden}  —  Mesa {mesa}";
        }
    }
}