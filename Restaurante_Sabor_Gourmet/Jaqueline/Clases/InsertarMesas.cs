using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL;


namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class InsertarMesas
    {
        // Acceso a datos SQL
        private SQLMesas sql = new SQLMesas();

        // Método principal: carga mesas en los 3 FlowLayoutPanel
        public void CargarMesas( FlowLayoutPanel flpSalon,FlowLayoutPanel flpFamiliar, FlowLayoutPanel flpEventos)
        {
            // Obtener datos desde BD
            DataTable mesas = sql.ObtenerMesas();

            // Limpiar paneles antes de cargar
            flpSalon.Controls.Clear();
            flpFamiliar.Controls.Clear();
            flpEventos.Controls.Clear();

            // Recorrer cada mesa de la base de datos
            foreach (DataRow row in mesas.Rows)
            {
                //  Datos de la mesa
                int idMesa = Convert.ToInt32(row["id_mesa"]);
                int numero = Convert.ToInt32(row["numero_mesa"]);
                int zona = Convert.ToInt32(row["id_zona_mesa"]);
                string estado = row["estado_mesa"].ToString();

                //  Crear botón dinámico
                Button btn = new Button();
                btn.Text = "Mesa " + numero;
                btn.Width = 90;
                btn.Height = 80;
                btn.Tag = idMesa; // guardar ID para usar después

                // Color según estado
                btn.BackColor = ObtenerColorEstado(estado);
                btn.ForeColor = Color.White;

                // Evento click 
                btn.Click += (s, e) =>
                {
                    MessageBox.Show($"Mesa: {numero}\nEstado: {estado}\nID: {idMesa}");
                };

                // Selección de panel según zona
                FlowLayoutPanel destino = null;

                if (zona == 1)
                    destino = flpSalon;
                else if (zona == 2)
                    destino = flpFamiliar;
                else if (zona == 3)
                    destino = flpEventos;

                // Agregar botón al panel correcto
                if (destino != null)
                {
                    destino.Controls.Add(btn);
                }
            }

        }

        // Método que define el color según estado de la mesa
        private Color ObtenerColorEstado(string estado)
        {
            switch (estado)
            {
                case "Disponible":
                    return Color.Green;

                case "Ocupada":
                    return Color.Red;

                case "Reservada":
                    return Color.Orange;

                case "Limpieza":
                    return Color.SkyBlue;

                case "Fuera de servicio":
                    return Color.Gray;

                default:
                    return Color.Blue;
            }
        }




    }
}
