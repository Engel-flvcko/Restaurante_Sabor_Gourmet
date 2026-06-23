using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL
{
    internal class SQLUsuarios
    {

        // Método para validar login en la base de datos
        // Retorna true si el usuario existe

        public bool IniciarSesion(string usuario, string contrasena)
        {
            // Crear conexión a la base de datos
            ConexionDB conexionBD = new ConexionDB();

            using (MySqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                // Consulta para validar usuario
                string consulta = @"SELECT u.*, r.nombre_rol
                    FROM tbl_usuarios u
                    INNER JOIN tbl_roles r
                        ON u.id_rol_usuario = r.id_rol
                    WHERE username_usuario = @usuario
                    AND contraseña_usuario = @contrasena
                    AND activo_usuario = TRUE";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Enviar parámetros
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contrasena", contrasena);

                MySqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    // Guardar información del usuario en la sesión

                    Sesion.IdUsuario = Convert.ToInt32(lector["id_usuario"]);

                    Sesion.NombreUsuario = lector["nombre_usuario"].ToString();

                    Sesion.Username =  lector["username_usuario"].ToString();

                    Sesion.IdRol = Convert.ToInt32(lector["id_rol_usuario"]);
                    
                    Sesion.NombreRol = lector["nombre_rol"].ToString();

                    return true;
                }
                return false;
               
            }
        }

        //AGREGADO POR ENGEL 
        ConexionDB conexion = new ConexionDB();

        // ══════════════════════════════════════════════════════════════════
        // OBTENER TODOS (con filtro opcional para búsqueda)
        // ══════════════════════════════════════════════════════════════════
        public DataTable MostrarTodo(string filtro = "")
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT
                        u.id_usuario,
                        u.nombre_usuario   AS Nombre,
                        u.username         AS Usuario,
                        u.telefono         AS Teléfono,
                        r.nombre_rol       AS Rol,
                        CASE u.activo
                            WHEN 1 THEN 'Activo'
                            ELSE 'Inactivo'
                        END                AS Estado
                    FROM tbl_usuarios u
                    INNER JOIN tbl_roles r ON u.id_rol_usuario = r.id_rol
                    WHERE u.nombre_usuario LIKE @filtro
                       OR u.username       LIKE @filtro
                    ORDER BY u.nombre_usuario";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                da.Fill(dt);
            }
            return dt;
        }

        // ══════════════════════════════════════════════════════════════════
        // OBTENER UN USUARIO POR ID
        // ══════════════════════════════════════════════════════════════════
        public Usuario ObtenerPorId(int idUsuario)
        {
            Usuario u = null;
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    SELECT id_usuario, nombre_usuario, username,
                           telefono, activo, id_rol_usuario
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
                            Username = dr.GetString("username"),
                            Telefono = dr["telefono"].ToString(),
                            Activo = dr.GetBoolean("activo"),
                            IdRol = dr.GetInt32("id_rol_usuario")
                        };
                    }
                }
            }
            return u;
        }

        // ══════════════════════════════════════════════════════════════════
        // VERIFICAR SI EL USERNAME YA EXISTE
        // ══════════════════════════════════════════════════════════════════
        public bool UsernameExiste(string username, int excluirId = 0)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT COUNT(*) FROM tbl_usuarios
                               WHERE username = @u AND id_usuario <> @id";
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@id", excluirId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // GUARDAR (INSERT nuevo usuario)
        // ══════════════════════════════════════════════════════════════════
        public bool Guardar(Usuario obj)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    INSERT INTO tbl_usuarios
                        (nombre_usuario, username, contraseña_usuario,
                         telefono, fecha_ingreso, activo, id_rol_usuario)
                    VALUES
                        (@nombre, @username, @clave,
                         @tel, NOW(), 1, @rol)";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@clave", obj.Contrasena);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@rol", obj.IdRol);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // ACTUALIZAR (sin cambiar contraseña)
        // ══════════════════════════════════════════════════════════════════
        public bool Actualizar(Usuario obj)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    UPDATE tbl_usuarios SET
                        nombre_usuario = @nombre,
                        username       = @username,
                        telefono       = @tel,
                        id_rol_usuario = @rol
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

        // ══════════════════════════════════════════════════════════════════
        // ACTUALIZAR CON NUEVA CONTRASEÑA
        // ══════════════════════════════════════════════════════════════════
        public bool ActualizarConClave(Usuario obj)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"
                    UPDATE tbl_usuarios SET
                        nombre_usuario     = @nombre,
                        username           = @username,
                        contraseña_usuario = @clave,
                        telefono           = @tel,
                        id_rol_usuario     = @rol
                    WHERE id_usuario = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@clave", obj.Contrasena);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@rol", obj.IdRol);
                cmd.Parameters.AddWithValue("@id", obj.IdUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // DESACTIVAR (baja lógica — nunca DELETE físico)
        // ══════════════════════════════════════════════════════════════════
        public bool Desactivar(int idUsuario)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "UPDATE tbl_usuarios SET activo = 0 WHERE id_usuario = @id";
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // CARGAR ROLES PARA COMBOBOX
        // ══════════════════════════════════════════════════════════════════
        public DataTable ObtenerRoles()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT id_rol, nombre_rol FROM tbl_roles ORDER BY nombre_rol";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            return dt;
        }

        // HASTA AQUI AGREGADO POR ENGEL
    }
}