using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Engel.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.consultasSQL
{
    internal class SQLDescuentoAutorizado
    {
        ConexionDB conexion = new ConexionDB();

        // Guardar descuento autorizado por supervisor
        public bool GuardarDescuento(DescuentoAutorizado descuento)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO tbl_descuentos_autorizados
                                   (id_orden_descuento, id_supervisor_descuento, id_cajero_descuento,
                                    porcentaje_descuento, motivo_descuento, fecha_descuento)
                               VALUES (@orden, @supervisor, @cajero, @porcentaje, @motivo, NOW())";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@orden", descuento.IdOrden);
                cmd.Parameters.AddWithValue("@supervisor", descuento.IdSupervisor);
                cmd.Parameters.AddWithValue("@cajero", descuento.IdCajero);
                cmd.Parameters.AddWithValue("@porcentaje", descuento.PorcentajeDescuento);
                cmd.Parameters.AddWithValue("@motivo", descuento.MotivoDescuento);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Mostrar descuentos autorizados hoy
        public DataTable MostrarDescuentosDelDia()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT da.id_descuento, m.numero_mesa,
                                      us.nombre_usuario AS supervisor,
                                      uc.nombre_usuario AS cajero,
                                      da.porcentaje_descuento,
                                      da.motivo_descuento,
                                      da.fecha_descuento
                               FROM tbl_descuentos_autorizados da
                               JOIN tbl_usuarios us ON us.id_usuario = da.id_supervisor_descuento
                               JOIN tbl_usuarios uc ON uc.id_usuario = da.id_cajero_descuento
                               JOIN tbl_ordenes o ON o.id_orden = da.id_orden_descuento
                               JOIN tbl_mesas m ON m.id_mesa = o.id_mesa_orden
                               WHERE DATE(da.fecha_descuento) = CURDATE()
                               ORDER BY da.fecha_descuento DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Mostrar órdenes activas sin descuento (para que el supervisor elija)
        public DataTable MostrarOrdenesSinDescuento()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT o.id_orden, m.numero_mesa,
                                      u.nombre_usuario AS mesero,
                                      o.estado_orden,
                                      COALESCE(SUM(d.cantidad_detalle * d.precio_unitario_detalle), 0) AS subtotal
                               FROM tbl_ordenes o
                               JOIN tbl_mesas m ON m.id_mesa = o.id_mesa_orden
                               JOIN tbl_usuarios u ON u.id_usuario = o.id_mesero_orden
                               LEFT JOIN tbl_detalle_orden d ON d.id_orden_detalle = o.id_orden
                               WHERE o.estado_orden IN ('abierta','pendiente_pago')
                                 AND o.id_orden NOT IN (
                                     SELECT id_orden_descuento FROM tbl_descuentos_autorizados)
                               GROUP BY o.id_orden, m.numero_mesa,
                                        u.nombre_usuario, o.estado_orden
                               ORDER BY o.fecha_hora_orden ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
