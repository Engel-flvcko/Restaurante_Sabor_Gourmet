using Restaurante_Sabor_Gourmet.ConsultasSQL;
using Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class InsertarMesas
    {
        private SQLMesas sql = new SQLMesas();

        public void CargarMesas(FlowLayoutPanel flpSalon, FlowLayoutPanel flpFamiliar,
                                FlowLayoutPanel flpEventos, Action<int> alSeleccionarMesa)
        {
            DataTable mesas = sql.ObtenerMesas();

            flpSalon.Controls.Clear();
            flpFamiliar.Controls.Clear();
            flpEventos.Controls.Clear();

            foreach (DataRow row in mesas.Rows)
            {
                int idMesa = Convert.ToInt32(row["id_mesa"]);
                int numero = Convert.ToInt32(row["numero_mesa"]);
                int zona = Convert.ToInt32(row["id_zona_mesa"]);
                string estado = row["estado_mesa"].ToString();
                bool esEventos = zona == 3;

                // ── Panel contenedor de la tarjeta ────────────────────
                Panel tarjeta = new Panel
                {
                    Width = 100,
                    Height = 90,
                    Margin = new Padding(6),
                    Cursor = esEventos ? Cursors.No : Cursors.Hand,
                    Tag = idMesa
                };

                // ── Icono de mesa (emoji en label) ────────────────────
                Label lblIcono = new Label
                {
                    Text = "🪑",
                    Font = new Font("Segoe UI", 18F),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 8),
                    Size = new Size(100, 32),
                    BackColor = Color.Transparent
                };

                // ── Número de mesa ────────────────────────────────────
                Label lblNumero = new Label
                {
                    Text = "Mesa " + numero,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 40),
                    Size = new Size(100, 18),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent
                };

                // ── Estado ────────────────────────────────────────────
                Label lblEstado = new Label
                {
                    Text = esEventos ? "Reservas" : estado,
                    Font = new Font("Segoe UI", 7.5F),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 58),
                    Size = new Size(100, 16),
                    ForeColor = Color.FromArgb(220, 220, 220),
                    BackColor = Color.Transparent
                };

                // ── Color de fondo según estado ───────────────────────
                Color colorFondo = esEventos
                    ? Color.FromArgb(130, 100, 180)   
                    : ObtenerColorEstado(estado);

                // Si es zona eventos, reducir opacidad visualmente
                if (esEventos)
                {
                    lblIcono.ForeColor = Color.FromArgb(200, 200, 200);
                    lblNumero.ForeColor = Color.FromArgb(200, 200, 200);
                }

                tarjeta.BackColor = colorFondo;

                // Borde redondeado via Paint
                tarjeta.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    // Sombra suave
                    using (var sombra = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                        g.FillRectangle(sombra, 3, 3, tarjeta.Width - 3, tarjeta.Height - 3);

                    // Fondo con bordes redondeados
                    var rect = new Rectangle(0, 0, tarjeta.Width - 4, tarjeta.Height - 4);
                    using (var path = RoundedRect(rect, 12))
                    using (var brush = new SolidBrush(colorFondo))
                        g.FillPath(brush, path);

                    // Borde sutil
                    using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                        g.DrawPath(pen, RoundedRect(rect, 12));
                };

                // Clip redondeado para los controles hijos 
                tarjeta.Region = RoundedRegion(tarjeta.Width, tarjeta.Height, 12);

                tarjeta.Controls.Add(lblIcono);
                tarjeta.Controls.Add(lblNumero);
                tarjeta.Controls.Add(lblEstado);

                // Click: bloquear zona eventos 
                if (!esEventos)
                {
                    EventHandler clickHandler = (s, e) => alSeleccionarMesa(idMesa);
                    tarjeta.Click += clickHandler;
                    lblIcono.Click += clickHandler;
                    lblNumero.Click += clickHandler;
                    lblEstado.Click += clickHandler;
                }

                // Distribuir en panel correcto 
                FlowLayoutPanel destino = zona == 1 ? flpSalon
                                        : zona == 2 ? flpFamiliar
                                        : flpEventos;
                destino.Controls.Add(tarjeta);
            }
        }

        //  Color por estado
        private Color ObtenerColorEstado(string estado)
        {
            switch (estado)
            {
                case "Disponible": return Color.FromArgb(34, 139, 34);
                case "Ocupada": return Color.FromArgb(200, 50, 50);
                case "Reservada": return Color.FromArgb(220, 140, 0);
                case "En limpieza": return Color.FromArgb(50, 120, 180);
                case "Fuera de servicio": return Color.FromArgb(100, 100, 110);
                default: return Color.FromArgb(80, 80, 100);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Region RoundedRegion(int w, int h, int radius)
        {
            var path = RoundedRect(new Rectangle(0, 0, w - 1, h - 1), radius);
            return new Region(path);
        }
    }
}