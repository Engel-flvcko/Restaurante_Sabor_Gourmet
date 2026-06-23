using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.ConsultasSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Formularios
{
    public partial class frmCocina : Form
    {
        // Sesión del cocinero logueado (la recibe del frmPrincipal de Persona 1)
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        // Filtro de estado actualmente activo en la barra superior
        private string filtroActual = "todas";

        // Caché en memoria de la cola completa (se recarga desde la BD)
        // Usa ColaCocina de Clases — ya no necesita clase local OrdenCocinaVM
        private List<ColaCocina> colaCompleta = new List<ColaCocina>();

        // Minutos a partir de los cuales una orden se considera retrasada
        private const int MINUTOS_RETRASO = 30;

        // Timer para refrescar automáticamente cada 30 segundos
        private System.Windows.Forms.Timer timerRefresco;

        public frmCocina(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

        // ============================================================
        //  CARGA INICIAL
        // ============================================================
        private void frmCocina_Load(object sender, EventArgs e)
        {
            CargarColaProduccion();
            MarcarFiltroActivo(btnFiltroTodas);

            timerRefresco = new System.Windows.Forms.Timer();
            timerRefresco.Interval = 30000; // 30 segundos
            timerRefresco.Tick += timerRefresco_Tick;
            timerRefresco.Start();

            this.FormClosed += (s, ev) => timerRefresco.Stop();
        }

        private void timerRefresco_Tick(object sender, EventArgs e)
        {
            CargarColaProduccion();
        }

        private void CargarColaProduccion()
        {
            try
            {
                SQLColaCocina sql = new SQLColaCocina();
                colaCompleta = sql.ObtenerColaDelDia();
                // ObtenerColaDelDia() ya devuelve la lista ordenada por hora_recepcion ASC
                // e incluye la lista de Productos (DetalleOrden) por cada orden

                AplicarFiltro(filtroActual);
                ActualizarIndicadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la cola de producción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  FILTROS
        // ============================================================
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (Guna.UI2.WinForms.Guna2Button)sender;
            MarcarFiltroActivo(btn);
            filtroActual = btn.Tag.ToString();
            AplicarFiltro(filtroActual);
        }

        private void MarcarFiltroActivo(Guna.UI2.WinForms.Guna2Button btnActivo)
        {
            foreach (Control c in pnlFiltros.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.FillColor = Color.FromArgb(240, 240, 248);
                    btn.ForeColor = ColorTextoSegunEstado(btn.Tag?.ToString());
                }
            }
            btnActivo.FillColor = Color.FromArgb(37, 99, 235);
            btnActivo.ForeColor = Color.White;
        }

        private Color ColorTextoSegunEstado(string estado)
        {
            switch (estado)
            {
                case "pendiente": return Color.FromArgb(249, 115, 22);
                case "en_preparacion": return Color.FromArgb(37, 99, 235);
                case "lista": return Color.FromArgb(34, 197, 94);
                case "entregada": return Color.FromArgb(80, 80, 90);
                case "cancelada": return Color.FromArgb(239, 68, 68);
                default: return Color.White;
            }
        }

        private void AplicarFiltro(string estado)
        {
            // Siempre en orden estricto de hora_recepcion (la más antigua arriba)
            List<ColaCocina> filtradas = estado == "todas"
                ? colaCompleta.OrderBy(o => o.HoraRecepcion).ToList()
                : colaCompleta
                    .Where(o => o.EstadoCocina == estado)
                    .OrderBy(o => o.HoraRecepcion)
                    .ToList();

            RenderizarTarjetas(filtradas);
        }

        // ============================================================
        //  RENDERIZADO DE TARJETAS (cuadrícula de 3 columnas)
        // ============================================================
        private void RenderizarTarjetas(List<ColaCocina> ordenes)
        {
            pnlColaProduccion.Controls.Clear();

            const int columnas = 3;
            const int anchoTarjeta = 480;
            const int altoTarjeta = 300;
            const int espacio = 18;

            for (int i = 0; i < ordenes.Count; i++)
            {
                int col = i % columnas;
                int fila = i / columnas;
                int x = col * (anchoTarjeta + espacio);
                int y = fila * (altoTarjeta + espacio);

                Control tarjeta = CrearTarjetaOrden(ordenes[i], anchoTarjeta, altoTarjeta);
                tarjeta.Location = new Point(x, y);
                pnlColaProduccion.Controls.Add(tarjeta);
            }

            if (ordenes.Count == 0)
            {
                Label lblVacio = new Label
                {
                    Text = "No hay órdenes en este filtro.",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                pnlColaProduccion.Controls.Add(lblVacio);
            }
        }

        private Control CrearTarjetaOrden(ColaCocina orden, int ancho, int alto)
        {
            // ---- Color de urgencia en el borde lateral ----
            int minutosTranscurridos = (int)(DateTime.Now - orden.HoraRecepcion).TotalMinutes;
            Color colorUrgencia;

            if (orden.EstadoCocina == "entregada")
                colorUrgencia = Color.FromArgb(160, 160, 170);
            else if (orden.EstadoCocina == "cancelada")
                colorUrgencia = Color.FromArgb(239, 68, 68);
            else if (minutosTranscurridos >= MINUTOS_RETRASO)
                colorUrgencia = Color.FromArgb(239, 68, 68);
            else if (minutosTranscurridos >= MINUTOS_RETRASO / 2)
                colorUrgencia = Color.FromArgb(249, 115, 22);
            else
                colorUrgencia = Color.FromArgb(34, 197, 94);

            Guna.UI2.WinForms.Guna2Panel tarjeta = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(ancho, alto),
                FillColor = Color.White,
                BorderRadius = 10,
                Tag = orden.IdCocina
            };
            tarjeta.ShadowDecoration.Enabled = true;

            // Franja de color lateral izquierda
            Panel franja = new Panel
            {
                BackColor = colorUrgencia,
                Dock = DockStyle.Left,
                Width = 6
            };
            tarjeta.Controls.Add(franja);

            // ---- Encabezado ----
            Label lblMesa = new Label
            {
                Text = "Mesa " + orden.NumeroMesa.ToString("00"),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                Location = new Point(20, 14),
                AutoSize = true
            };
            Label lblNumOrden = new Label
            {
                Text = "Orden #" + orden.IdOrden,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.Gray,
                Location = new Point(20, 40),
                AutoSize = true
            };
            Label lblHoraRecepcion = new Label
            {
                Text = "Recibido: " + orden.HoraRecepcion.ToString("hh:mm tt"),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                Location = new Point(ancho - 175, 18),
                AutoSize = true
            };

            tarjeta.Controls.Add(lblMesa);
            tarjeta.Controls.Add(lblNumOrden);
            tarjeta.Controls.Add(lblHoraRecepcion);

            int yCursor = 65;

            // Hora de inicio (si ya empezó preparación)
            if (orden.HoraInicio.HasValue)
            {
                Label lblInicio = new Label
                {
                    Text = "Inicio: " + orden.HoraInicio.Value.ToString("hh:mm tt"),
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, yCursor),
                    AutoSize = true
                };
                tarjeta.Controls.Add(lblInicio);
                yCursor += 18;
            }

            // Hora de finalización (si ya terminó)
            if (orden.HoraFinalizacion.HasValue)
            {
                string prefijo = orden.EstadoCocina == "cancelada" ? "Cancelado: " : "Finalizado: ";
                Label lblFin = new Label
                {
                    Text = prefijo + orden.HoraFinalizacion.Value.ToString("hh:mm tt"),
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, yCursor),
                    AutoSize = true
                };
                tarjeta.Controls.Add(lblFin);
                yCursor += 18;
            }

            yCursor += 6;

            // ---- Lista de productos (usa DetalleOrden de Clases) ----
            foreach (DetalleOrden p in orden.Productos)
            {
                string texto = p.CantidadDetalle + "x  " + p.NombreProducto;
                if (!string.IsNullOrWhiteSpace(p.Observaciones))
                    texto += "  -  " + p.Observaciones;

                Label lblProducto = new Label
                {
                    Text = texto,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(40, 40, 50),
                    Location = new Point(20, yCursor),
                    Size = new Size(ancho - 40, 20),
                    AutoEllipsis = true
                };
                tarjeta.Controls.Add(lblProducto);
                yCursor += 22;
            }

            // ---- Chip de estado ----
            (string textoChip, Color colorChip) = ObtenerEstiloChip(orden.EstadoCocina);
            Guna.UI2.WinForms.Guna2Panel chip = new Guna.UI2.WinForms.Guna2Panel
            {
                FillColor = colorChip,
                BorderRadius = 14,
                Size = new Size(155, 28),
                Location = new Point(20, alto - 90)
            };
            Label lblChip = new Label
            {
                Text = textoChip,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F,
                    FontStyle.Bold | (orden.EstadoCocina == "cancelada"
                        ? FontStyle.Strikeout
                        : FontStyle.Regular)),
                TextAlign = ContentAlignment.MiddleCenter
            };
            chip.Controls.Add(lblChip);
            tarjeta.Controls.Add(chip);

            // ---- Botón de acción (solo si no es estado final) ----
            if (orden.EstadoCocina != "entregada" && orden.EstadoCocina != "cancelada")
            {
                Guna.UI2.WinForms.Guna2Button btnAccion = new Guna.UI2.WinForms.Guna2Button
                {
                    Size = new Size(ancho - 40, 50),
                    Location = new Point(20, alto - 58),
                    BorderRadius = 10,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Tag = orden.IdCocina
                };

                switch (orden.EstadoCocina)
                {
                    case "pendiente":
                        btnAccion.Text = "▷  Iniciar Preparación";
                        btnAccion.FillColor = Color.FromArgb(37, 99, 235);
                        break;
                    case "en_preparacion":
                        btnAccion.Text = "✓  Marcar Lista";
                        btnAccion.FillColor = Color.FromArgb(34, 197, 94);
                        break;
                    case "lista":
                        btnAccion.Text = "🚚  Entregar";
                        btnAccion.FillColor = Color.FromArgb(80, 80, 90);
                        break;
                }

                btnAccion.Click += btnAccionTarjeta_Click;
                tarjeta.Controls.Add(btnAccion);
            }

            return tarjeta;
        }

        private (string texto, Color color) ObtenerEstiloChip(string estado)
        {
            switch (estado)
            {
                case "pendiente": return ("Pendiente", Color.FromArgb(249, 115, 22));
                case "en_preparacion": return ("En Preparación", Color.FromArgb(37, 99, 235));
                case "lista": return ("Lista para Entregar", Color.FromArgb(34, 197, 94));
                case "entregada": return ("Entregada", Color.FromArgb(150, 150, 160));
                case "cancelada": return ("Cancelada", Color.FromArgb(239, 68, 68));
                default: return (estado, Color.Gray);
            }
        }

        // ============================================================
        //  CAMBIO DE ESTADO (flujo unidireccional)
        // ============================================================
        private void btnAccionTarjeta_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (Guna.UI2.WinForms.Guna2Button)sender;
            int idCocina = (int)btn.Tag;

            ColaCocina orden = colaCompleta.FirstOrDefault(o => o.IdCocina == idCocina);
            if (orden == null) return;

            string estadoActual = orden.EstadoCocina;
            string siguienteEstado = null;

            switch (estadoActual)
            {
                case "pendiente": siguienteEstado = "en_preparacion"; break;
                case "en_preparacion": siguienteEstado = "lista"; break;
                case "lista": siguienteEstado = "entregada"; break;
                default: return; // estado final → no hace nada
            }

            DialogResult resp = MessageBox.Show(
                "¿Cambiar el estado de la Orden #" + orden.IdOrden + "\n" +
                "de \"" + ObtenerEstiloChip(estadoActual).texto + "\" → " +
                "\"" + ObtenerEstiloChip(siguienteEstado).texto + "\"?",
                "Confirmar cambio de estado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                SQLColaCocina sql = new SQLColaCocina();

                // CambiarEstado valida el flujo internamente (ValidacionesOrdenes)
                // y registra hora_inicio / hora_finalizacion automáticamente.
                // Si el nuevo estado es 'entregada', el trigger trg_descuento_inventario
                // descuenta los ingredientes automáticamente en la BD.
                bool exito = sql.CambiarEstado(idCocina, estadoActual, siguienteEstado);

                if (exito)
                {
                    // Actualizar caché en memoria para no tener que recargar toda la BD
                    orden.EstadoCocina = siguienteEstado;
                    if (siguienteEstado == "en_preparacion") orden.HoraInicio = DateTime.Now;
                    if (siguienteEstado == "entregada") orden.HoraFinalizacion = DateTime.Now;

                    AplicarFiltro(filtroActual);
                    ActualizarIndicadores();
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar el estado. Verifica el flujo de estados.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar estado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  INDICADORES KPI — todos desde la BD real
        // ============================================================
        private void ActualizarIndicadores()
        {
            try
            {
                SQLColaCocina sql = new SQLColaCocina();

                // 1. Órdenes pendientes
                int pendientes = sql.ObtenerTotalPendientes();
                lblKpiPendientesValor.Text = pendientes.ToString();

                // 2. Órdenes retrasadas (+30 min)
                int retrasadas = sql.ObtenerTotalRetrasadas(MINUTOS_RETRASO);
                lblKpiRetrasadasValor.Text = retrasadas.ToString();

                // 3. Tiempo promedio de preparación (entregadas hoy)
                double promedio = sql.ObtenerTiempoPromedioMinutos();
                lblKpiTiempoPromValor.Text = promedio > 0
                    ? Math.Round(promedio) + " min"
                    : "-- min";

                // 4. Top 3 productos más solicitados del día
                List<(string Nombre, int Total)> top = sql.ObtenerTopProductosHoy(3);

                string[] nombres = { "1.  ---", "2.  ---", "3.  ---" };
                string[] totales = { "0", "0", "0" };

                for (int i = 0; i < top.Count && i < 3; i++)
                {
                    nombres[i] = (i + 1) + ".  " + top[i].Nombre;
                    totales[i] = top[i].Total.ToString();
                }

                lblTop1Nombre.Text = nombres[0]; lblTop1Cantidad.Text = totales[0];
                lblTop2Nombre.Text = nombres[1]; lblTop2Cantidad.Text = totales[1];
                lblTop3Nombre.Text = nombres[2]; lblTop3Cantidad.Text = totales[2];
            }
            catch (Exception ex)
            {
                // No romper la UI si falla un indicador
                MessageBox.Show("Error al actualizar indicadores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}