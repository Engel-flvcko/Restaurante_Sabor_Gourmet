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

namespace Restaurante_Sabor_Gourmet.Engel
{
    public partial class frmDashboard : Form
    {
        // ── Estado alertas ────────────────────────────────────────────────────
        bool alertasVisibles = true;
        int yTabControlOriginal = 300;

        // Instancia de validaciones
        ValidacionesCaja val = new ValidacionesCaja();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblStatusFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblStatusHora.Text = DateTime.Now.ToString("hh:mm tt");

            CargarKPIs();
            CargarAlertas();
            CargarVentasMesero();
            CargarVentasCategoria();

            timerActualizacion.Start();
        }

        private void timerActualizacion_Tick(object sender, EventArgs e)
        {
            lblStatusFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblStatusHora.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void CargarKPIs()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                DataTable dt = sql.MostrarIndicadoresDia();

                if (dt.Rows.Count > 0)
                {
                    lblKpiVentasValor.Text = Convert.ToDecimal(dt.Rows[0]["ventas_hoy"]).ToString("C2");
                    lblKpiMesasValor.Text = dt.Rows[0]["mesas_ocupadas"].ToString();
                    lblKpiCocinaValor.Text = dt.Rows[0]["ordenes_en_cocina"].ToString();
                    lblKpiPropinaValor.Text = Convert.ToDecimal(dt.Rows[0]["propinas_hoy"]).ToString("C2");
                }

                lblUltimaActualizacion.Text = $"Última actualización: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar KPIs:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarAlertas()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                int totalAlertas = 0;

                // Alerta 1: Stock agotado
                DataTable dtAgotado = sql.MostrarStockAgotado();
                if (dtAgotado.Rows.Count > 0)
                {
                    lblAlerta1Desc.Text = dtAgotado.Rows[0]["nombre_ingrediente"].ToString();
                    lblAlerta1Desc.ForeColor = Color.FromArgb(200, 40, 40);
                    totalAlertas++;
                }
                else
                {
                    lblAlerta1Desc.Text = "Sin ingredientes agotados";
                    lblAlerta1Desc.ForeColor = Color.FromArgb(120, 120, 140);
                }

                // Alerta 2: Stock mínimo
                DataTable dtMinimo = sql.MostrarBajoStock();
                if (dtMinimo.Rows.Count > 0)
                {
                    lblAlerta2Desc.Text = $"{dtMinimo.Rows.Count} ingrediente(s)";
                    lblAlerta2Desc.ForeColor = Color.FromArgb(249, 115, 22);
                    totalAlertas++;
                }
                else
                {
                    lblAlerta2Desc.Text = "Stock en niveles normales";
                    lblAlerta2Desc.ForeColor = Color.FromArgb(120, 120, 140);
                }

                // Alerta 3: Órdenes retrasadas
                DataTable dtRetrasadas = sql.MostrarOrdenesRetrasadas();
                if (dtRetrasadas.Rows.Count > 0)
                {
                    lblAlerta3Desc.Text = $"Mesa {dtRetrasadas.Rows[0]["numero_mesa"]}";
                    lblAlerta3Desc.ForeColor = Color.FromArgb(200, 100, 0);
                    totalAlertas++;
                }
                else
                {
                    lblAlerta3Desc.Text = "Sin órdenes retrasadas";
                    lblAlerta3Desc.ForeColor = Color.FromArgb(120, 120, 140);
                }

                // Alerta 4: Diferencias de caja
                DataTable dtDiferencias = sql.MostrarArqueosConDiferencias();
                if (dtDiferencias.Rows.Count > 0)
                {
                    decimal dif = Convert.ToDecimal(dtDiferencias.Rows[0]["diferencia_arqueo"]);
                    lblAlerta4Desc.Text = $"Caja #{dtDiferencias.Rows[0]["id_arqueo"]} ({dif:C2})";
                    lblAlerta4Desc.ForeColor = Color.FromArgb(200, 40, 40);
                    totalAlertas++;
                }
                else
                {
                    lblAlerta4Desc.Text = "Sin diferencias de caja";
                    lblAlerta4Desc.ForeColor = Color.FromArgb(120, 120, 140);
                }

                // Alerta 5: Anulaciones (pendiente de otro módulo)
                lblAlerta5Desc.Text = "Ver módulo de supervisión";
                lblAlerta5Desc.ForeColor = Color.FromArgb(120, 120, 140);

                lblAlertasTitulo.Text = $"ALERTAS ACTIVAS ({totalAlertas})";
            }
            catch
            {
                lblAlertasTitulo.Text = "ALERTAS — error al cargar";
            }
        }

        private void btnOcultarAlertas_Click(object sender, EventArgs e)
        {
            alertasVisibles = !alertasVisibles;

            pnlAlerta1.Visible = alertasVisibles;
            pnlAlerta2.Visible = alertasVisibles;
            pnlAlerta3.Visible = alertasVisibles;
            pnlAlerta4.Visible = alertasVisibles;
            pnlAlerta5.Visible = alertasVisibles;

            if (alertasVisibles)
            {
                pnlAlertas.Height = 108;
                tabControl.Location = new System.Drawing.Point(12, yTabControlOriginal);
                tabControl.Height = 470;
            }
            else
            {
                pnlAlertas.Height = 36;
                tabControl.Location = new System.Drawing.Point(12, 228);
                tabControl.Height = 542;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: CargarVentasMesero(); CargarVentasCategoria(); break;
                case 1: CargarDatosCocina(); break;
                case 2: CargarBajoStock(); CargarCostosProduccion(); break;
                case 3: CargarArqueos(); break;
                case 4: CargarPersonal(); break;
            }
        }

        private void CargarVentasMesero()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                dgvVentasMesero.DataSource = sql.MostrarVentasPorMesero();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas por mesero:\n{ex.Message}");
            }
        }

        private void CargarVentasCategoria()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                dgvVentasCategoria.DataSource = sql.MostrarVentasPorCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas por categoría:\n{ex.Message}");
            }
        }

        // ── ÚNICO MÉTODO QUE CAMBIÓ — usa val.ValidarRangoFechas ─────────────
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!val.ValidarRangoFechas(dtpDesde.Value, dtpHasta.Value)) return;

            try
            {
                SQLReportes sql = new SQLReportes();
                DataTable dt = sql.MostrarVentasPorRango(dtpDesde.Value, dtpHasta.Value);

                if (dt.Rows.Count > 0)
                {
                    decimal total = Convert.ToDecimal(dt.Rows[0]["total_rango"]);
                    lblResultadoRango.Text = $"Resultado: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}  →  {total:C2}";
                }
                else
                {
                    lblResultadoRango.Text = "Resultado: sin datos en ese rango";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar:\n{ex.Message}");
            }
        }

        private void CargarDatosCocina()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                DataTable dtCocina = sql.MostrarDatosCocina();
                dgvCocina.DataSource = dtCocina;

                DataTable dtIndicadores = sql.MostrarIndicadoresDia();
                if (dtIndicadores.Rows.Count > 0)
                    lblAtendValor.Text = dtIndicadores.Rows[0]["ordenes_en_cocina"].ToString();

                int retrasadas = 0;
                foreach (DataGridViewRow row in dgvCocina.Rows)
                {
                    string estado = row.Cells["estado"].Value?.ToString() ?? "";
                    if (estado == "en_preparacion" || estado == "pendiente")
                    {
                        object minObj = row.Cells["tiempo_total"].Value;
                        if (minObj != null && minObj != DBNull.Value)
                        {
                            if (Convert.ToInt32(minObj) > 30)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                                retrasadas++;
                            }
                        }
                    }
                }

                lblRetValor.Text = retrasadas.ToString();
                lblTiempValor.Text = "—";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de cocina:\n{ex.Message}");
            }
        }

        private void CargarBajoStock()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                DataTable dt = sql.MostrarBajoStock();
                dgvBajoStock.DataSource = dt;

                foreach (DataGridViewRow row in dgvBajoStock.Rows)
                {
                    object exObj = row.Cells["existencia"].Value;
                    object minObj = row.Cells["stock_minimo"].Value;
                    if (exObj == null || minObj == null) continue;

                    decimal exist = Convert.ToDecimal(exObj);
                    decimal min = Convert.ToDecimal(minObj);

                    if (exist == 0)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 210, 210);
                    else if (exist <= min)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 213);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar stock:\n{ex.Message}");
            }
        }

        private void CargarCostosProduccion()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                DataTable dt = sql.MostrarCostosProduccion();
                dgvCostos.DataSource = dt;

                foreach (DataGridViewRow row in dgvCostos.Rows)
                {
                    object ganObj = row.Cells["ganancia"].Value;
                    if (ganObj == null || ganObj == DBNull.Value) continue;

                    decimal gan = Convert.ToDecimal(ganObj);
                    if (gan < 0)
                    {
                        row.Cells["ganancia"].Style.ForeColor = Color.FromArgb(200, 40, 40);
                        row.Cells["ganancia"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar costos:\n{ex.Message}");
            }
        }

        private void CargarArqueos()
        {
            try
            {
                SQLArqueo sql = new SQLArqueo();
                DataTable dt = sql.MostrarTodosLosArqueos();
                dgvArqueos.DataSource = dt;

                foreach (DataGridViewRow row in dgvArqueos.Rows)
                {
                    object difObj = row.Cells["diferencia"].Value;
                    if (difObj != null && difObj != DBNull.Value)
                    {
                        decimal dif = Convert.ToDecimal(difObj);
                        if (dif < 0)
                        {
                            row.Cells["diferencia"].Style.ForeColor = Color.FromArgb(200, 40, 40);
                            row.Cells["diferencia"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                    }

                    string estado = row.Cells["estado"].Value?.ToString() ?? "";
                    if (estado == "abierta")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar arqueos:\n{ex.Message}");
            }
        }

        private void CargarPersonal()
        {
            try
            {
                SQLReportes sql = new SQLReportes();
                DataTable dt = sql.MostrarVentasPorMesero();
                dgvPersonal.DataSource = dt;

                if (dgvPersonal.Rows.Count > 0)
                    dgvPersonal.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personal:\n{ex.Message}");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarKPIs();
            CargarAlertas();
            tabControl_SelectedIndexChanged(null, null);
        }

        public void EstablecerGerente(string nombreGerente)
        {
            lblGerente.Text = $"Gerente:  {nombreGerente}";
        }
    }
}