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
using Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Formularios
{
    public partial class FrmMesas : Form
    {
        private SQLMesas sqlMesas = new SQLMesas();
        private int mesaSeleccionada = -1;
        public FrmMesas()
        {
            InitializeComponent();
        }

        private void FrmMesas_Load(object sender, EventArgs e)
        {

            CrearTitulos();        // títulos de zonas
            ConfigurarLeyendaPanel(); // configuración visual
            CargarLeyenda();       // leyenda de colores
            OcultarPanelMesa();



            // Crear instancia de la clase UI
            InsertarMesas ui = new InsertarMesas();

            // Cargar mesas en cada zona
            ui.CargarMesas(flpSalon, flpFamiliar, flpEventos, MostrarInfoMesa);

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

        private void MostrarInfoMesa(int idMesa)
        {
            mesaSeleccionada = idMesa;
            DataTable dt = sqlMesas.ObtenerMesaPorId(idMesa);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                //  mostrar solo lo básico al seleccionar
                lblEstadoMesa.Text = row["estado_mesa"].ToString();
                lblCapacidadMesa.Text = row["capacidad_mesa"].ToString();

                // ubicación como nombre de zona
                lblUbicacionMesa.Text = row["nombre_zona"].ToString();

                // mesero logueado 
                lblMeseroAsignado.Text = Sesion.NombreUsuario;

                // clientes actuales
                lblCantidadCliente.Text = row["num_clientes_mesa"].ToString();

                lblNumMesa.Text = row["numero_mesa"].ToString(); // numero de mesa
                string estado = row["estado_mesa"].ToString();

                // hora inicio
                if (row["hora_ocupacion_mesa"] != DBNull.Value)
                {
                    lblHoraInicioOrden.Text = row["hora_ocupacion_mesa"].ToString();
                }
                else
                {
                    lblHoraInicioOrden.Text = "-";
                }

                MostrarPanelMesa();

                ConfigurarBotones(estado);
            }




        }


        private void OcultarPanelMesa()
        {
            // Título principal
            lblInfoMesa.Visible = false;

            // Número de mesa
            lblNumMesa.Visible = false;

            // Estado
            lblEstado.Visible = false;
            lblEstadoMesa.Visible = false;

            // Capacidad
            lblCapacidad.Visible = false;
            lblCapacidadMesa.Visible = false;

            // Resto de información
            lblUbicacion.Visible = false;
            lblUbicacionMesa.Visible = false;

            lblMesero.Visible = false;
            lblMeseroAsignado.Visible = false;

            lblClientes.Visible = false;
            lblCantidadCliente.Visible = false;

            lblHoraInicio.Visible = false;
            lblHoraInicioOrden.Visible = false;

            lblOrden.Visible = false;
            lblOrdenActiva.Visible = false;

            // Botones
            btnAsignarMesa.Visible = false;
            btnTransferirOrden.Visible = false;
            btnSolicitarPago.Visible = false;
            btnUnirMesas.Visible = false;
            btnDividirMesa.Visible = false;
            btnLiberarMesa.Visible = false;
            btnMesaFueraServicio.Visible = false;
        }

        private void MostrarPanelMesa() // Muestra toda la informacion 
        {
            lblNumMesa.Visible = true;

            lblEstado.Visible = true;
            lblEstadoMesa.Visible = true;

            lblCapacidad.Visible = true;
            lblCapacidadMesa.Visible = true;

            lblUbicacion.Visible = true;

            lblMesero.Visible = true;
            lblMeseroAsignado.Visible = true;   

            lblUbicacionMesa.Visible = true;
            lblInfoMesa.Visible = true;

        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAsignarMesa_Click(object sender, EventArgs e)
        {
          
        }

        private void ConfigurarBotones(string estado)
        {
            btnAsignarMesa.Visible = false;
            btnTransferirOrden.Visible = false;
            btnSolicitarPago.Visible = false;
            btnUnirMesas.Visible = false;
            btnDividirMesa.Visible = false;
            btnLiberarMesa.Visible = false;

            switch (estado)
            {
                case "Disponible":

                    btnAsignarMesa.Visible = true;
                    btnUnirMesas.Visible = true;

                    break;

                case "Ocupada":

                    lblUbicacion.Visible = true;
                    lblUbicacionMesa.Visible = true;

                    lblMesero.Visible = true;
                    lblMeseroAsignado.Visible = true;

                    lblClientes.Visible = true;
                    lblCantidadCliente.Visible = true;

                    lblHoraInicio.Visible = true;
                    lblHoraInicioOrden.Visible = true;

                    btnTransferirOrden.Visible = true;
                    btnSolicitarPago.Visible = true;
                    btnDividirMesa.Visible = true;
                    btnUnirMesas.Visible = true;

                    break;

                case "Limpieza":

                    btnLiberarMesa.Visible = true;

                    break;
            }
        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }
    }
}
