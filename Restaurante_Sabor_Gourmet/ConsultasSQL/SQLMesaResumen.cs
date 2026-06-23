using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using Restaurante_Sabor_Gourmet.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLMesaResumen
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ============================================================
        //  MESAS OCUPADAS (las únicas donde se puede registrar una orden)
        // ============================================================
        public List<MesaResumen> ObtenerMesasOcupadas()
        {
            List<MesaResumen> lista = new List<MesaResumen>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT m.id_mesa,
                           m.numero_mesa,
                           m.estado_mesa,
                           m.id_mesero_asignado,
                           z.nombre_zona,
                           COALESCE(u.nombre_usuario, '-- Sin asignar --') AS nombre_mesero
                    FROM   tbl_mesas    m
                    INNER  JOIN tbl_zonas    z ON z.id_zona   = m.id_zona
                    LEFT   JOIN tbl_usuarios u ON u.id_usuario = m.id_mesero_asignado
                    WHERE  m.estado_mesa = 'Ocupada'
                    ORDER  BY m.numero_mesa ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new MesaResumen
                            {
                                IdMesa = rd.GetInt32("id_mesa"),
                                NumeroMesa = rd.GetInt32("numero_mesa"),
                                EstadoMesa = rd.GetString("estado_mesa"),
                                IdMeseroAsignado = rd.IsDBNull(rd.GetOrdinal("id_mesero_asignado"))
                                                           ? (int?)null
                                                           : rd.GetInt32("id_mesero_asignado"),
                                NombreZona = rd.GetString("nombre_zona"),
                                NombreMeseroAsignado = rd.GetString("nombre_mesero")
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // ============================================================
        //  OBTENER UNA MESA POR ID
        // ============================================================
        public MesaResumen ObtenerPorId(int idMesa)
        {
            MesaResumen mesa = null;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT m.id_mesa,
                           m.numero_mesa,
                           m.estado_mesa,
                           m.id_mesero_asignado,
                           z.nombre_zona,
                           COALESCE(u.nombre_usuario, '-- Sin asignar --') AS nombre_mesero
                    FROM   tbl_mesas    m
                    INNER  JOIN tbl_zonas    z ON z.id_zona    = m.id_zona
                    LEFT   JOIN tbl_usuarios u ON u.id_usuario = m.id_mesero_asignado
                    WHERE  m.id_mesa = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idMesa);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            mesa = new MesaResumen
                            {
                                IdMesa = rd.GetInt32("id_mesa"),
                                NumeroMesa = rd.GetInt32("numero_mesa"),
                                EstadoMesa = rd.GetString("estado_mesa"),
                                IdMeseroAsignado = rd.IsDBNull(rd.GetOrdinal("id_mesero_asignado"))
                                                           ? (int?)null
                                                           : rd.GetInt32("id_mesero_asignado"),
                                NombreZona = rd.GetString("nombre_zona"),
                                NombreMeseroAsignado = rd.GetString("nombre_mesero")
                            };
                        }
                    }
                }
            }

            return mesa;
        }
    }
}