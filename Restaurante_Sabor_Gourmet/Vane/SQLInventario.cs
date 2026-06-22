using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using Restaurante_Sabor_Gourmet.Vane;
using System;
using System.Collections.Generic;

namespace Restaurante_Sabor_Gourmet.ConsultasSQL
{
    internal class SQLInventario
    {
        private readonly ConexionDB conexion = new ConexionDB();

        // ─────────────────────────────────────────
        // INGREDIENTES
        // ─────────────────────────────────────────

        public List<Ingrediente> ObtenerTodos()
        {
            List<Ingrediente> lista = new List<Ingrediente>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT id_ingrediente, nombre_ingrediente, unidad_medida,
                                      existencia, stock_minimo, costo_unitario
                               FROM tbl_ingredientes
                               ORDER BY nombre_ingrediente";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new Ingrediente
                        {
                            IdIngrediente     = rd.GetInt32("id_ingrediente"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            UnidadMedida      = rd.GetString("unidad_medida"),
                            Existencia        = rd.GetDecimal("existencia"),
                            StockMinimo       = rd.GetDecimal("stock_minimo"),
                            CostoUnitario     = rd.GetDecimal("costo_unitario")
                        });
                    }
                }
            }
            return lista;
        }

        public List<Ingrediente> ObtenerBajoStock()
        {
            List<Ingrediente> lista = new List<Ingrediente>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                // Usa la vista ya creada en la BD
                string sql = "SELECT id_ingrediente, nombre_ingrediente, unidad_medida, " +
                             "existencia, stock_minimo, costo_unitario " +
                             "FROM vista_ingredientes_bajo_stock";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new Ingrediente
                        {
                            IdIngrediente     = rd.GetInt32("id_ingrediente"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            UnidadMedida      = rd.GetString("unidad_medida"),
                            Existencia        = rd.GetDecimal("existencia"),
                            StockMinimo       = rd.GetDecimal("stock_minimo"),
                            CostoUnitario     = rd.GetDecimal("costo_unitario")
                        });
                    }
                }
            }
            return lista;
        }

        public bool InsertarIngrediente(Ingrediente i)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO tbl_ingredientes
                               (nombre_ingrediente, unidad_medida, existencia, stock_minimo, costo_unitario)
                               VALUES (@nombre, @unidad, @existencia, @stockMin, @costo)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", i.NombreIngrediente);
                    cmd.Parameters.AddWithValue("@unidad", i.UnidadMedida);
                    cmd.Parameters.AddWithValue("@existencia", i.Existencia);
                    cmd.Parameters.AddWithValue("@stockMin", i.StockMinimo);
                    cmd.Parameters.AddWithValue("@costo", i.CostoUnitario);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarIngrediente(Ingrediente i)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"UPDATE tbl_ingredientes SET
                               nombre_ingrediente = @nombre,
                               unidad_medida      = @unidad,
                               stock_minimo       = @stockMin,
                               costo_unitario     = @costo
                               WHERE id_ingrediente = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", i.NombreIngrediente);
                    cmd.Parameters.AddWithValue("@unidad", i.UnidadMedida);
                    cmd.Parameters.AddWithValue("@stockMin", i.StockMinimo);
                    cmd.Parameters.AddWithValue("@costo", i.CostoUnitario);
                    cmd.Parameters.AddWithValue("@id", i.IdIngrediente);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EstaEnReceta(int idIngrediente)
        {
            // Validación: no eliminar ingredientes usados en recetas
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "SELECT COUNT(*) FROM tbl_recetas WHERE id_ingrediente = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idIngrediente);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool EliminarIngrediente(int idIngrediente)
        {
            // Solo si no está en ninguna receta
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = "DELETE FROM tbl_ingredientes WHERE id_ingrediente = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idIngrediente);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ─────────────────────────────────────────
        // MOVIMIENTOS DE INVENTARIO
        // ─────────────────────────────────────────

        public List<MovimientoInventario> ObtenerMovimientos()
        {
            List<MovimientoInventario> lista = new List<MovimientoInventario>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT m.id_movimiento, m.id_ingrediente, i.nombre_ingrediente,
                                      m.id_usuario, m.tipo_movimiento, m.cantidad,
                                      m.fecha_movimiento, m.observacion
                               FROM tbl_movimientos_inventario m
                               INNER JOIN tbl_ingredientes i ON m.id_ingrediente = i.id_ingrediente
                               ORDER BY m.fecha_movimiento DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new MovimientoInventario
                        {
                            IdMovimiento      = rd.GetInt32("id_movimiento"),
                            IdIngrediente     = rd.GetInt32("id_ingrediente"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            IdUsuario         = rd.GetInt32("id_usuario"),
                            TipoMovimiento    = rd.GetString("tipo_movimiento"),
                            Cantidad          = rd.GetDecimal("cantidad"),
                            FechaMovimiento   = rd.GetDateTime("fecha_movimiento"),
                            Observacion       = rd.IsDBNull(rd.GetOrdinal("observacion"))
                                                ? "" : rd.GetString("observacion")
                        });
                    }
                }
            }
            return lista;
        }

        public bool RegistrarMovimiento(MovimientoInventario m)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            using (MySqlTransaction tr = cn.BeginTransaction())
            {
                try
                {
                    // 1. Insertar movimiento
                    string sqlInsert = @"INSERT INTO tbl_movimientos_inventario
                                        (id_ingrediente, id_usuario, tipo_movimiento,
                                         cantidad, fecha_movimiento, observacion)
                                        VALUES (@idIng, @idUsu, @tipo, @cantidad, NOW(), @obs)";

                    using (MySqlCommand cmd = new MySqlCommand(sqlInsert, cn, tr))
                    {
                        cmd.Parameters.AddWithValue("@idIng", m.IdIngrediente);
                        cmd.Parameters.AddWithValue("@idUsu", m.IdUsuario);
                        cmd.Parameters.AddWithValue("@tipo", m.TipoMovimiento);
                        cmd.Parameters.AddWithValue("@cantidad", m.Cantidad);
                        cmd.Parameters.AddWithValue("@obs", m.Observacion);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Actualizar existencia según tipo
                    string operacion = (m.TipoMovimiento == "Compra") ? "+" : "-";
                    string sqlExist = $"UPDATE tbl_ingredientes SET existencia = existencia {operacion} @cantidad " +
                                      "WHERE id_ingrediente = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sqlExist, cn, tr))
                    {
                        cmd.Parameters.AddWithValue("@cantidad", m.Cantidad);
                        cmd.Parameters.AddWithValue("@id", m.IdIngrediente);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Verificar que no quede negativo
                    string sqlCheck = "SELECT existencia FROM tbl_ingredientes WHERE id_ingrediente = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlCheck, cn, tr))
                    {
                        cmd.Parameters.AddWithValue("@id", m.IdIngrediente);
                        decimal existenciaResultante = Convert.ToDecimal(cmd.ExecuteScalar());
                        if (existenciaResultante < 0)
                        {
                            tr.Rollback();
                            return false; // No permitir existencias negativas
                        }
                    }

                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    return false;
                }

            }
        }
        public List<MovimientoInventario> ObtenerMovimientosConUsuario()
        {
            List<MovimientoInventario> lista = new List<MovimientoInventario>();

            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT m.id_movimiento, m.id_ingrediente, i.nombre_ingrediente,
                              m.id_usuario, u.nombre_usuario, m.tipo_movimiento,
                              m.cantidad, m.fecha_movimiento, m.observacion
                       FROM tbl_movimientos_inventario m
                       INNER JOIN tbl_ingredientes i ON m.id_ingrediente = i.id_ingrediente
                       INNER JOIN tbl_usuarios u     ON m.id_usuario     = u.id_usuario
                       ORDER BY m.fecha_movimiento DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new MovimientoInventario
                        {
                            IdMovimiento      = rd.GetInt32("id_movimiento"),
                            IdIngrediente     = rd.GetInt32("id_ingrediente"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            IdUsuario         = rd.GetInt32("id_usuario"),
                            NombreUsuario     = rd.GetString("nombre_usuario"),
                            TipoMovimiento    = rd.GetString("tipo_movimiento"),
                            Cantidad          = rd.GetDecimal("cantidad"),
                            FechaMovimiento   = rd.GetDateTime("fecha_movimiento"),
                            Observacion       = rd.IsDBNull(rd.GetOrdinal("observacion"))
                                                ? "" : rd.GetString("observacion")
                        });
                    }
                }
            }
            return lista;
        }
    }

}