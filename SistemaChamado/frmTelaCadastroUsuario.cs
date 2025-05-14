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
    public partial class frmTelaCadastroUsuario : Form
    {

        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";
        public frmTelaCadastroUsuario()
        {
            InitializeComponent();
        }

        private void lbDiretorio_Click(object sender, EventArgs e)
        {
            
                this.Hide();
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.ShowDialog();
               

             
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Consulta SQL para inserir um usuário na tabela tblUsuario
            string query = "INSERT INTO tblUsuario (Nome, Email, Senha) " +
                           "VALUES (@Nome, @Email, @Senha)";

            // Criando a conexão e o comando
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Adicionando os parâmetros com valores dos campos do formulário
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text); // Você deve ter um TextBox para o email
                cmd.Parameters.AddWithValue("@Senha", txtSenha.Text); // Você deve ter um TextBox para a senha

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
        }
    }
}
