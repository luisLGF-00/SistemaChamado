namespace SistemaChamado
{
    partial class frmTelaCadastroUsuario
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
            this.lbFuncionario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lbSenha = new System.Windows.Forms.Label();
            this.txtSenhaCadastro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeCadastro = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbDiretorio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFuncionario
            // 
            this.lbFuncionario.AutoSize = true;
            this.lbFuncionario.BackColor = System.Drawing.Color.White;
            this.lbFuncionario.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbFuncionario.Location = new System.Drawing.Point(115, 92);
            this.lbFuncionario.Name = "lbFuncionario";
            this.lbFuncionario.Size = new System.Drawing.Size(96, 20);
            this.lbFuncionario.TabIndex = 28;
            this.lbFuncionario.Text = "Funcionario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(30, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Cadastro:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCadastrar.Location = new System.Drawing.Point(267, 329);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(112, 39);
            this.btnCadastrar.TabIndex = 26;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.BackColor = System.Drawing.Color.White;
            this.lbSenha.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbSenha.Location = new System.Drawing.Point(39, 244);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(60, 20);
            this.lbSenha.TabIndex = 24;
            this.lbSenha.Text = "Senha:";
            // 
            // txtSenhaCadastro
            // 
            this.txtSenhaCadastro.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSenhaCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenhaCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaCadastro.Location = new System.Drawing.Point(40, 267);
            this.txtSenhaCadastro.Multiline = true;
            this.txtSenhaCadastro.Name = "txtSenhaCadastro";
            this.txtSenhaCadastro.Size = new System.Drawing.Size(339, 37);
            this.txtSenhaCadastro.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(37, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nome:";
            // 
            // txtNomeCadastro
            // 
            this.txtNomeCadastro.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNomeCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNomeCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCadastro.Location = new System.Drawing.Point(40, 190);
            this.txtNomeCadastro.Multiline = true;
            this.txtNomeCadastro.Name = "txtNomeCadastro";
            this.txtNomeCadastro.Size = new System.Drawing.Size(339, 37);
            this.txtNomeCadastro.TabIndex = 21;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaChamado.Properties.Resources.cad;
            this.pictureBox2.Location = new System.Drawing.Point(410, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(340, 332);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaChamado.Properties.Resources.Cliente;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(824, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // lbDiretorio
            // 
            this.lbDiretorio.AutoSize = true;
            this.lbDiretorio.BackColor = System.Drawing.Color.White;
            this.lbDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiretorio.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbDiretorio.Location = new System.Drawing.Point(771, 20);
            this.lbDiretorio.Name = "lbDiretorio";
            this.lbDiretorio.Size = new System.Drawing.Size(27, 31);
            this.lbDiretorio.TabIndex = 30;
            this.lbDiretorio.Text = "x";
            this.lbDiretorio.Click += new System.EventHandler(this.lbDiretorio_Click);
            // 
            // frmTelaCadastroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 515);
            this.Controls.Add(this.lbDiretorio);
            this.Controls.Add(this.lbFuncionario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.txtSenhaCadastro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeCadastro);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTelaCadastroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTelaCadastroUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFuncionario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.TextBox txtSenhaCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeCadastro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbDiretorio;
    }
}