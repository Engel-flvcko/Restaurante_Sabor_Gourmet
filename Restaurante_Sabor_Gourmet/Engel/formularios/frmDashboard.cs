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
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            CargarIndicadores();
            
        }

        private void CargarIndicadores()
        {
            SQLReportes sql = new SQLReportes();
            DataTable dt = sql.MostrarIndicadoresDia();

            if (dt.Rows.Count > 0)
            {
                lblVentasHoy.Text = Convert.ToDecimal(dt.Rows[0]["ventas_hoy"]).ToString("C2");
                lblMesasOcupadas.Text = dt.Rows[0]["mesas_ocupadas"].ToString();
                lblOrdenesEnCocina.Text = dt.Rows[0]["ordenes_en_cocina"].ToString();
                lblPropinasHoy.Text = Convert.ToDecimal(dt.Rows[0]["propinas_hoy"]).ToString("C2");
            }
        }

        private void CargarVentasPorMesero()
        {
            SQLReportes sql = new SQLReportes();
            dgvVentasMesero.DataSource = sql.MostrarVentasPorMesero();
        }

        private void CargarTopProductos()
        {
            SQLReportes sql = new SQLReportes();
            dgvTopProductos.DataSource = sql.MostrarProductosMasVendidos();
        }

        private void CargarVentasPorCategoria()
        {
            SQLReportes sql = new SQLReportes();
            dgvCategorias.DataSource = sql.MostrarVentasPorCategoria();
        }

        private void CargarPropinas()
        {
            SQLReportes sql = new SQLReportes();
            dgvPropinas.DataSource = sql.MostrarPropinas();
        }

        private void CargarCostosProduccion()
        {
            SQLReportes sql = new SQLReportes();
            dgvCostos.DataSource = sql.MostrarCostosProduccion();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarIndicadores();
        }

        private void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            SQLReportes sql = new SQLReportes();
            DataTable dt = sql.MostrarVentasPorRango(dtpDesde.Value, dtpHasta.Value);

            if (dt.Rows.Count > 0)
            {
                lblVentasRango.Text = Convert.ToDecimal(dt.Rows[0]["total_rango"]).ToString("C2");
            }
        }

        private void tabReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabReportes.SelectedIndex)
            {
                case 0: CargarVentasPorMesero(); break;
                case 1: CargarTopProductos(); break;
                case 2: CargarVentasPorCategoria(); break;
                case 3: CargarPropinas(); break;
                case 4: CargarCostosProduccion(); break;
            }
        }
    }
}
