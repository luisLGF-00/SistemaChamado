using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaChamado
{
    public partial class frmPrincipal : Form
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";


        public frmPrincipal()
        {
            InitializeComponent();
        }





        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lbLogin.BackColor = Color.FromArgb(76, 111, 191);
            btnAcessar.BackColor = Color.FromArgb(123, 150, 212);
            btnInscreva.BackColor = Color.FromArgb(123, 150, 212);
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        int tentativas = 0;

        private void btnAcessar_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string usuario = txtNome.Text;
                string senha = txtSenha.Text;
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM tblUsuario WHERE Nome = @usuario AND Senha = @senha";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            tentativas = 0; // Reseta o contador em caso de sucesso
                            this.Hide();
                            frmDiretorio frmDiretorio = new frmDiretorio();
                            frmDiretorio.ShowDialog();
                        }
                        else
                        {
                            tentativas++;
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnInscreva_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastro frmCadastro = new frmCadastro();
            frmCadastro.ShowDialog();
        }
    }
}
