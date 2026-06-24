using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLProductoCatalogo
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ============================================================
        //  OBTENER CATEGORÍAS (para los botones de filtro del catálogo)
        // ============================================================
        public List<(int Id, string Nombre)> ObtenerCategorias()
        {
            var lista = new List<(int, string)>();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT id_categoria, nombre_categoria FROM tbl_categorias ORDER BY nombre_categoria ASC";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        lista.Add((rd.GetInt32("id_categoria"), rd.GetString("nombre_categoria")));
                }
            }
            return lista;
        }

        public List<ProductoCatalogo> ObtenerPorCategoria(int idCategoria)
        {
            List<ProductoCatalogo> lista = new List<ProductoCatalogo>();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT p.id_producto, p.codigo_producto, p.nombre_producto,
                              p.precio_venta_producto, p.disponible_producto,
                              p.id_categoria_producto, c.nombre_categoria
                       FROM tbl_productos p
                       INNER JOIN tbl_categorias c ON p.id_categoria_producto = c.id_categoria
                       WHERE p.id_categoria_producto = @idCat
                       AND   p.disponible_producto   = 1
                       ORDER BY p.nombre_producto ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCat", idCategoria);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ProductoCatalogo
                            {
                                IdProducto = rd.GetInt32("id_producto"),
                                CodigoProducto = rd.GetString("codigo_producto"),
                                NombreProducto = rd.GetString("nombre_producto"),
                                PrecioVenta = rd.GetDecimal("precio_venta_producto"),
                                Disponible = rd.GetBoolean("disponible_producto"),
                                IdCategoria = rd.GetInt32("id_categoria_producto"),
                                NombreCategoria = rd.GetString("nombre_categoria")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public ProductoCatalogo ObtenerPorId(int idProducto)
        {
            ProductoCatalogo producto = null;
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT p.id_producto, p.codigo_producto, p.nombre_producto,
                              p.precio_venta_producto, p.disponible_producto,
                              p.id_categoria_producto, c.nombre_categoria
                       FROM tbl_productos p
                       INNER JOIN tbl_categorias c ON p.id_categoria_producto = c.id_categoria
                       WHERE p.id_producto = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            producto = new ProductoCatalogo
                            {
                                IdProducto = rd.GetInt32("id_producto"),
                                CodigoProducto = rd.GetString("codigo_producto"),
                                NombreProducto = rd.GetString("nombre_producto"),
                                PrecioVenta = rd.GetDecimal("precio_venta_producto"),
                                Disponible = rd.GetBoolean("disponible_producto"),
                                IdCategoria = rd.GetInt32("id_categoria_producto"),
                                NombreCategoria = rd.GetString("nombre_categoria")
                            };
                        }
                    }
                }
            }
            return producto;
        }
    }
}