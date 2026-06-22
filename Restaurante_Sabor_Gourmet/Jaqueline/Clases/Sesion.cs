using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class Sesion
    {
        // Id del usuario que inicio sesión
        public static int IdUsuario { get; set; }

        // Nombre del usuario
        public static string NombreUsuario { get; set; }

        // Username
        public static string Username { get; set; }

        // Id de rol del usuario
        public static int IdRol { get; set; }

        // Nombre del rol que tiene el usuario
        public static string NombreRol { get; set; }

    }
}
