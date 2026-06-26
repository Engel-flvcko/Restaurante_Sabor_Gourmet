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
    public class SQLMesas
    {


        private ConexionBD conexionBD = new ConexionBD();

        // Todas las mesas ,para dibujar el mapa

        // Detalle de una mesa ,para el panel lateral

        public bool OrdenTieneItemsPendientesEnCocina(int idOrden) // Verifica si una orden aún tiene platillos pendientes en cocina
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
            SELECT COUNT(*) FROM tbl_cola_cocina
            WHERE id_orden_cocina = @idOrden
              AND estado_cocina  NOT IN ('entregada', 'cancelada')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idOrden", idOrden);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public int? ObtenerOrdenActivaPorMesa(int idMesa) // Obtiene el ID de la orden activa asociada a una mesa
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open(); 
                string query = @"
            SELECT id_orden FROM tbl_ordenes
            WHERE id_mesa_orden  = @idMesa
              AND estado_orden IN ('abierta','pendiente_pago')
            ORDER BY fecha_hora_orden DESC
            LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value
                    ? (int?)Convert.ToInt32(result) : null;
            }
        }

        //  unir mesas
        public bool UnirMesas(int idMesa, int idMesaAdyacente) // Une dos mesas, las marca como ocupadas y registra la hora de ocupación.
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open();
                using (MySqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {
                        // Marcar la unión en ambas mesas
                        string sqlUnir = @"
                    UPDATE tbl_mesas
                    SET unida_con_mesa   = CASE WHEN id_mesa = @a THEN @b ELSE @a END,
                        estado_mesa      = 'Ocupada',
                        hora_ocupacion_mesa = NOW()
                    WHERE id_mesa IN (@a, @b)";
                        using (MySqlCommand cmd = new MySqlCommand(sqlUnir, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@a", idMesa);
                            cmd.Parameters.AddWithValue("@b", idMesaAdyacente);
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();
                        return true;
                    }
                    catch { tr.Rollback(); return false; }
                }
            }
        }

        // Obtener mesas unidas 
        public DataTable ObtenerMesasUnidas(int idMesa)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
            SELECT m.id_mesa, m.numero_mesa, z.nombre_zona
            FROM tbl_mesas m
            INNER JOIN tbl_zonas z ON z.id_zona = m.id_zona_mesa
            WHERE m.id_mesa = (
                SELECT unida_con_mesa FROM tbl_mesas WHERE id_mesa = @idMesa
            )
            AND m.id_mesa IS NOT NULL";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                new MySqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        // dividir mesas 
        public bool DividirMesas(int idMesa, int idMesaAdyacente)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open();
                using (MySqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {
                        // Limpiar el flag en ambas mesas
                        string sqlLimpiar = @"
                    UPDATE tbl_mesas
                    SET unida_con_mesa = NULL
                    WHERE id_mesa IN (@a, @b)";
                        using (MySqlCommand cmd = new MySqlCommand(sqlLimpiar, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@a", idMesa);
                            cmd.Parameters.AddWithValue("@b", idMesaAdyacente);
                            cmd.ExecuteNonQuery();
                        }

                        // Liberar la mesa que se separa
                        string sqlLiberar = @"
                    UPDATE tbl_mesas
                    SET estado_mesa             = 'Disponible',
                        id_mesero_asignado_mesa = NULL,
                        hora_ocupacion_mesa     = NULL,
                        num_clientes_mesa       = 0
                    WHERE id_mesa = @b";
                        using (MySqlCommand cmd = new MySqlCommand(sqlLiberar, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@b", idMesaAdyacente);
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();
                        return true;
                    }
                    catch { tr.Rollback(); return false; }
                }
            }
        }

        // Mesas adyacentes  , excluye la mesa ya unida
        public DataTable ObtenerMesasAdyacentesDisponibles(int idMesa)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
            SELECT m.id_mesa, m.numero_mesa, z.nombre_zona, m.estado_mesa
            FROM tbl_mesas_adyacentes ma
            INNER JOIN tbl_mesas m ON m.id_mesa = ma.id_mesa_adyacente_adyacentes
            INNER JOIN tbl_zonas z ON z.id_zona  = m.id_zona_mesa
            WHERE ma.id_mesa_adyacentes = @idMesa
              AND m.estado_mesa         = 'Disponible'
              AND m.unida_con_mesa      IS NULL
            ORDER BY m.numero_mesa ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                new MySqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        // Asigna un mesero a una mesa disponible, la marca como ocupada y registra la hora de inicio.
        public bool AsignarMesa(int idMesa, int idMesero) 
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open(); 
                string query = @"
            UPDATE tbl_mesas
            SET estado_mesa              = 'Ocupada',
                hora_ocupacion_mesa      = NOW(),
                id_mesero_asignado_mesa  = @idMesero,
                num_clientes_mesa        = 0
            WHERE id_mesa     = @idMesa
              AND estado_mesa = 'Disponible'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                cmd.Parameters.AddWithValue("@idMesero", idMesero);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cambia el estado de una orden de abierta a pendiente de pago.
        public bool CerrarCuenta(int idOrden)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open(); 
                string query = @"
            UPDATE tbl_ordenes
            SET estado_orden = 'pendiente_pago'
            WHERE id_orden    = @idOrden
              AND estado_orden = 'abierta'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idOrden", idOrden);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Libera una mesa, elimina el mesero asignado, borra la hora de ocupación y reinicia el número de clientes.
        public bool LiberarMesa(int idMesa)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
            UPDATE tbl_mesas
            SET estado_mesa             = 'Disponible',
                id_mesero_asignado_mesa = NULL,
                hora_ocupacion_mesa     = NULL,
                num_clientes_mesa       = 0
            WHERE id_mesa = @idMesa";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 
        public bool CambiarEstado(int idMesa, string nuevoEstado)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open(); 
                string query = "UPDATE tbl_mesas SET estado_mesa = @estado WHERE id_mesa = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", idMesa);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Obtiene toda la información de una mesa específica, incluyendo zona y mesero asignado.
        public DataTable ObtenerMesaPorId(int idMesa)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
                    SELECT m.id_mesa, m.numero_mesa, m.estado_mesa,
                           m.capacidad_mesa, m.num_clientes_mesa,
                           m.hora_ocupacion_mesa, m.id_mesero_asignado_mesa,
                           m.id_zona_mesa,                              -- ← agregar
                           z.nombre_zona,
                           u.nombre_usuario AS nombre_mesero
                    FROM tbl_mesas m
                    INNER JOIN tbl_zonas z ON m.id_zona_mesa = z.id_zona
                    LEFT  JOIN tbl_usuarios u ON u.id_usuario = m.id_mesero_asignado_mesa
                    WHERE m.id_mesa = @idMesa";
                

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                new MySqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        // Transferir orden a otra mesa
        public bool TransferirOrden(int idOrden, int idMesaOrigen, int idMesaDestino)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open(); 
                using (MySqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlOrden = @"
                    UPDATE tbl_ordenes SET id_mesa_orden = @destino
                    WHERE id_orden = @idOrden";
                        using (MySqlCommand cmd = new MySqlCommand(sqlOrden, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@destino", idMesaDestino);
                            cmd.Parameters.AddWithValue("@idOrden", idOrden);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlOrigen = @"
                    UPDATE tbl_mesas
                    SET estado_mesa             = 'En limpieza',
                        id_mesero_asignado_mesa = NULL
                    WHERE id_mesa = @origen";
                        using (MySqlCommand cmd = new MySqlCommand(sqlOrigen, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@origen", idMesaOrigen);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlDestino = @"
                    UPDATE tbl_mesas
                    SET estado_mesa         = 'Ocupada',
                        hora_ocupacion_mesa = NOW()
                    WHERE id_mesa = @destino";
                        using (MySqlCommand cmd = new MySqlCommand(sqlDestino, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@destino", idMesaDestino);
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();
                        return true;
                    }
                    catch
                    {
                        tr.Rollback();
                        return false;
                    }
                }
            }
        }


        // Obtiene el listado de todas las mesas con su número, estado y zona para mostrarlas en el mapa del restaurante.
        public DataTable ObtenerMesas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
                    SELECT m.id_mesa, m.numero_mesa, m.id_zona_mesa,
                           m.estado_mesa, z.nombre_zona, z.es_eventos_zona
                    FROM tbl_mesas m
                    INNER JOIN tbl_zonas z ON m.id_zona_mesa = z.id_zona
                    ORDER BY m.numero_mesa ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        //  Detalle de una mesa , para el panel lateral 

        // Mesas disponibles para unir / transferir 
        public DataTable ObtenerMesasDisponibles(int excluirIdMesa = 0)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
            SELECT m.id_mesa, m.numero_mesa, z.nombre_zona
            FROM tbl_mesas m
            INNER JOIN tbl_zonas z ON m.id_zona_mesa = z.id_zona
            WHERE m.estado_mesa   = 'Disponible'
              AND m.id_mesa      <> @excluir
              AND z.es_eventos_zona = 0
            ORDER BY m.numero_mesa ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@excluir", excluirIdMesa);
                new MySqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

    }
}