using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using System.Data;

namespace Restaurante_Sabor_Gourmet.Vane
{
    internal class ProductoDAO
    {
        ConexionDB conexion = new ConexionDB();

        public DataTable ObtenerTodosLosProductos()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT *
                               FROM tbl_productos";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}