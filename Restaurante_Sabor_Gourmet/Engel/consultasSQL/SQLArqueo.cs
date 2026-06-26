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
    internal class SQLArqueo
    {
        ConexionBD conexion = new ConexionBD();

        // Abrir caja — retorna el id_arqueo generado
        public int AbrirCaja(int idCajero, decimal fondoInicial)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO tbl_arqueos_caja
                           (id_cajero_arqueo, fecha_apertura_arqueo, fondo_inicial_arqueo,
                            total_esperado_arqueo, total_contado_arqueo, diferencia_arqueo, estado_arqueo)
                       VALUES (@cajero, NOW(), @fondo, @fondo, 0.00, 0.00, 'abierta');
                       SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cajero", idCajero);
                cmd.Parameters.AddWithValue("@fondo", fondoInicial);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Obtener arqueo activo del cajero
        public DataTable ObtenerArqueoActivo(int idCajero)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT a.*, u.nombre_usuario AS nombre_cajero
                               FROM tbl_arqueos_caja a
                               JOIN tbl_usuarios u ON u.id_usuario = a.id_cajero_arqueo
                               WHERE a.id_cajero_arqueo = @cajero
                                 AND a.estado_arqueo = 'abierta'
                               LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cajero", idCajero);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        // Cerrar caja
        public bool CerrarCaja(int idArqueo, decimal totalContado)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE tbl_arqueos_caja
                               SET fecha_cierre_arqueo  = NOW(),
                                   total_contado_arqueo = @contado,
                                   diferencia_arqueo    = total_esperado_arqueo - @contado,
                                   estado_arqueo        = 'cerrada'
                               WHERE id_arqueo    = @idArqueo
                                 AND estado_arqueo = 'abierta'";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@contado", totalContado);
                cmd.Parameters.AddWithValue("@idArqueo", idArqueo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Historial de arqueos del cajero
        public DataTable MostrarHistorialArqueos(int idCajero)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT a.id_arqueo, u.nombre_usuario AS cajero,
                                      a.fecha_apertura_arqueo, a.fondo_inicial_arqueo,
                                      a.total_esperado_arqueo, a.total_contado_arqueo,
                                      a.diferencia_arqueo, a.estado_arqueo
                               FROM tbl_arqueos_caja a
                               JOIN tbl_usuarios u ON u.id_usuario = a.id_cajero_arqueo
                               WHERE a.id_cajero_arqueo = @cajero
                               ORDER BY a.fecha_apertura_arqueo DESC";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cajero", idCajero);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        // Arqueos con diferencias (para supervisión)
        public DataTable MostrarArqueosConDiferencias()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT a.id_arqueo, u.nombre_usuario AS cajero,
                                      a.fecha_apertura_arqueo, a.total_esperado_arqueo,
                                      a.total_contado_arqueo, a.diferencia_arqueo
                               FROM tbl_arqueos_caja a
                               JOIN tbl_usuarios u ON u.id_usuario = a.id_cajero_arqueo
                               WHERE a.diferencia_arqueo != 0
                                 AND a.estado_arqueo = 'cerrada'
                               ORDER BY a.fecha_apertura_arqueo DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }

        // Todos los arqueos de todos los cajeros — para el Dashboard gerencial
        public DataTable MostrarTodosLosArqueos()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT a.id_arqueo,
                              u.nombre_usuario AS nombre_cajero,
                              a.fecha_apertura_arqueo AS apertura,
                              a.fecha_cierre_arqueo   AS hora_cierre,
                              a.total_esperado_arqueo AS monto_esperado,
                              a.total_contado_arqueo  AS monto_contado,
                              a.diferencia_arqueo     AS diferencia,
                              a.estado_arqueo         AS estado
                       FROM tbl_arqueos_caja a
                       JOIN tbl_usuarios u ON u.id_usuario = a.id_cajero_arqueo
                       ORDER BY a.fecha_apertura_arqueo DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}