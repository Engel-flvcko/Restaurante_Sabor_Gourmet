using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using System.Collections.Generic;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLMenu
    {
        private readonly ConexionDB conexion = new ConexionDB();

        // ─────────────────────────────────────────
        // CATEGORÍAS
        // ─────────────────────────────────────────

        public List<string> ObtenerCategorias()
        {
            List<string> lista = new List<string>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT id_categoria, nombre_categoria FROM tbl_categorias ORDER BY nombre_categoria";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        lista.Add(rd.GetString("nombre_categoria"));
                }
            }
            return lista;
        }

        public bool InsertarCategoria(string nombreCategoria)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "INSERT INTO tbl_categorias (nombre_categoria) VALUES (@nombre)";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarCategoria(int idCategoria, string nuevoNombre)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE tbl_categorias SET nombre_categoria = @nombre WHERE id_categoria = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", idCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarCategoria(int idCategoria)
        {
            // Solo eliminar si no tiene productos asociados
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "DELETE FROM tbl_categorias WHERE id_categoria = @id " +
                             "AND NOT EXISTS (SELECT 1 FROM tbl_productos WHERE id_categoria = @id)";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ─────────────────────────────────────────
        // PRODUCTOS
        // ─────────────────────────────────────────

        public List<ProductoCatalogo> ObtenerTodosLosProductos()
        {
            List<ProductoCatalogo> lista = new List<ProductoCatalogo>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT p.id_producto, p.codigo_producto, p.nombre_producto,
                                      p.descripcion, p.tiempo_preparacion_min, p.precio_venta,
                                      p.disponible, p.id_categoria, c.nombre_categoria
                               FROM tbl_productos p
                               INNER JOIN tbl_categorias c ON p.id_categoria = c.id_categoria
                               ORDER BY c.nombre_categoria, p.nombre_producto";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new ProductoCatalogo
                        {
                            IdProducto          = rd.GetInt32("id_producto"),
                            CodigoProducto      = rd.GetString("codigo_producto"),
                            NombreProducto      = rd.GetString("nombre_producto"),
                            Descripcion         = rd.GetString("descripcion"),
                            TiempoPreparacionMin= rd.GetInt32("tiempo_preparacion_min"),
                            PrecioVenta         = rd.GetDecimal("precio_venta"),
                            Disponible          = rd.GetBoolean("disponible"),
                            IdCategoria         = rd.GetInt32("id_categoria"),
                            NombreCategoria     = rd.GetString("nombre_categoria")
                        });
                    }
                }
            }
            return lista;
        }

        public bool InsertarProducto(ProductoCatalogo p)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO tbl_productos
                               (codigo_producto, nombre_producto, descripcion,
                                tiempo_preparacion_min, precio_venta, disponible, id_categoria)
                               VALUES (@codigo, @nombre, @desc, @tiempo, @precio, @disponible, @idCat)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", p.CodigoProducto);
                    cmd.Parameters.AddWithValue("@nombre", p.NombreProducto);
                    cmd.Parameters.AddWithValue("@desc", p.Descripcion);
                    cmd.Parameters.AddWithValue("@tiempo", p.TiempoPreparacionMin);
                    cmd.Parameters.AddWithValue("@precio", p.PrecioVenta);
                    cmd.Parameters.AddWithValue("@disponible", p.Disponible);
                    cmd.Parameters.AddWithValue("@idCat", p.IdCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarProducto(ProductoCatalogo p)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"UPDATE tbl_productos SET
                               codigo_producto       = @codigo,
                               nombre_producto       = @nombre,
                               descripcion           = @desc,
                               tiempo_preparacion_min= @tiempo,
                               precio_venta          = @precio,
                               disponible            = @disponible,
                               id_categoria          = @idCat
                               WHERE id_producto = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", p.CodigoProducto);
                    cmd.Parameters.AddWithValue("@nombre", p.NombreProducto);
                    cmd.Parameters.AddWithValue("@desc", p.Descripcion);
                    cmd.Parameters.AddWithValue("@tiempo", p.TiempoPreparacionMin);
                    cmd.Parameters.AddWithValue("@precio", p.PrecioVenta);
                    cmd.Parameters.AddWithValue("@disponible", p.Disponible);
                    cmd.Parameters.AddWithValue("@idCat", p.IdCategoria);
                    cmd.Parameters.AddWithValue("@id", p.IdProducto);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CambiarDisponibilidad(int idProducto, bool disponible)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE tbl_productos SET disponible = @disp WHERE id_producto = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@disp", disponible);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CodigoExiste(string codigo, int idExcluir = 0)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT COUNT(*) FROM tbl_productos " +
                             "WHERE codigo_producto = @codigo AND id_producto <> @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id", idExcluir);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public List<(int Id, string Nombre, int TotalProductos)> ObtenerCategoriasConConteo()
        {
            var lista = new List<(int, string, int)>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT c.id_categoria, c.nombre_categoria,
                              COUNT(p.id_producto) AS total_productos
                       FROM tbl_categorias c
                       LEFT JOIN tbl_productos p ON c.id_categoria = p.id_categoria
                       GROUP BY c.id_categoria, c.nombre_categoria
                       ORDER BY c.nombre_categoria";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        lista.Add((
                            rd.GetInt32("id_categoria"),
                            rd.GetString("nombre_categoria"),
                            rd.GetInt32("total_productos")
                        ));
                }
            }
            return lista;
        }

        public bool ActualizarNombreCategoria(int idCategoria, string nuevoNombre)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE tbl_categorias SET nombre_categoria = @nombre " +
                             "WHERE id_categoria = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", idCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool TieneProductos(int idCategoria)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT COUNT(*) FROM tbl_productos WHERE id_categoria = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idCategoria);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}