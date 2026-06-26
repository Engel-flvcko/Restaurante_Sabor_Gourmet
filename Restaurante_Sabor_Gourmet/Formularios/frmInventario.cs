using Restaurante_Sabor_Gourmet.ConsultasSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public partial class frmInventario : Form
    {
        // VARIABLES DE ESTADO
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        // Ingrediente seleccionado en grilla
        private int idIngredienteSeleccionado = 0;
        private string nombreIngSeleccionado = "";

        // Lista completa en memoria para filtros locales
        private List<Ingrediente> todosLosIngredientes = new List<Ingrediente>();
        private List<MovimientoInventario> todoElHistorial = new List<MovimientoInventario>();

        // Filtro activo: "todos" | "bajo" | "agotado"
        private string filtroActivo = "todos";

        // DAOs
       
        private readonly SQLInventario sqlInv = new SQLInventario();

      
        // CONSTRUCTOR
        
        public frmInventario(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion     = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

    
        // CARGA INICIAL
       
        private void frmInventario_Load(object sender, EventArgs e)
        {
           

            CargarTodo();
            ConfigurarPanelMovimiento(false);
        }

        private void CargarTodo()
        {
            CargarIngredientes();
            CargarHistorial();
        }

      
        // CARGAR INGREDIENTES 
     
        private void CargarIngredientes()
        {
            todosLosIngredientes = sqlInv.ObtenerTodos();
            ActualizarKpiCards();
            AplicarFiltroYMostrar();
        }

        private void ActualizarKpiCards()
        {
            int total = todosLosIngredientes.Count;
            int bajo = 0;
            int agotado = 0;

            foreach (Ingrediente i in todosLosIngredientes)
            {
                if (i.Agotado) agotado++;
                else if (i.BajoStock) bajo++;
            }

            int enStock = total - bajo - agotado;

            lblCardTotalValor.Text   = total.ToString();
            lblCardStockValor.Text   = enStock.ToString();
            lblCardBajoValor.Text    = bajo.ToString();
            lblCardAgotadoValor.Text = agotado.ToString();
        }

        private void AplicarFiltroYMostrar()
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            List<Ingrediente> filtrados = new List<Ingrediente>();

            foreach (Ingrediente i in todosLosIngredientes)
            {
                bool coincideTexto = string.IsNullOrEmpty(texto)
                    || i.NombreIngrediente.ToLower().Contains(texto);

                bool coincideFiltro =
                    filtroActivo == "todos"  ||
                    (filtroActivo == "bajo"   && i.BajoStock && !i.Agotado) ||
                    (filtroActivo == "agotado" && i.Agotado);

                if (coincideTexto && coincideFiltro)
                    filtrados.Add(i);
            }

            MostrarEnGrilla(filtrados);
        }

        private void MostrarEnGrilla(List<Ingrediente> lista)
        {
            dgvIngredientes.Rows.Clear();

            foreach (Ingrediente i in lista)
            {
                string estado = i.Agotado ? "⛔ Agotado" :
                                i.BajoStock ? "⚠ Stock bajo" : "✔ Normal";

                int idx = dgvIngredientes.Rows.Add(
                    i.IdIngrediente,         
                    i.NombreIngrediente,      
                    i.UnidadMedida,           
                    i.Existencia.ToString("F2"),   
                    i.StockMinimo.ToString("F2"),   
                    i.CostoUnitario.ToString("F2"), 
                    estado                    
                );

                dgvIngredientes.Rows[idx].Tag = i.IdIngrediente;
            }
        }

     
        // FORMATEO DE COLORES EN GRILLA (CellFormatting)
        
        private void dgvIngredientes_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string estado = dgvIngredientes.Rows[e.RowIndex]
                                           .Cells["colEstado"].Value?.ToString() ?? "";

            Color colorFila = estado.Contains("Agotado") ? Color.FromArgb(255, 235, 235) :
                              estado.Contains("Stock bajo") ? Color.FromArgb(255, 245, 225) :
                              Color.White;

            dgvIngredientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorFila;

            // Colorear celda Estado específicamente
            if (dgvIngredientes.Columns[e.ColumnIndex].Name == "colEstado")
            {
                if (estado.Contains("Agotado"))
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68);
                else if (estado.Contains("Stock bajo"))
                    e.CellStyle.ForeColor = Color.FromArgb(249, 115, 22);
                else
                    e.CellStyle.ForeColor = Color.FromArgb(34, 197, 94);
            }
        }

    
        // CARGAR HISTORIAL
    
        private void CargarHistorial()
        {
            todoElHistorial = sqlInv.ObtenerMovimientosConUsuario();
            MostrarHistorial(todoElHistorial);
        }

        private void MostrarHistorial(List<MovimientoInventario> lista)
        {
            dgvHistorial.Rows.Clear();

            foreach (MovimientoInventario m in lista)
            {
                int idx = dgvHistorial.Rows.Add(
                    m.FechaMovimiento.ToString("dd/MM/yyyy HH:mm"),
                    m.NombreIngrediente,
                    m.TipoMovimiento,
                    m.Cantidad.ToString("F2"),
                    m.NombreUsuario,
                    m.Observacion
                );

                // Colorear tipo de movimiento
                Color colorTipo = m.TipoMovimiento switch
                {
                    "Compra" => Color.FromArgb(220, 252, 231),
                    "Consumo" => Color.FromArgb(219, 234, 254),
                    "Ajuste" => Color.FromArgb(254, 249, 195),
                    "Desperdicio" => Color.FromArgb(254, 226, 226),
                    _ => Color.White
                };
                dgvHistorial.Rows[idx].Cells["colHTipo"]
                             .Style.BackColor = colorTipo;
            }
        }

        // BÚSQUEDA EN TIEMPO REAL
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroYMostrar();
        }


        // BOTONES FILTRO
  
        private void btnFiltroTodos_Click(object sender, EventArgs e)
        {
            filtroActivo = "todos";
            ActualizarEstiloFiltros();
            AplicarFiltroYMostrar();
        }

        private void btnFiltroStockBajo_Click(object sender, EventArgs e)
        {
            filtroActivo = "bajo";
            ActualizarEstiloFiltros();
            AplicarFiltroYMostrar();
        }

        private void btnFiltroAgotados_Click(object sender, EventArgs e)
        {
            filtroActivo = "agotado";
            ActualizarEstiloFiltros();
            AplicarFiltroYMostrar();
        }

        private void ActualizarEstiloFiltros()
        {
            // Resetear todos
            btnFiltroTodos.FillColor     = Color.White;
            btnFiltroStockBajo.FillColor = Color.White;
            btnFiltroAgotados.FillColor  = Color.White;

            // Resaltar el activo
            switch (filtroActivo)
            {
                case "todos":
                    btnFiltroTodos.FillColor     = Color.FromArgb(37, 99, 235);
                    btnFiltroTodos.ForeColor     = Color.White;
                    btnFiltroStockBajo.ForeColor = Color.FromArgb(249, 115, 22);
                    btnFiltroAgotados.ForeColor  = Color.FromArgb(239, 68, 68);
                    break;
                case "bajo":
                    btnFiltroStockBajo.FillColor = Color.FromArgb(249, 115, 22);
                    btnFiltroStockBajo.ForeColor = Color.White;
                    btnFiltroTodos.ForeColor     = Color.FromArgb(37, 99, 235);
                    btnFiltroAgotados.ForeColor  = Color.FromArgb(239, 68, 68);
                    break;
                case "agotado":
                    btnFiltroAgotados.FillColor  = Color.FromArgb(239, 68, 68);
                    btnFiltroAgotados.ForeColor  = Color.White;
                    btnFiltroTodos.ForeColor     = Color.FromArgb(37, 99, 235);
                    btnFiltroStockBajo.ForeColor = Color.FromArgb(249, 115, 22);
                    break;
            }
        }

        // SELECCIÓN EN GRILLA — carga panel movimiento
        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIngredientes.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvIngredientes.SelectedRows[0];
            if (fila.Tag == null) return;

            idIngredienteSeleccionado = Convert.ToInt32(fila.Tag);
            nombreIngSeleccionado     = fila.Cells["colIngrediente"].Value?.ToString();

            Ingrediente ing = todosLosIngredientes.Find(
                i => i.IdIngrediente == idIngredienteSeleccionado);

            if (ing == null) return;

            lblNombreIngVal.Text   = ing.NombreIngrediente;
            lblExistenciaVal.Text  = ing.Existencia.ToString("F2");
            lblStockMinVal.Text    = ing.StockMinimo.ToString("F2");
            lblUnidadMedidaVal.Text = ing.UnidadMedida;

            lblExistenciaVal.ForeColor = ing.Agotado ? Color.FromArgb(239, 68, 68) :
                                         ing.BajoStock ? Color.FromArgb(249, 115, 22) :
                                                          Color.FromArgb(34, 197, 94);

            ConfigurarPanelMovimiento(true);

            bool tieneReceta = sqlInv.EstaEnReceta(idIngredienteSeleccionado);
            btnEliminar.Enabled          = !tieneReceta;
            lblDeshabilitado.Visible     = tieneReceta;
            btnEditarIngrediente.Enabled = true;
        }

        // ─────────────────────────────────────────
        // CAMBIO DE TIPO — observación obligatoria en Ajuste/Desperdicio
        // ─────────────────────────────────────────
        private void cmbTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cmbTipoMovimiento.SelectedItem?.ToString();
            bool requiere = tipo == "Ajuste" || tipo == "Desperdicio";

            lblObservacion.Text      = requiere
                ? "Observación / Justificación *"
                : "Observación / Justificación";
            lblObservacion.ForeColor = requiere
                ? Color.FromArgb(239, 68, 68)
                : Color.FromArgb(60, 60, 80);
        }

        // BOTÓN REGISTRAR MOVIMIENTO
        private void btnRegistrarMovimiento_Click(object sender, EventArgs e)
        {
            if (idIngredienteSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un ingrediente de la lista primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarMovimiento()) return;

            MovimientoInventario mov = new MovimientoInventario
            {
                IdIngrediente  = idIngredienteSeleccionado,
                IdUsuario      = idUsuarioSesion,
                TipoMovimiento = cmbTipoMovimiento.SelectedItem.ToString(),
                Cantidad       = nudCantidad.Value,
                Observacion    = txtObservacion.Text.Trim()
            };

            bool ok = sqlInv.RegistrarMovimiento(mov);

            if (ok)
            {
                MessageBox.Show("Movimiento registrado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioMovimiento();
                CargarTodo(); 
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar el movimiento.\n" +
                    "Verifica que la existencia resultante no quede negativa.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FILTRO HISTORIAL POR FECHA
        private void dtpFiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = dtpFiltroFecha.Value.Date;

            List<MovimientoInventario> filtrados = todoElHistorial.FindAll(
                m => m.FechaMovimiento.Date == fecha);

            MostrarHistorial(filtrados);
        }

        private void btnLimpiarFecha_Click(object sender, EventArgs e)
        {
            dtpFiltroFecha.Value = DateTime.Today;
            MostrarHistorial(todoElHistorial);
        }

        // ─────────────────────────────────────────
        // BOTÓN NUEVO INGREDIENTE — inline en el panel movimiento
        // ─────────────────────────────────────────
        private void btnNuevoIngrediente_Click(object sender, EventArgs e)
        {
            string nombre = Microsoft.VisualBasic.Interaction.InputBox(
                "Nombre del ingrediente:", "Nuevo Ingrediente", "");
            if (string.IsNullOrWhiteSpace(nombre)) return;

            string unidad = Microsoft.VisualBasic.Interaction.InputBox(
                "Unidad de medida (kg, lt, unidades, etc.):", "Nuevo Ingrediente", "");
            if (string.IsNullOrWhiteSpace(unidad)) return;

            string stockStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Stock mínimo:", "Nuevo Ingrediente", "0");
            if (!decimal.TryParse(stockStr, out decimal stockMin) || stockMin < 0)
            {
                MessageBox.Show("Stock mínimo inválido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string costoStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Costo unitario:", "Nuevo Ingrediente", "0");
            if (!decimal.TryParse(costoStr, out decimal costo) || costo < 0)
            {
                MessageBox.Show("Costo inválido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string existenciaStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Existencia inicial (0 si aún no hay stock):", "Nuevo Ingrediente", "0");
            if (!decimal.TryParse(existenciaStr, out decimal existenciaInicial) || existenciaInicial < 0)
            {
                MessageBox.Show("Existencia inválida.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Ingrediente nuevo = new Ingrediente
            {
                NombreIngrediente = nombre.Trim(),
                UnidadMedida = unidad.Trim(),
                Existencia = 0,          
                StockMinimo = stockMin,
                CostoUnitario = costo
            };

            bool ok = sqlInv.InsertarIngrediente(nuevo);
            if (!ok)
            {
                MessageBox.Show("No se pudo crear el ingrediente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existenciaInicial > 0)
            {
                Ingrediente insertado = sqlInv.ObtenerTodos()
                    .Find(i => i.NombreIngrediente.Equals(
                        nuevo.NombreIngrediente, StringComparison.OrdinalIgnoreCase));

                if (insertado != null)
                {
                    MovimientoInventario movInicial = new MovimientoInventario
                    {
                        IdIngrediente = insertado.IdIngrediente,
                        IdUsuario = idUsuarioSesion,
                        TipoMovimiento = "Compra",
                        Cantidad = existenciaInicial,
                        Observacion = "Stock inicial al crear ingrediente"
                    };
                    sqlInv.RegistrarMovimiento(movInicial);
                }
            }

            MessageBox.Show("Ingrediente creado correctamente.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarIngredientes();
        }

        // BOTÓN EDITAR INGREDIENTE
        private void btnEditarIngrediente_Click(object sender, EventArgs e)
        {
            if (idIngredienteSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un ingrediente de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Ingrediente actual = todosLosIngredientes.Find(
                i => i.IdIngrediente == idIngredienteSeleccionado);
            if (actual == null) return;

            bool tieneReceta = sqlInv.EstaEnReceta(idIngredienteSeleccionado);

            if (!tieneReceta)
            {
                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                    "Nombre:", "Editar Ingrediente", actual.NombreIngrediente);
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                    actual.NombreIngrediente = nuevoNombre.Trim();

                string nuevaUnidad = Microsoft.VisualBasic.Interaction.InputBox(
                    "Unidad de medida:", "Editar Ingrediente", actual.UnidadMedida);
                if (!string.IsNullOrWhiteSpace(nuevaUnidad))
                    actual.UnidadMedida = nuevaUnidad.Trim();
            }
            else
            {
                MessageBox.Show("Este ingrediente está en recetas.\n" +
                    "Solo se editará Stock Mínimo, Costo Unitario y Existencia.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string stockStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Stock mínimo:", "Editar Ingrediente",
                actual.StockMinimo.ToString("F2"));

            if (string.IsNullOrWhiteSpace(stockStr))
            {
                MessageBox.Show("Edición cancelada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            stockStr = stockStr.Replace(',', '.');
            if (!decimal.TryParse(stockStr,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal nuevoStock) || nuevoStock < 0)
            {
                MessageBox.Show("Stock mínimo inválido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            actual.StockMinimo = nuevoStock;

            string costoStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Costo unitario:", "Editar Ingrediente",
                actual.CostoUnitario.ToString("F2"));

            if (string.IsNullOrWhiteSpace(costoStr))
            {
                MessageBox.Show("Edición cancelada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            costoStr = costoStr.Replace(',', '.');
            if (!decimal.TryParse(costoStr,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal nuevoCosto) || nuevoCosto < 0)
            {
                MessageBox.Show("Costo unitario inválido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            actual.CostoUnitario = nuevoCosto;

            string existenciaStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Existencia actual\n(corrige si el conteo físico difiere del sistema):",
                "Editar Ingrediente",
                actual.Existencia.ToString("F2"));

            if (string.IsNullOrWhiteSpace(existenciaStr))
            {
                MessageBox.Show("Edición cancelada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            existenciaStr = existenciaStr.Replace(',', '.');
            if (!decimal.TryParse(existenciaStr,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal nuevaExistencia) || nuevaExistencia < 0)
            {
                MessageBox.Show("Existencia inválida. Debe ser un número mayor o igual a 0.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool okDatos = sqlInv.ActualizarIngrediente(actual);

            bool okExistencia = true;
            if (nuevaExistencia != actual.Existencia)
                okExistencia = sqlInv.ActualizarExistencia(
                    idIngredienteSeleccionado, nuevaExistencia);

            if (okDatos && okExistencia)
            {
                MessageBox.Show("Ingrediente actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarIngredientes();
            }
            else
            {
                MessageBox.Show("Hubo un problema al guardar algunos campos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN ELIMINAR INGREDIENTE
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idIngredienteSeleccionado == 0) return;

            if (sqlInv.EstaEnReceta(idIngredienteSeleccionado))
            {
                MessageBox.Show("No se puede eliminar: el ingrediente está asignado a recetas.",
                    "No permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar permanentemente '{nombreIngSeleccionado}'?\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            bool ok = sqlInv.EliminarIngrediente(idIngredienteSeleccionado);
            if (ok)
            {
                MessageBox.Show("Ingrediente eliminado.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idIngredienteSeleccionado = 0;
                ConfigurarPanelMovimiento(false);
                CargarIngredientes();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el ingrediente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN ACTUALIZAR
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTodo();
        }

        private bool ValidarMovimiento()
        {
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return false;
            }

            string tipo = cmbTipoMovimiento.SelectedItem?.ToString();
            if ((tipo == "Ajuste" || tipo == "Desperdicio") &&
                string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show("Los movimientos de Ajuste y Desperdicio\nrequieren justificación.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormularioMovimiento()
        {
            nudCantidad.Value            = 0;
            txtObservacion.Text          = "";
            cmbTipoMovimiento.SelectedIndex = 0;
        }

        private void ConfigurarPanelMovimiento(bool haySeleccion)
        {
            btnRegistrarMovimiento.Enabled = haySeleccion;
            btnEditarIngrediente.Enabled   = haySeleccion;

            if (!haySeleccion)
            {
                lblNombreIngVal.Text    = "—";
                lblExistenciaVal.Text   = "0.00";
                lblStockMinVal.Text     = "0.00";
                lblUnidadMedidaVal.Text = "—";
                lblExistenciaVal.ForeColor = Color.FromArgb(34, 197, 94);
                btnEliminar.Enabled     = false;
                lblDeshabilitado.Visible = true;
            }
        }
    }
}
