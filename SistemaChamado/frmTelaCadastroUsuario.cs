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

            // Verificando se o email é válido
            if (!txtEmail.Text.EndsWith("@gmail.com") && !txtEmail.Text.EndsWith("@outlook.com") && !txtEmail.Text.EndsWith("@icloud.com"))
            {
                MessageBox.Show("Insira um email válido.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificando se há caracteres antes do '@'
            if (!txtEmail.Text.Contains("@") || txtEmail.Text.StartsWith("@"))
            {
                MessageBox.Show("O email deve conter caracteres antes do '@'.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Verificando se o email já existe no banco
                    string checkEmailQuery = "SELECT COUNT(*) FROM tblUsuario WHERE Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkEmailQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("E-mail já cadastrado!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Se o email não existir, cadastrar o novo usuário
                    string insertQuery = "INSERT INTO tblUsuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                        insertCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        insertCmd.Parameters.AddWithValue("@Senha", txtSenha.Text);

                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpando os campos após cadastro bem-sucedido
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtSenha.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
        }

    }
}


