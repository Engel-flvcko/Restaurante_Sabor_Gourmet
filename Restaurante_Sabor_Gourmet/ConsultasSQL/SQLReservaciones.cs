using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLReservaciones
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ══════════════════════════════════════════════════════════════
        //  OBTENER RESERVACIONES (grilla con filtros)
        //  Usa MySqlDataAdapter — NO necesita cn.Open()
        // ══════════════════════════════════════════════════════════════
        public DataTable ObtenerReservaciones(DateTime fecha, string buscar,
                                              string estado, string tipo)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    SELECT
                        r.id_reservacion,
                        r.nombre_cliente_reservacion        AS nombre_cliente,
                        r.telefono_cliente_reservacion      AS telefono_cliente,
                        DATE_FORMAT(r.fecha_reservacion,    '%d/%m/%Y')  AS fecha,
                        TIME_FORMAT(r.hora_inicio_reservacion, '%H:%i')  AS hora_inicio,
                        r.num_personas_reservacion          AS num_personas,
                        r.tipo_reservacion                  AS tipo,
                        COALESCE(r.nombre_evento_reservacion, '-')       AS nombre_evento,
                        COALESCE(
                            (SELECT GROUP_CONCAT(
                                        CONCAT(m2.numero_mesa, ' (', z.nombre_zona, ')')
                                        ORDER BY m2.numero_mesa
                                        SEPARATOR ', ')
                             FROM tbl_reservacion_mesas rm2
                             JOIN tbl_mesas m2 ON m2.id_mesa    = rm2.id_mesa_resmesa
                             JOIN tbl_zonas z  ON z.id_zona     = m2.id_zona_mesa
                             WHERE rm2.id_reservacion_resmesa   = r.id_reservacion
                            ), '-')                                      AS mesas_asignadas,
                        r.estado_reservacion                AS estado,
                        u.nombre_usuario
                    FROM tbl_reservaciones r
                    JOIN tbl_usuarios u ON u.id_usuario = r.id_empleado_reservacion
                    WHERE (@fecha = '0001-01-01' OR r.fecha_reservacion = @fecha)
                      AND (@buscar = '' OR r.nombre_cliente_reservacion  LIKE @buscarLike
                                       OR r.telefono_cliente_reservacion LIKE @buscarLike)
                      AND (@estado = '' OR r.estado_reservacion = @estado)
                      AND (@tipo   = '' OR r.tipo_reservacion   = @tipo)
                    ORDER BY r.hora_inicio_reservacion ASC, r.id_reservacion DESC";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@buscar", buscar);
                cmd.Parameters.AddWithValue("@buscarLike", "%" + buscar + "%");
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@tipo", tipo);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        // ══════════════════════════════════════════════════════════════
        //  OBTENER POR ID — necesita cn.Open() + ExecuteReader
        // ══════════════════════════════════════════════════════════════
        public Reservacion ObtenerPorId(int idReservacion)
        {
            Reservacion r = null;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT id_reservacion,
                           nombre_cliente_reservacion,
                           telefono_cliente_reservacion,
                           fecha_reservacion,
                           hora_inicio_reservacion,
                           num_personas_reservacion,
                           tipo_reservacion,
                           COALESCE(nombre_evento_reservacion, '') AS nombre_evento_reservacion,
                           estado_reservacion,
                           id_empleado_reservacion
                    FROM tbl_reservaciones
                    WHERE id_reservacion = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idReservacion);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            r = new Reservacion
                            {
                                IdReservacion = rd.GetInt32("id_reservacion"),
                                NombreCliente = rd.GetString("nombre_cliente_reservacion"),
                                TelefonoCliente = rd.GetString("telefono_cliente_reservacion"),
                                Fecha = rd.GetDateTime("fecha_reservacion"),
                                HoraInicio = rd.GetTimeSpan("hora_inicio_reservacion"),
                                NumPersonas = rd.GetInt32("num_personas_reservacion"),
                                Tipo = rd.GetString("tipo_reservacion"),
                                NombreEvento = rd.GetString("nombre_evento_reservacion"),
                                Estado = rd.GetString("estado_reservacion"),
                                IdEmpleadoRegistro = rd.GetInt32("id_empleado_reservacion")
                            };
                        }
                    }
                }
            }

            return r;
        }

        // ══════════════════════════════════════════════════════════════
        //  REGISTRAR RESERVACIÓN — cn.Open() + transacción
        // ══════════════════════════════════════════════════════════════
        public bool RegistrarReservacion(Reservacion r, List<int> idMesas)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                using (MySqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlInsert = @"
                            INSERT INTO tbl_reservaciones
                                (nombre_cliente_reservacion, telefono_cliente_reservacion,
                                 fecha_reservacion, hora_inicio_reservacion,
                                 num_personas_reservacion, tipo_reservacion,
                                 nombre_evento_reservacion, estado_reservacion,
                                 id_empleado_reservacion)
                            VALUES
                                (@nombre, @telefono, @fecha, @hora,
                                 @personas, @tipo, @evento, @estado, @empleado)";

                        int idNuevo;
                        using (MySqlCommand cmd = new MySqlCommand(sqlInsert, cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@nombre", r.NombreCliente);
                            cmd.Parameters.AddWithValue("@telefono", r.TelefonoCliente);
                            cmd.Parameters.AddWithValue("@fecha", r.Fecha.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@hora", r.HoraInicio.ToString(@"hh\:mm\:ss"));
                            cmd.Parameters.AddWithValue("@personas", r.NumPersonas);
                            cmd.Parameters.AddWithValue("@tipo", r.Tipo);
                            cmd.Parameters.AddWithValue("@evento",
                                string.IsNullOrEmpty(r.NombreEvento)
                                    ? (object)DBNull.Value : r.NombreEvento);
                            cmd.Parameters.AddWithValue("@estado", r.Estado);
                            cmd.Parameters.AddWithValue("@empleado", r.IdEmpleadoRegistro);
                            cmd.ExecuteNonQuery();
                            idNuevo = (int)cmd.LastInsertedId;
                        }

                        InsertarMesasReservacion(cn, tr, idNuevo, idMesas);
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

        // ══════════════════════════════════════════════════════════════
        //  ACTUALIZAR RESERVACIÓN — cn.Open() + transacción
        // ══════════════════════════════════════════════════════════════
        public bool ActualizarReservacion(Reservacion r, List<int> idMesas)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                using (MySqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlUpdate = @"
                            UPDATE tbl_reservaciones SET
                                nombre_cliente_reservacion   = @nombre,
                                telefono_cliente_reservacion = @telefono,
                                fecha_reservacion            = @fecha,
                                hora_inicio_reservacion      = @hora,
                                num_personas_reservacion     = @personas,
                                tipo_reservacion             = @tipo,
                                nombre_evento_reservacion    = @evento,
                                estado_reservacion           = @estado
                            WHERE id_reservacion = @id";

                        using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@nombre", r.NombreCliente);
                            cmd.Parameters.AddWithValue("@telefono", r.TelefonoCliente);
                            cmd.Parameters.AddWithValue("@fecha", r.Fecha.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@hora", r.HoraInicio.ToString(@"hh\:mm\:ss"));
                            cmd.Parameters.AddWithValue("@personas", r.NumPersonas);
                            cmd.Parameters.AddWithValue("@tipo", r.Tipo);
                            cmd.Parameters.AddWithValue("@evento",
                                string.IsNullOrEmpty(r.NombreEvento)
                                    ? (object)DBNull.Value : r.NombreEvento);
                            cmd.Parameters.AddWithValue("@estado", r.Estado);
                            cmd.Parameters.AddWithValue("@id", r.IdReservacion);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlDelete = @"DELETE FROM tbl_reservacion_mesas
                                             WHERE id_reservacion_resmesa = @id";
                        using (MySqlCommand cmd = new MySqlCommand(sqlDelete, cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@id", r.IdReservacion);
                            cmd.ExecuteNonQuery();
                        }

                        InsertarMesasReservacion(cn, tr, r.IdReservacion, idMesas);
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

        // ── Insertar mesas (reutilizable, la conexión ya está abierta) ─
        private void InsertarMesasReservacion(MySqlConnection cn, MySqlTransaction tr,
                                              int idReservacion, List<int> idMesas)
        {
            string sqlMesa = @"INSERT INTO tbl_reservacion_mesas
                                   (id_reservacion_resmesa, id_mesa_resmesa)
                               VALUES (@idRes, @idMesa)";

            foreach (int idMesa in idMesas)
            {
                using (MySqlCommand cmd = new MySqlCommand(sqlMesa, cn, tr))
                {
                    cmd.Parameters.AddWithValue("@idRes", idReservacion);
                    cmd.Parameters.AddWithValue("@idMesa", idMesa);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  CAMBIAR ESTADO — cn.Open() + ExecuteNonQuery
        // ══════════════════════════════════════════════════════════════
        public bool CambiarEstado(int idReservacion, string nuevoEstado)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE tbl_reservaciones
                               SET estado_reservacion = @estado
                               WHERE id_reservacion   = @id
                                 AND estado_reservacion <> 'cancelada'";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id", idReservacion);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  OBTENER MESAS POR RESERVACIÓN — cn.Open() + ExecuteReader
        // ══════════════════════════════════════════════════════════════
        public List<int> ObtenerMesasPorReservacion(int idReservacion)
        {
            List<int> ids = new List<int>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT id_mesa_resmesa
                               FROM tbl_reservacion_mesas
                               WHERE id_reservacion_resmesa = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idReservacion);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            ids.Add(rd.GetInt32("id_mesa_resmesa"));
                    }
                }
            }

            return ids;
        }

        // ══════════════════════════════════════════════════════════════
        //  OBTENER MESAS DISPONIBLES — cn.Open() + ExecuteReader
        // ══════════════════════════════════════════════════════════════
        public List<MesaResumen> ObtenerMesasDisponiblesParaReserva()
        {
            List<MesaResumen> lista = new List<MesaResumen>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT m.id_mesa,
                           m.numero_mesa,
                           m.capacidad_mesa,
                           m.estado_mesa,
                           z.nombre_zona
                    FROM tbl_mesas m
                    JOIN tbl_zonas z ON z.id_zona = m.id_zona_mesa
                    WHERE m.estado_mesa <> 'Fuera de servicio'
                    ORDER BY z.id_zona ASC, m.numero_mesa ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new MesaResumen
                        {
                            IdMesa = rd.GetInt32("id_mesa"),
                            NumeroMesa = rd.GetInt32("numero_mesa"),
                            Capacidad = rd.GetInt32("capacidad_mesa"),
                            EstadoMesa = rd.GetString("estado_mesa"),
                            NombreZona = rd.GetString("nombre_zona")
                        });
                    }
                }
            }

            return lista;
        }

        // ══════════════════════════════════════════════════════════════
        //  VERIFICAR CONFLICTO DE HORARIO — cn.Open() + ExecuteScalar
        // ══════════════════════════════════════════════════════════════
        public bool VerificarConflictoHorario(DateTime fecha, TimeSpan hora,
                                              List<int> idMesas, int excluirId = 0)
        {
            if (idMesas == null || idMesas.Count == 0) return false;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                StringBuilder sbParams = new StringBuilder();
                for (int i = 0; i < idMesas.Count; i++)
                    sbParams.Append(i == 0 ? "@m0" : $",@m{i}");

                string sql = $@"
                    SELECT COUNT(*)
                    FROM tbl_reservacion_mesas rm
                    JOIN tbl_reservaciones r
                         ON r.id_reservacion          = rm.id_reservacion_resmesa
                    WHERE rm.id_mesa_resmesa           IN ({sbParams})
                      AND r.fecha_reservacion          = @fecha
                      AND r.hora_inicio_reservacion    = @hora
                      AND r.estado_reservacion         IN ('pendiente','confirmada')
                      AND r.id_reservacion            <> @excluir";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    for (int i = 0; i < idMesas.Count; i++)
                        cmd.Parameters.AddWithValue($"@m{i}", idMesas[i]);

                    cmd.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@hora", hora.ToString(@"hh\:mm\:ss"));
                    cmd.Parameters.AddWithValue("@excluir", excluirId);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  OBTENER CAPACIDAD TOTAL — cn.Open() + ExecuteScalar
        // ══════════════════════════════════════════════════════════════
        public int ObtenerCapacidadTotal(List<int> idMesas)
        {
            if (idMesas == null || idMesas.Count == 0) return 0;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                StringBuilder sbParams = new StringBuilder();
                for (int i = 0; i < idMesas.Count; i++)
                    sbParams.Append(i == 0 ? "@m0" : $",@m{i}");

                string sql = $@"
                    SELECT COALESCE(SUM(capacidad_mesa), 0)
                    FROM tbl_mesas
                    WHERE id_mesa IN ({sbParams})";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    for (int i = 0; i < idMesas.Count; i++)
                        cmd.Parameters.AddWithValue($"@m{i}", idMesas[i]);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}