using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using Restaurante_Sabor_Gourmet.Jaqueline.Formularios;

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


    }
}
