using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
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
        ConexionDB conexion = new ConexionDB();

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

        // Costos de producción (usa la vista)
        public DataTable MostrarCostosProduccion()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT * FROM vista_costos_produccion ORDER BY ganancia_estimada DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Indicadores del dashboard (4 KPIs en una sola consulta)
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
    }
}
