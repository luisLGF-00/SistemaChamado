namespace SistemaChamado
{
    partial class frmDiretorio
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
            this.btnChamado = new System.Windows.Forms.Button();
            this.lbDiretorio = new System.Windows.Forms.Label();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.ptbWhatsApp = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWhatsApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChamado
            // 
            this.btnChamado.FlatAppearance.BorderSize = 0;
            this.btnChamado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChamado.ForeColor = System.Drawing.Color.White;
            this.btnChamado.Location = new System.Drawing.Point(469, 176);
            this.btnChamado.Name = "btnChamado";
            this.btnChamado.Size = new System.Drawing.Size(170, 44);
            this.btnChamado.TabIndex = 1;
            this.btnChamado.Text = "Chamado";
            this.btnChamado.UseVisualStyleBackColor = true;
            this.btnChamado.Click += new System.EventHandler(this.btnChamado_Click);
            // 
            // lbDiretorio
            // 
            this.lbDiretorio.AutoSize = true;
            this.lbDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiretorio.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbDiretorio.Location = new System.Drawing.Point(780, 18);
            this.lbDiretorio.Name = "lbDiretorio";
            this.lbDiretorio.Size = new System.Drawing.Size(27, 31);
            this.lbDiretorio.TabIndex = 3;
            this.lbDiretorio.Text = "x";
            this.lbDiretorio.Click += new System.EventHandler(this.lbDiretorio_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.FlatAppearance.BorderSize = 0;
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.ForeColor = System.Drawing.Color.White;
            this.btnRelatorio.Location = new System.Drawing.Point(469, 299);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(170, 45);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.Location = new System.Drawing.Point(469, 422);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(170, 45);
            this.btnCliente.TabIndex = 6;
            this.btnCliente.Text = "Cadastro Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // ptbWhatsApp
            // 
            this.ptbWhatsApp.Image = global::SistemaChamado.Properties.Resources.Comunicação__500_x_500_px_;
            this.ptbWhatsApp.Location = new System.Drawing.Point(790, 476);
            this.ptbWhatsApp.Name = "ptbWhatsApp";
            this.ptbWhatsApp.Size = new System.Drawing.Size(36, 33);
            this.ptbWhatsApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbWhatsApp.TabIndex = 7;
            this.ptbWhatsApp.TabStop = false;
            this.ptbWhatsApp.Click += new System.EventHandler(this.ptbWhatsApp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaChamado.Properties.Resources.Tela2;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(838, 525);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmDiretorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 517);
            this.Controls.Add(this.ptbWhatsApp);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lbDiretorio);
            this.Controls.Add(this.btnChamado);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDiretorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDiretorio";
            this.Load += new System.EventHandler(this.frmDiretorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbWhatsApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnChamado;
        private System.Windows.Forms.Label lbDiretorio;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.PictureBox ptbWhatsApp;
    }
}