using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Engel.clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.consultasSQL
{
    internal class SQLCaja
    {
        ConexionBD conexion = new ConexionBD();

        // Mostrar cuentas pendientes de pago
        public DataTable MostrarCuentasPendientes()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT o.id_orden, m.numero_mesa,
                                      u.nombre_usuario AS mesero,
                                      o.fecha_hora_orden,
                                      COALESCE(SUM(d.cantidad_detalle * d.precio_unitario_detalle), 0) AS subtotal,
                                      COALESCE(da.porcentaje_descuento, 0) AS descuento
                               FROM tbl_ordenes o
                               JOIN tbl_mesas m ON m.id_mesa = o.id_mesa_orden
                               JOIN tbl_usuarios u ON u.id_usuario = o.id_mesero_orden
                               LEFT JOIN tbl_detalle_orden d ON d.id_orden_detalle = o.id_orden
                               LEFT JOIN (
                                   SELECT id_orden_descuento, porcentaje_descuento
                                   FROM tbl_descuentos_autorizados
                                   WHERE (id_orden_descuento, fecha_descuento) IN (
                                       SELECT id_orden_descuento, MAX(fecha_descuento)
                                       FROM tbl_descuentos_autorizados
                                       GROUP BY id_orden_descuento)
                               ) da ON da.id_orden_descuento = o.id_orden
                               WHERE o.estado_orden = 'pendiente_pago'
                               GROUP BY o.id_orden, m.numero_mesa, u.nombre_usuario,
                                        o.fecha_hora_orden, da.porcentaje_descuento
                               ORDER BY o.fecha_hora_orden ASC";

                MySqlDataAdapter da2 = new MySqlDataAdapter(sql, cn);
                da2.Fill(dt);
            }

            return dt;
        }

        // Calcular subtotal de una orden
        public DataTable ObtenerSubtotalOrden(int idOrden)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT COALESCE(SUM(cantidad_detalle * precio_unitario_detalle), 0) AS subtotal
                               FROM tbl_detalle_orden
                               WHERE id_orden_detalle = @idOrden";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idOrden", idOrden);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        // Registrar pago llamando al procedimiento almacenado
        public bool RegistrarPago(Pago pago)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "CALL RegistrarPago(@orden, @cajero, @arqueo, @subtotal, @descuento, @propina, @metodo)";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@orden", pago.IdOrden);
                cmd.Parameters.AddWithValue("@cajero", pago.IdCajero);
                cmd.Parameters.AddWithValue("@arqueo", pago.IdArqueo);
                cmd.Parameters.AddWithValue("@subtotal", pago.Subtotal);
                cmd.Parameters.AddWithValue("@descuento", pago.Descuento);
                cmd.Parameters.AddWithValue("@propina", pago.Propina);
                cmd.Parameters.AddWithValue("@metodo", pago.MetodoPago);

                return cmd.ExecuteNonQuery() >= 0;
            }
        }

        // Historial de pagos del día
        public DataTable MostrarPagosDelDia()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT p.id_pago, m.numero_mesa,
                                      u.nombre_usuario AS cajero,
                                      p.subtotal_pago, p.descuento_pago,
                                      p.propina_pago, p.metodo_pago,
                                      p.total_pago, p.fecha_pago
                               FROM tbl_pagos p
                               JOIN tbl_ordenes o ON o.id_orden = p.id_orden_pago
                               JOIN tbl_mesas m ON m.id_mesa = o.id_mesa_orden
                               JOIN tbl_usuarios u ON u.id_usuario = p.id_cajero_pago
                               WHERE DATE(p.fecha_pago) = CURDATE()
                               ORDER BY p.fecha_pago DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
