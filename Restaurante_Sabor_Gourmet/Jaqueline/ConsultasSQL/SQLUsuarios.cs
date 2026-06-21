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
                string consulta = @"SELECT *
                                    FROM tbl_usuarios
                                    WHERE username_usuario = @usuario
                                    AND contraseña_usuario = @contrasena
                                    AND activo_usuario = TRUE";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Enviar parámetros (evita SQL Injection)
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contrasena", contrasena);

                MySqlDataReader lector = comando.ExecuteReader();

                // Si encuentra un registro, el login es correcto
                return lector.Read();
            }
        }

    }

}
