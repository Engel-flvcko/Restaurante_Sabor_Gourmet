namespace Restaurante_Sabor_Gourmet.Jaqueline.Formularios
{
    partial class FrmPopupMesas
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
            pnlContenedor = new Panel();
            pnlTabs = new Panel();
            btnTabUnir = new Button();
            btnTabTransferir = new Button();
            btnTabDividir = new Button();
            pnlSeparador = new Panel();
            pnlContenido = new Panel();
            pnlBotones = new Panel();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            pnlContenedor.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.White;
            pnlContenedor.Controls.Add(pnlTabs);
            pnlContenedor.Controls.Add(pnlSeparador);
            pnlContenedor.Controls.Add(pnlContenido);
            pnlContenedor.Controls.Add(pnlBotones);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(0, 0);
            pnlContenedor.Margin = new Padding(4, 4, 4, 4);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Padding = new Padding(25, 25, 25, 25);
            pnlContenedor.Size = new Size(625, 600);
            pnlContenedor.TabIndex = 0;
            // 
            // pnlTabs
            // 
            pnlTabs.BackColor = Color.White;
            pnlTabs.Controls.Add(btnTabUnir);
            pnlTabs.Controls.Add(btnTabTransferir);
            pnlTabs.Controls.Add(btnTabDividir);
            pnlTabs.Location = new Point(25, 20);
            pnlTabs.Margin = new Padding(4, 4, 4, 4);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(575, 50);
            pnlTabs.TabIndex = 0;
            // 
            // btnTabUnir
            // 
            btnTabUnir.BackColor = Color.White;
            btnTabUnir.FlatAppearance.BorderSize = 0;
            btnTabUnir.FlatStyle = FlatStyle.Flat;
            btnTabUnir.Font = new Font("Segoe UI", 10F);
            btnTabUnir.ForeColor = Color.FromArgb(30, 30, 47);
            btnTabUnir.Location = new Point(1, 1);
            btnTabUnir.Margin = new Padding(4, 4, 4, 4);
            btnTabUnir.Name = "btnTabUnir";
            btnTabUnir.Size = new Size(162, 45);
            btnTabUnir.TabIndex = 0;
            btnTabUnir.Text = "Unir mesas";
            btnTabUnir.UseVisualStyleBackColor = false;
            btnTabUnir.Click += btnTabUnir_Click;
            // 
            // btnTabTransferir
            // 
            btnTabTransferir.BackColor = Color.White;
            btnTabTransferir.FlatAppearance.BorderSize = 0;
            btnTabTransferir.FlatStyle = FlatStyle.Flat;
            btnTabTransferir.Font = new Font("Segoe UI", 10F);
            btnTabTransferir.ForeColor = Color.FromArgb(130, 130, 145);
            btnTabTransferir.Location = new Point(175, 1);
            btnTabTransferir.Margin = new Padding(4, 4, 4, 4);
            btnTabTransferir.Name = "btnTabTransferir";
            btnTabTransferir.Size = new Size(162, 45);
            btnTabTransferir.TabIndex = 1;
            btnTabTransferir.Text = "Transferir";
            btnTabTransferir.UseVisualStyleBackColor = false;
            btnTabTransferir.Click += btnTabTransferir_Click;
            // 
            // btnTabDividir
            // 
            btnTabDividir.BackColor = Color.White;
            btnTabDividir.FlatAppearance.BorderSize = 0;
            btnTabDividir.FlatStyle = FlatStyle.Flat;
            btnTabDividir.Font = new Font("Segoe UI", 10F);
            btnTabDividir.ForeColor = Color.FromArgb(130, 130, 145);
            btnTabDividir.Location = new Point(350, 1);
            btnTabDividir.Margin = new Padding(4, 4, 4, 4);
            btnTabDividir.Name = "btnTabDividir";
            btnTabDividir.Size = new Size(162, 45);
            btnTabDividir.TabIndex = 2;
            btnTabDividir.Text = "Dividir";
            btnTabDividir.UseVisualStyleBackColor = false;
            btnTabDividir.Click += btnTabDividir_Click;
            // 
            // pnlSeparador
            // 
            pnlSeparador.BackColor = Color.FromArgb(220, 220, 230);
            pnlSeparador.Location = new Point(25, 72);
            pnlSeparador.Margin = new Padding(4, 4, 4, 4);
            pnlSeparador.Name = "pnlSeparador";
            pnlSeparador.Size = new Size(575, 1);
            pnlSeparador.TabIndex = 1;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.White;
            pnlContenido.Location = new Point(25, 85);
            pnlContenido.Margin = new Padding(4, 4, 4, 4);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(575, 425);
            pnlContenido.TabIndex = 2;
            // 
            // pnlBotones
            // 
            pnlBotones.BackColor = Color.White;
            pnlBotones.Controls.Add(btnConfirmar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Location = new Point(25, 522);
            pnlBotones.Margin = new Padding(4, 4, 4, 4);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(575, 58);
            pnlBotones.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.White;
            btnConfirmar.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 47);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.FromArgb(30, 30, 47);
            btnConfirmar.Location = new Point(1, 1);
            btnConfirmar.Margin = new Padding(4, 4, 4, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(262, 52);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 47);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F);
            btnCancelar.ForeColor = Color.FromArgb(30, 30, 47);
            btnCancelar.Location = new Point(311, 2);
            btnCancelar.Margin = new Padding(4, 4, 4, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(262, 52);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmPopupMesas
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(625, 600);
            Controls.Add(pnlContenedor);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPopupMesas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Mesa";
            Load += FrmPopupMesas_Load;
            pnlContenedor.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabUnir;
        private System.Windows.Forms.Button btnTabTransferir;
        private System.Windows.Forms.Button btnTabDividir;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
} 