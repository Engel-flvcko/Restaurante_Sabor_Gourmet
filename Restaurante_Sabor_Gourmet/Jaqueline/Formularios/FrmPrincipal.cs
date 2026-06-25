using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
namespace Restaurante_Sabor_Gourmet.Jaqueline.Formularios
{
    public partial class FrmPrincipal : Form
    {
        // Gestionará la carga de formularios
        private GestionFormularios gestorFormularios;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Crear gestor de formularios
            gestorFormularios = new GestionFormularios(PnlCentro);

            // muestran el nombre y rol del usuario que ha iniciado sesion
            lblNombreUsuario.Text = Sesion.NombreUsuario;
            lblRolUsuario.Text = Sesion.NombreRol;

            PermisosUsuario permisos = new PermisosUsuario();

            permisos.ConfigurarBotones(
                btnMesas,
                btnCocina,
                btnMenu,
                btnUsuarios,
                btnOrdenes,
                btnInventario,
                btnCaja,
                btnReservaciones,
                btnReportes
            );

        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            // Abrir formulario de mesas dentro del panel central
            gestorFormularios.AbrirMesas();
        }

        private void btnCocina_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirCocina();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirMenu();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirInventario();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirUsuarios();
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirOrdenes();

        }


        private void btnCaja_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirCaja();
        }

        private void btnReservaciones_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirReservaciones();
        }

        

        private void btnReportes_Click(object sender, EventArgs e)
        {
            gestorFormularios.AbrirDashboard();

        }
    }
}
