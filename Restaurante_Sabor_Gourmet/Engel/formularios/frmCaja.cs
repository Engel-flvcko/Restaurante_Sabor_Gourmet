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
    public partial class frmCaja : Form
    {
        int idCajero;
        int idArqueo;

        public frmCaja(int idCajero, int idArqueo)
        {
            InitializeComponent();
            this.idCajero = idCajero;
            this.idArqueo = idArqueo;
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            CargarCuentasPendientes();
            ConfigurarComboMetodoPago();
        }

        private void CargarCuentasPendientes()
        {
            SQLCaja sql = new SQLCaja();
            dgvCuentas.DataSource = sql.MostrarCuentasPendientes();
        }

        private void ConfigurarComboMetodoPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("efectivo");
            cmbMetodoPago.Items.Add("tarjeta");
            cmbMetodoPago.Items.Add("transferencia");
            cmbMetodoPago.Items.Add("pago_movil");
            cmbMetodoPago.Items.Add("mixto");
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void dgvCuentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvCuentas.SelectedRows[0];

            txtMesa.Text = fila.Cells["numero_mesa"].Value.ToString();
            txtMesero.Text = fila.Cells["mesero"].Value.ToString();

            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentaje = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal descuento = subtotal * (porcentaje / 100);
            decimal total = subtotal - descuento;

            txtSubtotal.Text = subtotal.ToString("C2");
            txtDescuento.Text = $"{porcentaje}%  ({descuento:C2})";
            txtTotal.Text = total.ToString("C2");

            nudPropina.Value = 0;
        }

        private void nudPropina_ValueChanged(object sender, EventArgs e)
        {
            RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            if (dgvCuentas.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvCuentas.SelectedRows[0];
            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentaje = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal montoDescuento = subtotal * (porcentaje / 100);
            decimal totalConDescuento = subtotal - montoDescuento;
            decimal totalFinal = totalConDescuento + nudPropina.Value;

            txtTotal.Text = totalFinal.ToString("C2");

            decimal cambio = nudMontoRecibido.Value - totalFinal;
            txtCambio.Text = cambio >= 0 ? cambio.ToString("C2") : "$0.00";
        }

        private void nudMontoRecibido_ValueChanged(object sender, EventArgs e)
        {
            RecalcularTotal();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una cuenta de la lista.");
                return;
            }

            DataGridViewRow fila = dgvCuentas.SelectedRows[0];
            int idOrden = Convert.ToInt32(fila.Cells["id_orden"].Value);
            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentaje = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal montoDescuento = subtotal * (porcentaje / 100);
            decimal totalConDescuento = subtotal - montoDescuento;
            decimal totalFinal = totalConDescuento + nudPropina.Value;
            string metodo = cmbMetodoPago.SelectedItem.ToString();

            if (metodo == "efectivo" && nudMontoRecibido.Value < totalFinal)
            {
                MessageBox.Show("El monto recibido es menor al total.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
            $"¿Confirmar cobro de {totalFinal:C2}?",
            "Confirmar pago",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            Pago pago = new Pago();
            pago.IdOrden = idOrden;
            pago.IdCajero = idCajero;
            pago.IdArqueo = idArqueo;
            pago.Subtotal = subtotal;
            pago.Descuento = montoDescuento;
            pago.Propina = nudPropina.Value;
            pago.MetodoPago = metodo;
            pago.Total = totalFinal;

            SQLCaja sql = new SQLCaja();

            if (sql.RegistrarPago(pago))
            {
                MessageBox.Show("Pago registrado correctamente.");
                CargarCuentasPendientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al registrar el pago.");
            }
        }

        private void LimpiarCampos()
        {
            txtMesa.Clear();
            txtMesero.Clear();
            txtSubtotal.Clear();
            txtDescuento.Clear();
            txtTotal.Clear();
            txtCambio.Clear();
            nudPropina.Value = 0;
            nudMontoRecibido.Value = 0;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCuentasPendientes();
        }
    }
}