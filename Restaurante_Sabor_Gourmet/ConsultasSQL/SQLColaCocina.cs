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
    internal class SQLColaCocina
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ============================================================
        //  OBTENER COLA COMPLETA DEL DÍA
        //  Devuelve las órdenes en orden ESTRICTO de hora_recepcion ASC.
        //  Incluye los productos de cada orden en la propiedad Productos.
        // ============================================================
        public List<ColaCocina> ObtenerColaDelDia()
        {
            List<ColaCocina> lista = new List<ColaCocina>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                // 1. Traer la cabecera de cada orden en cola del día actual
                string sqlCabecera = @"
                    SELECT c.id_cocina,
                           c.id_orden,
                           c.estado_cocina,
                           c.hora_recepcion,
                           c.hora_inicio,
                           c.hora_finalizacion,
                           m.numero_mesa
                    FROM   tbl_cola_cocina c
                    INNER  JOIN tbl_ordenes  o ON o.id_orden  = c.id_orden
                    INNER  JOIN tbl_mesas    m ON m.id_mesa   = o.id_mesa_orden
                    WHERE  DATE(c.hora_recepcion) = CURDATE()
                    ORDER  BY c.hora_recepcion ASC";

                using (MySqlCommand cmd = new MySqlCommand(sqlCabecera, cn))
                {
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        cn.Open();
                        while (rd.Read())
                        {
                            lista.Add(new ColaCocina
                            {
                                IdCocina = rd.GetInt32("id_cocina"),
                                IdOrden = rd.GetInt32("id_orden"),
                                EstadoCocina = rd.GetString("estado_cocina"),
                                HoraRecepcion = rd.GetDateTime("hora_recepcion"),
                                HoraInicio = rd.IsDBNull(rd.GetOrdinal("hora_inicio"))
                                                       ? (DateTime?)null
                                                       : rd.GetDateTime("hora_inicio"),
                                HoraFinalizacion = rd.IsDBNull(rd.GetOrdinal("hora_finalizacion"))
                                                       ? (DateTime?)null
                                                       : rd.GetDateTime("hora_finalizacion"),
                                NumeroMesa = rd.GetInt32("numero_mesa")
                            });
                        }
                    }
                }

                // 2. Para cada orden, cargar su lista de productos
                foreach (ColaCocina item in lista)
                    item.Productos = ObtenerProductosPorOrden(cn, item.IdOrden);
            }

            return lista;
        }

        // ============================================================
        //  OBTENER PRODUCTOS DE UNA ORDEN (para mostrar en la tarjeta)
        // ============================================================
        private List<DetalleOrden> ObtenerProductosPorOrden(MySqlConnection cn, int idOrden)
        {
            List<DetalleOrden> productos = new List<DetalleOrden>();
            cn.Open();
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
                cn.Open();
                cmd.Parameters.AddWithValue("@idOrden", idOrden);

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        productos.Add(new DetalleOrden
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

            return productos;
        }

        // ============================================================
        //  CAMBIAR ESTADO EN COCINA (flujo unidireccional)
        //  Registra hora_inicio al pasar a en_preparacion y
        //  hora_finalizacion al pasar a lista/entregada/cancelada.
        //  El trigger trg_descuento_inventario se dispara automáticamente
        //  cuando el estado llega a 'entregada'.
        // ============================================================
        public bool CambiarEstado(int idCocina, string estadoActual, string estadoNuevo)
        {
            // Validar flujo antes de tocar la BD
            if (!ValidacionesOrdenes.TransicionEstadoCocinaValida(estadoActual, estadoNuevo))
                return false;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql;

                if (estadoNuevo == "en_preparacion")
                {
                    // Registrar hora de inicio de preparación
                    sql = @"
                        UPDATE tbl_cola_cocina
                           SET estado_cocina = @estado,
                               hora_inicio   = NOW()
                         WHERE id_cocina = @id";
                }
                else if (estadoNuevo == "lista" || estadoNuevo == "entregada" || estadoNuevo == "cancelada")
                {
                    // Registrar hora de finalización
                    sql = @"
                        UPDATE tbl_cola_cocina
                           SET estado_cocina      = @estado,
                               hora_finalizacion  = NOW()
                         WHERE id_cocina = @id";
                }
                else
                {
                    sql = @"
                        UPDATE tbl_cola_cocina
                           SET estado_cocina = @estado
                         WHERE id_cocina = @id";
                }

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@estado", estadoNuevo);
                    cmd.Parameters.AddWithValue("@id", idCocina);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================================
        //  MÉTRICAS DE COCINA
        // ============================================================

        /// <summary>
        /// Tiempo promedio de preparación de las órdenes entregadas hoy
        /// (desde hora_inicio hasta hora_finalizacion), en minutos.
        /// </summary>
        public double ObtenerTiempoPromedioMinutos()
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT AVG(TIMESTAMPDIFF(MINUTE, hora_inicio, hora_finalizacion))
                    FROM   tbl_cola_cocina
                    WHERE  estado_cocina     = 'entregada'
                    AND    hora_inicio       IS NOT NULL
                    AND    hora_finalizacion IS NOT NULL
                    AND    DATE(hora_recepcion) = CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    object resultado = cmd.ExecuteScalar();
                    return (resultado == null || resultado == DBNull.Value)
                        ? 0
                        : Convert.ToDouble(resultado);
                }
            }
        }

        /// <summary>
        /// Cantidad de órdenes en estado 'pendiente' en este momento.
        /// </summary>
        public int ObtenerTotalPendientes()
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT COUNT(*) FROM tbl_cola_cocina
                    WHERE  estado_cocina     = 'pendiente'
                    AND    DATE(hora_recepcion) = CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Cantidad de órdenes pendientes o en preparación que superaron
        /// el límite de minutos desde hora_recepcion (default: 30 min).
        /// </summary>
        public int ObtenerTotalRetrasadas(int minutosLimite = 30)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT COUNT(*) FROM tbl_cola_cocina
                    WHERE  estado_cocina IN ('pendiente', 'en_preparacion')
                    AND    TIMESTAMPDIFF(MINUTE, hora_recepcion, NOW()) >= @minutos
                    AND    DATE(hora_recepcion) = CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@minutos", minutosLimite);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Top 3 productos más solicitados del día (por cantidad total pedida).
        /// Devuelve lista de tuplas (NombreProducto, TotalUnidades).
        /// </summary>
        public List<(string Nombre, int Total)> ObtenerTopProductosHoy(int top = 3)
        {
            var lista = new List<(string, int)>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT p.nombre_producto,
                           SUM(d.cantidad_detalle) AS total_unidades
                    FROM   tbl_detalle_orden d
                    INNER  JOIN tbl_productos p ON p.id_producto = d.id_producto_detalle
                    INNER  JOIN tbl_ordenes   o ON o.id_orden    = d.id_orden_detalle
                    WHERE  DATE(o.fecha_hora_orden) = CURDATE()
                    GROUP  BY p.id_producto, p.nombre_producto
                    ORDER  BY total_unidades DESC
                    LIMIT  @top";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {cn.Open();
                    cmd.Parameters.AddWithValue("@top", top);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            lista.Add((rd.GetString("nombre_producto"),
                                       Convert.ToInt32(rd["total_unidades"])));
                    }
                }
            }

            return lista;
        }
    }
}
