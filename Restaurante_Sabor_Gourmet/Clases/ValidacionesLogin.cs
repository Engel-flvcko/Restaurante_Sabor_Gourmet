using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Validaciones
{
    internal class ValidacionesLogin
    {       
        public static bool CamposVacios(string usuario, string contrasena)
        {
            return string.IsNullOrWhiteSpace(usuario) ||
                   string.IsNullOrWhiteSpace(contrasena);
        }
    }
}
