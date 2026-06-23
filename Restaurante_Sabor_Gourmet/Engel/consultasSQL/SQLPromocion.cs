using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Engel.clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.consultasSQL
{
    internal class SQLPromocion
    {
        ConexionDB conexion = new ConexionDB();

        // Mostrar todas las promociones
        public DataTable MostrarPromociones()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT id_promocion, nombre_promocion,
                                      porcentaje_promocion, fecha_inicio_promocion,
                                      fecha_fin_promocion,
                                      CASE WHEN CURDATE() BETWEEN fecha_inicio_promocion
                                                              AND fecha_fin_promocion
                                           THEN 'Vigente' ELSE 'Inactiva' END AS estado
                               FROM tbl_promociones
                               ORDER BY fecha_inicio_promocion DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Guardar nueva promoción
        public bool GuardarPromocion(Promocion promocion)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO tbl_promociones
                                   (nombre_promocion, porcentaje_promocion,
                                    fecha_inicio_promocion, fecha_fin_promocion)
                               VALUES (@nombre, @porcentaje, @inicio, @fin)";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", promocion.NombrePromocion);
                cmd.Parameters.AddWithValue("@porcentaje", promocion.PorcentajePromocion);
                cmd.Parameters.AddWithValue("@inicio", promocion.FechaInicio.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fin", promocion.FechaFin.ToString("yyyy-MM-dd"));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar promoción
        public bool EliminarPromocion(int idPromocion)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "DELETE FROM tbl_promociones WHERE id_promocion = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", idPromocion);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
