using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;

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
                // Si encuentra un registro, el login es correcto
                // return lector.Read();
            }
        }

    }

}
