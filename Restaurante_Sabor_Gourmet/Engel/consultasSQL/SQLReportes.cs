using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.consultasSQL
{
    internal class SQLReportes
    {
        ConexionBD conexion = new ConexionBD();

        // Ventas del día
        public DataTable MostrarVentasDelDia()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT COALESCE(SUM(total_pago), 0) AS ventas_hoy
                               FROM tbl_pagos
                               WHERE DATE(fecha_pago) = CURDATE()";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }
        public DataTable MostrarBajoStock()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                // Vista correcta: vista_stock_bajo
                // Columnas correctas: existencia_actual, stock_minimo, unidad_medida
                string sql = @"SELECT nombre_ingrediente, existencia_actual,
                              stock_minimo, unidad_medida,
                              CASE WHEN existencia_actual = 0 THEN 'Agotado'
                                   ELSE 'Stock mínimo' END AS estado
                       FROM vista_stock_bajo
                       ORDER BY existencia_actual ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable MostrarStockAgotado()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                // Vista correcta: vista_stock_bajo con existencia_actual = 0
                string sql = "SELECT nombre_ingrediente FROM vista_stock_bajo WHERE existencia_actual = 0";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable MostrarCostosProduccion()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                // Columna correcta: ganancia_estimada (no ganancia)
                string sql = "SELECT * FROM vista_costos_produccion ORDER BY ganancia_estimada DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }

        // Ventas por rango de fechas
        public DataTable MostrarVentasPorRango(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT COALESCE(SUM(total_pago), 0) AS total_rango
                               FROM tbl_pagos
                               WHERE fecha_pago BETWEEN @desde AND @hasta";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@desde", desde.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@hasta", hasta.ToString("yyyy-MM-dd 23:59:59"));

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        // Ventas por mesero (usa la vista)
        public DataTable MostrarVentasPorMesero()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT * FROM vista_ventas_mesero ORDER BY total_ventas DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Productos más vendidos (usa la vista)
        public DataTable MostrarProductosMasVendidos()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT * FROM vista_productos_mas_vendidos LIMIT 10";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Ventas por categoría (usa la vista)
        public DataTable MostrarVentasPorCategoria()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT * FROM vista_ventas_categoria ORDER BY total_ingresos DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Propinas por mesero (usa la vista)
        public DataTable MostrarPropinas()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT * FROM vista_propinas_mesero ORDER BY total_propinas DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        
        public DataTable MostrarIndicadoresDia()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT
                    COALESCE((SELECT SUM(total_pago) FROM tbl_pagos
                              WHERE DATE(fecha_pago) = CURDATE()), 0)                    AS ventas_hoy,
                    COALESCE((SELECT COUNT(*) FROM tbl_mesas
                              WHERE estado_mesa = 'Ocupada'), 0)                         AS mesas_ocupadas,
                    COALESCE((SELECT COUNT(*) FROM tbl_cola_cocina
                              WHERE estado_cocina IN ('pendiente','en_preparacion')), 0) AS ordenes_en_cocina,
                    COALESCE((SELECT SUM(propina_pago) FROM tbl_pagos
                              WHERE DATE(fecha_pago) = CURDATE()), 0)                    AS propinas_hoy";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }
       

        public DataTable MostrarOrdenesRetrasadas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT cc.id_orden_cocina, m.numero_mesa,
               TIMESTAMPDIFF(MINUTE, cc.hora_recepcion_cocina, NOW()) AS minutos
               FROM tbl_cola_cocina cc
               JOIN tbl_ordenes o ON o.id_orden = cc.id_orden_cocina
               JOIN tbl_mesas m ON m.id_mesa = o.id_mesa_orden
               WHERE cc.estado_cocina IN ('pendiente','en_preparacion')
                 AND TIMESTAMPDIFF(MINUTE, cc.hora_recepcion_cocina, NOW()) > 30";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable MostrarDatosCocina()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT cc.id_orden_cocina, m.numero_mesa,
               cc.estado_cocina AS estado,
               cc.hora_recepcion_cocina,
               cc.hora_inicio_cocina,
               cc.hora_finalizacion_cocina AS hora_fin,
               TIMESTAMPDIFF(MINUTE, cc.hora_recepcion_cocina, IFNULL(cc.hora_finalizacion_cocina, NOW())) AS tiempo_total
               FROM tbl_cola_cocina cc
               JOIN tbl_ordenes o ON o.id_orden = cc.id_orden_cocina
               JOIN tbl_mesas m ON m.id_mesa = o.id_mesa_orden
               WHERE DATE(cc.hora_recepcion_cocina) = CURDATE()
               ORDER BY cc.hora_recepcion_cocina DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }
        

        
        public DataTable MostrarArqueosConDiferencias()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT a.id_arqueo, u.nombre_usuario AS nombre_cajero,
                              a.diferencia_arqueo, a.estado_arqueo
                       FROM tbl_arqueos_caja a
                       JOIN tbl_usuarios u ON u.id_usuario = a.id_cajero_arqueo
                       WHERE DATE(a.fecha_apertura_arqueo) = CURDATE()
                         AND a.diferencia_arqueo != 0
                         AND a.estado_arqueo = 'cerrada'
                       ORDER BY a.fecha_apertura_arqueo DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}