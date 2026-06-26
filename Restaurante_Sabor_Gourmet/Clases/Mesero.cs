using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class Mesero
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Username { get; set; }
        public string ContrasenaUsuario { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
        public int IdRolUsuario { get; set; }
    }
}
