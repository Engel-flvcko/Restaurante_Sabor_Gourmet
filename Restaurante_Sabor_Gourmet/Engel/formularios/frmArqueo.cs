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
    public partial class frmArqueo : Form
    {
        int idCajero;
        int idArqueoActivo = -1;
        decimal totalEsperado = 0;

        public int IdArqueoActivo { get { return idArqueoActivo; } }

        public frmArqueo(int idCajero)
        {
            InitializeComponent();
            this.idCajero = idCajero;
        }

        private void frmArqueo_Load(object sender, EventArgs e)
        {
            VerificarArqueoActivo();
            CargarHistorial();
        }

        private void VerificarArqueoActivo()
        {
            SQLArqueo sql = new SQLArqueo();
            DataTable dt = sql.ObtenerArqueoActivo(idCajero);

            if (dt.Rows.Count > 0)
            {
                idArqueoActivo = Convert.ToInt32(dt.Rows[0]["id_arqueo"]);
                totalEsperado = Convert.ToDecimal(dt.Rows[0]["total_esperado_arqueo"]); 
                lblEstado.Text = $"CAJA ABIERTA — Arqueo #{idArqueoActivo}";
                lblEsperado.Text = totalEsperado.ToString("C2");
                btnAbrirCaja.Enabled = false;
                btnCerrarCaja.Enabled = true;
                nudTotalContado.Enabled = true;
            }
            else
            {
                idArqueoActivo = -1;
                totalEsperado = 0;
                lblEstado.Text = "SIN CAJA ABIERTA";
                lblEsperado.Text = "$0.00";
                btnAbrirCaja.Enabled = true;
                btnCerrarCaja.Enabled = false;
                nudTotalContado.Enabled = false;
            }
        }

        private void CargarHistorial()
        {
            SQLArqueo sql = new SQLArqueo();
            dgvHistorial.DataSource = sql.MostrarHistorialArqueos(idCajero);
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            SQLArqueo sql = new SQLArqueo();
            int nuevoArqueo = sql.AbrirCaja(idCajero, nudFondoInicial.Value);

            if (nuevoArqueo > 0)
            {
                MessageBox.Show($"Caja abierta. Arqueo #{nuevoArqueo}");
                VerificarArqueoActivo();
                CargarHistorial();
            }
            else
            {
                MessageBox.Show("Error al abrir la caja.");
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (idArqueoActivo == -1)
            {
                MessageBox.Show("No hay caja abierta.");
                return;
            }

            SQLArqueo sql = new SQLArqueo();

            if (sql.CerrarCaja(idArqueoActivo, nudTotalContado.Value))
            {
                MessageBox.Show("Caja cerrada correctamente.");
                VerificarArqueoActivo();
                CargarHistorial();
            }
            else
            {
                MessageBox.Show("Error al cerrar la caja.");
            }
        }

        private void nudTotalContado_ValueChanged(object sender, EventArgs e)
        {
            if (idArqueoActivo == -1) return;

            // Ya no consulta la DB, usa la variable en memoria
            decimal diferencia = totalEsperado - nudTotalContado.Value;
            lblDiferencia.Text = diferencia == 0 ? "Sin diferencia"
                               : diferencia > 0 ? $"Faltante {diferencia:C2}"
                                                 : $"Sobrante {Math.Abs(diferencia):C2}";
        }
    }
}
