namespace Restaurante_Sabor_Gourmet.Vane
{
    partial class frmMenu
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

            // ── TOP BAR ──────────────────────────────────────────────────────────
            this.pnlTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.picIconoApp = new System.Windows.Forms.PictureBox();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.picAvatarUsuario = new System.Windows.Forms.PictureBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();

            // ── TAB CONTROL ──────────────────────────────────────────────────────
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.tabCategorias = new System.Windows.Forms.TabPage();

            // ── TAB PRODUCTOS ─ KPI CARDS ─────────────────────────────────────
            this.pnlCardTotal = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardTotal = new System.Windows.Forms.PictureBox();
            this.lblCardTotalTitulo = new System.Windows.Forms.Label();
            this.lblCardTotalValor = new System.Windows.Forms.Label();

            this.pnlCardDisponibles = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardDisponibles = new System.Windows.Forms.PictureBox();
            this.lblCardDispTitulo = new System.Windows.Forms.Label();
            this.lblCardDispValor = new System.Windows.Forms.Label();

            this.pnlCardNoDisponibles = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardNoDisp = new System.Windows.Forms.PictureBox();
            this.lblCardNoDispTitulo = new System.Windows.Forms.Label();
            this.lblCardNoDispValor = new System.Windows.Forms.Label();

            // ── TAB PRODUCTOS ─ PANEL IZQUIERDO (lista) ──────────────────────
            this.pnlListaProductos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblListaTitulo = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFiltroCategoria = new System.Windows.Forms.Label();
            this.cmbFiltroCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSoloDisponibles = new System.Windows.Forms.Label();
            this.tglSoloDisponibles = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.dgvProductos = new System.Windows.Forms.DataGridView();

            // ── TAB PRODUCTOS ─ PANEL DERECHO (formulario) ───────────────────
            this.pnlFormProducto = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTiempoPrep = new System.Windows.Forms.Label();
            this.txtTiempoPrep = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.tglDisponible = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lblDisponibleTexto = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();

            // ── TAB PRODUCTOS ─ BOTONES INFERIORES ──────────────────────────
            this.pnlBotonesInferiores = new Guna.UI2.WinForms.Guna2Panel();
            this.btnNuevoProducto = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnActualizarLista = new Guna.UI2.WinForms.Guna2Button();

            // ── TAB CATEGORÍAS ────────────────────────────────────────────────
            this.pnlListaCategorias = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCatListaTitulo = new System.Windows.Forms.Label();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();

            this.pnlFormCategoria = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCatFormTitulo = new System.Windows.Forms.Label();
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.txtNombreCategoria = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGuardarCategoria = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminarCategoria = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiarCategoria = new Guna.UI2.WinForms.Guna2Button();
            this.btnNuevaCategoria = new Guna.UI2.WinForms.Guna2Button();

