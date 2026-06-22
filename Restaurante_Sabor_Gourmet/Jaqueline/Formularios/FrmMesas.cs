using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Formularios
{
    public partial class FrmMesas : Form
    {
        public FrmMesas()
        {
            InitializeComponent();
        }

        private void FrmMesas_Load(object sender, EventArgs e)
        {

            CrearTitulos();        // títulos de zonas
            ConfigurarLeyendaPanel(); // configuración visual
            CargarLeyenda();       // leyenda de colores

            // Crear instancia de la clase UI
            InsertarMesas ui = new InsertarMesas();

            // Cargar mesas en cada zona
            ui.CargarMesas(flpSalon, flpFamiliar, flpEventos);
            
        }

        private void CrearTitulos()
        {
            // SALÓN PRINCIPAL
            Label lblSalon = new Label();
            lblSalon.Text = "SALÓN PRINCIPAL";
            lblSalon.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSalon.AutoSize = true;
            lblSalon.Location = new Point(flpSalon.Location.X, flpSalon.Location.Y - 25);
            this.Controls.Add(lblSalon);

            // ZONA FAMILIAR
            Label lblFamiliar = new Label();
            lblFamiliar.Text = "ZONA FAMILIAR";
            lblFamiliar.Font = new Font("Arial", 12, FontStyle.Bold);
            lblFamiliar.AutoSize = true;
            lblFamiliar.Location = new Point(flpFamiliar.Location.X, flpFamiliar.Location.Y - 25);
            this.Controls.Add(lblFamiliar);

            // ZONA EVENTOS
            Label lblEventos = new Label();
            lblEventos.Text = "ZONA EVENTOS";
            lblEventos.Font = new Font("Arial", 12, FontStyle.Bold);
            lblEventos.AutoSize = true;
            lblEventos.Location = new Point(flpEventos.Location.X, flpEventos.Location.Y - 25);
            this.Controls.Add(lblEventos);
        }

        private void ConfigurarLeyendaPanel()
        {
            // Asegurar distribución horizontal los titulos 
            flpLeyenda.FlowDirection = FlowDirection.LeftToRight;
            flpLeyenda.WrapContents = false;
            flpLeyenda.AutoScroll = true;
        }

        private void CargarLeyenda()
        {
            // Limpiar por si ya tiene elementos
            flpLeyenda.Controls.Clear();

            // Cada estado con su color
            flpLeyenda.Controls.Add(CrearLeyenda(Color.Green, "Disponible"));
            flpLeyenda.Controls.Add(CrearLeyenda(Color.Red, "Ocupada"));
            flpLeyenda.Controls.Add(CrearLeyenda(Color.Orange, "Reservada"));
            flpLeyenda.Controls.Add(CrearLeyenda(Color.Blue, "Limpieza"));
            flpLeyenda.Controls.Add(CrearLeyenda(Color.Gray, "Fuera de servicio"));
        }

        private Panel CrearLeyenda(Color color, string texto)
        {
            // Contenedor principal del item
            Panel panel = new Panel();
            panel.Width = 140;
            panel.Height = 30;

            // Cuadro de color
            Panel colorBox = new Panel();
            colorBox.BackColor = color;
            colorBox.Width = 18;
            colorBox.Height = 18;
            colorBox.Location = new Point(5, 6);

            //  Texto descriptivo
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.AutoSize = true;
            lbl.Location = new Point(30, 6);

            //  Agregar controles al panel
            panel.Controls.Add(colorBox);
            panel.Controls.Add(lbl);

            return panel;
        }

    }
}
