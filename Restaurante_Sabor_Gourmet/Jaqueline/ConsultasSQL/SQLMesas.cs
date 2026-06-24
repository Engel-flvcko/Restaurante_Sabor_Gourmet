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
        public DataTable ObtenerMesas() // Sirve para generar las mesas graficamente
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

        public DataTable ObtenerMesaPorId(int idMesa) // Sirve para mostrar la informacion de las mesas 
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
            SELECT 
                m.id_mesa,
                m.numero_mesa,
                m.estado_mesa,
                m.capacidad_mesa,
                m.num_clientes_mesa,
                m.hora_ocupacion_mesa,
                z.nombre_zona
            FROM tbl_mesas m
            INNER JOIN tbl_zonas z ON m.id_zona_mesa = z.id_zona
            WHERE m.id_mesa = @idMesa";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


    }
}