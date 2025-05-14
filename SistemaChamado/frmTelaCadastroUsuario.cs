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
            // Verificando se todos os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificando se o email é válido (contém @gmail ou @outlook)
            if (!txtEmail.Text.EndsWith("@gmail.com") && !txtEmail.Text.EndsWith("@outlook.com") && !txtEmail.Text.EndsWith("@icluod.com"))
            {
                MessageBox.Show("Insira um email valido","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            // Consulta SQL para inserir um usuário na tabela tblUsuario
            string query = "INSERT INTO tblUsuario (Nome, Email, Senha) " +
                           "VALUES (@Nome, @Email, @Senha)";

            // Criando a conexão e o comando
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Adicionando os parâmetros com valores dos campos do formulário
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Senha", txtSenha.Text);

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

