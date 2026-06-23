namespace Restaurante_Sabor_Gourmet.Formularios
{
    partial class frmOrdenes
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
            this.pnlSeleccionMesa = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloSeleccionMesa = new System.Windows.Forms.Label();
            this.cbxMesa = new Guna.UI2.WinForms.Guna2ComboBox();

            this.pnlMesaInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconoMesa = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconoMesa = new System.Windows.Forms.Label();
            this.lblMesaSeleccionadaTitulo = new System.Windows.Forms.Label();
            this.lblNumeroMesa = new System.Windows.Forms.Label();
            this.lblZonaTitulo = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.lblMeseroTitulo = new System.Windows.Forms.Label();
            this.lblMeseroAsignado = new System.Windows.Forms.Label();

            this.pnlEstadoOrden = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEstadoOrdenTitulo = new System.Windows.Forms.Label();
            this.lblEstadoOrden = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEstadoOrdenTexto = new System.Windows.Forms.Label();

            this.pnlCatalogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCatalogoTitulo = new System.Windows.Forms.Label();
            this.pnlCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCatEntradas = new Guna.UI2.WinForms.Guna2Button();
            this.btnCatPlatosFuertes = new Guna.UI2.WinForms.Guna2Button();
            this.btnCatBebidas = new Guna.UI2.WinForms.Guna2Button();
            this.btnCatPostres = new Guna.UI2.WinForms.Guna2Button();
            this.btnCatExtras = new Guna.UI2.WinForms.Guna2Button();
            this.pnlProductosHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblColProducto = new System.Windows.Forms.Label();
            this.lblColPrecio = new System.Windows.Forms.Label();
            this.pnlProductosContainer = new System.Windows.Forms.Panel();

            this.pnlDetalleOrden = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.dgvDetalleOrden = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblObservacionesGenerales = new System.Windows.Forms.Label();
            this.txtObservacionesGenerales = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContadorObs = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotalOrden = new System.Windows.Forms.Label();
            this.btnEnviarCocina = new Guna.UI2.WinForms.Guna2Button();
            this.btnSolicitarCierre = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).BeginInit();
            this.pnlSeleccionMesa.SuspendLayout();
            this.pnlMesaInfo.SuspendLayout();
            this.pnlEstadoOrden.SuspendLayout();
            this.pnlCatalogo.SuspendLayout();
            this.pnlCategorias.SuspendLayout();
            this.pnlProductosHeader.SuspendLayout();
            this.pnlDetalleOrden.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSeleccionMesa
            // 
            this.pnlSeleccionMesa.BorderRadius = 12;
            this.pnlSeleccionMesa.FillColor = System.Drawing.Color.White;
            this.pnlSeleccionMesa.Location = new System.Drawing.Point(20, 20);
            this.pnlSeleccionMesa.Name = "pnlSeleccionMesa";
            this.pnlSeleccionMesa.ShadowDecoration.Enabled = true;
            this.pnlSeleccionMesa.Size = new System.Drawing.Size(420, 110);
            this.pnlSeleccionMesa.TabIndex = 0;
            this.pnlSeleccionMesa.Controls.Add(this.lblTituloSeleccionMesa);
            this.pnlSeleccionMesa.Controls.Add(this.cbxMesa);

            // 
            // lblTituloSeleccionMesa
            // 
            this.lblTituloSeleccionMesa.AutoSize = true;
            this.lblTituloSeleccionMesa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloSeleccionMesa.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloSeleccionMesa.Location = new System.Drawing.Point(20, 15);
            this.lblTituloSeleccionMesa.Name = "lblTituloSeleccionMesa";
            this.lblTituloSeleccionMesa.Size = new System.Drawing.Size(130, 20);
            this.lblTituloSeleccionMesa.TabIndex = 0;
            this.lblTituloSeleccionMesa.Text = "Seleccionar Mesa";

            // 
            // cbxMesa
            // 
            this.cbxMesa.BackColor = System.Drawing.Color.Transparent;
            this.cbxMesa.BorderRadius = 8;
            this.cbxMesa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbxMesa.ItemHeight = 30;
            this.cbxMesa.Location = new System.Drawing.Point(20, 50);
            this.cbxMesa.Name = "cbxMesa";
            this.cbxMesa.Size = new System.Drawing.Size(380, 36);
            this.cbxMesa.TabIndex = 1;
            this.cbxMesa.SelectedIndexChanged += new System.EventHandler(this.cbxMesa_SelectedIndexChanged);

            // 
            // pnlMesaInfo
            // 
            this.pnlMesaInfo.BorderRadius = 12;
            this.pnlMesaInfo.FillColor = System.Drawing.Color.White;
            this.pnlMesaInfo.Location = new System.Drawing.Point(450, 20);
            this.pnlMesaInfo.Name = "pnlMesaInfo";
            this.pnlMesaInfo.ShadowDecoration.Enabled = true;
            this.pnlMesaInfo.Size = new System.Drawing.Size(630, 110);
            this.pnlMesaInfo.TabIndex = 1;
            this.pnlMesaInfo.Controls.Add(this.pnlIconoMesa);
            this.pnlMesaInfo.Controls.Add(this.lblMesaSeleccionadaTitulo);
            this.pnlMesaInfo.Controls.Add(this.lblNumeroMesa);
            this.pnlMesaInfo.Controls.Add(this.lblZonaTitulo);
            this.pnlMesaInfo.Controls.Add(this.lblZona);
            this.pnlMesaInfo.Controls.Add(this.lblMeseroTitulo);
            this.pnlMesaInfo.Controls.Add(this.lblMeseroAsignado);

            // 
            // pnlIconoMesa
            // 
            this.pnlIconoMesa.BorderRadius = 25;
            this.pnlIconoMesa.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.pnlIconoMesa.Location = new System.Drawing.Point(20, 20);
            this.pnlIconoMesa.Name = "pnlIconoMesa";
            this.pnlIconoMesa.Size = new System.Drawing.Size(50, 50);
            this.pnlIconoMesa.TabIndex = 0;
            this.pnlIconoMesa.Controls.Add(this.lblIconoMesa);

            // 
            // lblIconoMesa
            // 
            this.lblIconoMesa.AutoSize = false;
            this.lblIconoMesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconoMesa.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblIconoMesa.ForeColor = System.Drawing.Color.White;
            this.lblIconoMesa.Name = "lblIconoMesa";
            this.lblIconoMesa.Text = "🍽";
            this.lblIconoMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblMesaSeleccionadaTitulo
            // 
            this.lblMesaSeleccionadaTitulo.AutoSize = true;
            this.lblMesaSeleccionadaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMesaSeleccionadaTitulo.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblMesaSeleccionadaTitulo.Location = new System.Drawing.Point(80, 18);
            this.lblMesaSeleccionadaTitulo.Name = "lblMesaSeleccionadaTitulo";
            this.lblMesaSeleccionadaTitulo.Size = new System.Drawing.Size(110, 17);
            this.lblMesaSeleccionadaTitulo.TabIndex = 1;
            this.lblMesaSeleccionadaTitulo.Text = "Mesa Seleccionada";

            // 
            // lblNumeroMesa
            // 
            this.lblNumeroMesa.AutoSize = true;
            this.lblNumeroMesa.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNumeroMesa.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblNumeroMesa.Location = new System.Drawing.Point(80, 38);
            this.lblNumeroMesa.Name = "lblNumeroMesa";
            this.lblNumeroMesa.Size = new System.Drawing.Size(90, 30);
            this.lblNumeroMesa.TabIndex = 2;
            this.lblNumeroMesa.Text = "Mesa --";

            // 
            // lblZonaTitulo
            // 
            this.lblZonaTitulo.AutoSize = true;
            this.lblZonaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblZonaTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblZonaTitulo.Location = new System.Drawing.Point(260, 25);
            this.lblZonaTitulo.Name = "lblZonaTitulo";
            this.lblZonaTitulo.Size = new System.Drawing.Size(40, 17);
            this.lblZonaTitulo.TabIndex = 3;
            this.lblZonaTitulo.Text = "Zona";

            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblZona.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblZona.Location = new System.Drawing.Point(260, 44);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(50, 20);
            this.lblZona.TabIndex = 4;
            this.lblZona.Text = "--";

            // 
            // lblMeseroTitulo
            // 
            this.lblMeseroTitulo.AutoSize = true;
            this.lblMeseroTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMeseroTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblMeseroTitulo.Location = new System.Drawing.Point(420, 25);
            this.lblMeseroTitulo.Name = "lblMeseroTitulo";
            this.lblMeseroTitulo.Size = new System.Drawing.Size(110, 17);
            this.lblMeseroTitulo.TabIndex = 5;
            this.lblMeseroTitulo.Text = "Mesero Asignado";

            // 
            // lblMeseroAsignado
            // 
            this.lblMeseroAsignado.AutoSize = true;
            this.lblMeseroAsignado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMeseroAsignado.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblMeseroAsignado.Location = new System.Drawing.Point(420, 44);
            this.lblMeseroAsignado.Name = "lblMeseroAsignado";
            this.lblMeseroAsignado.Size = new System.Drawing.Size(60, 20);
            this.lblMeseroAsignado.TabIndex = 6;
            this.lblMeseroAsignado.Text = "--";

            // 
            // pnlEstadoOrden
            // 
            this.pnlEstadoOrden.BorderRadius = 12;
            this.pnlEstadoOrden.FillColor = System.Drawing.Color.White;
            this.pnlEstadoOrden.Location = new System.Drawing.Point(1090, 20);
            this.pnlEstadoOrden.Name = "pnlEstadoOrden";
            this.pnlEstadoOrden.ShadowDecoration.Enabled = true;
            this.pnlEstadoOrden.Size = new System.Drawing.Size(250, 110);
            this.pnlEstadoOrden.TabIndex = 2;
            this.pnlEstadoOrden.Controls.Add(this.lblEstadoOrdenTitulo);
            this.pnlEstadoOrden.Controls.Add(this.lblEstadoOrden);

            // 
            // lblEstadoOrdenTitulo
            // 
            this.lblEstadoOrdenTitulo.AutoSize = true;
            this.lblEstadoOrdenTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoOrdenTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblEstadoOrdenTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblEstadoOrdenTitulo.Name = "lblEstadoOrdenTitulo";
            this.lblEstadoOrdenTitulo.Size = new System.Drawing.Size(120, 17);
            this.lblEstadoOrdenTitulo.TabIndex = 0;
            this.lblEstadoOrdenTitulo.Text = "Estado de la Orden";

            // 
            // lblEstadoOrden (chip)
            // 
            this.lblEstadoOrden.BorderRadius = 16;
            this.lblEstadoOrden.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblEstadoOrden.Location = new System.Drawing.Point(20, 45);
            this.lblEstadoOrden.Name = "lblEstadoOrden";
            this.lblEstadoOrden.Size = new System.Drawing.Size(150, 35);
            this.lblEstadoOrden.TabIndex = 1;
            this.lblEstadoOrden.Controls.Add(this.lblEstadoOrdenTexto);

            // 
            // lblEstadoOrdenTexto
            // 
            this.lblEstadoOrdenTexto.AutoSize = false;
            this.lblEstadoOrdenTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoOrdenTexto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoOrdenTexto.ForeColor = System.Drawing.Color.White;
            this.lblEstadoOrdenTexto.Name = "lblEstadoOrdenTexto";
            this.lblEstadoOrdenTexto.Text = "● ABIERTA";
            this.lblEstadoOrdenTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlCatalogo
            // 
            this.pnlCatalogo.BorderRadius = 12;
            this.pnlCatalogo.FillColor = System.Drawing.Color.White;
            this.pnlCatalogo.Location = new System.Drawing.Point(20, 150);
            this.pnlCatalogo.Name = "pnlCatalogo";
            this.pnlCatalogo.ShadowDecoration.Enabled = true;
            this.pnlCatalogo.Size = new System.Drawing.Size(580, 700);
            this.pnlCatalogo.TabIndex = 3;
            this.pnlCatalogo.Controls.Add(this.lblCatalogoTitulo);
            this.pnlCatalogo.Controls.Add(this.pnlCategorias);
            this.pnlCatalogo.Controls.Add(this.pnlProductosHeader);
            this.pnlCatalogo.Controls.Add(this.pnlProductosContainer);

            // 
            // lblCatalogoTitulo
            // 
            this.lblCatalogoTitulo.AutoSize = true;
            this.lblCatalogoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCatalogoTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblCatalogoTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblCatalogoTitulo.Name = "lblCatalogoTitulo";
            this.lblCatalogoTitulo.Size = new System.Drawing.Size(190, 25);
            this.lblCatalogoTitulo.TabIndex = 0;
            this.lblCatalogoTitulo.Text = "🍽  Catálogo de Productos";

            // 
            // pnlCategorias
            // 
            this.pnlCategorias.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlCategorias.Location = new System.Drawing.Point(20, 55);
            this.pnlCategorias.Name = "pnlCategorias";
            this.pnlCategorias.Size = new System.Drawing.Size(140, 620);
            this.pnlCategorias.TabIndex = 1;
            this.pnlCategorias.Controls.Add(this.btnCatEntradas);
            this.pnlCategorias.Controls.Add(this.btnCatPlatosFuertes);
            this.pnlCategorias.Controls.Add(this.btnCatBebidas);
            this.pnlCategorias.Controls.Add(this.btnCatPostres);
            this.pnlCategorias.Controls.Add(this.btnCatExtras);

            // 
            // btnCatEntradas
            // 
            this.btnCatEntradas.BorderRadius = 8;
            this.btnCatEntradas.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCatEntradas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCatEntradas.ForeColor = System.Drawing.Color.White;
            this.btnCatEntradas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnCatEntradas.Name = "btnCatEntradas";
            this.btnCatEntradas.Size = new System.Drawing.Size(140, 40);
            this.btnCatEntradas.TabIndex = 0;
            this.btnCatEntradas.Text = "Entradas";
            this.btnCatEntradas.Tag = "1";
            this.btnCatEntradas.Click += new System.EventHandler(this.btnCategoria_Click);

            // 
            // btnCatPlatosFuertes
            // 
            this.btnCatPlatosFuertes.BorderRadius = 8;
            this.btnCatPlatosFuertes.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnCatPlatosFuertes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCatPlatosFuertes.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.btnCatPlatosFuertes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnCatPlatosFuertes.Name = "btnCatPlatosFuertes";
            this.btnCatPlatosFuertes.Size = new System.Drawing.Size(140, 40);
            this.btnCatPlatosFuertes.TabIndex = 1;
            this.btnCatPlatosFuertes.Text = "Platos Fuertes";
            this.btnCatPlatosFuertes.Tag = "2";
            this.btnCatPlatosFuertes.Click += new System.EventHandler(this.btnCategoria_Click);

            // 
            // btnCatBebidas
            // 
            this.btnCatBebidas.BorderRadius = 8;
            this.btnCatBebidas.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnCatBebidas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCatBebidas.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.btnCatBebidas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnCatBebidas.Name = "btnCatBebidas";
            this.btnCatBebidas.Size = new System.Drawing.Size(140, 40);
            this.btnCatBebidas.TabIndex = 2;
            this.btnCatBebidas.Text = "Bebidas";
            this.btnCatBebidas.Tag = "3";
            this.btnCatBebidas.Click += new System.EventHandler(this.btnCategoria_Click);

            // 
            // btnCatPostres
            // 
            this.btnCatPostres.BorderRadius = 8;
            this.btnCatPostres.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnCatPostres.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCatPostres.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.btnCatPostres.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnCatPostres.Name = "btnCatPostres";
            this.btnCatPostres.Size = new System.Drawing.Size(140, 40);
            this.btnCatPostres.TabIndex = 3;
            this.btnCatPostres.Text = "Postres";
            this.btnCatPostres.Tag = "4";
            this.btnCatPostres.Click += new System.EventHandler(this.btnCategoria_Click);

            // 
            // btnCatExtras
            // 
            this.btnCatExtras.BorderRadius = 8;
            this.btnCatExtras.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnCatExtras.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCatExtras.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.btnCatExtras.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnCatExtras.Name = "btnCatExtras";
            this.btnCatExtras.Size = new System.Drawing.Size(140, 40);
            this.btnCatExtras.TabIndex = 4;
            this.btnCatExtras.Text = "Extras";
            this.btnCatExtras.Tag = "5";
            this.btnCatExtras.Click += new System.EventHandler(this.btnCategoria_Click);

            // 
            // pnlProductosHeader
            // 
            this.pnlProductosHeader.BorderRadius = 6;
            this.pnlProductosHeader.FillColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlProductosHeader.Location = new System.Drawing.Point(175, 55);
            this.pnlProductosHeader.Name = "pnlProductosHeader";
            this.pnlProductosHeader.Size = new System.Drawing.Size(385, 40);
            this.pnlProductosHeader.TabIndex = 2;
            this.pnlProductosHeader.Controls.Add(this.lblColProducto);
            this.pnlProductosHeader.Controls.Add(this.lblColPrecio);

            // 
            // lblColProducto
            // 
            this.lblColProducto.AutoSize = true;
            this.lblColProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblColProducto.ForeColor = System.Drawing.Color.White;
            this.lblColProducto.Location = new System.Drawing.Point(15, 11);
            this.lblColProducto.Name = "lblColProducto";
            this.lblColProducto.Size = new System.Drawing.Size(70, 19);
            this.lblColProducto.TabIndex = 0;
            this.lblColProducto.Text = "Producto";

            // 
            // lblColPrecio
            // 
            this.lblColPrecio.AutoSize = true;
            this.lblColPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblColPrecio.ForeColor = System.Drawing.Color.White;
            this.lblColPrecio.Location = new System.Drawing.Point(290, 11);
            this.lblColPrecio.Name = "lblColPrecio";
            this.lblColPrecio.Size = new System.Drawing.Size(50, 19);
            this.lblColPrecio.TabIndex = 1;
            this.lblColPrecio.Text = "Precio";

            // 
            // pnlProductosContainer
            // (panel vacío: las tarjetas de producto se generan dinámicamente por código,
            //  una por cada producto de la categoría seleccionada)
            // 
            this.pnlProductosContainer.AutoScroll = true;
            this.pnlProductosContainer.BackColor = System.Drawing.Color.White;
            this.pnlProductosContainer.Location = new System.Drawing.Point(175, 100);
            this.pnlProductosContainer.Name = "pnlProductosContainer";
            this.pnlProductosContainer.Size = new System.Drawing.Size(385, 575);
            this.pnlProductosContainer.TabIndex = 3;

            // 
            // pnlDetalleOrden
            // 
            this.pnlDetalleOrden.BorderRadius = 12;
            this.pnlDetalleOrden.FillColor = System.Drawing.Color.White;
            this.pnlDetalleOrden.Location = new System.Drawing.Point(615, 150);
            this.pnlDetalleOrden.Name = "pnlDetalleOrden";
            this.pnlDetalleOrden.ShadowDecoration.Enabled = true;
            this.pnlDetalleOrden.Size = new System.Drawing.Size(725, 700);
            this.pnlDetalleOrden.TabIndex = 4;
            this.pnlDetalleOrden.Controls.Add(this.lblDetalleTitulo);
            this.pnlDetalleOrden.Controls.Add(this.dgvDetalleOrden);
            this.pnlDetalleOrden.Controls.Add(this.lblObservacionesGenerales);
            this.pnlDetalleOrden.Controls.Add(this.txtObservacionesGenerales);
            this.pnlDetalleOrden.Controls.Add(this.lblContadorObs);
            this.pnlDetalleOrden.Controls.Add(this.lblTotalTitulo);
            this.pnlDetalleOrden.Controls.Add(this.lblTotalOrden);
            this.pnlDetalleOrden.Controls.Add(this.btnEnviarCocina);
            this.pnlDetalleOrden.Controls.Add(this.btnSolicitarCierre);

            // 
            // lblDetalleTitulo
            // 
            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblDetalleTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(230, 25);
            this.lblDetalleTitulo.TabIndex = 0;
            this.lblDetalleTitulo.Text = "📋  Detalle de la Orden Actual";

            // 
            // dgvDetalleOrden
            // 
            this.dgvDetalleOrden.AllowUserToAddRows = false;
            this.dgvDetalleOrden.AllowUserToResizeRows = false;
            this.dgvDetalleOrden.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleOrden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleOrden.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvDetalleOrden.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalleOrden.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvDetalleOrden.ColumnHeadersHeight = 36;
            this.dgvDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleOrden.RowHeadersVisible = false;
            this.dgvDetalleOrden.RowTemplate.Height = 36;
            this.dgvDetalleOrden.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDetalleOrden.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(229, 240, 255);
            this.dgvDetalleOrden.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvDetalleOrden.GridColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.dgvDetalleOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleOrden.Location = new System.Drawing.Point(20, 55);
            this.dgvDetalleOrden.Name = "dgvDetalleOrden";
            this.dgvDetalleOrden.Size = new System.Drawing.Size(685, 380);
            this.dgvDetalleOrden.TabIndex = 1;
            this.dgvDetalleOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCantidad,
            this.colPrecioUnitario,
            this.colSubtotal,
            this.colObservaciones,
            this.colEditar,
            this.colEliminar});
            this.dgvDetalleOrden.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleOrden_CellClick);
            this.dgvDetalleOrden.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleOrden_CellEndEdit);

            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            this.colProducto.FillWeight = 28F;

            // 
            // colCantidad  (TextBoxColumn editable, según indicación del usuario)
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = false;
            this.colCantidad.FillWeight = 14F;
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // 
            // colPrecioUnitario
            // 
            this.colPrecioUnitario.HeaderText = "Precio Unitario";
            this.colPrecioUnitario.Name = "colPrecioUnitario";
            this.colPrecioUnitario.ReadOnly = true;
            this.colPrecioUnitario.FillWeight = 16F;
            this.colPrecioUnitario.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.FillWeight = 16F;
            this.colSubtotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // 
            // colObservaciones
            // 
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = false;
            this.colObservaciones.FillWeight = 18F;

            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "";
            this.colEditar.Name = "colEditar";
            this.colEditar.Text = "✎";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.FillWeight = 8F;
            this.colEditar.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "Acciones";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "✕";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.FillWeight = 8F;
            this.colEliminar.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            this.colEliminar.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);

            // 
            // lblObservacionesGenerales
            // 
            this.lblObservacionesGenerales.AutoSize = true;
            this.lblObservacionesGenerales.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblObservacionesGenerales.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblObservacionesGenerales.Location = new System.Drawing.Point(20, 450);
            this.lblObservacionesGenerales.Name = "lblObservacionesGenerales";
            this.lblObservacionesGenerales.Size = new System.Drawing.Size(220, 19);
            this.lblObservacionesGenerales.TabIndex = 2;
            this.lblObservacionesGenerales.Text = "Observaciones Generales de la Orden";

            // 
            // txtObservacionesGenerales
            // 
            this.txtObservacionesGenerales.BorderRadius = 8;
            this.txtObservacionesGenerales.DefaultText = "";
            this.txtObservacionesGenerales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObservacionesGenerales.Location = new System.Drawing.Point(20, 475);
            this.txtObservacionesGenerales.Multiline = true;
            this.txtObservacionesGenerales.Name = "txtObservacionesGenerales";
            this.txtObservacionesGenerales.PlaceholderText = "Agregar observaciones generales de la orden...";
            this.txtObservacionesGenerales.Size = new System.Drawing.Size(440, 100);
            this.txtObservacionesGenerales.TabIndex = 3;
            this.txtObservacionesGenerales.MaxLength = 300;
            this.txtObservacionesGenerales.TextChanged += new System.EventHandler(this.txtObservacionesGenerales_TextChanged);

            // 
            // lblContadorObs
            // 
            this.lblContadorObs.AutoSize = true;
            this.lblContadorObs.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblContadorObs.ForeColor = System.Drawing.Color.Gray;
            this.lblContadorObs.Location = new System.Drawing.Point(390, 580);
            this.lblContadorObs.Name = "lblContadorObs";
            this.lblContadorObs.Size = new System.Drawing.Size(50, 17);
            this.lblContadorObs.TabIndex = 4;
            this.lblContadorObs.Text = "0/300";

            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTotalTitulo.Location = new System.Drawing.Point(490, 460);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(150, 19);
            this.lblTotalTitulo.TabIndex = 5;
            this.lblTotalTitulo.Text = "TOTAL DE LA ORDEN";

            // 
            // lblTotalOrden
            // 
            this.lblTotalOrden.AutoSize = true;
            this.lblTotalOrden.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrden.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblTotalOrden.Location = new System.Drawing.Point(490, 482);
            this.lblTotalOrden.Name = "lblTotalOrden";
            this.lblTotalOrden.Size = new System.Drawing.Size(170, 49);
            this.lblTotalOrden.TabIndex = 6;
            this.lblTotalOrden.Text = "$0.00";

            // 
            // btnEnviarCocina
            // 
            this.btnEnviarCocina.BorderRadius = 10;
            this.btnEnviarCocina.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnEnviarCocina.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEnviarCocina.ForeColor = System.Drawing.Color.White;
            this.btnEnviarCocina.Location = new System.Drawing.Point(20, 600);
            this.btnEnviarCocina.Name = "btnEnviarCocina";
            this.btnEnviarCocina.Size = new System.Drawing.Size(330, 65);
            this.btnEnviarCocina.TabIndex = 7;
            this.btnEnviarCocina.Text = "🔔  Enviar a Cocina";
            this.btnEnviarCocina.Click += new System.EventHandler(this.btnEnviarCocina_Click);

            // 
            // btnSolicitarCierre
            // 
            this.btnSolicitarCierre.BorderRadius = 10;
            this.btnSolicitarCierre.FillColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.btnSolicitarCierre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSolicitarCierre.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarCierre.Location = new System.Drawing.Point(365, 600);
            this.btnSolicitarCierre.Name = "btnSolicitarCierre";
            this.btnSolicitarCierre.Size = new System.Drawing.Size(340, 65);
            this.btnSolicitarCierre.TabIndex = 8;
            this.btnSolicitarCierre.Text = "🧾  Solicitar Cierre de Cuenta";
            this.btnSolicitarCierre.Click += new System.EventHandler(this.btnSolicitarCierre_Click);

            // 
            // frmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1360, 870);
            this.Controls.Add(this.pnlSeleccionMesa);
            this.Controls.Add(this.pnlMesaInfo);
            this.Controls.Add(this.pnlEstadoOrden);
            this.Controls.Add(this.pnlCatalogo);
            this.Controls.Add(this.pnlDetalleOrden);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOrdenes";
            this.Text = "Registro de Órdenes";
            this.Load += new System.EventHandler(this.frmOrdenes_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).EndInit();
            this.pnlSeleccionMesa.ResumeLayout(false);
            this.pnlSeleccionMesa.PerformLayout();
            this.pnlMesaInfo.ResumeLayout(false);
            this.pnlMesaInfo.PerformLayout();
            this.pnlEstadoOrden.ResumeLayout(false);
            this.pnlEstadoOrden.PerformLayout();
            this.pnlCatalogo.ResumeLayout(false);
            this.pnlCatalogo.PerformLayout();
            this.pnlCategorias.ResumeLayout(false);
            this.pnlProductosHeader.ResumeLayout(false);
            this.pnlProductosHeader.PerformLayout();
            this.pnlDetalleOrden.ResumeLayout(false);
            this.pnlDetalleOrden.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlSeleccionMesa;
        private System.Windows.Forms.Label lblTituloSeleccionMesa;
        private Guna.UI2.WinForms.Guna2ComboBox cbxMesa;

        private Guna.UI2.WinForms.Guna2Panel pnlMesaInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlIconoMesa;
        private System.Windows.Forms.Label lblIconoMesa;
        private System.Windows.Forms.Label lblMesaSeleccionadaTitulo;
        private System.Windows.Forms.Label lblNumeroMesa;
        private System.Windows.Forms.Label lblZonaTitulo;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label lblMeseroTitulo;
        private System.Windows.Forms.Label lblMeseroAsignado;

        private Guna.UI2.WinForms.Guna2Panel pnlEstadoOrden;
        private System.Windows.Forms.Label lblEstadoOrdenTitulo;
        private Guna.UI2.WinForms.Guna2Panel lblEstadoOrden;
        private System.Windows.Forms.Label lblEstadoOrdenTexto;

        private Guna.UI2.WinForms.Guna2Panel pnlCatalogo;
        private System.Windows.Forms.Label lblCatalogoTitulo;
        private System.Windows.Forms.FlowLayoutPanel pnlCategorias;
        private Guna.UI2.WinForms.Guna2Button btnCatEntradas;
        private Guna.UI2.WinForms.Guna2Button btnCatPlatosFuertes;
        private Guna.UI2.WinForms.Guna2Button btnCatBebidas;
        private Guna.UI2.WinForms.Guna2Button btnCatPostres;
        private Guna.UI2.WinForms.Guna2Button btnCatExtras;
        private Guna.UI2.WinForms.Guna2Panel pnlProductosHeader;
        private System.Windows.Forms.Label lblColProducto;
        private System.Windows.Forms.Label lblColPrecio;
        private System.Windows.Forms.Panel pnlProductosContainer;

        private Guna.UI2.WinForms.Guna2Panel pnlDetalleOrden;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.DataGridView dgvDetalleOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Label lblObservacionesGenerales;
        private Guna.UI2.WinForms.Guna2TextBox txtObservacionesGenerales;
        private System.Windows.Forms.Label lblContadorObs;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalOrden;
        private Guna.UI2.WinForms.Guna2Button btnEnviarCocina;
        private Guna.UI2.WinForms.Guna2Button btnSolicitarCierre;
    }
}