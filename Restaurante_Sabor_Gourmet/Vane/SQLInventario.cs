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
        private readonly ConexionBD conexion = new ConexionBD();

        // INGREDIENTES
      

        public bool EstaEnReceta(int idIngrediente)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
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
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "DELETE FROM tbl_ingredientes WHERE id_ingrediente = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idIngrediente);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<MovimientoInventario> ObtenerMovimientos()
        {
            List<MovimientoInventario> lista = new List<MovimientoInventario>();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT m.id_movimiento, m.id_ingrediente_movimiento, i.nombre_ingrediente,
                              m.id_usuario_movimiento, m.tipo_movimiento, m.cantidad_movimiento,
                              m.fecha_movimiento, m.observacion_movimiento
                       FROM tbl_movimientos_inventario m
                       INNER JOIN tbl_ingredientes i ON m.id_ingrediente_movimiento = i.id_ingrediente
                       ORDER BY m.fecha_movimiento DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new MovimientoInventario
                        {
                            IdMovimiento = rd.GetInt32("id_movimiento"),
                            IdIngrediente = rd.GetInt32("id_ingrediente_movimiento"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            IdUsuario = rd.GetInt32("id_usuario_movimiento"),
                            TipoMovimiento = rd.GetString("tipo_movimiento"),
                            Cantidad = rd.GetDecimal("cantidad_movimiento"),
                            FechaMovimiento = rd.GetDateTime("fecha_movimiento"),
                            Observacion = rd.IsDBNull(rd.GetOrdinal("observacion_movimiento"))
                                                    ? "" : rd.GetString("observacion_movimiento")
                        });
                    }
                }
            }
            return lista;
        }

        public List<MovimientoInventario> ObtenerMovimientosConUsuario()
        {
            List<MovimientoInventario> lista = new List<MovimientoInventario>();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT m.id_movimiento, m.id_ingrediente_movimiento, i.nombre_ingrediente,
                              m.id_usuario_movimiento, u.nombre_usuario, m.tipo_movimiento,
                              m.cantidad_movimiento, m.fecha_movimiento, m.observacion_movimiento
                       FROM tbl_movimientos_inventario m
                       INNER JOIN tbl_ingredientes i ON m.id_ingrediente_movimiento = i.id_ingrediente
                       INNER JOIN tbl_usuarios u     ON m.id_usuario_movimiento     = u.id_usuario
                       ORDER BY m.fecha_movimiento DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new MovimientoInventario
                        {
                            IdMovimiento = rd.GetInt32("id_movimiento"),
                            IdIngrediente = rd.GetInt32("id_ingrediente_movimiento"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            IdUsuario = rd.GetInt32("id_usuario_movimiento"),
                            NombreUsuario = rd.GetString("nombre_usuario"),
                            TipoMovimiento = rd.GetString("tipo_movimiento"),
                            Cantidad = rd.GetDecimal("cantidad_movimiento"),
                            FechaMovimiento = rd.GetDateTime("fecha_movimiento"),
                            Observacion = rd.IsDBNull(rd.GetOrdinal("observacion_movimiento"))
                                                    ? "" : rd.GetString("observacion_movimiento")
                        });
                    }
                }
            }
            return lista;
        }

        public bool RegistrarMovimiento(MovimientoInventario m)
        {
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                using (MySqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlInsert = @"INSERT INTO tbl_movimientos_inventario
                                    (id_ingrediente_movimiento, id_usuario_movimiento, tipo_movimiento,
                                     cantidad_movimiento, fecha_movimiento, observacion_movimiento)
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

                        string operacion = (m.TipoMovimiento == "Compra") ? "+" : "-";
                        string sqlExist = $"UPDATE tbl_ingredientes SET existencia_ingrediente = existencia_ingrediente {operacion} @cantidad " +
                                           "WHERE id_ingrediente = @id";

                        using (MySqlCommand cmd = new MySqlCommand(sqlExist, cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@cantidad", m.Cantidad);
                            cmd.Parameters.AddWithValue("@id", m.IdIngrediente);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlCheck = "SELECT existencia_ingrediente FROM tbl_ingredientes WHERE id_ingrediente = @id";
                        using (MySqlCommand cmd = new MySqlCommand(sqlCheck, cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@id", m.IdIngrediente);
                            decimal existenciaResultante = Convert.ToDecimal(cmd.ExecuteScalar());
                            if (existenciaResultante < 0)
                            {
                                tr.Rollback();
                                return false;
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
        }
        public List<Ingrediente> ObtenerTodos()
        {
            List<Ingrediente> lista = new List<Ingrediente>();
            using (MySqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT id_ingrediente, nombre_ingrediente, unidad_medida_ingrediente,
                              existencia_ingrediente, stock_minimo_ingrediente, costo_unitario_ingrediente
                       FROM tbl_ingredientes
                       ORDER BY nombre_ingrediente";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new Ingrediente
                        {
                            IdIngrediente = rd.GetInt32("id_ingrediente"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            UnidadMedida = rd.GetString("unidad_medida_ingrediente"),
                            Existencia = rd.GetDecimal("existencia_ingrediente"),
                            StockMinimo = rd.GetDecimal("stock_minimo_ingrediente"),
                            CostoUnitario = rd.GetDecimal("costo_unitario_ingrediente")
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
                cn.Open();
                // La vista en BD se llama vista_stock_bajo, no vista_ingredientes_bajo_stock
                string sql = @"SELECT id_ingrediente, nombre_ingrediente, unidad_medida,
                              existencia_actual, stock_minimo, costo_unitario_ingrediente
                       FROM vista_stock_bajo";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new Ingrediente
                        {
                            IdIngrediente = rd.GetInt32("id_ingrediente"),
                            NombreIngrediente = rd.GetString("nombre_ingrediente"),
                            UnidadMedida = rd.GetString("unidad_medida"),
                            Existencia = rd.GetDecimal("existencia_actual"),
                            StockMinimo = rd.GetDecimal("stock_minimo"),
                            CostoUnitario = rd.GetDecimal("costo_unitario_ingrediente")
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
                cn.Open();
                string sql = @"INSERT INTO tbl_ingredientes
                       (nombre_ingrediente, unidad_medida_ingrediente, existencia_ingrediente,
                        stock_minimo_ingrediente, costo_unitario_ingrediente)
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
                cn.Open();
                string sql = @"UPDATE tbl_ingredientes SET
                       nombre_ingrediente       = @nombre,
                       unidad_medida_ingrediente= @unidad,
                       stock_minimo_ingrediente = @stockMin,
                       costo_unitario_ingrediente = @costo
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
    }
}