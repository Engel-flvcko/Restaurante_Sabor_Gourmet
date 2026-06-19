namespace Restaurante_Sabor_Gourmet.Engel.formularios
{
    partial class frmArqueo
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
            System.Windows.Forms.DataGridViewCellStyle dgvStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlSuperior = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlApertura = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAperturaTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFondo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.nudFondoInicial = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnAbrirCaja = new Guna.UI2.WinForms.Guna2Button();
            this.pnlEstado = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEstadoTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEstado = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEsperadoLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEsperado = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlCierre = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCierreTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblContado = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.nudTotalContado = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblDifLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDiferencia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCerrarCaja = new Guna.UI2.WinForms.Guna2Button();
            this.lblHistorial = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvHistorial = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlSuperior.SuspendLayout();
            this.pnlApertura.SuspendLayout();
            this.pnlEstado.SuspendLayout();
            this.pnlCierre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            // ── pnlSuperior ──────────────────────────────────────────────────
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1100, 60);
            this.pnlSuperior.TabIndex = 0;
            this.pnlSuperior.Controls.Add(this.lblTitulo);

            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Arqueo de Caja";

            // ── pnlApertura ──────────────────────────────────────────────────
            this.pnlApertura.BackColor = System.Drawing.Color.White;
            this.pnlApertura.Location = new System.Drawing.Point(10, 70);
            this.pnlApertura.Name = "pnlApertura";
            this.pnlApertura.Size = new System.Drawing.Size(340, 180);
            this.pnlApertura.TabIndex = 1;
            this.pnlApertura.Controls.Add(this.lblAperturaTitulo);
            this.pnlApertura.Controls.Add(this.lblFondo);
            this.pnlApertura.Controls.Add(this.nudFondoInicial);
            this.pnlApertura.Controls.Add(this.btnAbrirCaja);

            this.lblAperturaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblAperturaTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAperturaTitulo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.lblAperturaTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblAperturaTitulo.Name = "lblAperturaTitulo";
            this.lblAperturaTitulo.Size = new System.Drawing.Size(200, 20);
            this.lblAperturaTitulo.TabIndex = 0;
            this.lblAperturaTitulo.Text = "Apertura de caja";

            this.lblFondo.BackColor = System.Drawing.Color.Transparent;
            this.lblFondo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFondo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblFondo.Location = new System.Drawing.Point(15, 45);
            this.lblFondo.Name = "lblFondo";
            this.lblFondo.Size = new System.Drawing.Size(200, 18);
            this.lblFondo.TabIndex = 0;
            this.lblFondo.Text = "Fondo inicial ($)";

            this.nudFondoInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudFondoInicial.Location = new System.Drawing.Point(15, 70);
            this.nudFondoInicial.Name = "nudFondoInicial";
            this.nudFondoInicial.Size = new System.Drawing.Size(200, 36);
            this.nudFondoInicial.TabIndex = 1;
            this.nudFondoInicial.Minimum = 0;
            this.nudFondoInicial.Maximum = 99999;
            this.nudFondoInicial.DecimalPlaces = 2;

            this.btnAbrirCaja.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAbrirCaja.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAbrirCaja.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnAbrirCaja.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnAbrirCaja.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnAbrirCaja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCaja.BorderRadius = 8;
            this.btnAbrirCaja.Location = new System.Drawing.Point(15, 125);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(300, 42);
            this.btnAbrirCaja.TabIndex = 2;
            this.btnAbrirCaja.Text = "Abrir Caja";
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);

            // ── pnlEstado ────────────────────────────────────────────────────
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.pnlEstado.Location = new System.Drawing.Point(360, 70);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(340, 180);
            this.pnlEstado.TabIndex = 2;
            this.pnlEstado.Controls.Add(this.lblEstadoTitulo);
            this.pnlEstado.Controls.Add(this.lblEstado);
            this.pnlEstado.Controls.Add(this.lblEsperadoLabel);
            this.pnlEstado.Controls.Add(this.lblEsperado);

            this.lblEstadoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoTitulo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.lblEstadoTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblEstadoTitulo.Name = "lblEstadoTitulo";
            this.lblEstadoTitulo.Size = new System.Drawing.Size(200, 20);
            this.lblEstadoTitulo.TabIndex = 0;
            this.lblEstadoTitulo.Text = "Estado actual";

            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblEstado.Location = new System.Drawing.Point(15, 45);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(310, 30);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "SIN CAJA ABIERTA";

            this.lblEsperadoLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblEsperadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEsperadoLabel.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblEsperadoLabel.Location = new System.Drawing.Point(15, 90);
            this.lblEsperadoLabel.Name = "lblEsperadoLabel";
            this.lblEsperadoLabel.Size = new System.Drawing.Size(200, 18);
            this.lblEsperadoLabel.TabIndex = 0;
            this.lblEsperadoLabel.Text = "Total esperado en caja";

            this.lblEsperado.BackColor = System.Drawing.Color.Transparent;
            this.lblEsperado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblEsperado.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblEsperado.Location = new System.Drawing.Point(15, 115);
            this.lblEsperado.Name = "lblEsperado";
            this.lblEsperado.Size = new System.Drawing.Size(200, 40);
            this.lblEsperado.TabIndex = 0;
            this.lblEsperado.Text = "$0.00";

            // ── pnlCierre ────────────────────────────────────────────────────
            this.pnlCierre.BackColor = System.Drawing.Color.White;
            this.pnlCierre.Location = new System.Drawing.Point(710, 70);
            this.pnlCierre.Name = "pnlCierre";
            this.pnlCierre.Size = new System.Drawing.Size(370, 180);
            this.pnlCierre.TabIndex = 3;
            this.pnlCierre.Controls.Add(this.lblCierreTitulo);
            this.pnlCierre.Controls.Add(this.lblContado);
            this.pnlCierre.Controls.Add(this.nudTotalContado);
            this.pnlCierre.Controls.Add(this.lblDifLabel);
            this.pnlCierre.Controls.Add(this.lblDiferencia);
            this.pnlCierre.Controls.Add(this.btnCerrarCaja);

            this.lblCierreTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblCierreTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCierreTitulo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.lblCierreTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblCierreTitulo.Name = "lblCierreTitulo";
            this.lblCierreTitulo.Size = new System.Drawing.Size(200, 20);
            this.lblCierreTitulo.TabIndex = 0;
            this.lblCierreTitulo.Text = "Cierre de caja";

            this.lblContado.BackColor = System.Drawing.Color.Transparent;
            this.lblContado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContado.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblContado.Location = new System.Drawing.Point(15, 45);
            this.lblContado.Name = "lblContado";
            this.lblContado.Size = new System.Drawing.Size(200, 18);
            this.lblContado.TabIndex = 0;
            this.lblContado.Text = "Total contado ($)";

            this.nudTotalContado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudTotalContado.Location = new System.Drawing.Point(15, 70);
            this.nudTotalContado.Name = "nudTotalContado";
            this.nudTotalContado.Size = new System.Drawing.Size(200, 36);
            this.nudTotalContado.TabIndex = 1;
            this.nudTotalContado.Minimum = 0;
            this.nudTotalContado.Maximum = 999999;
            this.nudTotalContado.DecimalPlaces = 2;
            this.nudTotalContado.Enabled = false;
            this.nudTotalContado.ValueChanged += new System.EventHandler(this.nudTotalContado_ValueChanged);

            this.lblDifLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblDifLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDifLabel.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblDifLabel.Location = new System.Drawing.Point(230, 45);
            this.lblDifLabel.Name = "lblDifLabel";
            this.lblDifLabel.Size = new System.Drawing.Size(120, 18);
            this.lblDifLabel.TabIndex = 0;
            this.lblDifLabel.Text = "Diferencia";

            this.lblDiferencia.BackColor = System.Drawing.Color.Transparent;
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblDiferencia.Location = new System.Drawing.Point(230, 70);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(130, 36);
            this.lblDiferencia.TabIndex = 0;
            this.lblDiferencia.Text = "-";

            this.btnCerrarCaja.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarCaja.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarCaja.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCerrarCaja.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnCerrarCaja.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.BorderRadius = 8;
            this.btnCerrarCaja.Enabled = false;
            this.btnCerrarCaja.Location = new System.Drawing.Point(15, 125);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(340, 42);
            this.btnCerrarCaja.TabIndex = 2;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);

            // ── lblHistorial + dgvHistorial ───────────────────────────────────
            this.lblHistorial.BackColor = System.Drawing.Color.Transparent;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.lblHistorial.Location = new System.Drawing.Point(10, 265);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(250, 22);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "Historial de arqueos";

            dgvStyle1.BackColor = System.Drawing.Color.White;
            this.dgvHistorial.AlternatingRowsDefaultCellStyle = dgvStyle1;

            dgvStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyle2.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            dgvStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvStyle2.ForeColor = System.Drawing.Color.White;
            dgvStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle = dgvStyle2;

            dgvStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyle3.BackColor = System.Drawing.Color.White;
            dgvStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvStyle3.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            dgvStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(200, 210, 255);
            dgvStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvHistorial.DefaultCellStyle = dgvStyle3;

            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.GridColor = System.Drawing.Color.FromArgb(220, 220, 235);
            this.dgvHistorial.Location = new System.Drawing.Point(10, 295);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.Size = new System.Drawing.Size(1070, 390);
            this.dgvHistorial.TabIndex = 4;
            this.dgvHistorial.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(248, 248, 255);
            this.dgvHistorial.ThemeStyle.ReadOnly = true;

            // ── Form ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlApertura);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.pnlCierre);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.dgvHistorial);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmArqueo";
            this.Text = "Arqueo de Caja - Sabor Gourmet FMO";
            this.Load += new System.EventHandler(this.frmArqueo_Load);

            this.pnlSuperior.ResumeLayout(false);
            this.pnlApertura.ResumeLayout(false);
            this.pnlEstado.ResumeLayout(false);
            this.pnlCierre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlSuperior;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;
        private Guna.UI2.WinForms.Guna2Panel pnlApertura;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAperturaTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFondo;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudFondoInicial;
        private Guna.UI2.WinForms.Guna2Button btnAbrirCaja;
        private Guna.UI2.WinForms.Guna2Panel pnlEstado;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEstadoTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEstado;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEsperadoLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEsperado;
        private Guna.UI2.WinForms.Guna2Panel pnlCierre;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCierreTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblContado;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudTotalContado;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDifLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiferencia;
        private Guna.UI2.WinForms.Guna2Button btnCerrarCaja;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHistorial;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHistorial;
    }
}
