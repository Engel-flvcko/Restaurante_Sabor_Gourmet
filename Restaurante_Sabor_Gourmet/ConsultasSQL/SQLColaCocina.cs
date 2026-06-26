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

       
        // Obtener cola completa del día
        // Devuelve las órdenes en orden estricto de hora de recepción,
        // incluyendo los productos de cada orden en la propiedad Productos.
  
        public List<ColaCocina> ObtenerColaDelDia()
        {
            List<ColaCocina> lista = new List<ColaCocina>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sqlCabecera = @"
            SELECT c.id_cocina,
                   c.id_orden_cocina,
                   c.estado_cocina,
                   c.hora_recepcion_cocina,
                   c.hora_inicio_cocina,
                   c.hora_finalizacion_cocina,
                   m.numero_mesa
            FROM   tbl_cola_cocina c
            INNER  JOIN tbl_ordenes o ON o.id_orden  = c.id_orden_cocina
            INNER  JOIN tbl_mesas   m ON m.id_mesa   = o.id_mesa_orden
            WHERE  DATE(c.hora_recepcion_cocina) = CURDATE()
            ORDER  BY c.hora_recepcion_cocina ASC";
                // Trae solo las órdenes de cocina recibidas HOY, ordenadas de la más
                // antigua a la más nueva (orden estricto de llegada → primero en entrar, primero en salir).

                using (MySqlCommand cmd = new MySqlCommand(sqlCabecera, cn))
                {
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ColaCocina
                            {
                                IdCocina = rd.GetInt32("id_cocina"),
                                IdOrden = rd.GetInt32("id_orden_cocina"),
                                EstadoCocina = rd.GetString("estado_cocina"),
                                HoraRecepcion = rd.GetDateTime("hora_recepcion_cocina"),
                                HoraInicio = rd.IsDBNull(rd.GetOrdinal("hora_inicio_cocina"))
                                                    ? (DateTime?)null
                                                    : rd.GetDateTime("hora_inicio_cocina"),
                                // HoraInicio puede ser NULL si la orden todavía no entró en preparación
                                HoraFinalizacion = rd.IsDBNull(rd.GetOrdinal("hora_finalizacion_cocina"))
                                                    ? (DateTime?)null
                                                    : rd.GetDateTime("hora_finalizacion_cocina"),
                                // HoraFinalizacion puede ser NULL si aún no terminó/se entregó
                                NumeroMesa = rd.GetInt32("numero_mesa")
                            });
                        }
                    }
                }

                // Para cada orden de la cola, se hace una segunda consulta que trae
                // sus productos (detalle). Se reutiliza la misma conexión "cn" ya abierta.
                foreach (ColaCocina item in lista)
                    item.Productos = ObtenerProductosPorOrden(cn, item.IdOrden);
            }

            return lista;
        }

   
        // Trae el detalle de productos de UNA orden específica
        // (método privado, usado internamente por ObtenerColaDelDia)
       
        private List<DetalleOrden> ObtenerProductosPorOrden(MySqlConnection cn, int idOrden)
        {
            List<DetalleOrden> productos = new List<DetalleOrden>();

            string sql = @"
        SELECT d.id_detalle,
               d.id_orden_detalle,
               d.id_producto_detalle,
               d.cantidad_detalle,
               d.precio_unitario_detalle,
               d.observaciones_detalle,
               p.nombre_producto
        FROM   tbl_detalle_orden d
        INNER  JOIN tbl_productos p ON p.id_producto = d.id_producto_detalle
        WHERE  d.id_orden_detalle = @idOrden";
            // Trae cada línea de producto pedido en la orden, junto con su nombre (vía JOIN).

            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
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
                            Observaciones = rd.IsDBNull(rd.GetOrdinal("observaciones_detalle"))
                                                       ? "" : rd.GetString("observaciones_detalle"),
                            // Observaciones puede venir NULL en la BD (ej. "sin cebolla"), se convierte a "" si no hay
                            NombreProducto = rd.GetString("nombre_producto")
                        });
                    }
                }
            }

            return productos;
        }

      
        // Cambiar el estado de una orden dentro de la cola de cocina
        // (pendiente  en preparacion lista/entregada/cancelada)
       
        public bool CambiarEstado(int idCocina, string estadoActual, string estadoNuevo)
        {
            // Antes de tocar la BD, valida que el cambio de estado sea lógicamente permitido
            // (por ejemplo, no se puede pasar de "pendiente" directo a "entregada")
            if (!ValidacionesOrdenes.TransicionEstadoCocinaValida(estadoActual, estadoNuevo))
                return false;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql;

                if (estadoNuevo == "en_preparacion")
                {
                    // Al empezar a preparar, se registra la hora de inicio
                    sql = @"UPDATE tbl_cola_cocina
                       SET estado_cocina      = @estado,
                           hora_inicio_cocina = NOW()
                     WHERE id_cocina = @id";
                }
                else if (estadoNuevo == "lista" || estadoNuevo == "entregada" || estadoNuevo == "cancelada")
                {
                    // Al finalizar (de cualquier forma), se registra la hora de finalización
                    sql = @"UPDATE tbl_cola_cocina
                       SET estado_cocina           = @estado,
                           hora_finalizacion_cocina = NOW()
                     WHERE id_cocina = @id";
                }
                else
                {
                    // Cualquier otro estado: solo se actualiza el campo de estado, sin tocar horas
                    sql = @"UPDATE tbl_cola_cocina
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

       
        // Calcula el tiempo promedio (en minutos) que tardan las órdenes
        // entregadas HOY, desde que empezaron a prepararse hasta que terminaron
     
        public double ObtenerTiempoPromedioMinutos()
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
            SELECT AVG(TIMESTAMPDIFF(MINUTE, hora_inicio_cocina, hora_finalizacion_cocina))
            FROM   tbl_cola_cocina
            WHERE  estado_cocina          = 'entregada'
            AND    hora_inicio_cocina     IS NOT NULL
            AND    hora_finalizacion_cocina IS NOT NULL
            AND    DATE(hora_recepcion_cocina) = CURDATE()";
                // Solo considera órdenes ya entregadas y con ambas horas registradas (evita NULLs en la resta).

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    object resultado = cmd.ExecuteScalar();
                    return (resultado == null || resultado == DBNull.Value)
                        ? 0
                        : Convert.ToDouble(resultado);
                    // Si no hay ninguna orden que cumpla la condición, AVG() devuelve NULL,
                    // por eso se valida antes de convertir (si no, lanzaría una excepción).
                }
            }
        }

      
        // Cuenta cuántas órdenes están pendientes (sin empezar) hoy
    
        public int ObtenerTotalPendientes()
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
            SELECT COUNT(*) FROM tbl_cola_cocina
            WHERE  estado_cocina          = 'pendiente'
            AND    DATE(hora_recepcion_cocina) = CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Cuenta cuántas órdenes llevan "retrasadas" más de X minutos
        // (por defecto 30) sin terminar, hoy
     
        public int ObtenerTotalRetrasadas(int minutosLimite = 30)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
            SELECT COUNT(*) FROM tbl_cola_cocina
            WHERE  estado_cocina IN ('pendiente', 'en_preparacion')
            AND    TIMESTAMPDIFF(MINUTE, hora_recepcion_cocina, NOW()) >= @minutos
            AND    DATE(hora_recepcion_cocina) = CURDATE()";
                // Solo cuenta órdenes que SIGUEN activas (pendiente o en preparación)
                // y que ya superaron el límite de minutos desde que llegaron.

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@minutos", minutosLimite);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        
        // Devuelve el top N de productos más vendidos (en unidades) del día
    
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
                // Suma las cantidades vendidas de cada producto hoy, ordena de mayor a menor
                // y se queda solo con los primeros "top" resultados (por defecto 3).

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
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