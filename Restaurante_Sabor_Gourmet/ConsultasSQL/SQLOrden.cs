using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLOrden
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ============================================================
        //  VERIFICAR SI UNA MESA YA TIENE ORDEN ABIERTA
        //  Útil para saber si cargar el detalle existente o crear una nueva.
        // ============================================================
        public Orden ObtenerOrdenAbiertaPorMesa(int idMesa)
        {
            Orden orden = null;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT o.id_orden,
                           o.id_mesa_orden,
                           o.id_mesero_orden,
                           o.fecha_hora_orden,
                           o.estado_orden,
                           o.observaciones,
                           m.numero_mesa,
                           u.nombre_usuario AS nombre_mesero
                    FROM   tbl_ordenes  o
                    INNER  JOIN tbl_mesas    m ON m.id_mesa    = o.id_mesa_orden
                    INNER  JOIN tbl_usuarios u ON u.id_usuario = o.id_mesero_orden
                    WHERE  o.id_mesa_orden = @idMesa
                    AND    o.estado_orden  = 'abierta'
                    LIMIT  1";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idMesa", idMesa);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            orden = new Orden
                            {
                                IdOrden = rd.GetInt32("id_orden"),
                                IdMesaOrden = rd.GetInt32("id_mesa_orden"),
                                IdMeseroOrden = rd.GetInt32("id_mesero_orden"),
                                FechaHoraOrden = rd.GetDateTime("fecha_hora_orden"),
                                EstadoOrden = rd.GetString("estado_orden"),
                                Observaciones = rd.IsDBNull(rd.GetOrdinal("observaciones"))
                                                     ? "" : rd.GetString("observaciones"),
                                NumeroMesa = rd.GetInt32("numero_mesa"),
                                NombreMesero = rd.GetString("nombre_mesero")
                            };
                        }
                    }
                }

                // Si se encontró una orden, cargar su detalle
                if (orden != null)
                    orden.Detalles = ObtenerDetallesPorOrden(cn, orden.IdOrden);
            }

            return orden;
        }

        // ============================================================
        //  OBTENER DETALLES DE UNA ORDEN
        // ============================================================
        private List<DetalleOrden> ObtenerDetallesPorOrden(MySqlConnection cn, int idOrden)
        {
            List<DetalleOrden> detalles = new List<DetalleOrden>();

            string sql = @"
                SELECT d.id_detalle,
                       d.id_orden_detalle,
                       d.id_producto_detalle,
                       d.cantidad_detalle,
                       d.precio_unitario_detalle,
                       d.observaciones,
                       p.nombre_producto
                FROM   tbl_detalle_orden d
                INNER  JOIN tbl_productos p ON p.id_producto = d.id_producto_detalle
                WHERE  d.id_orden_detalle = @idOrden";

            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@idOrden", idOrden);

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        detalles.Add(new DetalleOrden
                        {
                            IdDetalle = rd.GetInt32("id_detalle"),
                            IdOrdenDetalle = rd.GetInt32("id_orden_detalle"),
                            IdProductoDetalle = rd.GetInt32("id_producto_detalle"),
                            CantidadDetalle = rd.GetInt32("cantidad_detalle"),
                            PrecioUnitarioDetalle = rd.GetDecimal("precio_unitario_detalle"),
                            Observaciones = rd.IsDBNull(rd.GetOrdinal("observaciones"))
                                                        ? "" : rd.GetString("observaciones"),
                            NombreProducto = rd.GetString("nombre_producto")
                        });
                    }
                }
            }

            return detalles;
        }

        // ============================================================
        //  REGISTRAR ORDEN COMPLETA → llama al SP RegistrarOrden()
        //  El SP internamente inserta en tbl_ordenes + tbl_detalle_orden
        //  y el trigger trg_crear_cola_cocina crea el registro en
        //  tbl_cola_cocina automáticamente.
        //  Devuelve el id_orden generado (o 0 si falló).
        // ============================================================
        public int RegistrarOrden(int idMesa, int idMesero,
                                  string observacionesGenerales,
                                  List<DetalleOrden> detalles)
        {
            int idOrdenGenerado = 0;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                using (MySqlTransaction tx = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar cabecera en tbl_ordenes
                        string sqlOrden = @"
                            INSERT INTO tbl_ordenes
                                (id_mesa_orden, id_mesero_orden,
                                 fecha_hora_orden, estado_orden, observaciones)
                            VALUES
                                (@idMesa, @idMesero,
                                 NOW(), 'abierta', @obs)";

                        using (MySqlCommand cmd = new MySqlCommand(sqlOrden, cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@idMesa", idMesa);
                            cmd.Parameters.AddWithValue("@idMesero", idMesero);
                            cmd.Parameters.AddWithValue("@obs", observacionesGenerales ?? "");
                            cmd.ExecuteNonQuery();
                            idOrdenGenerado = (int)cmd.LastInsertedId;
                        }

                        // 2. Insertar cada línea en tbl_detalle_orden
                        foreach (DetalleOrden d in detalles)
                        {
                            string sqlDetalle = @"
                                INSERT INTO tbl_detalle_orden
                                    (id_orden_detalle, id_producto_detalle,
                                     cantidad_detalle, precio_unitario_detalle, observaciones)
                                VALUES
                                    (@idOrden, @idProducto,
                                     @cantidad, @precio, @obs)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlDetalle, cn, tx))
                            {
                                cmd.Parameters.AddWithValue("@idOrden", idOrdenGenerado);
                                cmd.Parameters.AddWithValue("@idProducto", d.IdProductoDetalle);
                                cmd.Parameters.AddWithValue("@cantidad", d.CantidadDetalle);
                                cmd.Parameters.AddWithValue("@precio", d.PrecioUnitarioDetalle);
                                cmd.Parameters.AddWithValue("@obs", d.Observaciones ?? "");
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3. El trigger trg_crear_cola_cocina se dispara automáticamente
                        //    al hacer el INSERT en tbl_ordenes — no hay que llamarlo.

                        tx.Commit();
                    }
                    catch (Exception)
                    {
                        tx.Rollback();
                        idOrdenGenerado = 0;
                        throw; // re-lanza para que el formulario lo capture con try/catch
                    }
                }
            }

            return idOrdenGenerado;
        }

        // ============================================================
        //  CERRAR CUENTA → llama al SP CerrarCuenta()
        //  Cambia estado_orden de 'abierta' a 'pendiente_pago'.
        //  Devuelve true si el UPDATE afectó exactamente 1 fila.
        // ============================================================
        public bool CerrarCuenta(int idOrden)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                // Si existe el SP CerrarCuenta() en tu BD, usa esto:
                // string sql = "CALL CerrarCuenta(@idOrden)";

                // Si no, el UPDATE directo equivale al SP:
                string sql = @"
                    UPDATE tbl_ordenes
                       SET estado_orden = 'pendiente_pago'
                     WHERE id_orden     = @idOrden
                     AND   estado_orden = 'abierta'";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================================
        //  OBTENER TODAS LAS ÓRDENES DE UNA MESA (historial del día)
        //  Útil para mostrar estado en frmOrdenes.
        // ============================================================
        public List<Orden> ObtenerOrdenesPorMesa(int idMesa)
        {
            List<Orden> lista = new List<Orden>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT o.id_orden, o.id_mesa_orden, o.id_mesero_orden,
                           o.fecha_hora_orden, o.estado_orden, o.observaciones,
                           m.numero_mesa, u.nombre_usuario AS nombre_mesero
                    FROM   tbl_ordenes  o
                    INNER  JOIN tbl_mesas    m ON m.id_mesa    = o.id_mesa_orden
                    INNER  JOIN tbl_usuarios u ON u.id_usuario = o.id_mesero_orden
                    WHERE  o.id_mesa_orden = @idMesa
                    ORDER  BY o.fecha_hora_orden DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idMesa", idMesa);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Orden
                            {
                                IdOrden = rd.GetInt32("id_orden"),
                                IdMesaOrden = rd.GetInt32("id_mesa_orden"),
                                IdMeseroOrden = rd.GetInt32("id_mesero_orden"),
                                FechaHoraOrden = rd.GetDateTime("fecha_hora_orden"),
                                EstadoOrden = rd.GetString("estado_orden"),
                                Observaciones = rd.IsDBNull(rd.GetOrdinal("observaciones"))
                                                     ? "" : rd.GetString("observaciones"),
                                NumeroMesa = rd.GetInt32("numero_mesa"),
                                NombreMesero = rd.GetString("nombre_mesero")
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}