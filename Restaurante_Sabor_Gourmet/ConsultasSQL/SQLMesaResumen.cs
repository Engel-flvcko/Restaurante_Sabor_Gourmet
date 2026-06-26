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

       
        //  MESAS OCUPADAS (las únicas donde se puede registrar una orden)
      
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
                           m.id_mesero_asignado_mesa,
                           m.unida_con_mesa,
                           z.nombre_zona,
                           z.es_eventos_zona,
                           COALESCE(u.nombre_usuario, '-- Sin asignar --') AS nombre_mesero,
                           m2.numero_mesa AS numero_mesa_unida
                    FROM   tbl_mesas    m
                    INNER  JOIN tbl_zonas    z  ON z.id_zona    = m.id_zona_mesa
                    LEFT   JOIN tbl_usuarios u  ON u.id_usuario = m.id_mesero_asignado_mesa
                    LEFT   JOIN tbl_mesas    m2 ON m2.id_mesa   = m.unida_con_mesa
                    WHERE  m.estado_mesa = 'Ocupada'
                      AND (m.id_mesero_asignado_mesa IS NOT NULL
                           OR m.unida_con_mesa IS NULL)
                      AND  z.es_eventos_zona = 0
                    ORDER  BY m.numero_mesa ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        // Construir texto del ComboBox incluyendo mesa unida si existe
                        string textoMesa = "Mesa " + rd.GetInt32("numero_mesa").ToString("00")
                                         + " - " + rd.GetString("nombre_zona");

                        if (!rd.IsDBNull(rd.GetOrdinal("numero_mesa_unida")))
                            textoMesa += " + M" + rd.GetInt32("numero_mesa_unida").ToString("00");

                        lista.Add(new MesaResumen
                        {
                            IdMesa = rd.GetInt32("id_mesa"),
                            NumeroMesa = rd.GetInt32("numero_mesa"),
                            EstadoMesa = rd.GetString("estado_mesa"),
                            IdMeseroAsignado = rd.IsDBNull(rd.GetOrdinal("id_mesero_asignado_mesa"))
                                                      ? (int?)null
                                                      : rd.GetInt32("id_mesero_asignado_mesa"),
                            NombreZona = rd.GetString("nombre_zona"),
                            NombreMeseroAsignado = rd.GetString("nombre_mesero"),
                            TextoComboBox = textoMesa   //  propiedad nueva, ver abajo
                        });
                    }
                }
            }

            return lista;
        }

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
                   m.id_mesero_asignado_mesa,
                   z.nombre_zona,
                   COALESCE(u.nombre_usuario, '-- Sin asignar --') AS nombre_mesero
            FROM   tbl_mesas    m
            INNER  JOIN tbl_zonas    z ON z.id_zona    = m.id_zona_mesa
            LEFT   JOIN tbl_usuarios u ON u.id_usuario = m.id_mesero_asignado_mesa
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
                                IdMeseroAsignado = rd.IsDBNull(rd.GetOrdinal("id_mesero_asignado_mesa"))
                                                       ? (int?)null
                                                       : rd.GetInt32("id_mesero_asignado_mesa"),
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