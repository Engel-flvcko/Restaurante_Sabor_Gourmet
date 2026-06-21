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
    public partial class frmCaja_Arqueo : Form
    {


        // ── Variables de sesión ───────────────────────────────────────────────
        int idCajero;
        int idArqueoActivo = -1;
        decimal totalEsperado = 0;

        // Propiedad pública para que Program.cs pueda leer el arqueo activo
        public int IdArqueoActivo { get { return idArqueoActivo; } }

        // ── Constructor ───────────────────────────────────────────────────────

        public frmCaja_Arqueo(int idCajero)
        {
            InitializeComponent();
            this.idCajero = idCajero;
        }

        // ─────────────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────────────
        private void frmCajaArqueo_Load(object sender, EventArgs e)
        {
            ConfigurarComboMetodoPago();
            CargarCuentasPendientes();
            VerificarArqueoActivo();
            CargarHistorial();
        }

        // ─────────────────────────────────────────────────────────────────────
        // TAB CHANGED
        // ─────────────────────────────────────────────────────────────────────
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    CargarCuentasPendientes();
                    break;
                case 1:
                    VerificarArqueoActivo();
                    CargarHistorial();
                    break;
            }
        }

        // ═════════════════════════════════════════════════════════════════════
        // TAB CAJA
        // ═════════════════════════════════════════════════════════════════════

        private void CargarCuentasPendientes()
        {
            SQLCaja sql = new SQLCaja();
            DataTable dt = sql.MostrarCuentasPendientes();
            dgvCuentas.DataSource = dt;
            lblBadgeCuentas.Text = dt.Rows.Count.ToString();
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

        // ── Selección en la grilla ────────────────────────────────────────────
        private void dgvCuentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 0) return;
            if (dgvCuentas.SelectedRows[0].Cells["id_orden"].Value == null) return;

            DataGridViewRow fila = dgvCuentas.SelectedRows[0];

            txtMesa.Text = fila.Cells["numero_mesa"].Value.ToString();
            txtMesero.Text = fila.Cells["mesero"].Value.ToString();

            // Mostrar "Para: [mesero]" en el campo de propina
            lblParaMesero.Text = $"Para: {txtMesero.Text}";

            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentaje = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal descuento = subtotal * (porcentaje / 100);

            txtSubtotal.Text = subtotal.ToString("C2");
            txtDescuento.Text = $"{porcentaje}%  ({descuento:C2})";

            // Resetear propina y monto recibido al cambiar de orden
            rbSinPropina.Checked = true;
            nudPropina.Value = 0;
            nudPorcentajePropina.Value = 10;
            nudMontoRecibido.Value = 0;
            nudEfectivo.Value = 0;
            nudTarjeta.Value = 0;

            RecalcularTotal();
        }

        // ── Propina — 3 modos ─────────────────────────────────────────────────
        private void rbPropina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSinPropina.Checked)
            {
                nudPropina.Enabled = false;
                nudPorcentajePropina.Enabled = false;
                nudPropina.Value = 0;
            }
            else if (rbPropinaMonto.Checked)
            {
                nudPropina.Enabled = true;
                nudPorcentajePropina.Enabled = false;
            }
            else if (rbPropinaPorcentaje.Checked)
            {
                nudPropina.Enabled = false;
                nudPorcentajePropina.Enabled = true;
            }

            RecalcularTotal();
        }

        private void nudPropina_ValueChanged(object sender, EventArgs e)
        {
            RecalcularTotal();
        }

        // ── Método de pago ────────────────────────────────────────────────────
        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem == null) return;

            string metodo = cmbMetodoPago.SelectedItem.ToString();

            // Pago mixto: mostrar panel extra, ocultar monto recibido simple
            pnlMixto.Visible = (metodo == "mixto");
            nudMontoRecibido.Enabled = (metodo == "efectivo");
            lblLblMontoRecibido.ForeColor = nudMontoRecibido.Enabled
                ? Color.FromArgb(80, 80, 100)
                : Color.FromArgb(180, 180, 200);

            // Si no es efectivo ni mixto, monto recibido no aplica (tarjeta, etc.)
            if (metodo != "efectivo" && metodo != "mixto")
                nudMontoRecibido.Value = 0;

            // Ajustar posición del panel TOTAL cuando mixto aparece o desaparece
            pnlTotal.Location = pnlMixto.Visible
                ? new System.Drawing.Point(18, 552)
                : new System.Drawing.Point(18, 470);

            btnCobrar.Location = new System.Drawing.Point(18,
                pnlTotal.Location.Y + pnlTotal.Height + 12);

            RecalcularTotal();
        }

        private void nudMixto_ValueChanged(object sender, EventArgs e)
        {
            decimal suma = nudEfectivo.Value + nudTarjeta.Value;
            lblSumaMixto.Text = $"Suma: {suma:C2}";
            lblSumaMixto.ForeColor = (suma == ObtenerTotalFinal())
                ? Color.FromArgb(22, 140, 60)
                : Color.FromArgb(200, 60, 60);

            RecalcularTotal();
        }

        private void nudMontoRecibido_ValueChanged(object sender, EventArgs e)
        {
            RecalcularTotal();
        }

        // ── Cálculo central ───────────────────────────────────────────────────
        private decimal ObtenerMontoPropina()
        {
            if (dgvCuentas.SelectedRows.Count == 0) return 0;

            if (rbSinPropina.Checked)
                return 0;

            if (rbPropinaMonto.Checked)
                return nudPropina.Value;

            // Propina sugerida: porcentaje sobre el subtotal con descuento
            DataGridViewRow fila = dgvCuentas.SelectedRows[0];
            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentajeDesc = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal totalConDescuento = subtotal - subtotal * (porcentajeDesc / 100);
            return totalConDescuento * (nudPorcentajePropina.Value / 100);
        }

        private decimal ObtenerTotalFinal()
        {
            if (dgvCuentas.SelectedRows.Count == 0) return 0;

            DataGridViewRow fila = dgvCuentas.SelectedRows[0];
            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentajeDesc = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal montoDescuento = subtotal * (porcentajeDesc / 100);
            decimal totalConDescuento = subtotal - montoDescuento;
            return totalConDescuento + ObtenerMontoPropina();
        }

        private void RecalcularTotal()
        {
            if (dgvCuentas.SelectedRows.Count == 0) return;

            decimal totalFinal = ObtenerTotalFinal();
            lblTotal.Text = totalFinal.ToString("C2");

            string metodo = cmbMetodoPago.SelectedItem?.ToString() ?? "efectivo";

            if (metodo == "efectivo")
            {
                decimal cambio = nudMontoRecibido.Value - totalFinal;
                txtCambio.Text = cambio >= 0 ? cambio.ToString("C2") : "$0.00";
                txtCambio.ForeColor = cambio >= 0
                    ? Color.FromArgb(37, 99, 235)
                    : Color.FromArgb(200, 60, 60);
            }
            else if (metodo == "mixto")
            {
                decimal suma = nudEfectivo.Value + nudTarjeta.Value;
                decimal cambio = nudEfectivo.Value - totalFinal + nudTarjeta.Value;
                txtCambio.Text = (suma >= totalFinal) ? cambio.ToString("C2") : "—";
            }
            else
            {
                // Tarjeta, transferencia, pago_movil → no hay cambio
                txtCambio.Text = "N/A";
                txtCambio.ForeColor = Color.FromArgb(150, 150, 170);
            }
        }

        // ── Registrar cobro ───────────────────────────────────────────────────
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (idArqueoActivo == -1)
            {
                MessageBox.Show("No hay una caja abierta. Ve al tab 'Arqueo de Caja' y abre la caja primero.",
                    "Sin caja abierta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 1;
                return;
            }

            if (dgvCuentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una cuenta de la lista.");
                return;
            }

            DataGridViewRow fila = dgvCuentas.SelectedRows[0];
            int idOrden = Convert.ToInt32(fila.Cells["id_orden"].Value);
            decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);
            decimal porcentajeDesc = Convert.ToDecimal(fila.Cells["descuento"].Value);
            decimal montoDescuento = subtotal * (porcentajeDesc / 100);
            decimal totalConDescuento = subtotal - montoDescuento;
            decimal montoPropina = ObtenerMontoPropina();
            decimal totalFinal = totalConDescuento + montoPropina;
            string metodo = cmbMetodoPago.SelectedItem.ToString();

            // ── Validaciones según método ─────────────────────────────────────
            if (metodo == "efectivo" && nudMontoRecibido.Value < totalFinal)
            {
                MessageBox.Show("El monto recibido es menor al total a cobrar.");
                return;
            }

            if (metodo == "mixto")
            {
                decimal sumaMixta = nudEfectivo.Value + nudTarjeta.Value;
                if (sumaMixta < totalFinal)
                {
                    MessageBox.Show($"La suma del pago mixto ({sumaMixta:C2}) es menor al total ({totalFinal:C2}).");
                    return;
                }
            }

            // ── Confirmación ──────────────────────────────────────────────────
            DialogResult confirm = MessageBox.Show(
                $"¿Confirmar cobro de {totalFinal:C2}?\nMétodo: {metodo}\nPropina: {montoPropina:C2} (para {txtMesero.Text})",
                "Confirmar pago",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // ── Registrar pago ────────────────────────────────────────────────
            Pago pago = new Pago();
            pago.IdOrden = idOrden;
            pago.IdCajero = idCajero;
            pago.IdArqueo = idArqueoActivo;
            pago.Subtotal = subtotal;
            pago.Descuento = montoDescuento;
            pago.Propina = montoPropina;
            pago.MetodoPago = metodo;
            pago.Total = totalFinal;

            SQLCaja sql = new SQLCaja();

            if (sql.RegistrarPago(pago))
            {
                MessageBox.Show("Pago registrado correctamente.");
                CargarCuentasPendientes();
                LimpiarCampos();
                // Refrescar total esperado en el tab Arqueo
                VerificarArqueoActivo();
            }
            else
            {
                MessageBox.Show("Error al registrar el pago.");
            }
        }

        private void LimpiarCampos()
        {
            txtMesa.Text = "";
            txtMesero.Text = "";
            txtSubtotal.Text = "$0.00";
            txtDescuento.Text = "$0.00 (0%)";
            lblTotal.Text = "$0.00";
            txtCambio.Text = "$0.00";
            lblParaMesero.Text = "Para: —";
            rbSinPropina.Checked = true;
            nudPropina.Value = 0;
            nudPorcentajePropina.Value = 10;
            nudMontoRecibido.Value = 0;
            nudEfectivo.Value = 0;
            nudTarjeta.Value = 0;
            lblSumaMixto.Text = "Suma: $0.00";
            pnlMixto.Visible = false;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCuentasPendientes();
        }

        // ═════════════════════════════════════════════════════════════════════
        // TAB ARQUEO
        // ═════════════════════════════════════════════════════════════════════

        private void VerificarArqueoActivo()
        {
            SQLArqueo sql = new SQLArqueo();
            DataTable dt = sql.ObtenerArqueoActivo(idCajero);

            if (dt.Rows.Count > 0)
            {
                idArqueoActivo = Convert.ToInt32(dt.Rows[0]["id_arqueo"]);
                totalEsperado = Convert.ToDecimal(dt.Rows[0]["total_esperado_arqueo"]);

                // Card estado
                lblEstado.Text = $"CAJA ABIERTA #{idArqueoActivo}";
                pnlBadgeEstado.FillColor = Color.FromArgb(34, 197, 94);
                lblEsperado.Text = totalEsperado.ToString("C2");

                // Barra superior
                lblInfoArqueo.Text = $"Arqueo #{idArqueoActivo}  |  ABIERTO";

                // Habilitar cierre
                btnAbrirCaja.Enabled = false;
                nudFondoInicial.Enabled = false;
                btnCerrarCaja.Enabled = true;
                nudTotalContado.Enabled = true;
                btnCerrarCaja.FillColor = Color.FromArgb(239, 68, 68);
            }
            else
            {
                idArqueoActivo = -1;
                totalEsperado = 0;

                lblEstado.Text = "SIN CAJA ABIERTA";
                pnlBadgeEstado.FillColor = Color.FromArgb(239, 68, 68);
                lblEsperado.Text = "$0.00";
                lblDiferencia.Text = "—";

                lblInfoArqueo.Text = "Arqueo #—  |  CERRADO";

                btnAbrirCaja.Enabled = true;
                nudFondoInicial.Enabled = true;
                btnCerrarCaja.Enabled = false;
                nudTotalContado.Enabled = false;
                nudTotalContado.Value = 0;
                btnCerrarCaja.FillColor = Color.FromArgb(200, 200, 210);
            }
        }

        private void CargarHistorial()
        {
            SQLArqueo sql = new SQLArqueo();
            dgvHistorial.DataSource = sql.MostrarHistorialArqueos(idCajero);

            // Colorear filas: rojo faltante, verde abierta
            foreach (DataGridViewRow row in dgvHistorial.Rows)
            {
                string estado = row.Cells["estado_arqueo"].Value?.ToString() ?? "";
                if (estado == "abierta")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);

                // Si la diferencia es negativa (faltante), colorear rojo
                object difVal = row.Cells["diferencia_arqueo"].Value;
                if (difVal != null && difVal != DBNull.Value)
                {
                    decimal dif = Convert.ToDecimal(difVal);
                    if (dif < 0)
                    {
                        row.Cells["diferencia_arqueo"].Style.ForeColor = Color.FromArgb(200, 40, 40);
                        row.Cells["diferencia_arqueo"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            SQLArqueo sql = new SQLArqueo();
            int nuevoArqueo = sql.AbrirCaja(idCajero, nudFondoInicial.Value);

            if (nuevoArqueo > 0)
            {
                MessageBox.Show($"Caja abierta correctamente. Arqueo #{nuevoArqueo}",
                    "Apertura exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerificarArqueoActivo();
                CargarHistorial();
            }
            else
            {
                MessageBox.Show("Error al abrir la caja. Verifica que no tengas otra caja abierta.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (idArqueoActivo == -1)
            {
                MessageBox.Show("No hay caja abierta.");
                return;
            }

            decimal diferencia = totalEsperado - nudTotalContado.Value;
            string msgDif = diferencia == 0 ? "Sin diferencia."
                               : diferencia > 0 ? $"Faltante de {diferencia:C2}"
                                                 : $"Sobrante de {Math.Abs(diferencia):C2}";

            DialogResult confirm = MessageBox.Show(
                $"¿Cerrar la caja?\n\nTotal esperado:  {totalEsperado:C2}\nTotal contado:   {nudTotalContado.Value:C2}\n{msgDif}",
                "Confirmar cierre",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            SQLArqueo sql = new SQLArqueo();

            if (sql.CerrarCaja(idArqueoActivo, nudTotalContado.Value))
            {
                MessageBox.Show("Caja cerrada correctamente.",
                    "Cierre exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerificarArqueoActivo();
                CargarHistorial();
            }
            else
            {
                MessageBox.Show("Error al cerrar la caja.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudTotalContado_ValueChanged(object sender, EventArgs e)
        {
            if (idArqueoActivo == -1) return;

            decimal diferencia = totalEsperado - nudTotalContado.Value;

            if (diferencia == 0)
            {
                lblDiferencia.Text = "Sin diferencia";
                lblDiferencia.ForeColor = Color.FromArgb(34, 197, 94);
            }
            else if (diferencia > 0)
            {
                lblDiferencia.Text = $"Faltante {diferencia:C2}";
                lblDiferencia.ForeColor = Color.FromArgb(200, 40, 40);
            }
            else
            {
                lblDiferencia.Text = $"Sobrante {Math.Abs(diferencia):C2}";
                lblDiferencia.ForeColor = Color.FromArgb(37, 99, 235);
            }
        }
    }
}