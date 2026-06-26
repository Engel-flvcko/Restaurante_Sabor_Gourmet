using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using Restaurante_Sabor_Gourmet.Vane;
using System;
using System.Collections.Generic;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLRecetas
    {
        private readonly ConexionBD conexion = new ConexionBD();

       
        // Recetas

        public List<Receta> ObtenerPorProducto(int idProducto)
        {
            List<Receta> lista = new List<Receta>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT r.id_receta, r.id_producto, p.nombre_producto,
                                      r.id_ingrediente, i.nombre_ingrediente,
                                      i.unidad_medida, r.cantidad_receta
                               FROM tbl_recetas r
                               INNER JOIN tbl_productos p ON r.id_producto = p.id_producto
                               INNER JOIN tbl_ingredientes i ON r.id_ingrediente = i.id_ingrediente
                               WHERE r.id_producto = @idProd
                               ORDER BY i.nombre_ingrediente";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idProd", idProducto);
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Receta
                            {
                                IdReceta = rd.GetInt32("id_receta"),
                                IdProducto = rd.GetInt32("id_producto"),
                                NombreProducto = rd.GetString("nombre_producto"),
                                IdIngrediente = rd.GetInt32("id_ingrediente"),
                                NombreIngrediente = rd.GetString("nombre_ingrediente"),
                                UnidadMedida = rd.GetString("unidad_medida"),
                                CantidadReceta = rd.GetDecimal("cantidad_receta")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public bool IngredienteYaEnReceta(int idProducto, int idIngrediente)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT COUNT(*) FROM tbl_recetas " +
                             "WHERE id_producto = @idProd AND id_ingrediente = @idIng";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idProd", idProducto);
                    cmd.Parameters.AddWithValue("@idIng", idIngrediente);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool AgregarIngrediente(Receta r)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"INSERT INTO tbl_recetas (id_producto, id_ingrediente, cantidad_receta)
                               VALUES (@idProd, @idIng, @cantidad)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idProd", r.IdProducto);
                    cmd.Parameters.AddWithValue("@idIng", r.IdIngrediente);
                    cmd.Parameters.AddWithValue("@cantidad", r.CantidadReceta);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarCantidad(int idReceta, decimal nuevaCantidad)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "UPDATE tbl_recetas SET cantidad_receta = @cantidad WHERE id_receta = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@cantidad", nuevaCantidad);
                    cmd.Parameters.AddWithValue("@id", idReceta);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarIngrediente(int idReceta)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "DELETE FROM tbl_recetas WHERE id_receta = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idReceta);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // AUXILIARES — Solo para poblar ComboBox en frmRecetas
        // Los productos completos los maneja SQLProductoCatalogo (Persona 2)

        public Dictionary<int, string> ObtenerProductosParaCombo()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT id_producto, nombre_producto FROM tbl_productos " +
                             "WHERE disponible_producto = 1 ORDER BY nombre_producto";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        dict.Add(rd.GetInt32("id_producto"), rd.GetString("nombre_producto"));
                }
            }
            return dict;
        }

        public Dictionary<int, string> ObtenerIngredientesParaCombo()
        {
            // Solo id + nombre para llenar el ComboBox selector de ingrediente
            Dictionary<int, string> dict = new Dictionary<int, string>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT id_ingrediente, nombre_ingrediente FROM tbl_ingredientes " +
                             "ORDER BY nombre_ingrediente";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        dict.Add(rd.GetInt32("id_ingrediente"), rd.GetString("nombre_ingrediente"));
                }
            }
            return dict;
        }
    }
}