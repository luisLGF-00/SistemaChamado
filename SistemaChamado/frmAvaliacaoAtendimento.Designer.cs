namespace SistemaChamado
{
    partial class frmAvaliacaoAtendimento
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.cb2 = new System.Windows.Forms.ComboBox();
            this.cb3 = new System.Windows.Forms.ComboBox();
            this.cb4 = new System.Windows.Forms.ComboBox();
            this.cb5 = new System.Windows.Forms.ComboBox();
            this.btnAvaliacao = new System.Windows.Forms.Button();
            this.lbLogin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaChamado.Properties.Resources.DADOS;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(843, 510);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cb1
            // 
            this.cb1.FormattingEnabled = true;
            this.cb1.Location = new System.Drawing.Point(471, 173);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(116, 21);
            this.cb1.TabIndex = 1;
            // 
            // cb2
            // 
            this.cb2.FormattingEnabled = true;
            this.cb2.Location = new System.Drawing.Point(471, 232);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(116, 21);
            this.cb2.TabIndex = 2;
            // 
            // cb3
            // 
            this.cb3.FormattingEnabled = true;
            this.cb3.Location = new System.Drawing.Point(471, 292);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(116, 21);
            this.cb3.TabIndex = 3;
            // 
            // cb4
            // 
            this.cb4.FormattingEnabled = true;
            this.cb4.Location = new System.Drawing.Point(471, 353);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(116, 21);
            this.cb4.TabIndex = 4;
            // 
            // cb5
            // 
            this.cb5.FormattingEnabled = true;
            this.cb5.Location = new System.Drawing.Point(471, 411);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(116, 21);
            this.cb5.TabIndex = 5;
            // 
            // btnAvaliacao
            // 
            this.btnAvaliacao.Location = new System.Drawing.Point(665, 442);
            this.btnAvaliacao.Name = "btnAvaliacao";
            this.btnAvaliacao.Size = new System.Drawing.Size(131, 32);
            this.btnAvaliacao.TabIndex = 6;
            this.btnAvaliacao.Text = "button1";
            this.btnAvaliacao.UseVisualStyleBackColor = true;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.ForeColor = System.Drawing.Color.Black;
            this.lbLogin.Location = new System.Drawing.Point(779, 9);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(27, 31);
            this.lbLogin.TabIndex = 7;
            this.lbLogin.Text = "x";
            this.lbLogin.Click += new System.EventHandler(this.lbLogin_Click);
            // 
            // frmAvaliacaoAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 508);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.btnAvaliacao);
            this.Controls.Add(this.cb5);
            this.Controls.Add(this.cb4);
            this.Controls.Add(this.cb3);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAvaliacaoAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAvaliacaoAtendimento";
            this.Load += new System.EventHandler(this.frmAvaliacaoAtendimento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.ComboBox cb2;
        private System.Windows.Forms.ComboBox cb3;
        private System.Windows.Forms.ComboBox cb4;
        private System.Windows.Forms.ComboBox cb5;
        private System.Windows.Forms.Button btnAvaliacao;
        private System.Windows.Forms.Label lbLogin;
    }
}