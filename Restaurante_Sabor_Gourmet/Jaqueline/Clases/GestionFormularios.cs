using Guna.UI2.WinForms;
using Restaurante_Sabor_Gourmet.Engel;
using Restaurante_Sabor_Gourmet.Engel.formularios;
using Restaurante_Sabor_Gourmet.Formularios;
using Restaurante_Sabor_Gourmet.Haydee;
using Restaurante_Sabor_Gourmet.Jaqueline.Formularios;
using Restaurante_Sabor_Gourmet.Vane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class GestionFormularios
    {
        // Panel central donde se cargarán los formularios
        private Guna2Panel _pnlCentro;

        // Constructor
        public GestionFormularios(Guna2Panel pnlCentro)
        {
            _pnlCentro = pnlCentro;
        }

        // Método general para cargar formularios dentro del panel
        private void CargarFormulario(Form formulario)
        {
            // Limpiar el contenido actual del panel
            _pnlCentro.Controls.Clear();

            // Configurar el formulario para que se muestre dentro del panel
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.None; 
            formulario.Width = _pnlCentro.Width;
            formulario.Height = _pnlCentro.Height;

            // Agregar formulario al panel
            _pnlCentro.Controls.Add(formulario);

            // Mostrar formulario
            formulario.Show();
        }

        // Abrir formulario de mesas
        public void AbrirMesas()
        {
            CargarFormulario(new FrmMesas());
        }

        // ── Módulos existentes ─────────────────────────────────────────────────────

        public void AbrirCocina()
        {
            CargarFormulario(new frmCocina(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

        public void AbrirOrdenes()
        {
            CargarFormulario(new frmOrdenes(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

        public void AbrirInventario()
        {
            CargarFormulario(new frmInventario(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

        public void AbrirRecetas()
        {
            CargarFormulario(new frmRecetas(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

        public void AbrirMeseros()
        {
            CargarFormulario(new frmMeseros(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

        public void AbrirCaja()
        {
            CargarFormulario(new frmCaja_Arqueo(Sesion.IdUsuario));
        }

        public void AbrirSupervision()
        {
            CargarFormulario(new frmSupervision(Sesion.IdUsuario));
        }

        public void AbrirDashboard()
        {
            CargarFormulario(new frmReportes());
        }

        public void AbrirUsuarios()
        {
            CargarFormulario(new frmUsuarios());
        }

        public void AbrirMenu()
        {
            CargarFormulario(new frmMenu(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

        public void AbrirReservaciones()
        {
            CargarFormulario(new frmReservaciones(Sesion.IdUsuario, Sesion.NombreUsuario));
        }

    }
}