            // ── DGV COLUMNS ─ PRODUCTOS ───────────────────────────────────────
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoPrep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── DGV COLUMNS ─ CATEGORIAS ─────────────────────────────────────
            this.colCatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCatNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCatProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconoApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatarUsuario)).BeginInit();
            this.tabMenu.SuspendLayout();
            this.tabProductos.SuspendLayout();
            this.tabCategorias.SuspendLayout();
            this.pnlCardTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardTotal)).BeginInit();
            this.pnlCardDisponibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardDisponibles)).BeginInit();
            this.pnlCardNoDisponibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardNoDisp)).BeginInit();
            this.pnlListaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlFormProducto.SuspendLayout();
            this.pnlBotonesInferiores.SuspendLayout();
            this.pnlListaCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.pnlFormCategoria.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════════
            // TOP BAR
            // ════════════════════════════════════════════════════════════════════
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlTopBar.BorderRadius = 0;
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1366, 70);
            this.pnlTopBar.TabIndex = 0;
            this.pnlTopBar.Controls.Add(this.picIconoApp);
            this.pnlTopBar.Controls.Add(this.lblTituloForm);
            this.pnlTopBar.Controls.Add(this.lblSubtitulo);
            this.pnlTopBar.Controls.Add(this.picAvatarUsuario);
            this.pnlTopBar.Controls.Add(this.lblNombreUsuario);

            // picIconoApp
            this.picIconoApp.BackColor = System.Drawing.Color.Transparent;
            this.picIconoApp.Image = null;
            this.picIconoApp.Location = new System.Drawing.Point(15, 13);
            this.picIconoApp.Name = "picIconoApp";
            this.picIconoApp.Size = new System.Drawing.Size(44, 44);
            this.picIconoApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconoApp.TabIndex = 0;
            this.picIconoApp.TabStop = false;

            // lblTituloForm
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(68, 12);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(180, 25);
            this.lblTituloForm.TabIndex = 1;
            this.lblTituloForm.Text = "Gestión de Menú";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(70, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(130, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Sabor Gourmet FMO";

            // picAvatarUsuario
            this.picAvatarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.picAvatarUsuario.Image = null;
            this.picAvatarUsuario.Location = new System.Drawing.Point(1270, 18);
            this.picAvatarUsuario.Name = "picAvatarUsuario";
            this.picAvatarUsuario.Size = new System.Drawing.Size(34, 34);
            this.picAvatarUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatarUsuario.TabIndex = 3;
            this.picAvatarUsuario.TabStop = false;

            // lblNombreUsuario
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(1185, 26);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(80, 17);
            this.lblNombreUsuario.TabIndex = 4;
            this.lblNombreUsuario.Text = "Administrador";

            // ════════════════════════════════════════════════════════════════════
            // TAB CONTROL
            // ════════════════════════════════════════════════════════════════════
            this.tabMenu.Controls.Add(this.tabProductos);
            this.tabMenu.Controls.Add(this.tabCategorias);
            this.tabMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabMenu.Location = new System.Drawing.Point(12, 80);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1342, 628);
            this.tabMenu.TabIndex = 1;

            // tabProductos
            this.tabProductos.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.tabProductos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabProductos.Location = new System.Drawing.Point(4, 28);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Size = new System.Drawing.Size(1334, 596);
            this.tabProductos.TabIndex = 0;
            this.tabProductos.Text = "  Productos";
            this.tabProductos.Controls.Add(this.pnlCardTotal);
            this.tabProductos.Controls.Add(this.pnlCardDisponibles);
            this.tabProductos.Controls.Add(this.pnlCardNoDisponibles);
            this.tabProductos.Controls.Add(this.pnlListaProductos);
            this.tabProductos.Controls.Add(this.pnlFormProducto);
            this.tabProductos.Controls.Add(this.pnlBotonesInferiores);

            // tabCategorias
            this.tabCategorias.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.tabCategorias.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabCategorias.Location = new System.Drawing.Point(4, 28);
            this.tabCategorias.Name = "tabCategorias";
            this.tabCategorias.Size = new System.Drawing.Size(1334, 596);
            this.tabCategorias.TabIndex = 1;
            this.tabCategorias.Text = "  Categorías";
            this.tabCategorias.Controls.Add(this.pnlListaCategorias);
            this.tabCategorias.Controls.Add(this.pnlFormCategoria);

            // ════════════════════════════════════════════════════════════════════
            // KPI CARD — TOTAL PRODUCTOS
            // ════════════════════════════════════════════════════════════════════
            this.pnlCardTotal.BackColor = System.Drawing.Color.White;
            this.pnlCardTotal.BorderRadius = 12;
            this.pnlCardTotal.ShadowDecoration.Enabled = true;
            this.pnlCardTotal.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlCardTotal.ShadowDecoration.Depth = 4;
            this.pnlCardTotal.Location = new System.Drawing.Point(10, 10);
            this.pnlCardTotal.Name = "pnlCardTotal";
            this.pnlCardTotal.Size = new System.Drawing.Size(415, 80);
            this.pnlCardTotal.TabIndex = 0;
            this.pnlCardTotal.Controls.Add(this.picCardTotal);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalTitulo);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalValor);

            this.picCardTotal.BackColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.picCardTotal.Image = null;
            this.picCardTotal.Location = new System.Drawing.Point(12, 14);
            this.picCardTotal.Name = "picCardTotal";
            this.picCardTotal.Size = new System.Drawing.Size(50, 50);
            this.picCardTotal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardTotal.TabIndex = 0;
            this.picCardTotal.TabStop = false;

            this.lblCardTotalTitulo.AutoSize = true;
            this.lblCardTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardTotalTitulo.Location = new System.Drawing.Point(72, 16);
            this.lblCardTotalTitulo.Name = "lblCardTotalTitulo";
            this.lblCardTotalTitulo.Text = "Total Productos";

            this.lblCardTotalValor.AutoSize = true;
            this.lblCardTotalValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardTotalValor.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblCardTotalValor.Location = new System.Drawing.Point(70, 36);
            this.lblCardTotalValor.Name = "lblCardTotalValor";
            this.lblCardTotalValor.Text = "0";

            // KPI CARD — DISPONIBLES
            this.pnlCardDisponibles.BackColor = System.Drawing.Color.White;
            this.pnlCardDisponibles.BorderRadius = 12;
            this.pnlCardDisponibles.ShadowDecoration.Enabled = true;
            this.pnlCardDisponibles.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlCardDisponibles.ShadowDecoration.Depth = 4;
            this.pnlCardDisponibles.Location = new System.Drawing.Point(440, 10);
            this.pnlCardDisponibles.Name = "pnlCardDisponibles";
            this.pnlCardDisponibles.Size = new System.Drawing.Size(415, 80);
            this.pnlCardDisponibles.TabIndex = 1;
            this.pnlCardDisponibles.Controls.Add(this.picCardDisponibles);
            this.pnlCardDisponibles.Controls.Add(this.lblCardDispTitulo);
            this.pnlCardDisponibles.Controls.Add(this.lblCardDispValor);

            this.picCardDisponibles.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.picCardDisponibles.Image = null;
            this.picCardDisponibles.Location = new System.Drawing.Point(12, 14);
            this.picCardDisponibles.Name = "picCardDisponibles";
            this.picCardDisponibles.Size = new System.Drawing.Size(50, 50);
            this.picCardDisponibles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardDisponibles.TabIndex = 0;
            this.picCardDisponibles.TabStop = false;

            this.lblCardDispTitulo.AutoSize = true;
            this.lblCardDispTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardDispTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardDispTitulo.Location = new System.Drawing.Point(72, 16);
            this.lblCardDispTitulo.Name = "lblCardDispTitulo";
            this.lblCardDispTitulo.Text = "Disponibles";

            this.lblCardDispValor.AutoSize = true;
            this.lblCardDispValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardDispValor.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblCardDispValor.Location = new System.Drawing.Point(70, 36);
            this.lblCardDispValor.Name = "lblCardDispValor";
            this.lblCardDispValor.Text = "0";

            // KPI CARD — NO DISPONIBLES
            this.pnlCardNoDisponibles.BackColor = System.Drawing.Color.White;
            this.pnlCardNoDisponibles.BorderRadius = 12;
            this.pnlCardNoDisponibles.ShadowDecoration.Enabled = true;
            this.pnlCardNoDisponibles.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlCardNoDisponibles.ShadowDecoration.Depth = 4;
            this.pnlCardNoDisponibles.Location = new System.Drawing.Point(870, 10);
            this.pnlCardNoDisponibles.Name = "pnlCardNoDisponibles";
            this.pnlCardNoDisponibles.Size = new System.Drawing.Size(455, 80);
            this.pnlCardNoDisponibles.TabIndex = 2;
            this.pnlCardNoDisponibles.Controls.Add(this.picCardNoDisp);
            this.pnlCardNoDisponibles.Controls.Add(this.lblCardNoDispTitulo);
            this.pnlCardNoDisponibles.Controls.Add(this.lblCardNoDispValor);

            this.picCardNoDisp.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picCardNoDisp.Image = null;
            this.picCardNoDisp.Location = new System.Drawing.Point(12, 14);
            this.picCardNoDisp.Name = "picCardNoDisp";
            this.picCardNoDisp.Size = new System.Drawing.Size(50, 50);
            this.picCardNoDisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardNoDisp.TabIndex = 0;
            this.picCardNoDisp.TabStop = false;

            this.lblCardNoDispTitulo.AutoSize = true;
            this.lblCardNoDispTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardNoDispTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardNoDispTitulo.Location = new System.Drawing.Point(72, 16);
            this.lblCardNoDispTitulo.Name = "lblCardNoDispTitulo";
            this.lblCardNoDispTitulo.Text = "No Disponibles";

            this.lblCardNoDispValor.AutoSize = true;
            this.lblCardNoDispValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardNoDispValor.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblCardNoDispValor.Location = new System.Drawing.Point(70, 36);
            this.lblCardNoDispValor.Name = "lblCardNoDispValor";
            this.lblCardNoDispValor.Text = "0";

            // ════════════════════════════════════════════════════════════════════
            // PANEL IZQUIERDO — LISTA DE PRODUCTOS
            // ════════════════════════════════════════════════════════════════════
            this.pnlListaProductos.BackColor = System.Drawing.Color.White;
            this.pnlListaProductos.BorderRadius = 12;
            this.pnlListaProductos.ShadowDecoration.Enabled = true;
            this.pnlListaProductos.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlListaProductos.ShadowDecoration.Depth = 4;
            this.pnlListaProductos.Location = new System.Drawing.Point(10, 100);
            this.pnlListaProductos.Name = "pnlListaProductos";
            this.pnlListaProductos.Size = new System.Drawing.Size(810, 440);
            this.pnlListaProductos.TabIndex = 3;
            this.pnlListaProductos.Controls.Add(this.lblListaTitulo);
            this.pnlListaProductos.Controls.Add(this.txtBuscarProducto);
            this.pnlListaProductos.Controls.Add(this.lblFiltroCategoria);
            this.pnlListaProductos.Controls.Add(this.cmbFiltroCategoria);
            this.pnlListaProductos.Controls.Add(this.lblSoloDisponibles);
            this.pnlListaProductos.Controls.Add(this.tglSoloDisponibles);
            this.pnlListaProductos.Controls.Add(this.dgvProductos);

            // lblListaTitulo
            this.lblListaTitulo.AutoSize = true;
            this.lblListaTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblListaTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblListaTitulo.Location = new System.Drawing.Point(14, 14);
            this.lblListaTitulo.Name = "lblListaTitulo";
            this.lblListaTitulo.Text = "Lista de Productos";

            // txtBuscarProducto
            this.txtBuscarProducto.BorderRadius = 8;
            this.txtBuscarProducto.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtBuscarProducto.DefaultText = "Buscar producto...";
            this.txtBuscarProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.txtBuscarProducto.FillColor = System.Drawing.Color.White;
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarProducto.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtBuscarProducto.Location = new System.Drawing.Point(14, 42);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.PlaceholderText = "Buscar producto...";
            this.txtBuscarProducto.Size = new System.Drawing.Size(220, 36);
            this.txtBuscarProducto.TabIndex = 0;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);

            // lblFiltroCategoria
            this.lblFiltroCategoria.AutoSize = true;
            this.lblFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFiltroCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblFiltroCategoria.Location = new System.Drawing.Point(250, 50);
            this.lblFiltroCategoria.Name = "lblFiltroCategoria";
            this.lblFiltroCategoria.Text = "Filtrar por Categoría:";

            // cmbFiltroCategoria
            this.cmbFiltroCategoria.BorderRadius = 8;
            this.cmbFiltroCategoria.FillColor = System.Drawing.Color.White;
            this.cmbFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.cmbFiltroCategoria.ItemHeight = 30;
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(390, 42);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(210, 36);
            this.cmbFiltroCategoria.TabIndex = 1;
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroCategoria_SelectedIndexChanged);

            // lblSoloDisponibles
            this.lblSoloDisponibles.AutoSize = true;
            this.lblSoloDisponibles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoloDisponibles.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblSoloDisponibles.Location = new System.Drawing.Point(617, 50);
            this.lblSoloDisponibles.Name = "lblSoloDisponibles";
            this.lblSoloDisponibles.Text = "Solo disponibles";

            // tglSoloDisponibles
            this.tglSoloDisponibles.CheckedState.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.tglSoloDisponibles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tglSoloDisponibles.Location = new System.Drawing.Point(730, 47);
            this.tglSoloDisponibles.Name = "tglSoloDisponibles";
            this.tglSoloDisponibles.Size = new System.Drawing.Size(55, 26);
            this.tglSoloDisponibles.TabIndex = 2;
            this.tglSoloDisponibles.CheckedChanged += new System.EventHandler(this.tglSoloDisponibles_CheckedChanged);

            // dgvProductos
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvProductos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvProductos.ColumnHeadersHeight = 38;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvProductos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 235, 255);
            this.dgvProductos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(230, 230, 245);
            this.dgvProductos.Location = new System.Drawing.Point(10, 90);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 34;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(790, 335);
            this.dgvProductos.TabIndex = 3;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // Columnas dgvProductos
            this.colCodigo.DataPropertyName = "codigo_producto";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 95;

            this.colNombre.DataPropertyName = "nombre_producto";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Width = 180;

            this.colCategoria.DataPropertyName = "nombre_categoria";
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Width = 140;

            this.colPrecio.DataPropertyName = "precio_venta";
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Width = 85;
            this.colPrecio.DefaultCellStyle.Format = "C2";
            this.colPrecio.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colTiempoPrep.DataPropertyName = "tiempo_preparacion_min";
            this.colTiempoPrep.HeaderText = "Tiempo Prep.";
            this.colTiempoPrep.Name = "colTiempoPrep";
            this.colTiempoPrep.Width = 110;

            this.colDisponible.DataPropertyName = "disponible";
            this.colDisponible.HeaderText = "Disponible";
            this.colDisponible.Name = "colDisponible";
            this.colDisponible.Width = 90;
            this.colDisponible.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCodigo, this.colNombre, this.colCategoria,
                this.colPrecio, this.colTiempoPrep, this.colDisponible });

            // ════════════════════════════════════════════════════════════════════
            // PANEL DERECHO — FORMULARIO PRODUCTO
            // ════════════════════════════════════════════════════════════════════
            this.pnlFormProducto.BackColor = System.Drawing.Color.White;
            this.pnlFormProducto.BorderRadius = 12;
            this.pnlFormProducto.ShadowDecoration.Enabled = true;
            this.pnlFormProducto.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlFormProducto.ShadowDecoration.Depth = 4;
            this.pnlFormProducto.Location = new System.Drawing.Point(832, 100);
            this.pnlFormProducto.Name = "pnlFormProducto";
            this.pnlFormProducto.Size = new System.Drawing.Size(495, 440);
            this.pnlFormProducto.TabIndex = 4;
            this.pnlFormProducto.Controls.Add(this.lblFormTitulo);
            this.pnlFormProducto.Controls.Add(this.lblCodigo);
            this.pnlFormProducto.Controls.Add(this.txtCodigo);
            this.pnlFormProducto.Controls.Add(this.lblNombreProducto);
            this.pnlFormProducto.Controls.Add(this.txtNombreProducto);
            this.pnlFormProducto.Controls.Add(this.lblDescripcion);
            this.pnlFormProducto.Controls.Add(this.txtDescripcion);
            this.pnlFormProducto.Controls.Add(this.lblCategoria);
            this.pnlFormProducto.Controls.Add(this.cmbCategoria);
            this.pnlFormProducto.Controls.Add(this.lblPrecio);
            this.pnlFormProducto.Controls.Add(this.txtPrecio);
            this.pnlFormProducto.Controls.Add(this.lblTiempoPrep);
            this.pnlFormProducto.Controls.Add(this.txtTiempoPrep);
            this.pnlFormProducto.Controls.Add(this.lblDisponible);
            this.pnlFormProducto.Controls.Add(this.tglDisponible);
            this.pnlFormProducto.Controls.Add(this.lblDisponibleTexto);
            this.pnlFormProducto.Controls.Add(this.btnGuardar);
            this.pnlFormProducto.Controls.Add(this.btnEliminar);
            this.pnlFormProducto.Controls.Add(this.btnLimpiar);

            // lblFormTitulo
            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFormTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblFormTitulo.Location = new System.Drawing.Point(14, 14);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.Text = "Datos del Producto";

            // lblCodigo
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblCodigo.Location = new System.Drawing.Point(14, 46);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Text = "Código del producto";

            // txtCodigo
            this.txtCodigo.BorderRadius = 8;
            this.txtCodigo.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtCodigo.FillColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtCodigo.Location = new System.Drawing.Point(14, 66);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(462, 36);
            this.txtCodigo.TabIndex = 0;

            // lblNombreProducto
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreProducto.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblNombreProducto.Location = new System.Drawing.Point(14, 112);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Text = "Nombre del producto";

            // txtNombreProducto
            this.txtNombreProducto.BorderRadius = 8;
            this.txtNombreProducto.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtNombreProducto.FillColor = System.Drawing.Color.White;
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreProducto.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtNombreProducto.Location = new System.Drawing.Point(14, 132);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(462, 36);
            this.txtNombreProducto.TabIndex = 1;

            // lblDescripcion
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblDescripcion.Location = new System.Drawing.Point(14, 178);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Text = "Descripción";

            // txtDescripcion
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtDescripcion.Location = new System.Drawing.Point(14, 198);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(462, 72);
            this.txtDescripcion.TabIndex = 2;

            // lblCategoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblCategoria.Location = new System.Drawing.Point(14, 282);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Text = "Categoría";

            // cmbCategoria
            this.cmbCategoria.BorderRadius = 8;
            this.cmbCategoria.FillColor = System.Drawing.Color.White;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.cmbCategoria.ItemHeight = 30;
            this.cmbCategoria.Location = new System.Drawing.Point(14, 302);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(220, 36);
            this.cmbCategoria.TabIndex = 3;

            // lblPrecio
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblPrecio.Location = new System.Drawing.Point(248, 282);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Text = "Precio de venta ($)";

            // txtPrecio
            this.txtPrecio.BorderRadius = 8;
            this.txtPrecio.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtPrecio.FillColor = System.Drawing.Color.White;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtPrecio.Location = new System.Drawing.Point(248, 302);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(228, 36);
            this.txtPrecio.TabIndex = 4;

            // lblTiempoPrep
            this.lblTiempoPrep.AutoSize = true;
            this.lblTiempoPrep.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTiempoPrep.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblTiempoPrep.Location = new System.Drawing.Point(14, 350);
            this.lblTiempoPrep.Name = "lblTiempoPrep";
            this.lblTiempoPrep.Text = "Tiempo de preparación (min)";

            // txtTiempoPrep
            this.txtTiempoPrep.BorderRadius = 8;
            this.txtTiempoPrep.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtTiempoPrep.FillColor = System.Drawing.Color.White;
            this.txtTiempoPrep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTiempoPrep.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtTiempoPrep.Location = new System.Drawing.Point(14, 370);
            this.txtTiempoPrep.Name = "txtTiempoPrep";
            this.txtTiempoPrep.Size = new System.Drawing.Size(190, 36);
            this.txtTiempoPrep.TabIndex = 5;

            // lblDisponible
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDisponible.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblDisponible.Location = new System.Drawing.Point(248, 350);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Text = "Disponible";

            // tglDisponible
            this.tglDisponible.CheckedState.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.tglDisponible.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tglDisponible.Location = new System.Drawing.Point(248, 374);
            this.tglDisponible.Name = "tglDisponible";
            this.tglDisponible.Size = new System.Drawing.Size(55, 26);
            this.tglDisponible.TabIndex = 6;
            this.tglDisponible.CheckedChanged += new System.EventHandler(this.tglDisponible_CheckedChanged);

            // lblDisponibleTexto
            this.lblDisponibleTexto.AutoSize = true;
            this.lblDisponibleTexto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDisponibleTexto.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblDisponibleTexto.Location = new System.Drawing.Point(312, 379);
            this.lblDisponibleTexto.Name = "lblDisponibleTexto";
            this.lblDisponibleTexto.Text = "Sí";

            // btnGuardar
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnGuardar.Location = new System.Drawing.Point(14, 395);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(138, 38);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "  Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnEliminar
            this.btnEliminar.BorderRadius = 8;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.HoverState.FillColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminar.Location = new System.Drawing.Point(162, 395);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(138, 38);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "  Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnLimpiar
            this.btnLimpiar.BorderRadius = 8;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(220, 220, 235);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.btnLimpiar.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 200, 215);
            this.btnLimpiar.Location = new System.Drawing.Point(310, 395);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(166, 38);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "  Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // ════════════════════════════════════════════════════════════════════
            // PANEL INFERIOR — BOTONES DE ACCIÓN
            // ════════════════════════════════════════════════════════════════════
            this.pnlBotonesInferiores.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotonesInferiores.BorderRadius = 0;
            this.pnlBotonesInferiores.Location = new System.Drawing.Point(10, 550);
            this.pnlBotonesInferiores.Name = "pnlBotonesInferiores";
            this.pnlBotonesInferiores.Size = new System.Drawing.Size(810, 50);
            this.pnlBotonesInferiores.TabIndex = 5;
            this.pnlBotonesInferiores.Controls.Add(this.btnNuevoProducto);
            this.pnlBotonesInferiores.Controls.Add(this.btnEditar);
            this.pnlBotonesInferiores.Controls.Add(this.btnActualizarLista);

            // btnNuevoProducto
            this.btnNuevoProducto.BorderRadius = 8;
            this.btnNuevoProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoProducto.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNuevoProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoProducto.ForeColor = System.Drawing.Color.White;
            this.btnNuevoProducto.HoverState.FillColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnNuevoProducto.Location = new System.Drawing.Point(0, 5);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Size = new System.Drawing.Size(175, 40);
            this.btnNuevoProducto.TabIndex = 0;
            this.btnNuevoProducto.Text = "  + Nuevo Producto";
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);

            // btnEditar
            this.btnEditar.BorderRadius = 8;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FillColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.HoverState.FillColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnEditar.Location = new System.Drawing.Point(185, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 40);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "  Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnActualizarLista
            this.btnActualizarLista.BorderRadius = 8;
            this.btnActualizarLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarLista.FillColor = System.Drawing.Color.FromArgb(220, 220, 235);
            this.btnActualizarLista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizarLista.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.btnActualizarLista.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 200, 215);
            this.btnActualizarLista.Location = new System.Drawing.Point(335, 5);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(175, 40);
            this.btnActualizarLista.TabIndex = 2;
            this.btnActualizarLista.Text = "  Actualizar lista";
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);

            // ════════════════════════════════════════════════════════════════════
            // TAB CATEGORÍAS — PANEL LISTA
            // ════════════════════════════════════════════════════════════════════
            this.pnlListaCategorias.BackColor = System.Drawing.Color.White;
            this.pnlListaCategorias.BorderRadius = 12;
            this.pnlListaCategorias.ShadowDecoration.Enabled = true;
            this.pnlListaCategorias.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlListaCategorias.ShadowDecoration.Depth = 4;
            this.pnlListaCategorias.Location = new System.Drawing.Point(10, 10);
            this.pnlListaCategorias.Name = "pnlListaCategorias";
            this.pnlListaCategorias.Size = new System.Drawing.Size(810, 570);
            this.pnlListaCategorias.TabIndex = 0;
            this.pnlListaCategorias.Controls.Add(this.lblCatListaTitulo);
            this.pnlListaCategorias.Controls.Add(this.dgvCategorias);

            this.lblCatListaTitulo.AutoSize = true;
            this.lblCatListaTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCatListaTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblCatListaTitulo.Location = new System.Drawing.Point(14, 14);
            this.lblCatListaTitulo.Name = "lblCatListaTitulo";
            this.lblCatListaTitulo.Text = "Lista de Categorías";

            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvCategorias.ColumnHeadersHeight = 38;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCategorias.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvCategorias.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 235, 255);
            this.dgvCategorias.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvCategorias.EnableHeadersVisualStyles = false;
            this.dgvCategorias.GridColor = System.Drawing.Color.FromArgb(230, 230, 245);
            this.dgvCategorias.Location = new System.Drawing.Point(10, 44);
            this.dgvCategorias.MultiSelect = false;
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.RowTemplate.Height = 34;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(790, 508);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellClick);

            this.colCatId.DataPropertyName = "id_categoria";
            this.colCatId.HeaderText = "ID";
            this.colCatId.Name = "colCatId";
            this.colCatId.Width = 60;

            this.colCatNombre.DataPropertyName = "nombre_categoria";
            this.colCatNombre.HeaderText = "Nombre de Categoría";
            this.colCatNombre.Name = "colCatNombre";
            this.colCatNombre.Width = 300;
            this.colCatNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.colCatProductos.DataPropertyName = "total_productos";
            this.colCatProductos.HeaderText = "Total Productos";
            this.colCatProductos.Name = "colCatProductos";
            this.colCatProductos.Width = 130;
            this.colCatProductos.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCatId, this.colCatNombre, this.colCatProductos });

            // ════════════════════════════════════════════════════════════════════
            // TAB CATEGORÍAS — PANEL FORMULARIO
            // ════════════════════════════════════════════════════════════════════
            this.pnlFormCategoria.BackColor = System.Drawing.Color.White;
            this.pnlFormCategoria.BorderRadius = 12;
            this.pnlFormCategoria.ShadowDecoration.Enabled = true;
            this.pnlFormCategoria.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);
            this.pnlFormCategoria.ShadowDecoration.Depth = 4;
            this.pnlFormCategoria.Location = new System.Drawing.Point(832, 10);
            this.pnlFormCategoria.Name = "pnlFormCategoria";
            this.pnlFormCategoria.Size = new System.Drawing.Size(495, 200);
            this.pnlFormCategoria.TabIndex = 1;
            this.pnlFormCategoria.Controls.Add(this.lblCatFormTitulo);
            this.pnlFormCategoria.Controls.Add(this.lblNombreCategoria);
            this.pnlFormCategoria.Controls.Add(this.txtNombreCategoria);
            this.pnlFormCategoria.Controls.Add(this.btnGuardarCategoria);
            this.pnlFormCategoria.Controls.Add(this.btnEliminarCategoria);
            this.pnlFormCategoria.Controls.Add(this.btnLimpiarCategoria);
            this.pnlFormCategoria.Controls.Add(this.btnNuevaCategoria);

            this.lblCatFormTitulo.AutoSize = true;
            this.lblCatFormTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCatFormTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblCatFormTitulo.Location = new System.Drawing.Point(14, 14);
            this.lblCatFormTitulo.Name = "lblCatFormTitulo";
            this.lblCatFormTitulo.Text = "Datos de Categoría";

            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblNombreCategoria.Location = new System.Drawing.Point(14, 46);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Text = "Nombre de la categoría";

            this.txtNombreCategoria.BorderRadius = 8;
            this.txtNombreCategoria.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtNombreCategoria.FillColor = System.Drawing.Color.White;
            this.txtNombreCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.txtNombreCategoria.Location = new System.Drawing.Point(14, 66);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(462, 36);
            this.txtNombreCategoria.TabIndex = 0;

            this.btnGuardarCategoria.BorderRadius = 8;
            this.btnGuardarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCategoria.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardarCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCategoria.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnGuardarCategoria.Location = new System.Drawing.Point(14, 118);
            this.btnGuardarCategoria.Name = "btnGuardarCategoria";
            this.btnGuardarCategoria.Size = new System.Drawing.Size(130, 38);
            this.btnGuardarCategoria.TabIndex = 1;
            this.btnGuardarCategoria.Text = "  Guardar";
            this.btnGuardarCategoria.Click += new System.EventHandler(this.btnGuardarCategoria_Click);

            this.btnEliminarCategoria.BorderRadius = 8;
            this.btnEliminarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCategoria.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminarCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCategoria.HoverState.FillColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminarCategoria.Location = new System.Drawing.Point(154, 118);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(130, 38);
            this.btnEliminarCategoria.TabIndex = 2;
            this.btnEliminarCategoria.Text = "  Eliminar";
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);

            this.btnLimpiarCategoria.BorderRadius = 8;
            this.btnLimpiarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarCategoria.FillColor = System.Drawing.Color.FromArgb(220, 220, 235);
            this.btnLimpiarCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarCategoria.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.btnLimpiarCategoria.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 200, 215);
            this.btnLimpiarCategoria.Location = new System.Drawing.Point(294, 118);
            this.btnLimpiarCategoria.Name = "btnLimpiarCategoria";
            this.btnLimpiarCategoria.Size = new System.Drawing.Size(130, 38);
            this.btnLimpiarCategoria.TabIndex = 3;
            this.btnLimpiarCategoria.Text = "  Limpiar";
            this.btnLimpiarCategoria.Click += new System.EventHandler(this.btnLimpiarCategoria_Click);

            this.btnNuevaCategoria.BorderRadius = 8;
            this.btnNuevaCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCategoria.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNuevaCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCategoria.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCategoria.HoverState.FillColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnNuevaCategoria.Location = new System.Drawing.Point(14, 162);
            this.btnNuevaCategoria.Name = "btnNuevaCategoria";
            this.btnNuevaCategoria.Size = new System.Drawing.Size(175, 38);
            this.btnNuevaCategoria.TabIndex = 4;
            this.btnNuevaCategoria.Text = "  + Nueva Categoría";
            this.btnNuevaCategoria.Click += new System.EventHandler(this.btnNuevaCategoria_Click);

            // ════════════════════════════════════════════════════════════════════
            // frmMenu — FORM PROPERTIES
            // ════════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Menú - Sabor Gourmet FMO";
            this.Load += new System.EventHandler(this.frmMenu_Load);

            // ════════════════════════════════════════════════════════════════════
            // RESUME LAYOUTS
            // ════════════════════════════════════════════════════════════════════
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconoApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatarUsuario)).EndInit();
            this.tabMenu.ResumeLayout(false);
            this.tabProductos.ResumeLayout(false);
            this.tabCategorias.ResumeLayout(false);
            this.pnlCardTotal.ResumeLayout(false);
            this.pnlCardTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardTotal)).EndInit();
            this.pnlCardDisponibles.ResumeLayout(false);
            this.pnlCardDisponibles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardDisponibles)).EndInit();
            this.pnlCardNoDisponibles.ResumeLayout(false);
            this.pnlCardNoDisponibles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardNoDisp)).EndInit();
            this.pnlListaProductos.ResumeLayout(false);
            this.pnlListaProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlFormProducto.ResumeLayout(false);
            this.pnlFormProducto.PerformLayout();
            this.pnlBotonesInferiores.ResumeLayout(false);
            this.pnlListaCategorias.ResumeLayout(false);
            this.pnlListaCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.pnlFormCategoria.ResumeLayout(false);
            this.pnlFormCategoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── TOP BAR
        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picIconoApp;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox picAvatarUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;

        // ── TABS
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TabPage tabCategorias;

        // ── KPI CARDS
        private Guna.UI2.WinForms.Guna2Panel pnlCardTotal;
        private System.Windows.Forms.PictureBox picCardTotal;
        private System.Windows.Forms.Label lblCardTotalTitulo;
        private System.Windows.Forms.Label lblCardTotalValor;

        private Guna.UI2.WinForms.Guna2Panel pnlCardDisponibles;
        private System.Windows.Forms.PictureBox picCardDisponibles;
        private System.Windows.Forms.Label lblCardDispTitulo;
        private System.Windows.Forms.Label lblCardDispValor;

        private Guna.UI2.WinForms.Guna2Panel pnlCardNoDisponibles;
        private System.Windows.Forms.PictureBox picCardNoDisp;
        private System.Windows.Forms.Label lblCardNoDispTitulo;
        private System.Windows.Forms.Label lblCardNoDispValor;

        // ── LISTA PRODUCTOS
        private Guna.UI2.WinForms.Guna2Panel pnlListaProductos;
        private System.Windows.Forms.Label lblListaTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblFiltroCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.Label lblSoloDisponibles;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tglSoloDisponibles;
        private System.Windows.Forms.DataGridView dgvProductos;

        // ── FORM PRODUCTO
        private Guna.UI2.WinForms.Guna2Panel pnlFormProducto;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombreProducto;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label lblCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblPrecio;
        private Guna.UI2.WinForms.Guna2TextBox txtPrecio;
        private System.Windows.Forms.Label lblTiempoPrep;
        private Guna.UI2.WinForms.Guna2TextBox txtTiempoPrep;
        private System.Windows.Forms.Label lblDisponible;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tglDisponible;
        private System.Windows.Forms.Label lblDisponibleTexto;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;

        // ── BOTONES INFERIORES
        private Guna.UI2.WinForms.Guna2Panel pnlBotonesInferiores;
        private Guna.UI2.WinForms.Guna2Button btnNuevoProducto;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnActualizarLista;

        // ── CATEGORÍAS
        private Guna.UI2.WinForms.Guna2Panel pnlListaCategorias;
        private System.Windows.Forms.Label lblCatListaTitulo;
        private System.Windows.Forms.DataGridView dgvCategorias;

        private Guna.UI2.WinForms.Guna2Panel pnlFormCategoria;
        private System.Windows.Forms.Label lblCatFormTitulo;
        private System.Windows.Forms.Label lblNombreCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreCategoria;
        private Guna.UI2.WinForms.Guna2Button btnGuardarCategoria;
        private Guna.UI2.WinForms.Guna2Button btnEliminarCategoria;
        private Guna.UI2.WinForms.Guna2Button btnLimpiarCategoria;
        private Guna.UI2.WinForms.Guna2Button btnNuevaCategoria;

        // ── DGV COLUMNS
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoPrep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisponible;

        private System.Windows.Forms.DataGridViewTextBoxColumn colCatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCatNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCatProductos;
    }
}