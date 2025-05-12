using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaChamado
{
    public partial class frmPrincipal : Form
    {

       
        public frmPrincipal()
        {
            InitializeComponent();
        }

       
    


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lbLogin.BackColor = Color.FromArgb(76, 111, 191);
            btnAcessar.BackColor = Color.FromArgb(123, 150, 212);
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        int tentativas = 0;
       
        private void btnAcessar_Click(object sender, EventArgs e)
        {

            //BANCO DE DADOS
            /////////////////////////////////////////
            string usuario = txtNome.Text;
            string senha = txtSenha.Text;

            // Verifica se os dados estão corretos

            if (usuario == "1234" && senha == "1234")
            {
                tentativas = 0; // Reseta o contador em caso de sucesso
                this.Hide();
                frmDiretorio frmDiretorio = new frmDiretorio();
                frmDiretorio.ShowDialog();
            }
            else
            {
                tentativas++; // Incrementa o contador de tentativas
                if (tentativas >= 5)
                {
                    MessageBox.Show("Muitas tentativas falhas! Por favor, procure o administrador.", "Acesso Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
                else
                {
                    MessageBox.Show($"Usuário ou senha incorretos! Tentativa {tentativas} de 5.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }





        }

    }
}
