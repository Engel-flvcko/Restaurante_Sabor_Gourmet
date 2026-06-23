using Restaurante_Sabor_Gourmet.Clases;
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
    public partial class frmMenu : Form
    {
        
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        // Producto seleccionado
        private int idProductoSeleccionado = 0;
        private bool modoEdicion = false;

        // Categoría seleccionada (tab Categorías)
        private int idCategoriaSeleccionada = 0;
        private bool modoCatEdicion = false;

        // Lista en memoria para filtros locales
        private List<ProductoCatalogo> todosLosProductos = new List<ProductoCatalogo>();

        // Mapa nombre → id para categorías (uso interno)
        private Dictionary<string, int> mapaCategorias = new Dictionary<string, int>();

        private readonly SQLMenu sqlMenu = new SQLMenu();

        
        public frmMenu(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────
        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = nombreUsuarioSesion;

            CargarCategoriasEnCombos();
            CargarProductos();
            CargarGrillaCategorias();
            ConfigurarFormProducto(false);
        }

        // ════════════════════════════════════════════════════
        // SECCIÓN PRODUCTOS
        // ════════════════════════════════════════════════════

        // ─────────────────────────────────────────
        // CARGAR CATEGORÍAS EN COMBOS
        // ─────────────────────────────────────────
        private void CargarCategoriasEnCombos()
        {
            cmbFiltroCategoria.Items.Clear();
            cmbCategoria.Items.Clear();
            mapaCategorias.Clear();

            cmbFiltroCategoria.Items.Add("Todas");

            List<string> cats = sqlMenu.ObtenerCategorias();
            foreach (string cat in cats)
            {
                cmbFiltroCategoria.Items.Add(cat);
                cmbCategoria.Items.Add(cat);
            }

            cmbFiltroCategoria.SelectedIndex = 0;
            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;

            // Poblar mapa id usando conteo
            var conConteo = sqlMenu.ObtenerCategoriasConConteo();
            foreach (var c in conConteo)
                mapaCategorias[c.Nombre] = c.Id;
        }

        // ─────────────────────────────────────────
        // CARGAR PRODUCTOS Y KPI CARDS
        // ─────────────────────────────────────────
        private void CargarProductos()
        {
            todosLosProductos = sqlMenu.ObtenerTodosLosProductos();
            ActualizarKpiCards();
            AplicarFiltrosYMostrar();
        }

        private void ActualizarKpiCards()
        {
            int total = todosLosProductos.Count;
            int disponibles = 0;
            int noDisponibles = 0;

            foreach (ProductoCatalogo p in todosLosProductos)
            {
                if (p.Disponible) disponibles++;
                else noDisponibles++;
            }

            lblCardTotalValor.Text = total.ToString();
            lblCardDispValor.Text = disponibles.ToString();
            lblCardNoDispValor.Text = noDisponibles.ToString();
        }

        private void AplicarFiltrosYMostrar()
        {
            string texto = txtBuscarProducto.Text.Trim().ToLower();
            string cat = cmbFiltroCategoria.SelectedItem?.ToString() ?? "Todas";
            bool soloDisp = tglSoloDisponibles.Checked;

            List<ProductoCatalogo> filtrados = new List<ProductoCatalogo>();

            foreach (ProductoCatalogo p in todosLosProductos)
            {
                bool coincideTexto = string.IsNullOrEmpty(texto)
                    || p.NombreProducto.ToLower().Contains(texto)
                    || p.CodigoProducto.ToLower().Contains(texto);

                bool coincideCategoria = cat == "Todas" || p.NombreCategoria == cat;
                bool coincideDisponible = !soloDisp || p.Disponible;

                if (coincideTexto && coincideCategoria && coincideDisponible)
                    filtrados.Add(p);
            }

            MostrarProductosEnGrilla(filtrados);
        }

        private void MostrarProductosEnGrilla(List<ProductoCatalogo> lista)
        {
            dgvProductos.Rows.Clear();

            foreach (ProductoCatalogo p in lista)
            {
                int idx = dgvProductos.Rows.Add(
                    p.CodigoProducto,
                    p.NombreProducto,
                    p.NombreCategoria,
                    p.PrecioVenta,
                    $"{p.TiempoPreparacionMin} min",
                    p.Disponible ? "✔ Sí" : "✗ No"
                );

                dgvProductos.Rows[idx].Tag = p.IdProducto;

                // Colorear fila si no está disponible
                if (!p.Disponible)
                    dgvProductos.Rows[idx].DefaultCellStyle.ForeColor =
                        Color.FromArgb(180, 180, 180);
            }
        }

        // ─────────────────────────────────────────
        // EVENTOS FILTROS
        // ─────────────────────────────────────────
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        private void tglSoloDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        // ─────────────────────────────────────────
        // TOGGLE DISPONIBLE EN FORMULARIO
        // ─────────────────────────────────────────
        private void tglDisponible_CheckedChanged(object sender, EventArgs e)
        {
            lblDisponibleTexto.Text = tglDisponible.Checked ? "Sí" : "No";
            lblDisponibleTexto.ForeColor = tglDisponible.Checked
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(239, 68, 68);
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA PRODUCTOS
        // ─────────────────────────────────────────
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            if (fila.Tag == null) return;

            int id = Convert.ToInt32(fila.Tag);
            ProductoCatalogo prod = todosLosProductos.Find(p => p.IdProducto == id);
            if (prod == null) return;

            CargarProductoEnFormulario(prod);
        }

        private void CargarProductoEnFormulario(ProductoCatalogo p)
        {
            idProductoSeleccionado = p.IdProducto;
            modoEdicion = false; // solo lectura hasta que presione Editar

            txtCodigo.Text = p.CodigoProducto;
            txtNombreProducto.Text = p.NombreProducto;
            txtDescripcion.Text = p.Descripcion;
            txtPrecio.Text = p.PrecioVenta.ToString("F2");
            txtTiempoPrep.Text = p.TiempoPreparacionMin.ToString();
            tglDisponible.Checked = p.Disponible;
            lblDisponibleTexto.Text = p.Disponible ? "Sí" : "No";

            if (mapaCategorias.ContainsValue(p.IdCategoria))
                cmbCategoria.SelectedItem = p.NombreCategoria;

            lblFormTitulo.Text = $"Producto: {p.NombreProducto}";
            ConfigurarFormProducto(true);
            BloquearFormulario(true); // lectura hasta que haga click en Editar
        }

        // ─────────────────────────────────────────
        // BOTÓN NUEVO PRODUCTO
        // ─────────────────────────────────────────
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            LimpiarFormularioProducto();
            modoEdicion = false;
            idProductoSeleccionado = 0;
            lblFormTitulo.Text = "Nuevo Producto";
            BloquearFormulario(false);
            txtCodigo.ReadOnly = false;
            txtCodigo.Focus();
        }

        // ─────────────────────────────────────────
        // BOTÓN EDITAR
        // ─────────────────────────────────────────
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modoEdicion = true;
            txtCodigo.ReadOnly = true; // el código no se cambia al editar
            BloquearFormulario(false);
            lblFormTitulo.Text = "Editando producto...";
            txtNombreProducto.Focus();
        }

        // ─────────────────────────────────────────
        // BOTÓN GUARDAR
        // ─────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioProducto()) return;

            string nombreCat = cmbCategoria.SelectedItem?.ToString();
            int idCat = mapaCategorias.ContainsKey(nombreCat) ? mapaCategorias[nombreCat] : 0;

            if (idCat == 0)
            {
                MessageBox.Show("Selecciona una categoría válida.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductoCatalogo p = new ProductoCatalogo
            {
                IdProducto = idProductoSeleccionado,
                CodigoProducto = txtCodigo.Text.Trim(),
                NombreProducto = txtNombreProducto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                PrecioVenta = decimal.Parse(txtPrecio.Text.Trim()),
                TiempoPreparacionMin = int.Parse(txtTiempoPrep.Text.Trim()),
                Disponible = tglDisponible.Checked,
                IdCategoria = idCat,
                NombreCategoria = nombreCat
            };

            bool resultado;

            if (!modoEdicion)
            {
                if (sqlMenu.CodigoExiste(p.CodigoProducto))
                {
                    MessageBox.Show("Ya existe un producto con ese código.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                resultado = sqlMenu.InsertarProducto(p);
            }
            else
            {
                resultado = sqlMenu.ActualizarProducto(p);
            }

            if (resultado)
            {
                MessageBox.Show(modoEdicion
                    ? "Producto actualizado correctamente."
                    : "Producto agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioProducto();
                CargarProductos();
                ConfigurarFormProducto(false);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el producto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ELIMINAR (soft-disable)
        // ─────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desactivar este producto del menú?\n" +
                "No se eliminará permanentemente.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ok = sqlMenu.CambiarDisponibilidad(idProductoSeleccionado, false);

            if (ok)
            {
                MessageBox.Show("Producto desactivado del menú.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioProducto();
                CargarProductos();
                ConfigurarFormProducto(false);
            }
            else
            {
                MessageBox.Show("No se pudo desactivar el producto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN LIMPIAR
        // ─────────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioProducto();
            ConfigurarFormProducto(false);
        }

        // ─────────────────────────────────────────
        // BOTÓN ACTUALIZAR LISTA
        // ─────────────────────────────────────────
        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarCategoriasEnCombos();
            CargarProductos();
            CargarGrillaCategorias();
        }

        // ════════════════════════════════════════════════════
        // SECCIÓN CATEGORÍAS
        // ════════════════════════════════════════════════════

        private void CargarGrillaCategorias()
        {
            dgvCategorias.Rows.Clear();

            var lista = sqlMenu.ObtenerCategoriasConConteo();
            foreach (var c in lista)
            {
                int idx = dgvCategorias.Rows.Add(c.Id, c.Nombre, c.TotalProductos);
                dgvCategorias.Rows[idx].Tag = c.Id;
            }
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA CATEGORÍAS
        // ─────────────────────────────────────────
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];
            if (fila.Tag == null) return;

            idCategoriaSeleccionada = Convert.ToInt32(fila.Tag);
            modoCatEdicion = true;

            txtNombreCategoria.Text = fila.Cells["colCatNombre"].Value?.ToString();
            lblCatFormTitulo.Text = "Editar Categoría";

            btnEliminarCategoria.Enabled =
                !sqlMenu.TieneProductos(idCategoriaSeleccionada);
        }

        // ─────────────────────────────────────────
        // BOTÓN NUEVA CATEGORÍA
        // ─────────────────────────────────────────
        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            idCategoriaSeleccionada = 0;
            modoCatEdicion = false;
            txtNombreCategoria.Text = "";
            lblCatFormTitulo.Text = "Nueva Categoría";
            btnEliminarCategoria.Enabled = false;
            txtNombreCategoria.Focus();
        }

        // ─────────────────────────────────────────
        // BOTÓN GUARDAR CATEGORÍA
        // ─────────────────────────────────────────
        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return;
            }

            bool ok;

            if (!modoCatEdicion)
                ok = sqlMenu.InsertarCategoria(nombre);
            else
                ok = sqlMenu.ActualizarNombreCategoria(idCategoriaSeleccionada, nombre);

            if (ok)
            {
                MessageBox.Show(modoCatEdicion
                    ? "Categoría actualizada correctamente."
                    : "Categoría creada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioCategoria();
                CargarGrillaCategorias();
                CargarCategoriasEnCombos();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la categoría.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ELIMINAR CATEGORÍA
        // ─────────────────────────────────────────
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0) return;

            if (sqlMenu.TieneProductos(idCategoriaSeleccionada))
            {
                MessageBox.Show("No se puede eliminar: la categoría tiene productos asociados.",
                    "No permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar la categoría '{txtNombreCategoria.Text}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ok = sqlMenu.EliminarCategoria(idCategoriaSeleccionada);

            if (ok)
            {
                MessageBox.Show("Categoría eliminada.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioCategoria();
                CargarGrillaCategorias();
                CargarCategoriasEnCombos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la categoría.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN LIMPIAR CATEGORÍA
        // ─────────────────────────────────────────
        private void btnLimpiarCategoria_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCategoria();
        }

        // ════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════

        private bool ValidarFormularioProducto()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus(); return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus(); return false;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus(); return false;
            }

            if (!int.TryParse(txtTiempoPrep.Text.Trim(), out int tiempo) || tiempo < 0)
            {
                MessageBox.Show("Ingresa un tiempo de preparación válido (en minutos).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiempoPrep.Focus(); return false;
            }

            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona una categoría.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus(); return false;
            }

            return true;
        }

        private void LimpiarFormularioProducto()
        {
            idProductoSeleccionado = 0;
            modoEdicion = false;
            txtCodigo.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtTiempoPrep.Text = "";
            tglDisponible.Checked = true;
            lblDisponibleTexto.Text = "Sí";
            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
            lblFormTitulo.Text = "Datos del Producto";
            txtCodigo.ReadOnly = true;
        }

        private void LimpiarFormularioCategoria()
        {
            idCategoriaSeleccionada = 0;
            modoCatEdicion = false;
            txtNombreCategoria.Text = "";
            lblCatFormTitulo.Text = "Datos de Categoría";
            btnEliminarCategoria.Enabled = false;
        }

        private void ConfigurarFormProducto(bool haySeleccion)
        {
            btnEliminar.Enabled = haySeleccion;
            btnEditar.Enabled = haySeleccion;
        }

        private void BloquearFormulario(bool bloqueado)
        {
            txtNombreProducto.ReadOnly = bloqueado;
            txtDescripcion.ReadOnly = bloqueado;
            txtPrecio.ReadOnly = bloqueado;
            txtTiempoPrep.ReadOnly = bloqueado;
            cmbCategoria.Enabled = !bloqueado;
            tglDisponible.Enabled = !bloqueado;
            btnGuardar.Enabled = !bloqueado;
        }
    }
}
