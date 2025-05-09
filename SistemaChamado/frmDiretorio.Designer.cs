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
            this.ptbWhatsApp = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnRelatorio.Location = new System.Drawing.Point(469, 315);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(170, 45);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // ptbWhatsApp
            // 
            this.ptbWhatsApp.Image = global::SistemaChamado.Properties.Resources.Comunicação__500_x_500_px_;
            this.ptbWhatsApp.Location = new System.Drawing.Point(759, 468);
            this.ptbWhatsApp.Name = "ptbWhatsApp";
            this.ptbWhatsApp.Size = new System.Drawing.Size(48, 40);
            this.ptbWhatsApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbWhatsApp.TabIndex = 6;
            this.ptbWhatsApp.TabStop = false;
            this.ptbWhatsApp.Click += new System.EventHandler(this.ptbWhatsApp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaChamado.Properties.Resources._2;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(838, 525);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(623, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Canal de contato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(629, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Clique no ícone";
            // 
            // frmDiretorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 517);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptbWhatsApp);
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
        private System.Windows.Forms.PictureBox ptbWhatsApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}