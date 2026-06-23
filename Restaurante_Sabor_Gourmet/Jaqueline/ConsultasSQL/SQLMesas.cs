using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;

namespace Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL
{
    internal class SQLMesas
    {
        
        private ConexionBD conexionBD = new ConexionBD();

        // Obtener todas las mesas con su zona y estado
        public DataTable ObtenerMesas()
        {
            DataTable dt = new DataTable();

            // abir conexión 
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open();

                // Consulta con relación a zonas
                string query = @"
                    SELECT 
                        m.id_mesa,
                        m.numero_mesa,
                        m.id_zona_mesa,
                        m.estado_mesa,
                        z.nombre_zona,
                        z.es_eventos_zona
                    FROM tbl_mesas m
                    INNER JOIN tbl_zonas z ON m.id_zona_mesa = z.id_zona";

                //  Ejecuta  consulta y llena el DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
