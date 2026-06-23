using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class Mesero
    {
        public int IdUsuario { get; set; }            // id_usuario (PK)
        public string NombreUsuario { get; set; }     // nombre_usuario
        public string Username { get; set; }          // username
        public string ContrasenaUsuario { get; set; } // contraseña_usuario (solo se envía al crear/cambiar)
        public string Telefono { get; set; }          // telefono
        public DateTime FechaIngreso { get; set; }    // fecha_ingreso
        public bool Activo { get; set; }               // activo
        public int IdRolUsuario { get; set; }          // id_rol_usuario (FK -> tbl_roles, fijo al rol "Mesero")
    }
}
