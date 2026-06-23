using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL
{
    internal class SQLUsuarios
    {
        ConexionBD conexion = new ConexionBD();

        public bool IniciarSesion(string username, string contrasenaPlana)
        {
            string hash = HashSHA256(contrasenaPlana);

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    SELECT u.id_usuario, u.nombre_usuario, u.username_usuario,
                           u.id_rol_usuario, r.nombre_rol
                    FROM tbl_usuarios u
                    INNER JOIN tbl_roles r ON u.id_rol_usuario = r.id_rol
                    WHERE u.username_usuario  = @username
                      AND u.contraseña_usuario = @clave
                      AND u.activo_usuario      = 1";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@clave", hash);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Sesion.IdUsuario = dr.GetInt32("id_usuario");
                        Sesion.NombreUsuario = dr.GetString("nombre_usuario");
                        Sesion.Username = dr.GetString("username_usuario");
                        Sesion.IdRol = dr.GetInt32("id_rol_usuario");
                        Sesion.NombreRol = dr.GetString("nombre_rol");
                        return true;
                    }
                    return false;
                }
            }
        }

        //desde aqui engel
        public DataTable MostrarTodo(string filtro = "")
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    SELECT
                        u.id_usuario,
                        u.nombre_usuario      AS Nombre,
                        u.username_usuario    AS Usuario,
                        u.telefono_usuario    AS Teléfono,
                        r.nombre_rol          AS Rol,
                        CASE u.activo_usuario
                            WHEN 1 THEN 'Activo'
                            ELSE 'Inactivo'
                        END                   AS Estado
                    FROM tbl_usuarios u
                    INNER JOIN tbl_roles r ON u.id_rol_usuario = r.id_rol
                    WHERE u.nombre_usuario   LIKE @filtro
                       OR u.username_usuario LIKE @filtro
                    ORDER BY u.nombre_usuario";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                da.Fill(dt);
            }
            return dt;
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            Usuario u = null;
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    SELECT id_usuario, nombre_usuario, username_usuario,
                           telefono_usuario, activo_usuario, id_rol_usuario
                    FROM tbl_usuarios
                    WHERE id_usuario = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", idUsuario);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        u = new Usuario
                        {
                            IdUsuario = dr.GetInt32("id_usuario"),
                            Nombre = dr.GetString("nombre_usuario"),
                            Username = dr.GetString("username_usuario"),
                            Telefono = dr["telefono_usuario"].ToString(),
                            Activo = dr.GetBoolean("activo_usuario"),
                            IdRol = dr.GetInt32("id_rol_usuario")
                        };
                    }
                }
            }
            return u;
        }

        public bool UsernameExiste(string username, int excluirId = 0)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT COUNT(*) FROM tbl_usuarios
                               WHERE username_usuario = @u AND id_usuario <> @id";
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@id", excluirId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool Guardar(Usuario obj)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    INSERT INTO tbl_usuarios
                        (nombre_usuario, username_usuario, contrasena_usuario,
                         telefono_usuario, fecha_ingreso_usuario, activo_usuario, id_rol_usuario)
                    VALUES
                        (@nombre, @username, @clave,
                         @tel, NOW(), 1, @rol)";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@clave", HashSHA256(obj.Contrasena));
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@rol", obj.IdRol);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Usuario obj)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    UPDATE tbl_usuarios SET
                        nombre_usuario   = @nombre,
                        username_usuario = @username,
                        telefono_usuario = @tel,
                        id_rol_usuario   = @rol
                    WHERE id_usuario = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@rol", obj.IdRol);
                cmd.Parameters.AddWithValue("@id", obj.IdUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarConClave(Usuario obj)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"
                    UPDATE tbl_usuarios SET
                        nombre_usuario    = @nombre,
                        username_usuario  = @username,
                        contrasena_usuario = @clave,
                        telefono_usuario  = @tel,
                        id_rol_usuario    = @rol
                    WHERE id_usuario = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@clave", HashSHA256(obj.Contrasena));
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@rol", obj.IdRol);
                cmd.Parameters.AddWithValue("@id", obj.IdUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Desactivar(int idUsuario)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE tbl_usuarios SET activo_usuario = 0 WHERE id_usuario = @id";
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ObtenerRoles()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT id_rol, nombre_rol FROM tbl_roles ORDER BY nombre_rol";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }

        private string HashSHA256(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        //hasta aqui
    }
}