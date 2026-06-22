namespace Restaurante_Sabor_Gourmet.Vane
{
    partial class frmInventario
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

            // ── Barra superior ──
            this.pnlTopBar              = new Guna.UI2.WinForms.Guna2Panel();
            this.picIcono               = new System.Windows.Forms.PictureBox();
            this.lblTitulo              = new System.Windows.Forms.Label();
            this.lblSubtitulo           = new System.Windows.Forms.Label();
            this.picUsuario             = new System.Windows.Forms.PictureBox();
            this.lblUsuario             = new System.Windows.Forms.Label();
            this.lblUsuarioFlecha       = new System.Windows.Forms.Label();

            // ── KPI Cards ──
            this.pnlCardTotal           = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardTotal           = new System.Windows.Forms.PictureBox();
            this.lblCardTotalTitulo     = new System.Windows.Forms.Label();
            this.lblCardTotalValor      = new System.Windows.Forms.Label();

            this.pnlCardStock           = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardStock           = new System.Windows.Forms.PictureBox();
            this.lblCardStockTitulo     = new System.Windows.Forms.Label();
            this.lblCardStockValor      = new System.Windows.Forms.Label();

            this.pnlCardBajo            = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardBajo            = new System.Windows.Forms.PictureBox();
            this.lblCardBajoTitulo      = new System.Windows.Forms.Label();
            this.lblCardBajoValor       = new System.Windows.Forms.Label();

            this.pnlCardAgotado         = new Guna.UI2.WinForms.Guna2Panel();
            this.picCardAgotado         = new System.Windows.Forms.PictureBox();
            this.lblCardAgotadoTitulo   = new System.Windows.Forms.Label();
            this.lblCardAgotadoValor    = new System.Windows.Forms.Label();

            // ── Panel Lista de Ingredientes ──
            this.pnlLista               = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloLista         = new System.Windows.Forms.Label();
            this.txtBuscar              = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFiltroTodos         = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroStockBajo     = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroAgotados      = new Guna.UI2.WinForms.Guna2Button();
            this.dgvIngredientes        = new System.Windows.Forms.DataGridView();
            this.colCodigo              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngrediente         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistencia          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnit           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado              = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── Panel Registrar Movimiento ──
            this.pnlMovimiento          = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloMovimiento    = new System.Windows.Forms.Label();

            // Subpanel ingrediente seleccionado
            this.pnlIngSeleccionado     = new System.Windows.Forms.Panel();
            this.lblIngSelTitulo        = new System.Windows.Forms.Label();
            this.lblNombreIngLbl        = new System.Windows.Forms.Label();
            this.lblExistenciaLbl       = new System.Windows.Forms.Label();
            this.lblNombreIngVal        = new System.Windows.Forms.Label();
            this.lblExistenciaVal       = new System.Windows.Forms.Label();
            this.lblStockMinLbl         = new System.Windows.Forms.Label();
            this.lblUnidadMedidaLbl     = new System.Windows.Forms.Label();
            this.lblStockMinVal         = new System.Windows.Forms.Label();
            this.lblUnidadMedidaVal     = new System.Windows.Forms.Label();

            // Subpanel nuevo movimiento
            this.lblNuevoMovTitulo      = new System.Windows.Forms.Label();
            this.lblTipoMovimiento      = new System.Windows.Forms.Label();
            this.cmbTipoMovimiento      = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCantidad            = new System.Windows.Forms.Label();
            this.lblObservacion         = new System.Windows.Forms.Label();
            this.nudCantidad            = new System.Windows.Forms.NumericUpDown();
            this.txtObservacion         = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRegistrarMovimiento = new Guna.UI2.WinForms.Guna2Button();

            // ── Panel Historial ──
            this.pnlHistorial           = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloHistorial     = new System.Windows.Forms.Label();
            this.lblFechaFiltro         = new System.Windows.Forms.Label();
            this.dtpFiltroFecha         = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnLimpiarFecha        = new System.Windows.Forms.Button();
            this.dgvHistorial           = new System.Windows.Forms.DataGridView();
            this.colHFecha              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIngrediente        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTipo               = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCantidad           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUsuario            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHObservacion        = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── Barra inferior ──
            this.pnlBotonesInf          = new System.Windows.Forms.Panel();
            this.btnNuevoIngrediente    = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditarIngrediente   = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar            = new Guna.UI2.WinForms.Guna2Button();
            this.lblDeshabilitado       = new System.Windows.Forms.Label();
            this.btnActualizar          = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // ════════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════════
            this.Text            = "Control de Inventario - Sabor Gourmet FMO";
            this.Size            = new System.Drawing.Size(1366, 850);
            this.MinimumSize     = new System.Drawing.Size(1100, 750);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = System.Drawing.Color.FromArgb(240, 240, 248);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);

            // ════════════════════════════════════════════════════
            // BARRA SUPERIOR
            // ════════════════════════════════════════════════════
            this.pnlTopBar.Dock         = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height       = 65;
            this.pnlTopBar.FillColor    = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlTopBar.BorderRadius = 0;
            this.pnlTopBar.ShadowDecoration.Enabled = false;

            this.picIcono.Size      = new System.Drawing.Size(42, 42);
            this.picIcono.Location  = new System.Drawing.Point(14, 12);
            this.picIcono.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcono.Image     = null;
            this.picIcono.BackColor = System.Drawing.Color.Transparent;

            this.lblTitulo.Text      = "Control de Inventario";
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(64, 10);
            this.lblTitulo.AutoSize  = true;

            this.lblSubtitulo.Text      = "Sabor Gourmet FMO";
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 180, 210);
            this.lblSubtitulo.Location  = new System.Drawing.Point(66, 34);
            this.lblSubtitulo.AutoSize  = true;

            this.picUsuario.Size      = new System.Drawing.Size(36, 36);
            this.picUsuario.Location  = new System.Drawing.Point(1240, 15);
            this.picUsuario.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsuario.Image     = null;
            this.picUsuario.BackColor = System.Drawing.Color.Transparent;

            this.lblUsuario.Text      = "Administrador";
            this.lblUsuario.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location  = new System.Drawing.Point(1282, 18);
            this.lblUsuario.AutoSize  = true;

            this.lblUsuarioFlecha.Text      = "▾";
            this.lblUsuarioFlecha.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuarioFlecha.ForeColor = System.Drawing.Color.FromArgb(180, 180, 210);
            this.lblUsuarioFlecha.Location  = new System.Drawing.Point(1344, 36);
            this.lblUsuarioFlecha.AutoSize  = true;

            this.pnlTopBar.Controls.Add(this.picIcono);
            this.pnlTopBar.Controls.Add(this.lblTitulo);
            this.pnlTopBar.Controls.Add(this.lblSubtitulo);
            this.pnlTopBar.Controls.Add(this.picUsuario);
            this.pnlTopBar.Controls.Add(this.lblUsuario);
            this.pnlTopBar.Controls.Add(this.lblUsuarioFlecha);

            // ════════════════════════════════════════════════════
            // KPI CARDS — fila superior (4 tarjetas)
            // ════════════════════════════════════════════════════
            int cardY = 77;
            int cardH = 90;
            int cardW = 318;
            int cardGap = 12;
            int cardStartX = 12;

            // ── Card 1: Total Ingredientes (morado) ──
            this.pnlCardTotal.Location        = new System.Drawing.Point(cardStartX, cardY);
            this.pnlCardTotal.Size            = new System.Drawing.Size(cardW, cardH);
            this.pnlCardTotal.FillColor       = System.Drawing.Color.White;
            this.pnlCardTotal.BorderRadius    = 12;
            this.pnlCardTotal.ShadowDecoration.Enabled = true;
            this.pnlCardTotal.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlCardTotal.ShadowDecoration.Depth   = 4;

            this.picCardTotal.Size      = new System.Drawing.Size(48, 48);
            this.picCardTotal.Location  = new System.Drawing.Point(14, 20);
            this.picCardTotal.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardTotal.Image     = null;
            this.picCardTotal.BackColor = System.Drawing.Color.FromArgb(168, 85, 247);

            this.lblCardTotalTitulo.Text      = "Total\r\nIngredientes";
            this.lblCardTotalTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardTotalTitulo.Location  = new System.Drawing.Point(74, 14);
            this.lblCardTotalTitulo.AutoSize  = true;

            this.lblCardTotalValor.Text      = "0";
            this.lblCardTotalValor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardTotalValor.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblCardTotalValor.Location  = new System.Drawing.Point(74, 46);
            this.lblCardTotalValor.AutoSize  = true;

            this.pnlCardTotal.Controls.Add(this.picCardTotal);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalTitulo);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalValor);

            // ── Card 2: En Stock (verde) ──
            this.pnlCardStock.Location        = new System.Drawing.Point(cardStartX + (cardW + cardGap), cardY);
            this.pnlCardStock.Size            = new System.Drawing.Size(cardW, cardH);
            this.pnlCardStock.FillColor       = System.Drawing.Color.White;
            this.pnlCardStock.BorderRadius    = 12;
            this.pnlCardStock.ShadowDecoration.Enabled = true;
            this.pnlCardStock.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlCardStock.ShadowDecoration.Depth   = 4;

            this.picCardStock.Size      = new System.Drawing.Size(48, 48);
            this.picCardStock.Location  = new System.Drawing.Point(14, 20);
            this.picCardStock.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardStock.Image     = null;
            this.picCardStock.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);

            this.lblCardStockTitulo.Text      = "En Stock";
            this.lblCardStockTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardStockTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardStockTitulo.Location  = new System.Drawing.Point(74, 22);
            this.lblCardStockTitulo.AutoSize  = true;

            this.lblCardStockValor.Text      = "0";
            this.lblCardStockValor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardStockValor.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblCardStockValor.Location  = new System.Drawing.Point(74, 46);
            this.lblCardStockValor.AutoSize  = true;

            this.pnlCardStock.Controls.Add(this.picCardStock);
            this.pnlCardStock.Controls.Add(this.lblCardStockTitulo);
            this.pnlCardStock.Controls.Add(this.lblCardStockValor);

            // ── Card 3: Stock Bajo (naranja) ──
            this.pnlCardBajo.Location        = new System.Drawing.Point(cardStartX + 2 * (cardW + cardGap), cardY);
            this.pnlCardBajo.Size            = new System.Drawing.Size(cardW, cardH);
            this.pnlCardBajo.FillColor       = System.Drawing.Color.White;
            this.pnlCardBajo.BorderRadius    = 12;
            this.pnlCardBajo.ShadowDecoration.Enabled = true;
            this.pnlCardBajo.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlCardBajo.ShadowDecoration.Depth   = 4;

            this.picCardBajo.Size      = new System.Drawing.Size(48, 48);
            this.picCardBajo.Location  = new System.Drawing.Point(14, 20);
            this.picCardBajo.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardBajo.Image     = null;
            this.picCardBajo.BackColor = System.Drawing.Color.FromArgb(249, 115, 22);

            this.lblCardBajoTitulo.Text      = "Stock Bajo";
            this.lblCardBajoTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardBajoTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardBajoTitulo.Location  = new System.Drawing.Point(74, 22);
            this.lblCardBajoTitulo.AutoSize  = true;

            this.lblCardBajoValor.Text      = "0";
            this.lblCardBajoValor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardBajoValor.ForeColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.lblCardBajoValor.Location  = new System.Drawing.Point(74, 46);
            this.lblCardBajoValor.AutoSize  = true;

            this.pnlCardBajo.Controls.Add(this.picCardBajo);
            this.pnlCardBajo.Controls.Add(this.lblCardBajoTitulo);
            this.pnlCardBajo.Controls.Add(this.lblCardBajoValor);

            // ── Card 4: Agotados (rojo) ──
            this.pnlCardAgotado.Location        = new System.Drawing.Point(cardStartX + 3 * (cardW + cardGap), cardY);
            this.pnlCardAgotado.Size            = new System.Drawing.Size(cardW, cardH);
            this.pnlCardAgotado.FillColor       = System.Drawing.Color.White;
            this.pnlCardAgotado.BorderRadius    = 12;
            this.pnlCardAgotado.ShadowDecoration.Enabled = true;
            this.pnlCardAgotado.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlCardAgotado.ShadowDecoration.Depth   = 4;

            this.picCardAgotado.Size      = new System.Drawing.Size(48, 48);
            this.picCardAgotado.Location  = new System.Drawing.Point(14, 20);
            this.picCardAgotado.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardAgotado.Image     = null;
            this.picCardAgotado.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);

            this.lblCardAgotadoTitulo.Text      = "Agotados";
            this.lblCardAgotadoTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardAgotadoTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCardAgotadoTitulo.Location  = new System.Drawing.Point(74, 22);
            this.lblCardAgotadoTitulo.AutoSize  = true;

            this.lblCardAgotadoValor.Text      = "0";
            this.lblCardAgotadoValor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardAgotadoValor.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblCardAgotadoValor.Location  = new System.Drawing.Point(74, 46);
            this.lblCardAgotadoValor.AutoSize  = true;

            this.pnlCardAgotado.Controls.Add(this.picCardAgotado);
            this.pnlCardAgotado.Controls.Add(this.lblCardAgotadoTitulo);
            this.pnlCardAgotado.Controls.Add(this.lblCardAgotadoValor);

            // ════════════════════════════════════════════════════
            // PANEL LISTA DE INGREDIENTES — centro izquierdo
            // ════════════════════════════════════════════════════
            this.pnlLista.Location        = new System.Drawing.Point(12, 180);
            this.pnlLista.Size            = new System.Drawing.Size(850, 340);
            this.pnlLista.FillColor       = System.Drawing.Color.White;
            this.pnlLista.BorderRadius    = 12;
            this.pnlLista.ShadowDecoration.Enabled = true;
            this.pnlLista.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlLista.ShadowDecoration.Depth   = 4;

            this.lblTituloLista.Text      = "Lista de Ingredientes";
            this.lblTituloLista.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloLista.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloLista.Location  = new System.Drawing.Point(14, 12);
            this.lblTituloLista.AutoSize  = true;

            // Búsqueda
            this.txtBuscar.Location        = new System.Drawing.Point(14, 40);
            this.txtBuscar.Size            = new System.Drawing.Size(260, 34);
            this.txtBuscar.PlaceholderText = "Buscar ingrediente...";
            this.txtBuscar.Font            = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.BorderRadius    = 8;
            this.txtBuscar.FillColor       = System.Drawing.Color.FromArgb(245, 245, 252);
            this.txtBuscar.BorderColor     = System.Drawing.Color.FromArgb(200, 200, 220);

            // Botones filtro
            this.btnFiltroTodos.Text            = "Todos";
            this.btnFiltroTodos.Location        = new System.Drawing.Point(510, 40);
            this.btnFiltroTodos.Size            = new System.Drawing.Size(90, 34);
            this.btnFiltroTodos.Font            = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroTodos.FillColor       = System.Drawing.Color.White;
            this.btnFiltroTodos.ForeColor       = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltroTodos.BorderColor     = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltroTodos.BorderRadius    = 8;
            this.btnFiltroTodos.BorderThickness = 1;
            this.btnFiltroTodos.ShadowDecoration.Enabled = false;

            this.btnFiltroStockBajo.Text            = "● Stock Bajo";
            this.btnFiltroStockBajo.Location        = new System.Drawing.Point(610, 40);
            this.btnFiltroStockBajo.Size            = new System.Drawing.Size(115, 34);
            this.btnFiltroStockBajo.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltroStockBajo.FillColor       = System.Drawing.Color.White;
            this.btnFiltroStockBajo.ForeColor       = System.Drawing.Color.FromArgb(249, 115, 22);
            this.btnFiltroStockBajo.BorderColor     = System.Drawing.Color.FromArgb(230, 230, 240);
            this.btnFiltroStockBajo.BorderRadius    = 8;
            this.btnFiltroStockBajo.BorderThickness = 1;
            this.btnFiltroStockBajo.ShadowDecoration.Enabled = false;

            this.btnFiltroAgotados.Text            = "● Agotados";
            this.btnFiltroAgotados.Location        = new System.Drawing.Point(734, 40);
            this.btnFiltroAgotados.Size            = new System.Drawing.Size(105, 34);
            this.btnFiltroAgotados.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltroAgotados.FillColor       = System.Drawing.Color.White;
            this.btnFiltroAgotados.ForeColor       = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnFiltroAgotados.BorderColor     = System.Drawing.Color.FromArgb(230, 230, 240);
            this.btnFiltroAgotados.BorderRadius    = 8;
            this.btnFiltroAgotados.BorderThickness = 1;
            this.btnFiltroAgotados.ShadowDecoration.Enabled = false;

            // DataGridView ingredientes
            this.dgvIngredientes.Location              = new System.Drawing.Point(14, 84);
            this.dgvIngredientes.Size                  = new System.Drawing.Size(820, 242);
            this.dgvIngredientes.AllowUserToAddRows    = false;
            this.dgvIngredientes.AllowUserToDeleteRows = false;
            this.dgvIngredientes.ReadOnly              = true;
            this.dgvIngredientes.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientes.MultiSelect           = false;
            this.dgvIngredientes.RowHeadersVisible     = false;
            this.dgvIngredientes.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvIngredientes.BackgroundColor       = System.Drawing.Color.White;
            this.dgvIngredientes.GridColor             = System.Drawing.Color.FromArgb(230, 230, 240);
            this.dgvIngredientes.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvIngredientes.ColumnHeadersBorderStyle                = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvIngredientes.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvIngredientes.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(37, 99, 235);
            this.dgvIngredientes.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.White;
            this.dgvIngredientes.RowTemplate.Height                      = 30;
            this.dgvIngredientes.EnableHeadersVisualStyles               = false;

            // Columnas
            this.colCodigo.Name             = "colCodigo";
            this.colCodigo.HeaderText       = "Código";
            this.colCodigo.DataPropertyName = "codigo_ingrediente";
            this.colCodigo.FillWeight       = 12;

            this.colIngrediente.Name             = "colIngrediente";
            this.colIngrediente.HeaderText       = "Ingrediente";
            this.colIngrediente.DataPropertyName = "nombre_ingrediente";
            this.colIngrediente.FillWeight       = 22;

            this.colUnidad.Name             = "colUnidad";
            this.colUnidad.HeaderText       = "Unidad";
            this.colUnidad.DataPropertyName = "unidad_medida";
            this.colUnidad.FillWeight       = 10;
            this.colUnidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colExistencia.Name             = "colExistencia";
            this.colExistencia.HeaderText       = "Existencia";
            this.colExistencia.DataPropertyName = "existencia";
            this.colExistencia.FillWeight       = 13;
            this.colExistencia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colStockMinimo.Name             = "colStockMinimo";
            this.colStockMinimo.HeaderText       = "Stock Mínimo";
            this.colStockMinimo.DataPropertyName = "stock_minimo";
            this.colStockMinimo.FillWeight       = 13;
            this.colStockMinimo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colCostoUnit.Name             = "colCostoUnit";
            this.colCostoUnit.HeaderText       = "Costo Unit.";
            this.colCostoUnit.DataPropertyName = "costo_unitario";
            this.colCostoUnit.FillWeight       = 13;
            this.colCostoUnit.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colEstado.Name             = "colEstado";
            this.colEstado.HeaderText       = "Estado";
            this.colEstado.DataPropertyName = "estado";
            this.colEstado.FillWeight       = 17;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCodigo,
                this.colIngrediente,
                this.colUnidad,
                this.colExistencia,
                this.colStockMinimo,
                this.colCostoUnit,
                this.colEstado
            });

            this.pnlLista.Controls.Add(this.lblTituloLista);
            this.pnlLista.Controls.Add(this.txtBuscar);
            this.pnlLista.Controls.Add(this.btnFiltroTodos);
            this.pnlLista.Controls.Add(this.btnFiltroStockBajo);
            this.pnlLista.Controls.Add(this.btnFiltroAgotados);
            this.pnlLista.Controls.Add(this.dgvIngredientes);

            // ════════════════════════════════════════════════════
            // PANEL REGISTRAR MOVIMIENTO — centro derecho
            // ════════════════════════════════════════════════════
            this.pnlMovimiento.Location        = new System.Drawing.Point(872, 180);
            this.pnlMovimiento.Size            = new System.Drawing.Size(478, 340);
            this.pnlMovimiento.FillColor       = System.Drawing.Color.White;
            this.pnlMovimiento.BorderRadius    = 12;
            this.pnlMovimiento.ShadowDecoration.Enabled = true;
            this.pnlMovimiento.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlMovimiento.ShadowDecoration.Depth   = 4;

            this.lblTituloMovimiento.Text      = "Registrar Movimiento";
            this.lblTituloMovimiento.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloMovimiento.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloMovimiento.Location  = new System.Drawing.Point(14, 12);
            this.lblTituloMovimiento.AutoSize  = true;

            // ── Subpanel: Ingrediente Seleccionado ──
            this.pnlIngSeleccionado.Location  = new System.Drawing.Point(14, 42);
            this.pnlIngSeleccionado.Size      = new System.Drawing.Size(448, 118);
            this.pnlIngSeleccionado.BackColor = System.Drawing.Color.FromArgb(245, 245, 252);
            this.pnlIngSeleccionado.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.lblIngSelTitulo.Text      = "Ingrediente Seleccionado";
            this.lblIngSelTitulo.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIngSelTitulo.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblIngSelTitulo.Location  = new System.Drawing.Point(8, 8);
            this.lblIngSelTitulo.AutoSize  = true;

            // Fila 1: Nombre ingrediente | Existencia actual
            this.lblNombreIngLbl.Text      = "Nombre del ingrediente";
            this.lblNombreIngLbl.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombreIngLbl.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblNombreIngLbl.Location  = new System.Drawing.Point(8, 32);
            this.lblNombreIngLbl.AutoSize  = true;

            this.lblExistenciaLbl.Text      = "Existencia actual";
            this.lblExistenciaLbl.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblExistenciaLbl.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblExistenciaLbl.Location  = new System.Drawing.Point(240, 32);
            this.lblExistenciaLbl.AutoSize  = true;

            this.lblNombreIngVal.Text      = "—";
            this.lblNombreIngVal.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNombreIngVal.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblNombreIngVal.Location  = new System.Drawing.Point(8, 50);
            this.lblNombreIngVal.AutoSize  = true;

            this.lblExistenciaVal.Text      = "0.00";
            this.lblExistenciaVal.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblExistenciaVal.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblExistenciaVal.Location  = new System.Drawing.Point(240, 50);
            this.lblExistenciaVal.AutoSize  = true;

            // Fila 2: Stock mínimo | Unidad de medida
            this.lblStockMinLbl.Text      = "Stock mínimo";
            this.lblStockMinLbl.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStockMinLbl.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblStockMinLbl.Location  = new System.Drawing.Point(8, 82);
            this.lblStockMinLbl.AutoSize  = true;

            this.lblUnidadMedidaLbl.Text      = "Unidad de medida";
            this.lblUnidadMedidaLbl.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUnidadMedidaLbl.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblUnidadMedidaLbl.Location  = new System.Drawing.Point(240, 82);
            this.lblUnidadMedidaLbl.AutoSize  = true;

            this.lblStockMinVal.Text      = "0.00";
            this.lblStockMinVal.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockMinVal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblStockMinVal.Location  = new System.Drawing.Point(8, 98);
            this.lblStockMinVal.AutoSize  = true;

            this.lblUnidadMedidaVal.Text      = "—";
            this.lblUnidadMedidaVal.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnidadMedidaVal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblUnidadMedidaVal.Location  = new System.Drawing.Point(240, 98);
            this.lblUnidadMedidaVal.AutoSize  = true;

            this.pnlIngSeleccionado.Controls.Add(this.lblIngSelTitulo);
            this.pnlIngSeleccionado.Controls.Add(this.lblNombreIngLbl);
            this.pnlIngSeleccionado.Controls.Add(this.lblExistenciaLbl);
            this.pnlIngSeleccionado.Controls.Add(this.lblNombreIngVal);
            this.pnlIngSeleccionado.Controls.Add(this.lblExistenciaVal);
            this.pnlIngSeleccionado.Controls.Add(this.lblStockMinLbl);
            this.pnlIngSeleccionado.Controls.Add(this.lblUnidadMedidaLbl);
            this.pnlIngSeleccionado.Controls.Add(this.lblStockMinVal);
            this.pnlIngSeleccionado.Controls.Add(this.lblUnidadMedidaVal);

            // ── Sección Nuevo Movimiento ──
            this.lblNuevoMovTitulo.Text      = "Nuevo Movimiento";
            this.lblNuevoMovTitulo.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNuevoMovTitulo.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblNuevoMovTitulo.Location  = new System.Drawing.Point(14, 172);
            this.lblNuevoMovTitulo.AutoSize  = true;

            this.lblTipoMovimiento.Text      = "Tipo de Movimiento";
            this.lblTipoMovimiento.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoMovimiento.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblTipoMovimiento.Location  = new System.Drawing.Point(14, 198);
            this.lblTipoMovimiento.AutoSize  = true;

            this.cmbTipoMovimiento.Location     = new System.Drawing.Point(14, 218);
            this.cmbTipoMovimiento.Size         = new System.Drawing.Size(448, 36);
            this.cmbTipoMovimiento.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoMovimiento.BorderRadius = 8;
            this.cmbTipoMovimiento.FillColor    = System.Drawing.Color.FromArgb(245, 245, 252);
            this.cmbTipoMovimiento.BorderColor  = System.Drawing.Color.FromArgb(200, 200, 220);
            this.cmbTipoMovimiento.Items.AddRange(new object[] { "Compra", "Consumo", "Ajuste", "Desperdicio" });
            this.cmbTipoMovimiento.SelectedIndex = 0;

            this.lblCantidad.Text      = "Cantidad";
            this.lblCantidad.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblCantidad.Location  = new System.Drawing.Point(14, 264);
            this.lblCantidad.AutoSize  = true;

            this.lblObservacion.Text      = "Observación / Justificación";
            this.lblObservacion.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblObservacion.Location  = new System.Drawing.Point(178, 264);
            this.lblObservacion.AutoSize  = true;

            this.nudCantidad.Location      = new System.Drawing.Point(14, 284);
            this.nudCantidad.Size          = new System.Drawing.Size(152, 36);
            this.nudCantidad.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Minimum       = 0;
            this.nudCantidad.Maximum       = 999999;
            this.nudCantidad.Value         = 0;
            this.nudCantidad.Increment     = (decimal)0.01;
            this.nudCantidad.BorderStyle   = System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtObservacion.Location        = new System.Drawing.Point(178, 284);
            this.txtObservacion.Size            = new System.Drawing.Size(284, 70);
            this.txtObservacion.Font            = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservacion.PlaceholderText = "Ingrese observación o justificación...";
            this.txtObservacion.Multiline       = true;
            this.txtObservacion.BorderRadius    = 8;
            this.txtObservacion.FillColor       = System.Drawing.Color.FromArgb(245, 245, 252);
            this.txtObservacion.BorderColor     = System.Drawing.Color.FromArgb(200, 200, 220);

            this.btnRegistrarMovimiento.Text         = "+ Registrar Movimiento";
            this.btnRegistrarMovimiento.Location     = new System.Drawing.Point(14, 362);
            this.btnRegistrarMovimiento.Size         = new System.Drawing.Size(448, 38);
            this.btnRegistrarMovimiento.Font         = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarMovimiento.FillColor    = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnRegistrarMovimiento.ForeColor    = System.Drawing.Color.White;
            this.btnRegistrarMovimiento.BorderRadius = 8;
            this.btnRegistrarMovimiento.ShadowDecoration.Enabled = false;

            this.pnlMovimiento.Controls.Add(this.lblTituloMovimiento);
            this.pnlMovimiento.Controls.Add(this.pnlIngSeleccionado);
            this.pnlMovimiento.Controls.Add(this.lblNuevoMovTitulo);
            this.pnlMovimiento.Controls.Add(this.lblTipoMovimiento);
            this.pnlMovimiento.Controls.Add(this.cmbTipoMovimiento);
            this.pnlMovimiento.Controls.Add(this.lblCantidad);
            this.pnlMovimiento.Controls.Add(this.lblObservacion);
            this.pnlMovimiento.Controls.Add(this.nudCantidad);
            this.pnlMovimiento.Controls.Add(this.txtObservacion);
            this.pnlMovimiento.Controls.Add(this.btnRegistrarMovimiento);

            // ════════════════════════════════════════════════════
            // PANEL HISTORIAL DE MOVIMIENTOS
            // ════════════════════════════════════════════════════
            this.pnlHistorial.Location        = new System.Drawing.Point(12, 532);
            this.pnlHistorial.Size            = new System.Drawing.Size(1338, 210);
            this.pnlHistorial.FillColor       = System.Drawing.Color.White;
            this.pnlHistorial.BorderRadius    = 12;
            this.pnlHistorial.ShadowDecoration.Enabled = true;
            this.pnlHistorial.ShadowDecoration.Color   = System.Drawing.Color.FromArgb(25, 0, 0, 0);
            this.pnlHistorial.ShadowDecoration.Depth   = 4;

            this.lblTituloHistorial.Text      = "Historial de Movimientos";
            this.lblTituloHistorial.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloHistorial.Location  = new System.Drawing.Point(14, 12);
            this.lblTituloHistorial.AutoSize  = true;

            this.lblFechaFiltro.Text      = "Fecha:";
            this.lblFechaFiltro.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaFiltro.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblFechaFiltro.Location  = new System.Drawing.Point(272, 14);
            this.lblFechaFiltro.AutoSize  = true;

            this.dtpFiltroFecha.Location     = new System.Drawing.Point(318, 10);
            this.dtpFiltroFecha.Size         = new System.Drawing.Size(160, 30);
            this.dtpFiltroFecha.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFiltroFecha.BorderRadius = 6;
            this.dtpFiltroFecha.FillColor    = System.Drawing.Color.FromArgb(245, 245, 252);
            this.dtpFiltroFecha.Format       = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Value        = System.DateTime.Today;

            this.btnLimpiarFecha.Text      = "✕";
            this.btnLimpiarFecha.Location  = new System.Drawing.Point(486, 12);
            this.btnLimpiarFecha.Size      = new System.Drawing.Size(28, 28);
            this.btnLimpiarFecha.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFecha.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.btnLimpiarFecha.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarFecha.FlatAppearance.BorderSize = 0;

            // DataGridView historial
            this.dgvHistorial.Location              = new System.Drawing.Point(14, 46);
            this.dgvHistorial.Size                  = new System.Drawing.Size(1308, 152);
            this.dgvHistorial.AllowUserToAddRows    = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ReadOnly              = true;
            this.dgvHistorial.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.MultiSelect           = false;
            this.dgvHistorial.RowHeadersVisible     = false;
            this.dgvHistorial.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.BackgroundColor       = System.Drawing.Color.White;
            this.dgvHistorial.GridColor             = System.Drawing.Color.FromArgb(230, 230, 240);
            this.dgvHistorial.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHistorial.ColumnHeadersBorderStyle                = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHistorial.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHistorial.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(37, 99, 235);
            this.dgvHistorial.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.White;
            this.dgvHistorial.RowTemplate.Height                      = 30;
            this.dgvHistorial.EnableHeadersVisualStyles               = false;

            this.colHFecha.Name             = "colHFecha";
            this.colHFecha.HeaderText       = "Fecha";
            this.colHFecha.DataPropertyName = "fecha_movimiento";
            this.colHFecha.FillWeight       = 15;

            this.colHIngrediente.Name             = "colHIngrediente";
            this.colHIngrediente.HeaderText       = "Ingrediente";
            this.colHIngrediente.DataPropertyName = "nombre_ingrediente";
            this.colHIngrediente.FillWeight       = 18;

            this.colHTipo.Name             = "colHTipo";
            this.colHTipo.HeaderText       = "Tipo";
            this.colHTipo.DataPropertyName = "tipo_movimiento";
            this.colHTipo.FillWeight       = 13;
            this.colHTipo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colHCantidad.Name             = "colHCantidad";
            this.colHCantidad.HeaderText       = "Cantidad";
            this.colHCantidad.DataPropertyName = "cantidad";
            this.colHCantidad.FillWeight       = 12;
            this.colHCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colHUsuario.Name             = "colHUsuario";
            this.colHUsuario.HeaderText       = "Usuario";
            this.colHUsuario.DataPropertyName = "nombre_usuario";
            this.colHUsuario.FillWeight       = 15;

            this.colHObservacion.Name             = "colHObservacion";
            this.colHObservacion.HeaderText       = "Observación";
            this.colHObservacion.DataPropertyName = "observacion";
            this.colHObservacion.FillWeight       = 27;

            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colHFecha,
                this.colHIngrediente,
                this.colHTipo,
                this.colHCantidad,
                this.colHUsuario,
                this.colHObservacion
            });

            this.pnlHistorial.Controls.Add(this.lblTituloHistorial);
            this.pnlHistorial.Controls.Add(this.lblFechaFiltro);
            this.pnlHistorial.Controls.Add(this.dtpFiltroFecha);
            this.pnlHistorial.Controls.Add(this.btnLimpiarFecha);
            this.pnlHistorial.Controls.Add(this.dgvHistorial);

            // ════════════════════════════════════════════════════
            // BARRA INFERIOR — BOTONES GLOBALES
            // ════════════════════════════════════════════════════
            this.pnlBotonesInf.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotonesInf.Height    = 58;
            this.pnlBotonesInf.BackColor = System.Drawing.Color.FromArgb(230, 230, 242);

            this.btnNuevoIngrediente.Text         = "+ Nuevo Ingrediente";
            this.btnNuevoIngrediente.Location     = new System.Drawing.Point(12, 10);
            this.btnNuevoIngrediente.Size         = new System.Drawing.Size(180, 38);
            this.btnNuevoIngrediente.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevoIngrediente.FillColor    = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNuevoIngrediente.ForeColor    = System.Drawing.Color.White;
            this.btnNuevoIngrediente.BorderRadius = 8;
            this.btnNuevoIngrediente.ShadowDecoration.Enabled = false;

            this.btnEditarIngrediente.Text         = " Editar Ingrediente";
            this.btnEditarIngrediente.Location     = new System.Drawing.Point(202, 10);
            this.btnEditarIngrediente.Size         = new System.Drawing.Size(180, 38);
            this.btnEditarIngrediente.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEditarIngrediente.FillColor    = System.Drawing.Color.FromArgb(249, 115, 22);
            this.btnEditarIngrediente.ForeColor    = System.Drawing.Color.White;
            this.btnEditarIngrediente.BorderRadius = 8;
            this.btnEditarIngrediente.ShadowDecoration.Enabled = false;

            this.btnEliminar.Text         = " Eliminar";
            this.btnEliminar.Location     = new System.Drawing.Point(392, 10);
            this.btnEliminar.Size         = new System.Drawing.Size(140, 38);
            this.btnEliminar.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.FillColor    = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.ForeColor    = System.Drawing.Color.White;
            this.btnEliminar.BorderRadius = 8;
            this.btnEliminar.Enabled      = false;  // deshabilitado si tiene recetas
            this.btnEliminar.ShadowDecoration.Enabled = false;

            this.lblDeshabilitado.Text      = "(Deshabilitado si tiene recetas)";
            this.lblDeshabilitado.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblDeshabilitado.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblDeshabilitado.Location  = new System.Drawing.Point(542, 20);
            this.lblDeshabilitado.AutoSize  = true;

            this.btnActualizar.Text         = "  Actualizar";
            this.btnActualizar.Location     = new System.Drawing.Point(1190, 10);
            this.btnActualizar.Size         = new System.Drawing.Size(150, 38);
            this.btnActualizar.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.FillColor    = System.Drawing.Color.FromArgb(210, 210, 225);
            this.btnActualizar.ForeColor    = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnActualizar.BorderRadius = 8;
            this.btnActualizar.ShadowDecoration.Enabled = false;

            this.pnlBotonesInf.Controls.Add(this.btnNuevoIngrediente);
            this.pnlBotonesInf.Controls.Add(this.btnEditarIngrediente);
            this.pnlBotonesInf.Controls.Add(this.btnEliminar);
            this.pnlBotonesInf.Controls.Add(this.lblDeshabilitado);
            this.pnlBotonesInf.Controls.Add(this.btnActualizar);

            // ════════════════════════════════════════════════════
            // EVENTOS
            // ════════════════════════════════════════════════════
            this.Load
                += new System.EventHandler(this.frmInventario_Load);
            this.txtBuscar.TextChanged
                += new System.EventHandler(this.txtBuscar_TextChanged);
            this.btnFiltroTodos.Click
                += new System.EventHandler(this.btnFiltroTodos_Click);
            this.btnFiltroStockBajo.Click
                += new System.EventHandler(this.btnFiltroStockBajo_Click);
            this.btnFiltroAgotados.Click
                += new System.EventHandler(this.btnFiltroAgotados_Click);
            this.dgvIngredientes.SelectionChanged
                += new System.EventHandler(this.dgvIngredientes_SelectionChanged);
            this.dgvIngredientes.CellFormatting
                += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvIngredientes_CellFormatting);
            this.cmbTipoMovimiento.SelectedIndexChanged
                += new System.EventHandler(this.cmbTipoMovimiento_SelectedIndexChanged);
            this.btnRegistrarMovimiento.Click
                += new System.EventHandler(this.btnRegistrarMovimiento_Click);
            this.dtpFiltroFecha.ValueChanged
                += new System.EventHandler(this.dtpFiltroFecha_ValueChanged);
            this.btnLimpiarFecha.Click
                += new System.EventHandler(this.btnLimpiarFecha_Click);
            this.btnNuevoIngrediente.Click
                += new System.EventHandler(this.btnNuevoIngrediente_Click);
            this.btnEditarIngrediente.Click
                += new System.EventHandler(this.btnEditarIngrediente_Click);
            this.btnEliminar.Click
                += new System.EventHandler(this.btnEliminar_Click);
            this.btnActualizar.Click
                += new System.EventHandler(this.btnActualizar_Click);

            // ════════════════════════════════════════════════════
            // AGREGAR AL FORM
            // ════════════════════════════════════════════════════
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlCardTotal);
            this.Controls.Add(this.pnlCardStock);
            this.Controls.Add(this.pnlCardBajo);
            this.Controls.Add(this.pnlCardAgotado);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlMovimiento);
            this.Controls.Add(this.pnlHistorial);
            this.Controls.Add(this.pnlBotonesInf);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ════════════════════════════════════════════════════
        // DECLARACIÓN DE VARIABLES
        // ════════════════════════════════════════════════════

        // Top bar
        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picIcono;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblUsuarioFlecha;

        // KPI Cards
        private Guna.UI2.WinForms.Guna2Panel pnlCardTotal;
        private System.Windows.Forms.PictureBox picCardTotal;
        private System.Windows.Forms.Label lblCardTotalTitulo;
        private System.Windows.Forms.Label lblCardTotalValor;

        private Guna.UI2.WinForms.Guna2Panel pnlCardStock;
        private System.Windows.Forms.PictureBox picCardStock;
        private System.Windows.Forms.Label lblCardStockTitulo;
        private System.Windows.Forms.Label lblCardStockValor;

        private Guna.UI2.WinForms.Guna2Panel pnlCardBajo;
        private System.Windows.Forms.PictureBox picCardBajo;
        private System.Windows.Forms.Label lblCardBajoTitulo;
        private System.Windows.Forms.Label lblCardBajoValor;

        private Guna.UI2.WinForms.Guna2Panel pnlCardAgotado;
        private System.Windows.Forms.PictureBox picCardAgotado;
        private System.Windows.Forms.Label lblCardAgotadoTitulo;
        private System.Windows.Forms.Label lblCardAgotadoValor;

        // Panel Lista
        private Guna.UI2.WinForms.Guna2Panel pnlLista;
        private System.Windows.Forms.Label lblTituloLista;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2Button btnFiltroTodos;
        private Guna.UI2.WinForms.Guna2Button btnFiltroStockBajo;
        private Guna.UI2.WinForms.Guna2Button btnFiltroAgotados;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;

        // Panel Movimiento
        private Guna.UI2.WinForms.Guna2Panel pnlMovimiento;
        private System.Windows.Forms.Label lblTituloMovimiento;
        private System.Windows.Forms.Panel pnlIngSeleccionado;
        private System.Windows.Forms.Label lblIngSelTitulo;
        private System.Windows.Forms.Label lblNombreIngLbl;
        private System.Windows.Forms.Label lblExistenciaLbl;
        private System.Windows.Forms.Label lblNombreIngVal;
        private System.Windows.Forms.Label lblExistenciaVal;
        private System.Windows.Forms.Label lblStockMinLbl;
        private System.Windows.Forms.Label lblUnidadMedidaLbl;
        private System.Windows.Forms.Label lblStockMinVal;
        private System.Windows.Forms.Label lblUnidadMedidaVal;
        private System.Windows.Forms.Label lblNuevoMovTitulo;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private Guna.UI2.WinForms.Guna2TextBox txtObservacion;
        private Guna.UI2.WinForms.Guna2Button btnRegistrarMovimiento;

        // Panel Historial
        private Guna.UI2.WinForms.Guna2Panel pnlHistorial;
        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.Label lblFechaFiltro;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Button btnLimpiarFecha;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHObservacion;

        // Barra inferior
        private System.Windows.Forms.Panel pnlBotonesInf;
        private Guna.UI2.WinForms.Guna2Button btnNuevoIngrediente;
        private Guna.UI2.WinForms.Guna2Button btnEditarIngrediente;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private System.Windows.Forms.Label lblDeshabilitado;
        private Guna.UI2.WinForms.Guna2Button btnActualizar;
    }
}
