using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class ConexionBD
    {
        private string cadenaConexion = "Server=127.0.0.1;Database=db_sabor_gourmet_fmo;Uid=root;Pwd=;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
