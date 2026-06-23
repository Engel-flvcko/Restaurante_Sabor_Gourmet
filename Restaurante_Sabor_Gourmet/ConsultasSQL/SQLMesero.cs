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
    internal class SQLMesero
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ============================================================
        //  OBTENER TODOS LOS MESEROS
        // ============================================================
        public List<Mesero> ObtenerMeseros(int idRolMesero)
        {
            List<Mesero> lista = new List<Mesero>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT id_usuario,
                           nombre_usuario,
                           username,
                           telefono,
                           fecha_ingreso,
                           activo,
                           id_rol_usuario
                    FROM   tbl_usuarios
                    WHERE  id_rol_usuario = @idRol
                    ORDER  BY nombre_usuario ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idRol", idRolMesero);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Mesero
                            {
                                IdUsuario = rd.GetInt32("id_usuario"),
                                NombreUsuario = rd.GetString("nombre_usuario"),
                                Username = rd.GetString("username"),
                                Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                                FechaIngreso = rd.GetDateTime("fecha_ingreso"),
                                Activo = rd.GetBoolean("activo"),
                                IdRolUsuario = rd.GetInt32("id_rol_usuario")
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // ============================================================
        //  OBTENER UN MESERO POR ID
        // ============================================================
        public Mesero ObtenerPorId(int idUsuario)
        {
            Mesero mesero = null;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT id_usuario, nombre_usuario, username,
                           telefono, fecha_ingreso, activo, id_rol_usuario
                    FROM   tbl_usuarios
                    WHERE  id_usuario = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            mesero = new Mesero
                            {
                                IdUsuario = rd.GetInt32("id_usuario"),
                                NombreUsuario = rd.GetString("nombre_usuario"),
                                Username = rd.GetString("username"),
                                Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                                FechaIngreso = rd.GetDateTime("fecha_ingreso"),
                                Activo = rd.GetBoolean("activo"),
                                IdRolUsuario = rd.GetInt32("id_rol_usuario")
                            };
                        }
                    }
                }
            }

            return mesero;
        }

        // ============================================================
        //  VERIFICAR USERNAME DUPLICADO
        //  (validación a nivel de BD, complementa la de Validaciones.cs)
        // ============================================================
        public bool UsernameExiste(string username, int idExcluir = 0)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT COUNT(*) FROM tbl_usuarios
                    WHERE  username = @username
                    AND    id_usuario <> @idExcluir";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@username", username.Trim());
                    cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // ============================================================
        //  INSERTAR NUEVO MESERO
        // ============================================================
        public bool Insertar(Mesero m)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    INSERT INTO tbl_usuarios
                        (nombre_usuario, username, contraseña_usuario,
                         telefono, fecha_ingreso, activo, id_rol_usuario)
                    VALUES
                        (@nombre, @username, @contrasena,
                         @telefono, @fechaIngreso, @activo, @idRol)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", m.NombreUsuario.Trim());
                    cmd.Parameters.AddWithValue("@username", m.Username.Trim());
                    cmd.Parameters.AddWithValue("@contrasena", m.ContrasenaUsuario);
                    cmd.Parameters.AddWithValue("@telefono", m.Telefono.Trim());
                    cmd.Parameters.AddWithValue("@fechaIngreso", m.FechaIngreso.Date);
                    cmd.Parameters.AddWithValue("@activo", m.Activo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@idRol", m.IdRolUsuario);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================================
        //  ACTUALIZAR MESERO
        //  Si cambiarContrasena = false, el campo contraseña_usuario
        //  se deja intacto en la BD.
        // ============================================================
        public bool Actualizar(Mesero m, bool cambiarContrasena)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = cambiarContrasena
                    ? @"UPDATE tbl_usuarios
                           SET nombre_usuario    = @nombre,
                               username          = @username,
                               contraseña_usuario = @contrasena,
                               telefono          = @telefono,
                               fecha_ingreso     = @fechaIngreso,
                               activo            = @activo
                         WHERE id_usuario = @id"
                    : @"UPDATE tbl_usuarios
                           SET nombre_usuario = @nombre,
                               username       = @username,
                               telefono       = @telefono,
                               fecha_ingreso  = @fechaIngreso,
                               activo         = @activo
                         WHERE id_usuario = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", m.NombreUsuario.Trim());
                    cmd.Parameters.AddWithValue("@username", m.Username.Trim());
                    if (cambiarContrasena)
                        cmd.Parameters.AddWithValue("@contrasena", m.ContrasenaUsuario);
                    cmd.Parameters.AddWithValue("@telefono", m.Telefono.Trim());
                    cmd.Parameters.AddWithValue("@fechaIngreso", m.FechaIngreso.Date);
                    cmd.Parameters.AddWithValue("@activo", m.Activo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", m.IdUsuario);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================================
        //  DESACTIVAR MESERO (soft-delete: activo = 0)
        //  No se borra físicamente para preservar historial de órdenes.
        // ============================================================
        public bool Desactivar(int idUsuario)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    UPDATE tbl_usuarios
                       SET activo = 0
                     WHERE id_usuario = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================================
        //  MÉTRICAS DE DESEMPEÑO
        //  Usa las vistas ya creadas en la BD (vista_ventas_mesero
        //  y vista_propinas_mesero) para el mesero seleccionado,
        //  filtrando por el mes actual.
        // ============================================================
        public (int totalOrdenes, decimal totalVentas, decimal totalPropinas)
            ObtenerMetricasPorMesero(int idMesero)
        {
            int ordenes = 0;
            decimal ventas = 0;
            decimal propinas = 0;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                // Ventas y órdenes desde vista_ventas_mesero
                string sqlVentas = @"
                    SELECT total_ordenes, total_ventas
                    FROM   vista_ventas_mesero
                    WHERE  id_mesero = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlVentas, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idMesero);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            ordenes = rd.GetInt32("total_ordenes");
                            ventas = rd.GetDecimal("total_ventas");
                        }
                    }
                }

                // Propinas desde vista_propinas_mesero
                string sqlPropinas = @"
                    SELECT total_propinas
                    FROM   vista_propinas_mesero
                    WHERE  id_mesero = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlPropinas, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idMesero);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                            propinas = rd.GetDecimal("total_propinas");
                    }
                }
            }

            return (ordenes, ventas, propinas);
        }

        // ============================================================
        //  MÉTRICAS GENERALES (todos los meseros del mes actual)
        //  Útil para mostrar en las KPI cards cuando no hay mesero
        //  seleccionado (vista global).
        // ============================================================
        public (int totalOrdenes, decimal totalVentas, decimal totalPropinas)
            ObtenerMetricasGenerales()
        {
            int ordenes = 0;
            decimal ventas = 0;
            decimal propinas = 0;

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT COALESCE(SUM(v.total_ordenes), 0) AS tot_ordenes,
                           COALESCE(SUM(v.total_ventas),  0) AS tot_ventas,
                           COALESCE(SUM(p.total_propinas),0) AS tot_propinas
                    FROM   vista_ventas_mesero  v
                    LEFT   JOIN vista_propinas_mesero p USING (id_mesero)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            ordenes = rd.GetInt32("tot_ordenes");
                            ventas = rd.GetDecimal("tot_ventas");
                            propinas = rd.GetDecimal("tot_propinas");
                        }
                    }
                }
            }

            return (ordenes, ventas, propinas);
        }
    }
}