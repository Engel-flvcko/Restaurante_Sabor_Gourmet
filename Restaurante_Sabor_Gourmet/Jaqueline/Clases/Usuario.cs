using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }   // Antes de guardarse se convierte a SHA256.
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }   // Solo para mostrar en grid (JOIN con tbl_roles)
    }
}
