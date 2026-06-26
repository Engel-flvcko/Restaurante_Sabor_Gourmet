namespace Restaurante_Sabor_Gourmet.Haydee
{
    partial class frmUsuarios
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
            this.pnlTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.picIcono = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuarioSesion = new System.Windows.Forms.Label();
            this.lblRolSesion = new System.Windows.Forms.Label();

            this.pnlDatos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDatosUsuario = new System.Windows.Forms.Label();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new Guna.UI2.WinForms.Guna2ComboBox();

            this.btnCrearUsuario = new Guna.UI2.WinForms.Guna2Button();
            this.lblTituloAccion = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();

            this.pnlGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();

            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).BeginInit();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════════
            this.Text = "Sabor Gourmet FMO - Gestión de Usuarios";
            this.Size = new System.Drawing.Size(1060, 760);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.frmUsuarios_Load);

            // ══════════════════════════════════════════════════════════════
            // BARRA SUPERIOR
            // ══════════════════════════════════════════════════════════════
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Size = new System.Drawing.Size(1060, 108);
            this.pnlTopBar.FillColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlTopBar.BorderRadius = 0;
            this.pnlTopBar.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.picIcono, this.lblTitulo, this.lblUsuarioSesion, this.lblRolSesion
            });

            this.picIcono.Location = new System.Drawing.Point(18, 24);
            this.picIcono.Size = new System.Drawing.Size(58, 58);
            this.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcono.Image = null;

            this.lblTitulo.Text = "Gestión de Usuarios";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(90, 28);
            this.lblTitulo.Size = new System.Drawing.Size(480, 50);
            this.lblTitulo.AutoSize = false;

            this.lblUsuarioSesion.Text = "";
            this.lblUsuarioSesion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioSesion.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUsuarioSesion.Location = new System.Drawing.Point(750, 28);
            this.lblUsuarioSesion.Size = new System.Drawing.Size(280, 24);

            this.lblRolSesion.Text = "";
            this.lblRolSesion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRolSesion.ForeColor = System.Drawing.Color.FromArgb(180, 180, 200);
            this.lblRolSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRolSesion.Location = new System.Drawing.Point(750, 56);
            this.lblRolSesion.Size = new System.Drawing.Size(280, 20);

            // ══════════════════════════════════════════════════════════════
            // PANEL DATOS DE USUARIO
            // ══════════════════════════════════════════════════════════════
            this.pnlDatos.Location = new System.Drawing.Point(18, 122);
            this.pnlDatos.Size = new System.Drawing.Size(1020, 295);
            this.pnlDatos.FillColor = System.Drawing.Color.White;
            this.pnlDatos.BorderRadius = 12;
            this.pnlDatos.ShadowDecoration.Enabled = true;
            this.pnlDatos.ShadowDecoration.Color = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            this.pnlDatos.ShadowDecoration.Depth = 6;
            this.pnlDatos.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblDatosUsuario,
                this.picBuscar, this.txtBuscar,
                this.lblNombre,   this.txtNombre,
                this.lblTelefono, this.txtTelefono,
                this.lblUsername, this.txtUsername,
                this.lblPassword, this.txtPassword,
                this.lblRol,      this.cmbRol
            });

            this.lblDatosUsuario.Text = "Datos de Usuario";
            this.lblDatosUsuario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDatosUsuario.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblDatosUsuario.Location = new System.Drawing.Point(18, 14);
            this.lblDatosUsuario.AutoSize = true;

            // Buscador
            this.picBuscar.Location = new System.Drawing.Point(18, 48);
            this.picBuscar.Size = new System.Drawing.Size(26, 26);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBuscar.Image = null;

            this.txtBuscar.Location = new System.Drawing.Point(50, 44);
            this.txtBuscar.Size = new System.Drawing.Size(950, 36);
            this.txtBuscar.PlaceholderText = "Buscar...";
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.BorderRadius = 6;
            this.txtBuscar.FillColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.txtBuscar.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // Columna izquierda — Nombre
            this.lblNombre.Text = "Nombre completo:";
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblNombre.Location = new System.Drawing.Point(18, 100);
            this.lblNombre.AutoSize = true;

            this.txtNombre.Location = new System.Drawing.Point(18, 120);
            this.txtNombre.Size = new System.Drawing.Size(470, 38);
            this.txtNombre.PlaceholderText = "Ingrese el nombre completo";
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.BorderRadius = 6;
            this.txtNombre.FillColor = System.Drawing.Color.White;
            this.txtNombre.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);

            // Columna izquierda — Teléfono
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblTelefono.Location = new System.Drawing.Point(18, 175);
            this.lblTelefono.AutoSize = true;

            this.txtTelefono.Location = new System.Drawing.Point(18, 195);
            this.txtTelefono.Size = new System.Drawing.Size(470, 38);
            this.txtTelefono.PlaceholderText = "Ingrese el teléfono";
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.BorderRadius = 6;
            this.txtTelefono.FillColor = System.Drawing.Color.White;
            this.txtTelefono.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);

            // Columna derecha — Usuario
            this.lblUsername.Text = "Usuario:";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblUsername.Location = new System.Drawing.Point(532, 100);
            this.lblUsername.AutoSize = true;

            this.txtUsername.Location = new System.Drawing.Point(532, 120);
            this.txtUsername.Size = new System.Drawing.Size(468, 38);
            this.txtUsername.PlaceholderText = "Ingrese el nombre de usuario";
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.BorderRadius = 6;
            this.txtUsername.FillColor = System.Drawing.Color.White;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);

            // Columna derecha — Contraseña
            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblPassword.Location = new System.Drawing.Point(532, 175);
            this.lblPassword.AutoSize = true;

            this.txtPassword.Location = new System.Drawing.Point(532, 195);
            this.txtPassword.Size = new System.Drawing.Size(468, 38);
            this.txtPassword.PlaceholderText = "••••••••";
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.BorderRadius = 6;
            this.txtPassword.FillColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.txtPassword.UseSystemPasswordChar = true;

            // Columna derecha — Rol
            this.lblRol.Text = "Rol:";
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblRol.Location = new System.Drawing.Point(532, 250);
            this.lblRol.AutoSize = true;

            this.cmbRol.Location = new System.Drawing.Point(532, 268);
            this.cmbRol.Size = new System.Drawing.Size(468, 38);
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRol.BorderRadius = 6;
            this.cmbRol.FillColor = System.Drawing.Color.White;
            this.cmbRol.BorderColor = System.Drawing.Color.FromArgb(200, 200, 220);

            // ══════════════════════════════════════════════════════════════
            // FILA DE BOTONES
            // ══════════════════════════════════════════════════════════════
            this.btnCrearUsuario.Text = "+ Nuevo Usuario";
            this.btnCrearUsuario.Location = new System.Drawing.Point(18, 432);
            this.btnCrearUsuario.Size = new System.Drawing.Size(170, 42);
            this.btnCrearUsuario.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnCrearUsuario.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrearUsuario.BorderRadius = 8;
            this.btnCrearUsuario.BorderThickness = 0;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);

            this.lblTituloAccion.Text = "Nuevo usuario";
            this.lblTituloAccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloAccion.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblTituloAccion.Location = new System.Drawing.Point(420, 442);
            this.lblTituloAccion.Size = new System.Drawing.Size(220, 22);
            this.lblTituloAccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(870, 432);
            this.btnGuardar.Size = new System.Drawing.Size(168, 42);
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGuardar.HoverState.FillColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.BorderThickness = 0;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // ══════════════════════════════════════════════════════════════
            // PANEL GRID
            // ══════════════════════════════════════════════════════════════
            this.pnlGrid.Location = new System.Drawing.Point(18, 490);
            this.pnlGrid.Size = new System.Drawing.Size(1020, 230);
            this.pnlGrid.FillColor = System.Drawing.Color.White;
            this.pnlGrid.BorderRadius = 12;
            this.pnlGrid.ShadowDecoration.Enabled = true;
            this.pnlGrid.ShadowDecoration.Color = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            this.pnlGrid.ShadowDecoration.Depth = 6;
            this.pnlGrid.Controls.Add(this.dgvUsuarios);

            // DataGridView
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.dgvUsuarios.Size = new System.Drawing.Size(1020, 230);
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(230, 230, 240);
            this.dgvUsuarios.AutoGenerateColumns = false;

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvUsuarios.ColumnHeadersHeight = 42;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;

            this.dgvUsuarios.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsuarios.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 60);
            this.dgvUsuarios.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsuarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.dgvUsuarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvUsuarios.RowTemplate.Height = 38;
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);

            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);

            // ══════════════════════════════════════════════════════════════
            // AGREGAR AL FORM
            // ══════════════════════════════════════════════════════════════
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.pnlTopBar,
                this.pnlDatos,
                this.btnCrearUsuario,
                this.lblTituloAccion,
                this.btnGuardar,
                this.pnlGrid
            });

            this.pnlTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Declaración de variables ──────────────────────────────────────
        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picIcono;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioSesion;
        private System.Windows.Forms.Label lblRolSesion;

        private Guna.UI2.WinForms.Guna2Panel pnlDatos;
        private System.Windows.Forms.Label lblDatosUsuario;
        private System.Windows.Forms.PictureBox picBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefono;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblRol;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRol;

        private Guna.UI2.WinForms.Guna2Button btnCrearUsuario;
        private System.Windows.Forms.Label lblTituloAccion;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;

        private Guna.UI2.WinForms.Guna2Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}