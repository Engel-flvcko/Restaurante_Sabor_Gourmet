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
using Restaurante_Sabor_Gourmet.Jaqueline.Formularios;
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

        //  Carga inicial
        private void FrmMesas_Load(object sender, EventArgs e)
        {
            AgregarTitulosZonas();
            ConfigurarLeyendaPanel();
            CargarLeyenda();
            OcultarPanelMesa();
            CargarTodasLasMesas();
        }

        // Cargar mesas en los 3 paneles 
        private void CargarTodasLasMesas()
        {
            InsertarMesas ui = new InsertarMesas();
            ui.CargarMesas(flpSalon, flpFamiliar, flpEventos, MostrarInfoMesa);
        }

        // Títulos de zona encima de cada FlowLayoutPanel 
        private void AgregarTitulosZonas()
        {
            AgregarTitulo("SALÓN PRINCIPAL", pnlSalonPrincipal, flpSalon);
            AgregarTitulo("ZONA FAMILIAR", pnlZonaFamiliar, flpFamiliar);
            AgregarTitulo("ZONA EVENTOS", pnlZonaEventos, flpEventos);
        }

        private void AgregarTitulo(string texto, Guna.UI2.WinForms.Guna2Panel contenedor,
                                    FlowLayoutPanel flp)
        {
            // Crear label del título
            Label lbl = new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                AutoSize = false,
                Height = 30,
                Dock = DockStyle.None,
                Location = new Point(8, 4),
                Width = contenedor.Width - 16
            };

            // Quitar Dock Fill del FlowLayoutPanel para poder posicionarlo
            flp.Dock = DockStyle.None;
            flp.Location = new Point(0, 34);  // debajo del título
            flp.Width = contenedor.Width;
            flp.Height = contenedor.Height - 34;
            flp.Anchor = AnchorStyles.Top | AnchorStyles.Left
                         | AnchorStyles.Right | AnchorStyles.Bottom;

            contenedor.Controls.Add(lbl);
        }

        //  LEYENDA
        private void ConfigurarLeyendaPanel()
        {
            flpLeyenda.FlowDirection = FlowDirection.LeftToRight;
            flpLeyenda.WrapContents = false;
            flpLeyenda.AutoScroll = true;
        }

        private void CargarLeyenda()
        {
            flpLeyenda.Controls.Clear();
            flpLeyenda.Controls.Add(CrearItemLeyenda(Color.FromArgb(34, 139, 34), "Disponible"));
            flpLeyenda.Controls.Add(CrearItemLeyenda(Color.FromArgb(220, 53, 69), "Ocupada"));
            flpLeyenda.Controls.Add(CrearItemLeyenda(Color.FromArgb(255, 165, 0), "Reservada"));
            flpLeyenda.Controls.Add(CrearItemLeyenda(Color.FromArgb(70, 130, 180), "En limpieza"));
            flpLeyenda.Controls.Add(CrearItemLeyenda(Color.FromArgb(108, 117, 125), "Fuera de servicio"));
        }

        private Panel CrearItemLeyenda(Color color, string texto)
        {
            Panel p = new Panel { Width = 155, Height = 30 };

            Panel cuadro = new Panel
            {
                BackColor = color,
                Width = 16,
                Height = 16,
                Location = new Point(5, 7)
            };

            Label lbl = new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Location = new Point(27, 6)
            };

            p.Controls.Add(cuadro);
            p.Controls.Add(lbl);
            return p;
        }

        //  PANEL LATERAL — mostrar info al seleccionar mesa

        private void MostrarInfoMesa(int idMesa)
        {
            DataTable dtCheck = sqlMesas.ObtenerMesaPorId(idMesa);
            if (dtCheck.Rows.Count == 0) return;

            // Si es zona de eventos, no mostrar panel ni permitir acciones
            // (ObtenerMesaPorId ya incluye nombre_zona, agregar es_eventos_zona)
            // Por ahora bloqueamos por id_zona_mesa = 3
            if (Convert.ToInt32(dtCheck.Rows[0]["id_zona_mesa"]) == 3)
            {
                MessageBox.Show(
                    "Las mesas de la Zona de Eventos solo pueden\n" +
                    "asignarse a través del módulo de Reservaciones.",
                    "Zona exclusiva para eventos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mesaSeleccionada = idMesa;
            DataTable dt = sqlMesas.ObtenerMesaPorId(idMesa);
            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];
            string estado = row["estado_mesa"].ToString();

            // Datos básicos siempre visibles
            lblNumMesa.Text = "Mesa " + row["numero_mesa"].ToString();
            lblEstadoMesa.Text = estado;
            lblCapacidadMesa.Text = row["capacidad_mesa"].ToString() + " personas";
            lblUbicacionMesa.Text = row["nombre_zona"].ToString();
            lblMeseroAsignado.Text = Sesion.NombreUsuario;
            

            lblHoraInicioOrden.Text = row["hora_ocupacion_mesa"] != DBNull.Value
                                      ? Convert.ToDateTime(row["hora_ocupacion_mesa"])
                                                .ToString("hh:mm tt")
                                      : "-";

            // Orden activa (si existe)
            int? idOrden = sqlMesas.ObtenerOrdenActivaPorMesa(idMesa);
            lblOrdenActiva.Text = idOrden.HasValue ? "#" + idOrden.Value.ToString() : "-";

            // Color del estado
            lblEstadoMesa.ForeColor = ObtenerColorEstado(estado);

            MostrarPanelMesa();
            ConfigurarBotones(estado);
        }

       

        private Color ObtenerColorEstado(string estado)
        {
            switch (estado)
            {
                case "Disponible": return Color.FromArgb(34, 139, 34);
                case "Ocupada": return Color.FromArgb(220, 53, 69);
                case "Reservada": return Color.FromArgb(255, 140, 0);
                case "En limpieza": return Color.FromArgb(70, 130, 180);
                case "Fuera de servicio": return Color.FromArgb(108, 117, 125);
                default: return Color.Black;
            }
        }

        // Visibilidad del panel lateral 
        private void OcultarPanelMesa()
        {
            lblInfoMesa.Visible = false;
            lblNumMesa.Visible = false;
            lblEstado.Visible = false;
            lblEstadoMesa.Visible = false;
            lblCapacidad.Visible = false;
            lblCapacidadMesa.Visible = false;
            lblUbicacion.Visible = false;
            lblUbicacionMesa.Visible = false;
            lblMesero.Visible = false;
            lblMeseroAsignado.Visible = false;
           
            lblHoraInicio.Visible = false;
            lblHoraInicioOrden.Visible = false;
            lblOrden.Visible = false;
            lblOrdenActiva.Visible = false;
            flowLayoutPanel1.Visible = false;
        }

        private void MostrarPanelMesa()
        {
            lblInfoMesa.Visible = true;
            lblNumMesa.Visible = true;
            lblEstado.Visible = true;
            lblEstadoMesa.Visible = true;
            lblCapacidad.Visible = true;
            lblCapacidadMesa.Visible = true;
            lblUbicacion.Visible = true;
            lblUbicacionMesa.Visible = true;
            flowLayoutPanel1.Visible = true;
        }

        //Botones según estado 
        
        private void ConfigurarBotones(string estado)
        {
            // Ocultar todo primero
            btnVerOrden.Visible = false;          // ← agregar esta línea
            btnAsignarMesa.Visible = false;
            btnTransferirOrden.Visible = false;
            btnSolicitarPago.Visible = false;
            btnUnirMesas.Visible = false;
            btnDividirMesa.Visible = false;
            btnLiberarMesa.Visible = false;
            btnMesaFueraServicio.Visible = false;
            lblMesero.Visible = false;
            lblMeseroAsignado.Visible = false;
            
            lblHoraInicio.Visible = false;
            lblHoraInicioOrden.Visible = false;
            lblOrden.Visible = false;
            lblOrdenActiva.Visible = false;

            // Botón Fuera de Servicio solo para Admin (rol 1) y Supervisor (rol 5)
            bool esSupervisorOAdmin = Sesion.IdRol == 1 || Sesion.IdRol == 5;

            switch (estado)
            {
                case "Disponible":
                    btnAsignarMesa.Visible = true;
                    btnUnirMesas.Visible = true;
                    btnMesaFueraServicio.Visible = esSupervisorOAdmin;

                    // Colores
                    btnAsignarMesa.FillColor = Color.FromArgb(34, 197, 94);
                    btnUnirMesas.FillColor = Color.FromArgb(37, 99, 235);
                    btnMesaFueraServicio.FillColor = Color.FromArgb(108, 117, 125);
                    break;

                case "Ocupada":
                    lblMesero.Visible = true;
                    lblMeseroAsignado.Visible = true;
                    lblHoraInicio.Visible = true;
                    lblHoraInicioOrden.Visible = true;
                    lblOrden.Visible = true;
                    lblOrdenActiva.Visible = true;

                    btnVerOrden.Visible = true;           
                    btnTransferirOrden.Visible = true;
                    btnSolicitarPago.Visible = true;
                    btnUnirMesas.Visible = true;
                    btnDividirMesa.Visible = true;

                    btnVerOrden.FillColor = Color.FromArgb(34, 197, 94);
                    btnTransferirOrden.FillColor = Color.FromArgb(37, 99, 235);
                    btnSolicitarPago.FillColor = Color.FromArgb(249, 115, 22);
                    btnUnirMesas.FillColor = Color.FromArgb(168, 85, 247);
                    btnDividirMesa.FillColor = Color.FromArgb(234, 179, 8);
                    break;

                case "En limpieza":
                    btnLiberarMesa.Visible = true;
                    btnLiberarMesa.FillColor = Color.FromArgb(70, 130, 180);
                    break;

                case "Reservada":
                    // Solo info, sin acciones de mesero
                    btnMesaFueraServicio.Visible = esSupervisorOAdmin;
                    break;

                case "Fuera de servicio":
                    // Solo supervisor/admin puede restaurarla
                    if (esSupervisorOAdmin)
                    {
                        btnLiberarMesa.Visible = true;
                        btnLiberarMesa.Text = "Poner disponible";
                        btnLiberarMesa.FillColor = Color.FromArgb(34, 197, 94);
                    }
                    break;
            }
        }

        //  Eventos de los botones

        // Asignar Mesa

        private void btnAsignarMesa_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            bool ok = sqlMesas.AsignarMesa(mesaSeleccionada, Sesion.IdUsuario);
            if (ok)
            {
                CargarTodasLasMesas();
                MostrarInfoMesa(mesaSeleccionada);

                // ── Abrir frmOrdenes pre-seleccionando la mesa recién asignada ──
                int idMesaParaOrden = mesaSeleccionada; // capturar antes de que el dialog la resetee
                using (Restaurante_Sabor_Gourmet.Formularios.frmOrdenes frm =
                       new Restaurante_Sabor_Gourmet.Formularios.frmOrdenes(
                           Sesion.IdUsuario, Sesion.NombreUsuario, idMesaParaOrden))
                {
                    frm.ShowDialog();
                }

                // Al volver, recargar el mapa (puede haber cambiado estado de orden)
                CargarTodasLasMesas();
                MostrarInfoMesa(mesaSeleccionada);
            }
            else
            {
                MessageBox.Show("No se pudo asignar la mesa.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Solicitar Pago (Cerrar Cuenta)
        private void btnSolicitarPago_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            int? idOrden = sqlMesas.ObtenerOrdenActivaPorMesa(mesaSeleccionada);
            if (!idOrden.HasValue)
            {
                MessageBox.Show("No hay orden activa en esta mesa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show(
                "¿Solicitar cierre de cuenta para la Mesa " + mesaSeleccionada + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            bool ok = sqlMesas.CerrarCuenta(idOrden.Value);
            if (ok)
            {
                MessageBox.Show("Cuenta enviada a caja. Estado: Pendiente de pago.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTodasLasMesas();
                MostrarInfoMesa(mesaSeleccionada);
            }
            else
            {
                MessageBox.Show("No se pudo solicitar el pago.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Liberar Mesa
        private void btnLiberarMesa_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            bool ok = sqlMesas.LiberarMesa(mesaSeleccionada);
            if (ok)
            {
                btnLiberarMesa.Text = "Liberar mesa"; // restaurar texto si era Fuera de servicio
                CargarTodasLasMesas();
                OcultarPanelMesa();
                mesaSeleccionada = -1;
            }
            else
            {
                MessageBox.Show("No se pudo liberar la mesa.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  Fuera de Servicio
        private void btnMesaFueraServicio_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            DialogResult resp = MessageBox.Show(
                "¿Marcar la Mesa " + mesaSeleccionada + " como Fuera de servicio?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            bool ok = sqlMesas.CambiarEstado(mesaSeleccionada, "Fuera de servicio");
            if (ok)
            {
                CargarTodasLasMesas();
                MostrarInfoMesa(mesaSeleccionada);
            }
        }

        // Unir Mesas abre popup 
        private void btnUnirMesas_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            using (FrmPopupMesas popup = new FrmPopupMesas(
                       mesaSeleccionada, FrmPopupMesas.TabInicial.Unir, sqlMesas))
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    CargarTodasLasMesas();
                    MostrarInfoMesa(mesaSeleccionada);

                    // Abrir frmOrdenes pre-seleccionando la mesa principal
                    int idMesaParaOrden = mesaSeleccionada;
                    using (Restaurante_Sabor_Gourmet.Formularios.frmOrdenes frm =
                           new Restaurante_Sabor_Gourmet.Formularios.frmOrdenes(
                               Sesion.IdUsuario, Sesion.NombreUsuario, idMesaParaOrden))
                    {
                        frm.ShowDialog();
                    }

                    CargarTodasLasMesas();
                    MostrarInfoMesa(mesaSeleccionada);
                }
            }
        }

        // Transferir Orden , abre popup 
        private void btnTransferirOrden_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            using (FrmPopupMesas popup = new FrmPopupMesas(
                       mesaSeleccionada, FrmPopupMesas.TabInicial.Transferir, sqlMesas))
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    CargarTodasLasMesas();
                    OcultarPanelMesa();
                    mesaSeleccionada = -1;
                }
            }
        }

        // Dividir Mesa → abre popup 
        private void btnDividirMesa_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            using (FrmPopupMesas popup = new FrmPopupMesas(
                       mesaSeleccionada, FrmPopupMesas.TabInicial.Dividir, sqlMesas))
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    CargarTodasLasMesas();
                    MostrarInfoMesa(mesaSeleccionada);
                }
            }
        }

        private void btnVerOrden_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada == -1) return;

            using (Restaurante_Sabor_Gourmet.Formularios.frmOrdenes frm =
                   new Restaurante_Sabor_Gourmet.Formularios.frmOrdenes(
                       Sesion.IdUsuario, Sesion.NombreUsuario, mesaSeleccionada))
            {
                frm.ShowDialog();
            }

            CargarTodasLasMesas();
            MostrarInfoMesa(mesaSeleccionada);
        }
    }
}