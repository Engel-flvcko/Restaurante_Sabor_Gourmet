namespace Restaurante_Sabor_Gourmet.Vane
{
    partial class frmRecetas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Controles principales ──
            this.pnlTopBar              = new Guna.UI2.WinForms.Guna2Panel();
            this.picIcono               = new System.Windows.Forms.PictureBox();
            this.lblTitulo              = new System.Windows.Forms.Label();
            this.lblSubtitulo           = new System.Windows.Forms.Label();
            this.picUsuario             = new System.Windows.Forms.PictureBox();
            this.lblUsuario             = new System.Windows.Forms.Label();
            this.lblUsuarioFlecha       = new System.Windows.Forms.Label();

            // ── Panel Producto (superior izquierdo) ──
            this.pnlProducto            = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloProducto      = new System.Windows.Forms.Label();
            this.txtBuscarProducto      = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFiltrarCategoria    = new System.Windows.Forms.Label();
            this.cmbCategoriaFiltro     = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvProductos           = new System.Windows.Forms.DataGridView();
            this.colNombreProducto      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumIngredientes     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalProductos      = new System.Windows.Forms.Label();

            // ── Panel Receta (superior derecho) ──
            this.pnlReceta              = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNombreReceta        = new System.Windows.Forms.Label();
            this.lblInfoReceta          = new System.Windows.Forms.Label();
            this.dgvReceta              = new System.Windows.Forms.DataGridView();
            this.colIngrediente         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadMedida        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones            = new System.Windows.Forms.DataGridViewButtonColumn();

            // ── Panel Agregar Ingrediente (inferior izquierdo) ──
            this.pnlAgregarIngrediente  = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloAgregar       = new System.Windows.Forms.Label();
            this.lblSelIngrediente      = new System.Windows.Forms.Label();
            this.cmbIngrediente         = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCantidadReq         = new System.Windows.Forms.Label();
            this.nudCantidad            = new System.Windows.Forms.NumericUpDown();
            this.lblUnidadMedida        = new System.Windows.Forms.Label();
            this.txtUnidadMedida        = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlAdvertencia         = new System.Windows.Forms.Panel();
            this.lblAdvertencia         = new System.Windows.Forms.Label();
            this.btnAgregarReceta       = new Guna.UI2.WinForms.Guna2Button();

            // ── Panel Análisis de Costo (inferior derecho) ──
            this.pnlAnalisisCosto       = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloAnalisis      = new System.Windows.Forms.Label();
            this.lblCostoProduccionLbl  = new System.Windows.Forms.Label();
            this.lblCostoProduccionVal  = new System.Windows.Forms.Label();
            this.lblPrecioVentaLbl      = new System.Windows.Forms.Label();
            this.lblPrecioVentaVal      = new System.Windows.Forms.Label();
            this.lblGananciaLbl         = new System.Windows.Forms.Label();
            this.lblGananciaVal         = new System.Windows.Forms.Label();
            this.lblMargenLbl           = new System.Windows.Forms.Label();
            this.prgMargen              = new System.Windows.Forms.ProgressBar();
            this.lblMargenPorcentaje    = new System.Windows.Forms.Label();
            this.lblNotaCosto           = new System.Windows.Forms.Label();

            // ── Botones globales barra inferior ──
            this.pnlBotonesInf          = new System.Windows.Forms.Panel();
            this.btnGuardarReceta       = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiarReceta       = new Guna.UI2.WinForms.Guna2Button();
            this.btnActualizar          = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // ════════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════════
            this.Text            = "Gestión de Recetas - Sabor Gourmet FMO";
            this.Size            = new System.Drawing.Size(1366, 768);
            this.MinimumSize     = new System.Drawing.Size(1100, 700);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = System.Drawing.Color.FromArgb(240, 240, 248);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);

            // ════════════════════════════════════════════════════
            // BARRA SUPERIOR
            // ════════════════════════════════════════════════════
            this.pnlTopBar.Dock            = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height          = 65;
            this.pnlTopBar.FillColor       = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlTopBar.BorderRadius    = 0;
            this.pnlTopBar.ShadowDecoration.Enabled = false;

            // Ícono formulario
            this.picIcono.Size      = new System.Drawing.Size(42, 42);
            this.picIcono.Location  = new System.Drawing.Point(14, 12);
            this.picIcono.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcono.Image     = null;
            this.picIcono.BackColor = System.Drawing.Color.Transparent;

            // Título
            this.lblTitulo.Text      = "Gestión de Recetas";
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(64, 10);
            this.lblTitulo.AutoSize  = true;

            // Subtítulo
            this.lblSubtitulo.Text      = "Sabor Gourmet FMO";
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 180, 210);
            this.lblSubtitulo.Location  = new System.Drawing.Point(66, 34);
            this.lblSubtitulo.AutoSize  = true;

            // Ícono usuario (derecha)
            this.picUsuario.Size      = new System.Drawing.Size(36, 36);
            this.picUsuario.Location  = new System.Drawing.Point(1240, 15);
            this.picUsuario.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsuario.Image     = null;
            this.picUsuario.BackColor = System.Drawing.Color.Transparent;

            // Label usuario
            this.lblUsuario.Text      = "Administrador";
            this.lblUsuario.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location  = new System.Drawing.Point(1282, 14);
            this.lblUsuario.AutoSize  = true;

            this.lblUsuarioFlecha.Text      = "▾";
            this.lblUsuarioFlecha.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuarioFlecha.ForeColor = System.Drawing.Color.FromArgb(180, 180, 210);
            this.lblUsuarioFlecha.Location  = new System.Drawing.Point(1340, 34);
            this.lblUsuarioFlecha.AutoSize  = true;

            this.pnlTopBar.Controls.Add(this.picIcono);
            this.pnlTopBar.Controls.Add(this.lblTitulo);
            this.pnlTopBar.Controls.Add(this.lblSubtitulo);
            this.pnlTopBar.Controls.Add(this.picUsuario);
            this.pnlTopBar.Controls.Add(this.lblUsuario);
            this.pnlTopBar.Controls.Add(this.lblUsuarioFlecha);

            // ════════════════════════════════════════════════════
            // PANEL PRODUCTO — superior izquierdo
            // ════════════════════════════════════════════════════
            this.pnlProducto.Location        = new System.Drawing.Point(12, 77);
            this.pnlProducto.Size            = new System.Drawing.Size(460, 380);
            this.pnlProducto.FillColor       = System.Drawing.Color.White;
            this.pnlProducto.BorderRadius    = 12;
            this.pnlProducto.ShadowDecoration.Enabled  = true;
            this.pnlProducto.ShadowDecoration.Color    = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            this.pnlProducto.ShadowDecoration.Depth    = 4;

            // Título sección
            this.lblTituloProducto.Text      = "Producto";
            this.lblTituloProducto.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloProducto.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloProducto.Location  = new System.Drawing.Point(14, 12);
            this.lblTituloProducto.AutoSize  = true;

            // Búsqueda
            this.txtBuscarProducto.Location        = new System.Drawing.Point(14, 40);
            this.txtBuscarProducto.Size            = new System.Drawing.Size(428, 36);
            this.txtBuscarProducto.PlaceholderText = "Buscar producto...";
            this.txtBuscarProducto.Font            = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarProducto.BorderRadius    = 8;
            this.txtBuscarProducto.FillColor       = System.Drawing.Color.FromArgb(245, 245, 252);
            this.txtBuscarProducto.BorderColor     = System.Drawing.Color.FromArgb(200, 200, 220);

            // Filtro categoría
            this.lblFiltrarCategoria.Text      = "Filtrar por Categoría:";
            this.lblFiltrarCategoria.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltrarCategoria.ForeColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.lblFiltrarCategoria.Location  = new System.Drawing.Point(14, 88);
            this.lblFiltrarCategoria.AutoSize  = true;

            this.cmbCategoriaFiltro.Location     = new System.Drawing.Point(150, 84);
            this.cmbCategoriaFiltro.Size         = new System.Drawing.Size(292, 36);
            this.cmbCategoriaFiltro.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoriaFiltro.BorderRadius = 8;
            this.cmbCategoriaFiltro.FillColor    = System.Drawing.Color.FromArgb(245, 245, 252);
            this.cmbCategoriaFiltro.BorderColor  = System.Drawing.Color.FromArgb(200, 200, 220);
            this.cmbCategoriaFiltro.Items.Add("Todas las categorías");

            // DataGridView productos
            this.dgvProductos.Location               = new System.Drawing.Point(14, 130);
            this.dgvProductos.Size                   = new System.Drawing.Size(428, 220);
            this.dgvProductos.AllowUserToAddRows     = false;
            this.dgvProductos.AllowUserToDeleteRows  = false;
            this.dgvProductos.ReadOnly               = true;
            this.dgvProductos.SelectionMode          = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.MultiSelect            = false;
            this.dgvProductos.RowHeadersVisible      = false;
            this.dgvProductos.BorderStyle            = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.BackgroundColor        = System.Drawing.Color.White;
            this.dgvProductos.GridColor              = System.Drawing.Color.FromArgb(230, 230, 240);
            this.dgvProductos.AutoSizeColumnsMode    = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersDefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor  = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersDefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvProductos.ColumnHeadersBorderStyle                 = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.DefaultCellStyle.SelectionBackColor      = System.Drawing.Color.FromArgb(37, 99, 235);
            this.dgvProductos.DefaultCellStyle.SelectionForeColor      = System.Drawing.Color.White;
            this.dgvProductos.DefaultCellStyle.Font                    = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProductos.RowTemplate.Height                       = 28;
            this.dgvProductos.EnableHeadersVisualStyles                = false;

            // Columnas dgvProductos
            this.colNombreProducto.Name           = "colNombreProducto";
            this.colNombreProducto.HeaderText     = "Nombre Producto";
            this.colNombreProducto.DataPropertyName = "nombre_producto";
            this.colNombreProducto.FillWeight     = 45;

            this.colCategoria.Name                = "colCategoria";
            this.colCategoria.HeaderText          = "Categoría";
            this.colCategoria.DataPropertyName    = "nombre_categoria";
            this.colCategoria.FillWeight          = 35;

            this.colNumIngredientes.Name          = "colNumIngredientes";
            this.colNumIngredientes.HeaderText    = "# Ingredientes";
            this.colNumIngredientes.DataPropertyName = "num_ingredientes";
            this.colNumIngredientes.FillWeight    = 20;

            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombreProducto,
            this.colCategoria,
            this.colNumIngredientes
        });

            // Total productos
            this.lblTotalProductos.Text      = "Total productos: 0";
            this.lblTotalProductos.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblTotalProductos.Location  = new System.Drawing.Point(14, 358);
            this.lblTotalProductos.AutoSize  = true;

            this.pnlProducto.Controls.Add(this.lblTituloProducto);
            this.pnlProducto.Controls.Add(this.txtBuscarProducto);
            this.pnlProducto.Controls.Add(this.lblFiltrarCategoria);
            this.pnlProducto.Controls.Add(this.cmbCategoriaFiltro);
            this.pnlProducto.Controls.Add(this.dgvProductos);
            this.pnlProducto.Controls.Add(this.lblTotalProductos);

            // ════════════════════════════════════════════════════
            // PANEL RECETA — superior derecho
            // ════════════════════════════════════════════════════
            this.pnlReceta.Location        = new System.Drawing.Point(482, 77);
            this.pnlReceta.Size            = new System.Drawing.Size(868, 380);
            this.pnlReceta.FillColor       = System.Drawing.Color.White;
            this.pnlReceta.BorderRadius    = 12;
            this.pnlReceta.ShadowDecoration.Enabled = true;
            this.pnlReceta.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            this.pnlReceta.ShadowDecoration.Depth   = 4;

            // Nombre receta
            this.lblNombreReceta.Text      = "Receta: [Seleccione un producto]";
            this.lblNombreReceta.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblNombreReceta.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblNombreReceta.Location  = new System.Drawing.Point(16, 14);
            this.lblNombreReceta.AutoSize  = true;

            // Info receta (categoría | precio | tiempo)
            this.lblInfoReceta.Text      = "Categoría: — | Precio: $0.00 | Tiempo: — min";
            this.lblInfoReceta.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoReceta.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblInfoReceta.Location  = new System.Drawing.Point(18, 48);
            this.lblInfoReceta.AutoSize  = true;

            // DataGridView receta
            this.dgvReceta.Location              = new System.Drawing.Point(14, 72);
            this.dgvReceta.Size                  = new System.Drawing.Size(836, 290);
            this.dgvReceta.AllowUserToAddRows    = false;
            this.dgvReceta.AllowUserToDeleteRows = false;
            this.dgvReceta.ReadOnly              = false;
            this.dgvReceta.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceta.MultiSelect           = false;
            this.dgvReceta.RowHeadersVisible     = false;
            this.dgvReceta.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvReceta.BackgroundColor       = System.Drawing.Color.White;
            this.dgvReceta.GridColor             = System.Drawing.Color.FromArgb(230, 230, 240);
            this.dgvReceta.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceta.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvReceta.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReceta.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvReceta.ColumnHeadersBorderStyle                = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReceta.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvReceta.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(220, 230, 255);
            this.dgvReceta.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvReceta.RowTemplate.Height                      = 30;
            this.dgvReceta.EnableHeadersVisualStyles               = false;

            // Columnas dgvReceta
            this.colIngrediente.Name              = "colIngrediente";
            this.colIngrediente.HeaderText        = "Ingrediente";
            this.colIngrediente.DataPropertyName  = "nombre_ingrediente";
            this.colIngrediente.ReadOnly          = true;
            this.colIngrediente.FillWeight        = 40;

            this.colUnidadMedida.Name             = "colUnidadMedida";
            this.colUnidadMedida.HeaderText       = "Unidad de Medida";
            this.colUnidadMedida.DataPropertyName = "unidad_medida";
            this.colUnidadMedida.ReadOnly         = true;
            this.colUnidadMedida.FillWeight       = 25;

            this.colCantidad.Name                 = "colCantidad";
            this.colCantidad.HeaderText           = "Cantidad";
            this.colCantidad.DataPropertyName     = "cantidad_receta";
            this.colCantidad.ReadOnly             = true;
            this.colCantidad.FillWeight           = 20;
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colAcciones.Name                 = "colAcciones";
            this.colAcciones.HeaderText           = "Acciones";
            this.colAcciones.Text                 = "";
            this.colAcciones.UseColumnTextForButtonValue = true;
            this.colAcciones.FillWeight           = 15;
            this.colAcciones.DefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(254, 226, 226);
            this.colAcciones.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(239, 68, 68);
            this.colAcciones.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 11F);
            this.colAcciones.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvReceta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIngrediente,
            this.colUnidadMedida,
            this.colCantidad,
            this.colAcciones
        });

            this.pnlReceta.Controls.Add(this.lblNombreReceta);
            this.pnlReceta.Controls.Add(this.lblInfoReceta);
            this.pnlReceta.Controls.Add(this.dgvReceta);


            this.pnlAgregarIngrediente.Location     = new System.Drawing.Point(12, 467);
            this.pnlAgregarIngrediente.Size         = new System.Drawing.Size(686, 220);
            this.pnlAgregarIngrediente.FillColor    = System.Drawing.Color.White;
            this.pnlAgregarIngrediente.BorderRadius = 12;
            this.pnlAgregarIngrediente.ShadowDecoration.Enabled = true;
            this.pnlAgregarIngrediente.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            this.pnlAgregarIngrediente.ShadowDecoration.Depth   = 4;

            this.pnlAgregarIngrediente.BorderColor  = System.Drawing.Color.FromArgb(37, 99, 235);

            // Título agregar
            this.lblTituloAgregar.Text      = "Agregar Ingrediente a Receta";
            this.lblTituloAgregar.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloAgregar.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblTituloAgregar.Location  = new System.Drawing.Point(14, 12);
            this.lblTituloAgregar.AutoSize  = true;

            // Label seleccionar ingrediente
            this.lblSelIngrediente.Text      = "Seleccionar Ingrediente";
            this.lblSelIngrediente.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelIngrediente.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblSelIngrediente.Location  = new System.Drawing.Point(14, 46);
            this.lblSelIngrediente.AutoSize  = true;

            // ComboBox ingrediente
            this.cmbIngrediente.Location     = new System.Drawing.Point(14, 68);
            this.cmbIngrediente.Size         = new System.Drawing.Size(380, 36);
            this.cmbIngrediente.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbIngrediente.BorderRadius = 8;
            this.cmbIngrediente.FillColor    = System.Drawing.Color.FromArgb(245, 245, 252);
            this.cmbIngrediente.BorderColor  = System.Drawing.Color.FromArgb(200, 200, 220);
            this.cmbIngrediente.PlaceholderText = "Seleccione un ingrediente...";

            // Label cantidad requerida
            this.lblCantidadReq.Text      = "Cantidad requerida";
            this.lblCantidadReq.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidadReq.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblCantidadReq.Location  = new System.Drawing.Point(410, 46);
            this.lblCantidadReq.AutoSize  = true;

            // NumericUpDown cantidad
            this.nudCantidad.Location       = new System.Drawing.Point(410, 68);
            this.nudCantidad.Size           = new System.Drawing.Size(258, 36);
            this.nudCantidad.Font           = new System.Drawing.Font("Segoe UI", 10F);
            this.nudCantidad.DecimalPlaces  = 3;
            this.nudCantidad.Minimum        = 0;
            this.nudCantidad.Maximum        = 99999;
            this.nudCantidad.Value          = 0;
            this.nudCantidad.Increment      = (decimal)0.001;
            this.nudCantidad.BorderStyle    = System.Windows.Forms.BorderStyle.FixedSingle;

            // Label unidad de medida
            this.lblUnidadMedida.Text      = "Unidad de medida";
            this.lblUnidadMedida.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnidadMedida.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblUnidadMedida.Location  = new System.Drawing.Point(14, 116);
            this.lblUnidadMedida.AutoSize  = true;

            // TextBox unidad medida (solo lectura)
            this.txtUnidadMedida.Location      = new System.Drawing.Point(14, 138);
            this.txtUnidadMedida.Size          = new System.Drawing.Size(240, 36);
            this.txtUnidadMedida.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUnidadMedida.ReadOnly      = true;
            this.txtUnidadMedida.Text          = "---";
            this.txtUnidadMedida.BorderRadius  = 8;
            this.txtUnidadMedida.FillColor     = System.Drawing.Color.FromArgb(240, 240, 248);
            this.txtUnidadMedida.BorderColor   = System.Drawing.Color.FromArgb(200, 200, 220);

            // Panel advertencia (ingrediente duplicado)
            this.pnlAdvertencia.Location  = new System.Drawing.Point(14, 140);
            this.pnlAdvertencia.Size      = new System.Drawing.Size(654, 36);
            this.pnlAdvertencia.BackColor = System.Drawing.Color.FromArgb(255, 247, 230);
            this.pnlAdvertencia.Visible   = false;

            this.lblAdvertencia.Text      = " Este ingrediente ya está en la receta";
            this.lblAdvertencia.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(180, 90, 0);
            this.lblAdvertencia.Location  = new System.Drawing.Point(10, 9);
            this.lblAdvertencia.AutoSize  = true;
            this.pnlAdvertencia.Controls.Add(this.lblAdvertencia);

            // Botón agregar a receta
            this.btnAgregarReceta.Text              = "+ Agregar a Receta";
            this.btnAgregarReceta.Location          = new System.Drawing.Point(14, 182);
            this.btnAgregarReceta.Size              = new System.Drawing.Size(654, 30);
            this.btnAgregarReceta.Font              = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarReceta.FillColor         = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnAgregarReceta.ForeColor         = System.Drawing.Color.White;
            this.btnAgregarReceta.BorderRadius      = 8;
            this.btnAgregarReceta.ShadowDecoration.Enabled = false;

            this.pnlAgregarIngrediente.Controls.Add(this.lblTituloAgregar);
            this.pnlAgregarIngrediente.Controls.Add(this.lblSelIngrediente);
            this.pnlAgregarIngrediente.Controls.Add(this.cmbIngrediente);
            this.pnlAgregarIngrediente.Controls.Add(this.lblCantidadReq);
            this.pnlAgregarIngrediente.Controls.Add(this.nudCantidad);
            this.pnlAgregarIngrediente.Controls.Add(this.lblUnidadMedida);
            this.pnlAgregarIngrediente.Controls.Add(this.txtUnidadMedida);
            this.pnlAgregarIngrediente.Controls.Add(this.pnlAdvertencia);
            this.pnlAgregarIngrediente.Controls.Add(this.btnAgregarReceta);

            // ════════════════════════════════════════════════════
            // PANEL ANÁLISIS DE COSTO — inferior derecho
            // ════════════════════════════════════════════════════
            this.pnlAnalisisCosto.Location     = new System.Drawing.Point(708, 467);
            this.pnlAnalisisCosto.Size         = new System.Drawing.Size(642, 220);
            this.pnlAnalisisCosto.FillColor    = System.Drawing.Color.White;
            this.pnlAnalisisCosto.BorderRadius = 12;
            this.pnlAnalisisCosto.ShadowDecoration.Enabled = true;
            this.pnlAnalisisCosto.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            this.pnlAnalisisCosto.ShadowDecoration.Depth   = 4;
            this.pnlAnalisisCosto.BorderColor  = System.Drawing.Color.FromArgb(168, 85, 247);

            // Título análisis
            this.lblTituloAnalisis.Text      = "Análisis de Costo";
            this.lblTituloAnalisis.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloAnalisis.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblTituloAnalisis.Location  = new System.Drawing.Point(16, 14);
            this.lblTituloAnalisis.AutoSize  = true;

            // Costo de producción
            this.lblCostoProduccionLbl.Text      = "Costo de producción:";
            this.lblCostoProduccionLbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCostoProduccionLbl.ForeColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.lblCostoProduccionLbl.Location  = new System.Drawing.Point(16, 58);
            this.lblCostoProduccionLbl.AutoSize  = true;

            this.lblCostoProduccionVal.Text      = "$ 0.00";
            this.lblCostoProduccionVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCostoProduccionVal.ForeColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.lblCostoProduccionVal.Location  = new System.Drawing.Point(520, 58);
            this.lblCostoProduccionVal.AutoSize  = true;
            this.lblCostoProduccionVal.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // Precio de venta
            this.lblPrecioVentaLbl.Text      = "Precio de venta:";
            this.lblPrecioVentaLbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrecioVentaLbl.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblPrecioVentaLbl.Location  = new System.Drawing.Point(16, 90);
            this.lblPrecioVentaLbl.AutoSize  = true;

            this.lblPrecioVentaVal.Text      = "$ 0.00";
            this.lblPrecioVentaVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrecioVentaVal.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblPrecioVentaVal.Location  = new System.Drawing.Point(520, 90);
            this.lblPrecioVentaVal.AutoSize  = true;
            this.lblPrecioVentaVal.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // Ganancia estimada
            this.lblGananciaLbl.Text      = "Ganancia estimada:";
            this.lblGananciaLbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGananciaLbl.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblGananciaLbl.Location  = new System.Drawing.Point(16, 122);
            this.lblGananciaLbl.AutoSize  = true;

            this.lblGananciaVal.Text      = "$ 0.00";
            this.lblGananciaVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGananciaVal.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblGananciaVal.Location  = new System.Drawing.Point(520, 122);
            this.lblGananciaVal.AutoSize  = true;
            this.lblGananciaVal.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // Margen de ganancia
            this.lblMargenLbl.Text      = "Margen de ganancia:";
            this.lblMargenLbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMargenLbl.ForeColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.lblMargenLbl.Location  = new System.Drawing.Point(16, 156);
            this.lblMargenLbl.AutoSize  = true;

            this.prgMargen.Location = new System.Drawing.Point(140, 156);
            this.prgMargen.Size     = new System.Drawing.Size(380, 18);
            this.prgMargen.Minimum  = 0;
            this.prgMargen.Maximum  = 100;
            this.prgMargen.Value    = 0;
            this.prgMargen.Style    = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.lblMargenPorcentaje.Text      = "0.0%";
            this.lblMargenPorcentaje.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMargenPorcentaje.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblMargenPorcentaje.Location  = new System.Drawing.Point(530, 154);
            this.lblMargenPorcentaje.AutoSize  = true;

            // Nota basado en costos
            this.lblNotaCosto.Text      = "Basado en costos unitarios de inventario";
            this.lblNotaCosto.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNotaCosto.ForeColor = System.Drawing.Color.FromArgb(140, 140, 160);
            this.lblNotaCosto.Location  = new System.Drawing.Point(16, 186);
            this.lblNotaCosto.AutoSize  = true;

            this.pnlAnalisisCosto.Controls.Add(this.lblTituloAnalisis);
            this.pnlAnalisisCosto.Controls.Add(this.lblCostoProduccionLbl);
            this.pnlAnalisisCosto.Controls.Add(this.lblCostoProduccionVal);
            this.pnlAnalisisCosto.Controls.Add(this.lblPrecioVentaLbl);
            this.pnlAnalisisCosto.Controls.Add(this.lblPrecioVentaVal);
            this.pnlAnalisisCosto.Controls.Add(this.lblGananciaLbl);
            this.pnlAnalisisCosto.Controls.Add(this.lblGananciaVal);
            this.pnlAnalisisCosto.Controls.Add(this.lblMargenLbl);
            this.pnlAnalisisCosto.Controls.Add(this.prgMargen);
            this.pnlAnalisisCosto.Controls.Add(this.lblMargenPorcentaje);
            this.pnlAnalisisCosto.Controls.Add(this.lblNotaCosto);

            // ════════════════════════════════════════════════════
            // BARRA INFERIOR — BOTONES GLOBALES
            // ════════════════════════════════════════════════════
            this.pnlBotonesInf.Location  = new System.Drawing.Point(0, 695);
            this.pnlBotonesInf.Size      = new System.Drawing.Size(1366, 58);
            this.pnlBotonesInf.BackColor = System.Drawing.Color.FromArgb(230, 230, 242);
            this.pnlBotonesInf.Dock      = System.Windows.Forms.DockStyle.Bottom;

            // Guardar Receta
            this.btnGuardarReceta.Text         = " Guardar Receta";
            this.btnGuardarReceta.Location     = new System.Drawing.Point(12, 10);
            this.btnGuardarReceta.Size         = new System.Drawing.Size(185, 38);
            this.btnGuardarReceta.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarReceta.FillColor    = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardarReceta.ForeColor    = System.Drawing.Color.White;
            this.btnGuardarReceta.BorderRadius = 8;
            this.btnGuardarReceta.ShadowDecoration.Enabled = false;

            // Limpiar Receta
            this.btnLimpiarReceta.Text         = "  Limpiar Receta";
            this.btnLimpiarReceta.Location     = new System.Drawing.Point(207, 10);
            this.btnLimpiarReceta.Size         = new System.Drawing.Size(185, 38);
            this.btnLimpiarReceta.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarReceta.FillColor    = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnLimpiarReceta.ForeColor    = System.Drawing.Color.White;
            this.btnLimpiarReceta.BorderRadius = 8;
            this.btnLimpiarReceta.ShadowDecoration.Enabled = false;

            // Actualizar
            this.btnActualizar.Text         = " Actualizar";
            this.btnActualizar.Location     = new System.Drawing.Point(402, 10);
            this.btnActualizar.Size         = new System.Drawing.Size(160, 38);
            this.btnActualizar.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.FillColor    = System.Drawing.Color.FromArgb(200, 200, 215);
            this.btnActualizar.ForeColor    = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnActualizar.BorderRadius = 8;
            this.btnActualizar.ShadowDecoration.Enabled = false;

            this.pnlBotonesInf.Controls.Add(this.btnGuardarReceta);
            this.pnlBotonesInf.Controls.Add(this.btnLimpiarReceta);
            this.pnlBotonesInf.Controls.Add(this.btnActualizar);


            this.Load
                += new System.EventHandler(this.frmRecetas_Load);
            this.txtBuscarProducto.TextChanged
                += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            this.cmbCategoriaFiltro.SelectedIndexChanged
                += new System.EventHandler(this.cmbCategoriaFiltro_SelectedIndexChanged);
            this.dgvProductos.SelectionChanged
                += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.dgvReceta.CellClick
                += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceta_CellClick);
            this.cmbIngrediente.SelectedIndexChanged
                += new System.EventHandler(this.cmbIngrediente_SelectedIndexChanged);
            this.btnAgregarReceta.Click
                += new System.EventHandler(this.btnAgregarReceta_Click);
            this.btnGuardarReceta.Click
                += new System.EventHandler(this.btnGuardarReceta_Click);
            this.btnLimpiarReceta.Click
                += new System.EventHandler(this.btnLimpiarReceta_Click);
            this.btnActualizar.Click
                += new System.EventHandler(this.btnActualizar_Click);

            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlProducto);
            this.Controls.Add(this.pnlReceta);
            this.Controls.Add(this.pnlAgregarIngrediente);
            this.Controls.Add(this.pnlAnalisisCosto);
            this.Controls.Add(this.pnlBotonesInf);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion


        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picIcono;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblUsuarioFlecha;

        // Panel Producto
        private Guna.UI2.WinForms.Guna2Panel pnlProducto;
        private System.Windows.Forms.Label lblTituloProducto;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblFiltrarCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoriaFiltro;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumIngredientes;
        private System.Windows.Forms.Label lblTotalProductos;

        // Panel Receta
        private Guna.UI2.WinForms.Guna2Panel pnlReceta;
        private System.Windows.Forms.Label lblNombreReceta;
        private System.Windows.Forms.Label lblInfoReceta;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colAcciones;

        // Panel Agregar Ingrediente
        private Guna.UI2.WinForms.Guna2Panel pnlAgregarIngrediente;
        private System.Windows.Forms.Label lblTituloAgregar;
        private System.Windows.Forms.Label lblSelIngrediente;
        private Guna.UI2.WinForms.Guna2ComboBox cmbIngrediente;
        private System.Windows.Forms.Label lblCantidadReq;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblUnidadMedida;
        private Guna.UI2.WinForms.Guna2TextBox txtUnidadMedida;
        private System.Windows.Forms.Panel pnlAdvertencia;
        private System.Windows.Forms.Label lblAdvertencia;
        private Guna.UI2.WinForms.Guna2Button btnAgregarReceta;

        // Panel Análisis de Costo
        private Guna.UI2.WinForms.Guna2Panel pnlAnalisisCosto;
        private System.Windows.Forms.Label lblTituloAnalisis;
        private System.Windows.Forms.Label lblCostoProduccionLbl;
        private System.Windows.Forms.Label lblCostoProduccionVal;
        private System.Windows.Forms.Label lblPrecioVentaLbl;
        private System.Windows.Forms.Label lblPrecioVentaVal;
        private System.Windows.Forms.Label lblGananciaLbl;
        private System.Windows.Forms.Label lblGananciaVal;
        private System.Windows.Forms.Label lblMargenLbl;
        private System.Windows.Forms.ProgressBar prgMargen;
        private System.Windows.Forms.Label lblMargenPorcentaje;
        private System.Windows.Forms.Label lblNotaCosto;

        // Barra inferior
        private System.Windows.Forms.Panel pnlBotonesInf;
        private Guna.UI2.WinForms.Guna2Button btnGuardarReceta;
        private Guna.UI2.WinForms.Guna2Button btnLimpiarReceta;
        private Guna.UI2.WinForms.Guna2Button btnActualizar;
    }
}