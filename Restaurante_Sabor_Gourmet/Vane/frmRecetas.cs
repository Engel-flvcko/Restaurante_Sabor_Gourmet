using Restaurante_Sabor_Gourmet.ConsultasSQL;
using Restaurante_Sabor_Gourmet.Clases;
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
    public partial class frmRecetas : Form
    {
        // ─────────────────────────────────────────
        // VARIABLES DE ESTADO
        // ─────────────────────────────────────────
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        // Producto seleccionado actualmente
        private int idProductoActual = 0;
        private string nombreProductoActual = "";
        private decimal precioVentaActual = 0;

        // Lista en memoria de ingredientes a guardar
        // Tag de cada fila: int idReceta (0 = nuevo, >0 = ya guardado en BD)
        private readonly SQLRecetas sqlRecetas = new SQLRecetas();
        private readonly SQLInventario sqlInv = new SQLInventario();
        private readonly SQLMenu sqlMenu = new SQLMenu();

        // Mapa nombre→id para ingredientes del combo
        private Dictionary<string, int> mapaIngredientes = new Dictionary<string, int>();
        // Mapa nombre→costoUnitario para el análisis de costo
        private Dictionary<string, decimal> mapaCostos = new Dictionary<string, decimal>();
        // Mapa nombre→unidadMedida para autocompletar
        private Dictionary<string, string> mapaUnidades = new Dictionary<string, string>();

        // Lista de productos para la grilla izquierda
        private List<ProductoCatalogo> todosLosProductos = new List<ProductoCatalogo>();

        // ─────────────────────────────────────────
        // CONSTRUCTORES
        // ─────────────────────────────────────────

        // Desde frmPrincipal (sin preselección)
        public frmRecetas(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion     = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

        // Desde frmMenu (con producto preseleccionado)
        public frmRecetas(int idProducto, string nombreProducto,
                           int idUsuarioSesion, string nombreUsuarioSesion)
            : this(idUsuarioSesion, nombreUsuarioSesion)
        {
            this.idProductoActual      = idProducto;
            this.nombreProductoActual  = nombreProducto;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────
        private void frmRecetas_Load(object sender, EventArgs e)
        {
           

            CargarCategoriasFiltro();
            CargarIngredientesCombo();
            CargarGrillaProductos();

            // Si viene preseleccionado desde frmMenu, cargarlo
            if (idProductoActual > 0)
                SeleccionarProductoEnGrilla(idProductoActual);
        }

        // ─────────────────────────────────────────
        // CARGAR CATEGORÍAS EN COMBO FILTRO
        // ─────────────────────────────────────────
        private void CargarCategoriasFiltro()
        {
            cmbCategoriaFiltro.Items.Clear();
            cmbCategoriaFiltro.Items.Add("Todas las categorías");

            List<string> cats = sqlMenu.ObtenerCategorias();
            foreach (string cat in cats)
                cmbCategoriaFiltro.Items.Add(cat);

            cmbCategoriaFiltro.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────
        // CARGAR INGREDIENTES EN COMBO + MAPAS
        // ─────────────────────────────────────────
        private void CargarIngredientesCombo()
        {
            cmbIngrediente.Items.Clear();
            mapaIngredientes.Clear();
            mapaCostos.Clear();
            mapaUnidades.Clear();

            List<Ingrediente> lista = sqlInv.ObtenerTodos();
            foreach (Ingrediente i in lista)
            {
                cmbIngrediente.Items.Add(i.NombreIngrediente);
                mapaIngredientes[i.NombreIngrediente] = i.IdIngrediente;
                mapaCostos[i.NombreIngrediente]       = i.CostoUnitario;
                mapaUnidades[i.NombreIngrediente]     = i.UnidadMedida;
            }

            if (cmbIngrediente.Items.Count > 0)
                cmbIngrediente.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────
        // CARGAR GRILLA DE PRODUCTOS
        // ─────────────────────────────────────────
        private void CargarGrillaProductos()
        {
            todosLosProductos = sqlMenu.ObtenerTodosLosProductos();
            FiltrarYMostrarProductos();
        }

        private void FiltrarYMostrarProductos()
        {
            string texto = txtBuscarProducto.Text.Trim().ToLower();
            string cat = cmbCategoriaFiltro.SelectedItem?.ToString() ?? "Todas las categorías";

            dgvProductos.Rows.Clear();

            int contador = 0;
            foreach (ProductoCatalogo p in todosLosProductos)
            {
                bool coincideTexto = string.IsNullOrEmpty(texto)
                    || p.NombreProducto.ToLower().Contains(texto);

                bool coincideCategoria = cat == "Todas las categorías"
                    || p.NombreCategoria == cat;

                if (!coincideTexto || !coincideCategoria) continue;

                // Contar ingredientes de este producto
                List<Receta> ings = sqlRecetas.ObtenerPorProducto(p.IdProducto);

                int idx = dgvProductos.Rows.Add(
                    p.NombreProducto,
                    p.NombreCategoria,
                    ings.Count
                );
                // Guardar id en Tag de la fila
                dgvProductos.Rows[idx].Tag = p.IdProducto;
                contador++;
            }

            lblTotalProductos.Text = $"Total productos: {contador}";
        }

        // ─────────────────────────────────────────
        // SELECCIONAR PRODUCTO EN GRILLA (desde frmMenu)
        // ─────────────────────────────────────────
        private void SeleccionarProductoEnGrilla(int idProducto)
        {
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.Tag is int id && id == idProducto)
                {
                    dgvProductos.ClearSelection();
                    fila.Selected = true;
                    dgvProductos.FirstDisplayedScrollingRowIndex = fila.Index;
                    CargarRecetaDeProducto(idProducto);
                    return;
                }
            }
        }

        // ─────────────────────────────────────────
        // FILTROS PANEL PRODUCTO
        // ─────────────────────────────────────────
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarYMostrarProductos();
        }

        private void cmbCategoriaFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYMostrarProductos();
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA PRODUCTOS
        // ─────────────────────────────────────────
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvProductos.SelectedRows[0];
            if (fila.Tag is int id && id > 0)
                CargarRecetaDeProducto(id);
        }

        // ─────────────────────────────────────────
        // CARGAR RECETA DEL PRODUCTO SELECCIONADO
        // ─────────────────────────────────────────
        private void CargarRecetaDeProducto(int idProducto)
        {
            idProductoActual = idProducto;

            // Buscar datos del producto
            ProductoCatalogo prod = todosLosProductos.Find(p => p.IdProducto == idProducto);
            if (prod == null) return;

            nombreProductoActual = prod.NombreProducto;
            precioVentaActual    = prod.PrecioVenta;

            // Actualizar cabecera del panel receta
            lblNombreReceta.Text = $"Receta: {prod.NombreProducto}";
            lblInfoReceta.Text   = $"Categoría: {prod.NombreCategoria}  |  " +
                                   $"Precio: ${prod.PrecioVenta:F2}  |  " +
                                   $"Tiempo: {prod.TiempoPreparacionMin} min";

            // Cargar grilla de ingredientes
            dgvReceta.Rows.Clear();

            List<Receta> receta = sqlRecetas.ObtenerPorProducto(idProducto);
            foreach (Receta r in receta)
            {
                int idx = dgvReceta.Rows.Add(
                    r.NombreIngrediente,
                    r.UnidadMedida,
                    r.CantidadReceta.ToString("F3"),
                    "🗑"
                );
                dgvReceta.Rows[idx].Tag = r.IdReceta; // Tag = idReceta ya guardado
            }

            ActualizarAnalisisCosto();
            LimpiarFormularioAgregar();
        }

        // ─────────────────────────────────────────
        // CAMBIO DE INGREDIENTE EN COMBO — autocompleta unidad
        // ─────────────────────────────────────────
        private void cmbIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIngrediente.SelectedItem == null) return;

            string nombre = cmbIngrediente.SelectedItem.ToString();

            // Autocompletar unidad de medida
            if (mapaUnidades.ContainsKey(nombre))
                txtUnidadMedida.Text = mapaUnidades[nombre];

            // Verificar si ya está en la receta actual
            bool yaExiste = IngredienteYaEnGrilla(nombre);
            pnlAdvertencia.Visible  = yaExiste;
            btnAgregarReceta.Enabled = !yaExiste;
        }

        private bool IngredienteYaEnGrilla(string nombre)
        {
            foreach (DataGridViewRow fila in dgvReceta.Rows)
            {
                if (fila.Cells["colIngrediente"].Value?.ToString() == nombre)
                    return true;
            }
            return false;
        }

        // ─────────────────────────────────────────
        // BOTÓN AGREGAR A RECETA
        // ─────────────────────────────────────────
        private void btnAgregarReceta_Click(object sender, EventArgs e)
        {
            if (idProductoActual == 0)
            {
                MessageBox.Show("Selecciona un producto antes de agregar ingredientes.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbIngrediente.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un ingrediente.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return;
            }

            string nombre = cmbIngrediente.SelectedItem.ToString();

            if (IngredienteYaEnGrilla(nombre))
            {
                pnlAdvertencia.Visible = true;
                return;
            }

            // Agregar directamente a BD
            Receta nueva = new Receta
            {
                IdProducto    = idProductoActual,
                IdIngrediente = mapaIngredientes[nombre],
                CantidadReceta = nudCantidad.Value
            };

            bool ok = sqlRecetas.AgregarIngrediente(nueva);
            if (ok)
            {
                // Recargar receta completa desde BD para tener idReceta real
                CargarRecetaDeProducto(idProductoActual);
                FiltrarYMostrarProductos(); // actualiza contador de ingredientes
                LimpiarFormularioAgregar();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el ingrediente. Intenta de nuevo.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ELIMINAR EN GRILLA RECETA (colAcciones)
        // ─────────────────────────────────────────
        private void dgvReceta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvReceta.Columns["colAcciones"].Index) return;

            DataGridViewRow fila = dgvReceta.Rows[e.RowIndex];
            string nombreIng = fila.Cells["colIngrediente"].Value?.ToString();

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar '{nombreIng}' de la receta?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // Si la fila tiene idReceta (Tag > 0), eliminar de BD
            if (fila.Tag is int idReceta && idReceta > 0)
            {
                bool ok = sqlRecetas.EliminarIngrediente(idReceta);
                if (!ok)
                {
                    MessageBox.Show("No se pudo eliminar el ingrediente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dgvReceta.Rows.RemoveAt(e.RowIndex);
            ActualizarAnalisisCosto();
            FiltrarYMostrarProductos();
        }

        // ─────────────────────────────────────────
        // ANÁLISIS DE COSTO
        // Se calcula desde los datos en la grilla usando mapaCostos
        // ─────────────────────────────────────────
        private void ActualizarAnalisisCosto()
        {
            decimal costoTotal = 0;

            foreach (DataGridViewRow fila in dgvReceta.Rows)
            {
                string nombre = fila.Cells["colIngrediente"].Value?.ToString() ?? "";
                string cantStr = fila.Cells["colCantidad"].Value?.ToString() ?? "0";

                if (!decimal.TryParse(cantStr, out decimal cant)) continue;

                decimal costoU = mapaCostos.ContainsKey(nombre) ? mapaCostos[nombre] : 0;
                costoTotal += costoU * cant;
            }

            decimal ganancia = precioVentaActual - costoTotal;
            decimal margen = precioVentaActual > 0
                ? (ganancia / precioVentaActual) * 100
                : 0;

            lblCostoProduccionVal.Text = $"$ {costoTotal:F2}";
            lblPrecioVentaVal.Text     = $"$ {precioVentaActual:F2}";
            lblGananciaVal.Text        = $"$ {ganancia:F2}";
            lblMargenPorcentaje.Text   = $"{margen:F1}%";

            // ProgressBar (máximo 100)
            int margenInt = (int)Math.Min(Math.Max(margen, 0), 100);
            prgMargen.Value = margenInt;

            // Colorear ganancia según margen
            if (margen >= 40)
            {
                lblGananciaVal.ForeColor    = Color.FromArgb(34, 197, 94);
                lblMargenPorcentaje.ForeColor = Color.FromArgb(34, 197, 94);
            }
            else if (margen >= 20)
            {
                lblGananciaVal.ForeColor    = Color.FromArgb(249, 115, 22);
                lblMargenPorcentaje.ForeColor = Color.FromArgb(249, 115, 22);
            }
            else
            {
                lblGananciaVal.ForeColor    = Color.FromArgb(239, 68, 68);
                lblMargenPorcentaje.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN GUARDAR RECETA
        // Guarda los cambios pendientes (por si se usó edición directa en grilla)
        // ─────────────────────────────────────────
        private void btnGuardarReceta_Click(object sender, EventArgs e)
        {
            if (idProductoActual == 0)
            {
                MessageBox.Show("Selecciona un producto primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvReceta.Rows.Count == 0)
            {
                MessageBox.Show("La receta no tiene ingredientes.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recorrer grilla y actualizar cantidades modificadas en BD
            int actualizados = 0;
            foreach (DataGridViewRow fila in dgvReceta.Rows)
            {
                if (!(fila.Tag is int idReceta) || idReceta <= 0) continue;

                string cantStr = fila.Cells["colCantidad"].Value?.ToString() ?? "0";
                if (!decimal.TryParse(cantStr, out decimal cant) || cant <= 0) continue;

                sqlRecetas.ActualizarCantidad(idReceta, cant);
                actualizados++;
            }

            MessageBox.Show($"Receta guardada. {actualizados} ingrediente(s) actualizado(s).",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarRecetaDeProducto(idProductoActual);
            FiltrarYMostrarProductos();
        }

        // ─────────────────────────────────────────
        // BOTÓN LIMPIAR RECETA
        // Elimina TODOS los ingredientes de la receta actual
        // ─────────────────────────────────────────
        private void btnLimpiarReceta_Click(object sender, EventArgs e)
        {
            if (idProductoActual == 0 || dgvReceta.Rows.Count == 0) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar TODOS los ingredientes de la receta '{nombreProductoActual}'?\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            bool todoOk = true;
            foreach (DataGridViewRow fila in dgvReceta.Rows)
            {
                if (fila.Tag is int idReceta && idReceta > 0)
                {
                    if (!sqlRecetas.EliminarIngrediente(idReceta))
                        todoOk = false;
                }
            }

            if (todoOk)
            {
                dgvReceta.Rows.Clear();
                ActualizarAnalisisCosto();
                FiltrarYMostrarProductos();
                LimpiarFormularioAgregar();
                MessageBox.Show("Receta limpiada correctamente.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Algunos ingredientes no pudieron eliminarse.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarRecetaDeProducto(idProductoActual);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ACTUALIZAR — recarga todo desde BD
        // ─────────────────────────────────────────
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarIngredientesCombo();
            CargarGrillaProductos();

            if (idProductoActual > 0)
                CargarRecetaDeProducto(idProductoActual);
        }

        // ─────────────────────────────────────────
        // HELPER — limpiar panel agregar ingrediente
        // ─────────────────────────────────────────
        private void LimpiarFormularioAgregar()
        {
            if (cmbIngrediente.Items.Count > 0)
                cmbIngrediente.SelectedIndex = 0;

            nudCantidad.Value          = 0;
            txtUnidadMedida.Text       = "---";
            pnlAdvertencia.Visible     = false;
            btnAgregarReceta.Enabled   = true;
        }
    }
}

