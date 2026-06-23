namespace Restaurante_Sabor_Gourmet.Formularios
{
    partial class frmMeseros
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
            this.pnlDatosMesero = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloDatos = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTogglePassword = new Guna.UI2.WinForms.Guna2Button();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblActivo = new System.Windows.Forms.Label();
            this.switchActivo = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lblActivoTexto = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnActualizar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();

            this.pnlListaMeseros = new Guna.UI2.WinForms.Guna2Panel();
            this.lblListaTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvMeseros = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlMetricas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMetricasTitulo = new System.Windows.Forms.Label();

            this.pnlKpiOrdenes = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconOrdenes = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconOrdenes = new System.Windows.Forms.Label();
            this.lblKpiOrdenesValor = new System.Windows.Forms.Label();
            this.lblKpiOrdenesLabel = new System.Windows.Forms.Label();
            this.lblKpiOrdenesPeriodo = new System.Windows.Forms.Label();

            this.pnlKpiVentas = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconVentas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconVentas = new System.Windows.Forms.Label();
            this.lblKpiVentasValor = new System.Windows.Forms.Label();
            this.lblKpiVentasLabel = new System.Windows.Forms.Label();
            this.lblKpiVentasPeriodo = new System.Windows.Forms.Label();

            this.pnlKpiTiempo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconTiempo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconTiempo = new System.Windows.Forms.Label();
            this.lblKpiTiempoValor = new System.Windows.Forms.Label();
            this.lblKpiTiempoLabel = new System.Windows.Forms.Label();
            this.lblKpiTiempoPeriodo = new System.Windows.Forms.Label();

            this.pnlKpiPropinas = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconPropinas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconPropinas = new System.Windows.Forms.Label();
            this.lblKpiPropinasValor = new System.Windows.Forms.Label();
            this.lblKpiPropinasLabel = new System.Windows.Forms.Label();
            this.lblKpiPropinasPeriodo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMeseros)).BeginInit();
            this.pnlDatosMesero.SuspendLayout();
            this.pnlListaMeseros.SuspendLayout();
            this.pnlMetricas.SuspendLayout();
            this.pnlKpiOrdenes.SuspendLayout();
            this.pnlIconOrdenes.SuspendLayout();
            this.pnlKpiVentas.SuspendLayout();
            this.pnlIconVentas.SuspendLayout();
            this.pnlKpiTiempo.SuspendLayout();
            this.pnlIconTiempo.SuspendLayout();
            this.pnlKpiPropinas.SuspendLayout();
            this.pnlIconPropinas.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlDatosMesero
            // 
            this.pnlDatosMesero.BorderRadius = 12;
            this.pnlDatosMesero.FillColor = System.Drawing.Color.White;
            this.pnlDatosMesero.Location = new System.Drawing.Point(20, 20);
            this.pnlDatosMesero.Name = "pnlDatosMesero";
            this.pnlDatosMesero.ShadowDecoration.Enabled = true;
            this.pnlDatosMesero.Size = new System.Drawing.Size(470, 900);
            this.pnlDatosMesero.TabIndex = 0;
            this.pnlDatosMesero.Controls.Add(this.lblTituloDatos);
            this.pnlDatosMesero.Controls.Add(this.lblNombreCompleto);
            this.pnlDatosMesero.Controls.Add(this.txtNombreCompleto);
            this.pnlDatosMesero.Controls.Add(this.lblUsername);
            this.pnlDatosMesero.Controls.Add(this.txtUsername);
            this.pnlDatosMesero.Controls.Add(this.lblContrasena);
            this.pnlDatosMesero.Controls.Add(this.txtContrasena);
            this.pnlDatosMesero.Controls.Add(this.btnTogglePassword);
            this.pnlDatosMesero.Controls.Add(this.lblTelefono);
            this.pnlDatosMesero.Controls.Add(this.txtTelefono);
            this.pnlDatosMesero.Controls.Add(this.lblFechaIngreso);
            this.pnlDatosMesero.Controls.Add(this.dtpFechaIngreso);
            this.pnlDatosMesero.Controls.Add(this.lblActivo);
            this.pnlDatosMesero.Controls.Add(this.switchActivo);
            this.pnlDatosMesero.Controls.Add(this.lblActivoTexto);
            this.pnlDatosMesero.Controls.Add(this.btnGuardar);
            this.pnlDatosMesero.Controls.Add(this.btnActualizar);
            this.pnlDatosMesero.Controls.Add(this.btnEliminar);
            this.pnlDatosMesero.Controls.Add(this.btnLimpiar);

            // 
            // lblTituloDatos
            // 
            this.lblTituloDatos.AutoSize = true;
            this.lblTituloDatos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloDatos.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloDatos.Location = new System.Drawing.Point(20, 15);
            this.lblTituloDatos.Name = "lblTituloDatos";
            this.lblTituloDatos.Size = new System.Drawing.Size(200, 25);
            this.lblTituloDatos.TabIndex = 0;
            this.lblTituloDatos.Text = "👤  Datos del Mesero";

            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblNombreCompleto.Location = new System.Drawing.Point(20, 70);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(120, 19);
            this.lblNombreCompleto.TabIndex = 1;
            this.lblNombreCompleto.Text = "Nombre completo:";

            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.BorderRadius = 8;
            this.txtNombreCompleto.DefaultText = "";
            this.txtNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNombreCompleto.Location = new System.Drawing.Point(20, 95);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(430, 40);
            this.txtNombreCompleto.TabIndex = 2;

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblUsername.Location = new System.Drawing.Point(20, 150);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 19);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";

            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 8;
            this.txtUsername.DefaultText = "";
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUsername.Location = new System.Drawing.Point(20, 175);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(430, 40);
            this.txtUsername.TabIndex = 4;

            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblContrasena.Location = new System.Drawing.Point(20, 230);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(80, 19);
            this.lblContrasena.TabIndex = 5;
            this.lblContrasena.Text = "Contraseña:";

            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderRadius = 8;
            this.txtContrasena.DefaultText = "";
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtContrasena.Location = new System.Drawing.Point(20, 255);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(380, 40);
            this.txtContrasena.TabIndex = 6;

            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.BorderRadius = 8;
            this.btnTogglePassword.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnTogglePassword.Location = new System.Drawing.Point(410, 255);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(40, 40);
            this.btnTogglePassword.TabIndex = 7;
            this.btnTogglePassword.Text = "👁";
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblTelefono.Location = new System.Drawing.Point(20, 310);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(63, 19);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderRadius = 8;
            this.txtTelefono.DefaultText = "";
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTelefono.Location = new System.Drawing.Point(20, 335);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(430, 40);
            this.txtTelefono.TabIndex = 9;

            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFechaIngreso.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblFechaIngreso.Location = new System.Drawing.Point(20, 390);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(100, 19);
            this.lblFechaIngreso.TabIndex = 10;
            this.lblFechaIngreso.Text = "Fecha de ingreso:";

            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.BorderRadius = 8;
            this.dtpFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(20, 415);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(430, 40);
            this.dtpFechaIngreso.TabIndex = 11;
            this.dtpFechaIngreso.Value = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);

            // 
            // lblActivo
            // 
            this.lblActivo.AutoSize = true;
            this.lblActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblActivo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblActivo.Location = new System.Drawing.Point(20, 470);
            this.lblActivo.Name = "lblActivo";
            this.lblActivo.Size = new System.Drawing.Size(45, 19);
            this.lblActivo.TabIndex = 12;
            this.lblActivo.Text = "Activo:";

            // 
            // switchActivo
            // 
            this.switchActivo.CheckedState.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.switchActivo.Location = new System.Drawing.Point(20, 495);
            this.switchActivo.Name = "switchActivo";
            this.switchActivo.Size = new System.Drawing.Size(50, 26);
            this.switchActivo.TabIndex = 13;
            this.switchActivo.Checked = true;
            this.switchActivo.CheckedChanged += new System.EventHandler(this.switchActivo_CheckedChanged);

            // 
            // lblActivoTexto
            // 
            this.lblActivoTexto.AutoSize = true;
            this.lblActivoTexto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActivoTexto.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblActivoTexto.Location = new System.Drawing.Point(80, 498);
            this.lblActivoTexto.Name = "lblActivoTexto";
            this.lblActivoTexto.Size = new System.Drawing.Size(20, 20);
            this.lblActivoTexto.TabIndex = 14;
            this.lblActivoTexto.Text = "Sí";

            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 560);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(430, 55);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "💾  Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // btnActualizar
            // 
            this.btnActualizar.BorderRadius = 10;
            this.btnActualizar.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(20, 625);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(430, 55);
            this.btnActualizar.TabIndex = 16;
            this.btnActualizar.Text = "✏️  Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // 
            // btnEliminar
            // 
            this.btnEliminar.BorderRadius = 10;
            this.btnEliminar.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(20, 690);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(430, 55);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "🗑  Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BorderRadius = 10;
            this.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(120, 120, 130);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(20, 755);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(430, 55);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "🧹  Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // 
            // pnlListaMeseros
            // 
            this.pnlListaMeseros.BorderRadius = 12;
            this.pnlListaMeseros.FillColor = System.Drawing.Color.White;
            this.pnlListaMeseros.Location = new System.Drawing.Point(510, 20);
            this.pnlListaMeseros.Name = "pnlListaMeseros";
            this.pnlListaMeseros.ShadowDecoration.Enabled = true;
            this.pnlListaMeseros.Size = new System.Drawing.Size(1006, 560);
            this.pnlListaMeseros.TabIndex = 1;
            this.pnlListaMeseros.Controls.Add(this.lblListaTitulo);
            this.pnlListaMeseros.Controls.Add(this.txtBuscar);
            this.pnlListaMeseros.Controls.Add(this.dgvMeseros);

            // 
            // lblListaTitulo
            // 
            this.lblListaTitulo.AutoSize = true;
            this.lblListaTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblListaTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblListaTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblListaTitulo.Name = "lblListaTitulo";
            this.lblListaTitulo.Size = new System.Drawing.Size(190, 25);
            this.lblListaTitulo.TabIndex = 0;
            this.lblListaTitulo.Text = "📋  Lista de Meseros";

            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.IconLeft = null;
            this.txtBuscar.Location = new System.Drawing.Point(766, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "🔍  Buscar mesero...";
            this.txtBuscar.Size = new System.Drawing.Size(220, 40);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // 
            // dgvMeseros
            // 
            this.dgvMeseros.AllowUserToAddRows = false;
            this.dgvMeseros.AllowUserToResizeRows = false;
            this.dgvMeseros.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeseros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMeseros.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvMeseros.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMeseros.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvMeseros.ColumnHeadersHeight = 38;
            this.dgvMeseros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMeseros.RowHeadersVisible = false;
            this.dgvMeseros.RowTemplate.Height = 40;
            this.dgvMeseros.ReadOnly = true;
            this.dgvMeseros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeseros.MultiSelect = false;
            this.dgvMeseros.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvMeseros.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(229, 240, 255);
            this.dgvMeseros.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvMeseros.GridColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.dgvMeseros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeseros.Location = new System.Drawing.Point(20, 65);
            this.dgvMeseros.Name = "dgvMeseros";
            this.dgvMeseros.Size = new System.Drawing.Size(966, 480);
            this.dgvMeseros.TabIndex = 2;
            this.dgvMeseros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colUsername,
            this.colTelefono,
            this.colFechaIngreso,
            this.colActivo});
            this.dgvMeseros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeseros_CellClick);
            this.dgvMeseros.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMeseros_CellFormatting);

            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.FillWeight = 8F;
            this.colId.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.FillWeight = 28F;

            // 
            // colUsername
            // 
            this.colUsername.HeaderText = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.FillWeight = 18F;

            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.FillWeight = 18F;

            // 
            // colFechaIngreso
            // 
            this.colFechaIngreso.HeaderText = "Fecha Ingreso";
            this.colFechaIngreso.Name = "colFechaIngreso";
            this.colFechaIngreso.FillWeight = 18F;
            this.colFechaIngreso.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // 
            // colActivo
            // 
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.FillWeight = 12F;
            this.colActivo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colActivo.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // 
            // pnlMetricas
            // 
            this.pnlMetricas.BorderRadius = 12;
            this.pnlMetricas.FillColor = System.Drawing.Color.White;
            this.pnlMetricas.Location = new System.Drawing.Point(510, 600);
            this.pnlMetricas.Name = "pnlMetricas";
            this.pnlMetricas.ShadowDecoration.Enabled = true;
            this.pnlMetricas.Size = new System.Drawing.Size(1006, 320);
            this.pnlMetricas.TabIndex = 2;
            this.pnlMetricas.Controls.Add(this.lblMetricasTitulo);
            this.pnlMetricas.Controls.Add(this.pnlKpiOrdenes);
            this.pnlMetricas.Controls.Add(this.pnlKpiVentas);
            this.pnlMetricas.Controls.Add(this.pnlKpiTiempo);
            this.pnlMetricas.Controls.Add(this.pnlKpiPropinas);

            // 
            // lblMetricasTitulo
            // 
            this.lblMetricasTitulo.AutoSize = true;
            this.lblMetricasTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMetricasTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblMetricasTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblMetricasTitulo.Name = "lblMetricasTitulo";
            this.lblMetricasTitulo.Size = new System.Drawing.Size(260, 25);
            this.lblMetricasTitulo.TabIndex = 0;
            this.lblMetricasTitulo.Text = "📊  Métricas de Desempeño";

            // ===================== KPI: Órdenes Atendidas =====================
            // 
            // pnlKpiOrdenes
            // 
            this.pnlKpiOrdenes.BorderColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.pnlKpiOrdenes.BorderThickness = 2;
            this.pnlKpiOrdenes.BorderRadius = 10;
            this.pnlKpiOrdenes.FillColor = System.Drawing.Color.White;
            this.pnlKpiOrdenes.Location = new System.Drawing.Point(20, 60);
            this.pnlKpiOrdenes.Name = "pnlKpiOrdenes";
            this.pnlKpiOrdenes.Size = new System.Drawing.Size(230, 230);
            this.pnlKpiOrdenes.TabIndex = 1;
            this.pnlKpiOrdenes.Controls.Add(this.pnlIconOrdenes);
            this.pnlKpiOrdenes.Controls.Add(this.lblKpiOrdenesValor);
            this.pnlKpiOrdenes.Controls.Add(this.lblKpiOrdenesLabel);
            this.pnlKpiOrdenes.Controls.Add(this.lblKpiOrdenesPeriodo);

            this.pnlIconOrdenes.BorderRadius = 28;
            this.pnlIconOrdenes.FillColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.pnlIconOrdenes.Location = new System.Drawing.Point(87, 20);
            this.pnlIconOrdenes.Name = "pnlIconOrdenes";
            this.pnlIconOrdenes.Size = new System.Drawing.Size(56, 56);
            this.pnlIconOrdenes.TabIndex = 0;
            this.pnlIconOrdenes.Controls.Add(this.lblIconOrdenes);

            this.lblIconOrdenes.AutoSize = false;
            this.lblIconOrdenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconOrdenes.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconOrdenes.Name = "lblIconOrdenes";
            this.lblIconOrdenes.Text = "🍽";
            this.lblIconOrdenes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiOrdenesValor.AutoSize = false;
            this.lblKpiOrdenesValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiOrdenesValor.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblKpiOrdenesValor.Location = new System.Drawing.Point(0, 85);
            this.lblKpiOrdenesValor.Name = "lblKpiOrdenesValor";
            this.lblKpiOrdenesValor.Size = new System.Drawing.Size(230, 40);
            this.lblKpiOrdenesValor.TabIndex = 1;
            this.lblKpiOrdenesValor.Text = "0";
            this.lblKpiOrdenesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiOrdenesLabel.AutoSize = false;
            this.lblKpiOrdenesLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiOrdenesLabel.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblKpiOrdenesLabel.Location = new System.Drawing.Point(0, 130);
            this.lblKpiOrdenesLabel.Name = "lblKpiOrdenesLabel";
            this.lblKpiOrdenesLabel.Size = new System.Drawing.Size(230, 20);
            this.lblKpiOrdenesLabel.TabIndex = 2;
            this.lblKpiOrdenesLabel.Text = "Órdenes Atendidas";
            this.lblKpiOrdenesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiOrdenesPeriodo.AutoSize = false;
            this.lblKpiOrdenesPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiOrdenesPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiOrdenesPeriodo.Location = new System.Drawing.Point(0, 152);
            this.lblKpiOrdenesPeriodo.Name = "lblKpiOrdenesPeriodo";
            this.lblKpiOrdenesPeriodo.Size = new System.Drawing.Size(230, 18);
            this.lblKpiOrdenesPeriodo.TabIndex = 3;
            this.lblKpiOrdenesPeriodo.Text = "Este mes";
            this.lblKpiOrdenesPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===================== KPI: Ventas Generadas =====================
            // 
            // pnlKpiVentas
            // 
            this.pnlKpiVentas.BorderColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlKpiVentas.BorderThickness = 2;
            this.pnlKpiVentas.BorderRadius = 10;
            this.pnlKpiVentas.FillColor = System.Drawing.Color.White;
            this.pnlKpiVentas.Location = new System.Drawing.Point(270, 60);
            this.pnlKpiVentas.Name = "pnlKpiVentas";
            this.pnlKpiVentas.Size = new System.Drawing.Size(230, 230);
            this.pnlKpiVentas.TabIndex = 2;
            this.pnlKpiVentas.Controls.Add(this.pnlIconVentas);
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasValor);
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasLabel);
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasPeriodo);

            this.pnlIconVentas.BorderRadius = 28;
            this.pnlIconVentas.FillColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.pnlIconVentas.Location = new System.Drawing.Point(87, 20);
            this.pnlIconVentas.Name = "pnlIconVentas";
            this.pnlIconVentas.Size = new System.Drawing.Size(56, 56);
            this.pnlIconVentas.TabIndex = 0;
            this.pnlIconVentas.Controls.Add(this.lblIconVentas);

            this.lblIconVentas.AutoSize = false;
            this.lblIconVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconVentas.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconVentas.Name = "lblIconVentas";
            this.lblIconVentas.Text = "🛒";
            this.lblIconVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiVentasValor.AutoSize = false;
            this.lblKpiVentasValor.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpiVentasValor.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiVentasValor.Location = new System.Drawing.Point(0, 88);
            this.lblKpiVentasValor.Name = "lblKpiVentasValor";
            this.lblKpiVentasValor.Size = new System.Drawing.Size(230, 36);
            this.lblKpiVentasValor.TabIndex = 1;
            this.lblKpiVentasValor.Text = "$0.00";
            this.lblKpiVentasValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiVentasLabel.AutoSize = false;
            this.lblKpiVentasLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiVentasLabel.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblKpiVentasLabel.Location = new System.Drawing.Point(0, 130);
            this.lblKpiVentasLabel.Name = "lblKpiVentasLabel";
            this.lblKpiVentasLabel.Size = new System.Drawing.Size(230, 20);
            this.lblKpiVentasLabel.TabIndex = 2;
            this.lblKpiVentasLabel.Text = "Ventas Generadas";
            this.lblKpiVentasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiVentasPeriodo.AutoSize = false;
            this.lblKpiVentasPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiVentasPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiVentasPeriodo.Location = new System.Drawing.Point(0, 152);
            this.lblKpiVentasPeriodo.Name = "lblKpiVentasPeriodo";
            this.lblKpiVentasPeriodo.Size = new System.Drawing.Size(230, 18);
            this.lblKpiVentasPeriodo.TabIndex = 3;
            this.lblKpiVentasPeriodo.Text = "Este mes";
            this.lblKpiVentasPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===================== KPI: Tiempo Promedio =====================
            // 
            // pnlKpiTiempo
            // 
            this.pnlKpiTiempo.BorderColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.pnlKpiTiempo.BorderThickness = 2;
            this.pnlKpiTiempo.BorderRadius = 10;
            this.pnlKpiTiempo.FillColor = System.Drawing.Color.White;
            this.pnlKpiTiempo.Location = new System.Drawing.Point(520, 60);
            this.pnlKpiTiempo.Name = "pnlKpiTiempo";
            this.pnlKpiTiempo.Size = new System.Drawing.Size(230, 230);
            this.pnlKpiTiempo.TabIndex = 3;
            this.pnlKpiTiempo.Controls.Add(this.pnlIconTiempo);
            this.pnlKpiTiempo.Controls.Add(this.lblKpiTiempoValor);
            this.pnlKpiTiempo.Controls.Add(this.lblKpiTiempoLabel);
            this.pnlKpiTiempo.Controls.Add(this.lblKpiTiempoPeriodo);

            this.pnlIconTiempo.BorderRadius = 28;
            this.pnlIconTiempo.FillColor = System.Drawing.Color.FromArgb(255, 237, 213);
            this.pnlIconTiempo.Location = new System.Drawing.Point(87, 20);
            this.pnlIconTiempo.Name = "pnlIconTiempo";
            this.pnlIconTiempo.Size = new System.Drawing.Size(56, 56);
            this.pnlIconTiempo.TabIndex = 0;
            this.pnlIconTiempo.Controls.Add(this.lblIconTiempo);

            this.lblIconTiempo.AutoSize = false;
            this.lblIconTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconTiempo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconTiempo.Name = "lblIconTiempo";
            this.lblIconTiempo.Text = "⏱";
            this.lblIconTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTiempoValor.AutoSize = false;
            this.lblKpiTiempoValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiTiempoValor.ForeColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.lblKpiTiempoValor.Location = new System.Drawing.Point(0, 85);
            this.lblKpiTiempoValor.Name = "lblKpiTiempoValor";
            this.lblKpiTiempoValor.Size = new System.Drawing.Size(230, 40);
            this.lblKpiTiempoValor.TabIndex = 1;
            this.lblKpiTiempoValor.Text = "0 min";
            this.lblKpiTiempoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTiempoLabel.AutoSize = false;
            this.lblKpiTiempoLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiTiempoLabel.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblKpiTiempoLabel.Location = new System.Drawing.Point(0, 130);
            this.lblKpiTiempoLabel.Name = "lblKpiTiempoLabel";
            this.lblKpiTiempoLabel.Size = new System.Drawing.Size(230, 35);
            this.lblKpiTiempoLabel.TabIndex = 2;
            this.lblKpiTiempoLabel.Text = "Tiempo Promedio\nde Atención";
            this.lblKpiTiempoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTiempoPeriodo.AutoSize = false;
            this.lblKpiTiempoPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiTiempoPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiTiempoPeriodo.Location = new System.Drawing.Point(0, 168);
            this.lblKpiTiempoPeriodo.Name = "lblKpiTiempoPeriodo";
            this.lblKpiTiempoPeriodo.Size = new System.Drawing.Size(230, 18);
            this.lblKpiTiempoPeriodo.TabIndex = 3;
            this.lblKpiTiempoPeriodo.Text = "Este mes";
            this.lblKpiTiempoPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===================== KPI: Total de Propinas =====================
            // 
            // pnlKpiPropinas
            // 
            this.pnlKpiPropinas.BorderColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.pnlKpiPropinas.BorderThickness = 2;
            this.pnlKpiPropinas.BorderRadius = 10;
            this.pnlKpiPropinas.FillColor = System.Drawing.Color.White;
            this.pnlKpiPropinas.Location = new System.Drawing.Point(770, 60);
            this.pnlKpiPropinas.Name = "pnlKpiPropinas";
            this.pnlKpiPropinas.Size = new System.Drawing.Size(216, 230);
            this.pnlKpiPropinas.TabIndex = 4;
            this.pnlKpiPropinas.Controls.Add(this.pnlIconPropinas);
            this.pnlKpiPropinas.Controls.Add(this.lblKpiPropinasValor);
            this.pnlKpiPropinas.Controls.Add(this.lblKpiPropinasLabel);
            this.pnlKpiPropinas.Controls.Add(this.lblKpiPropinasPeriodo);

            this.pnlIconPropinas.BorderRadius = 28;
            this.pnlIconPropinas.FillColor = System.Drawing.Color.FromArgb(243, 232, 255);
            this.pnlIconPropinas.Location = new System.Drawing.Point(80, 20);
            this.pnlIconPropinas.Name = "pnlIconPropinas";
            this.pnlIconPropinas.Size = new System.Drawing.Size(56, 56);
            this.pnlIconPropinas.TabIndex = 0;
            this.pnlIconPropinas.Controls.Add(this.lblIconPropinas);

            this.lblIconPropinas.AutoSize = false;
            this.lblIconPropinas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconPropinas.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconPropinas.Name = "lblIconPropinas";
            this.lblIconPropinas.Text = "💰";
            this.lblIconPropinas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiPropinasValor.AutoSize = false;
            this.lblKpiPropinasValor.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpiPropinasValor.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblKpiPropinasValor.Location = new System.Drawing.Point(0, 88);
            this.lblKpiPropinasValor.Name = "lblKpiPropinasValor";
            this.lblKpiPropinasValor.Size = new System.Drawing.Size(216, 36);
            this.lblKpiPropinasValor.TabIndex = 1;
            this.lblKpiPropinasValor.Text = "$0.00";
            this.lblKpiPropinasValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiPropinasLabel.AutoSize = false;
            this.lblKpiPropinasLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiPropinasLabel.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblKpiPropinasLabel.Location = new System.Drawing.Point(0, 130);
            this.lblKpiPropinasLabel.Name = "lblKpiPropinasLabel";
            this.lblKpiPropinasLabel.Size = new System.Drawing.Size(216, 20);
            this.lblKpiPropinasLabel.TabIndex = 2;
            this.lblKpiPropinasLabel.Text = "Total de Propinas";
            this.lblKpiPropinasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiPropinasPeriodo.AutoSize = false;
            this.lblKpiPropinasPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiPropinasPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiPropinasPeriodo.Location = new System.Drawing.Point(0, 152);
            this.lblKpiPropinasPeriodo.Name = "lblKpiPropinasPeriodo";
            this.lblKpiPropinasPeriodo.Size = new System.Drawing.Size(216, 18);
            this.lblKpiPropinasPeriodo.TabIndex = 3;
            this.lblKpiPropinasPeriodo.Text = "Este mes";
            this.lblKpiPropinasPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // frmMeseros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1536, 940);
            this.Controls.Add(this.pnlDatosMesero);
            this.Controls.Add(this.pnlListaMeseros);
            this.Controls.Add(this.pnlMetricas);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMeseros";
            this.Text = "Gestión de Meseros";
            this.Load += new System.EventHandler(this.frmMeseros_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMeseros)).EndInit();
            this.pnlDatosMesero.ResumeLayout(false);
            this.pnlDatosMesero.PerformLayout();
            this.pnlListaMeseros.ResumeLayout(false);
            this.pnlListaMeseros.PerformLayout();
            this.pnlMetricas.ResumeLayout(false);
            this.pnlMetricas.PerformLayout();
            this.pnlKpiOrdenes.ResumeLayout(false);
            this.pnlIconOrdenes.ResumeLayout(false);
            this.pnlKpiVentas.ResumeLayout(false);
            this.pnlIconVentas.ResumeLayout(false);
            this.pnlKpiTiempo.ResumeLayout(false);
            this.pnlIconTiempo.ResumeLayout(false);
            this.pnlKpiPropinas.ResumeLayout(false);
            this.pnlIconPropinas.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlDatosMesero;
        private System.Windows.Forms.Label lblTituloDatos;
        private System.Windows.Forms.Label lblNombreCompleto;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lblContrasena;
        private Guna.UI2.WinForms.Guna2TextBox txtContrasena;
        private Guna.UI2.WinForms.Guna2Button btnTogglePassword;
        private System.Windows.Forms.Label lblTelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefono;
        private System.Windows.Forms.Label lblFechaIngreso;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblActivo;
        private Guna.UI2.WinForms.Guna2ToggleSwitch switchActivo;
        private System.Windows.Forms.Label lblActivoTexto;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnActualizar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;

        private Guna.UI2.WinForms.Guna2Panel pnlListaMeseros;
        private System.Windows.Forms.Label lblListaTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvMeseros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivo;

        private Guna.UI2.WinForms.Guna2Panel pnlMetricas;
        private System.Windows.Forms.Label lblMetricasTitulo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiOrdenes;
        private Guna.UI2.WinForms.Guna2Panel pnlIconOrdenes;
        private System.Windows.Forms.Label lblIconOrdenes;
        private System.Windows.Forms.Label lblKpiOrdenesValor;
        private System.Windows.Forms.Label lblKpiOrdenesLabel;
        private System.Windows.Forms.Label lblKpiOrdenesPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiVentas;
        private Guna.UI2.WinForms.Guna2Panel pnlIconVentas;
        private System.Windows.Forms.Label lblIconVentas;
        private System.Windows.Forms.Label lblKpiVentasValor;
        private System.Windows.Forms.Label lblKpiVentasLabel;
        private System.Windows.Forms.Label lblKpiVentasPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiTiempo;
        private Guna.UI2.WinForms.Guna2Panel pnlIconTiempo;
        private System.Windows.Forms.Label lblIconTiempo;
        private System.Windows.Forms.Label lblKpiTiempoValor;
        private System.Windows.Forms.Label lblKpiTiempoLabel;
        private System.Windows.Forms.Label lblKpiTiempoPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiPropinas;
        private Guna.UI2.WinForms.Guna2Panel pnlIconPropinas;
        private System.Windows.Forms.Label lblIconPropinas;
        private System.Windows.Forms.Label lblKpiPropinasValor;
        private System.Windows.Forms.Label lblKpiPropinasLabel;
        private System.Windows.Forms.Label lblKpiPropinasPeriodo;
    }
}