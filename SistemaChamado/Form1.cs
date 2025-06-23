using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
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
            btnAcessarCadastro.BackColor = Color.FromArgb(123, 150, 212);
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
                    string query = "SELECT idUsuario FROM tblUsuario WHERE Nome = @usuario AND Senha = @senha";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int idUsuario = Convert.ToInt32(result);
                            tentativas = 0;

                            this.Hide();

                            // ✅ passa o id para o frmDiretorio
                            frmDiretorio frmDiretorio = new frmDiretorio(idUsuario);
                            frmDiretorio.ShowDialog();
                        }
                        else
                        {
                            tentativas++;
                            if (tentativas >= 5)
                            {
                                MessageBox.Show("Muitas tentativas falhas! Procure o administrador.", "Acesso Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnAcessarCadastro_Click(object sender, EventArgs e)
        {
            string senha = SolicitarSenhaAdmin();

            if (senha == "admin")
            {
                this.Hide();
                frmTelaCadastroUsuario frmTelaCadastroUsuario = new frmTelaCadastroUsuario();
                frmTelaCadastroUsuario.ShowDialog();


            }
            else
            {
                MessageBox.Show("Senha incorreta! Acesso negado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SolicitarSenhaAdmin()
        {
            Form senhaForm = new Form();
            senhaForm.Text = "Autenticação";
            senhaForm.Size = new Size(250, 150);
            senhaForm.StartPosition = FormStartPosition.CenterParent;

            Label lblMensagem = new Label { Text = "Digite a senha do administrador:", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
            senhaForm.Controls.Add(lblMensagem);

            TextBox txtSenha = new TextBox { PasswordChar = '*', Dock = DockStyle.Top, TextAlign = HorizontalAlignment.Center };
            senhaForm.Controls.Add(txtSenha);

            Button btnOk = new Button { Text = "OK", Dock = DockStyle.Bottom };
            btnOk.Click += (sender, e) => senhaForm.DialogResult = DialogResult.OK;
            senhaForm.Controls.Add(btnOk);

            senhaForm.AcceptButton = btnOk;

            return senhaForm.ShowDialog() == DialogResult.OK ? txtSenha.Text : string.Empty;
        }
    }
}
