using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaChamado
{
    public partial class frmCadastro : Form
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";

        public frmCadastro()
        {
            InitializeComponent();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            lbTipoCadastro.Text = "Cliente";
            btnCadastrar.BackColor = Color.FromArgb(149, 190, 254);
        }

        private void lbDiretorio_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiretorio frmDiretorio = new frmDiretorio();
            frmDiretorio.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Validação dos campos
            if (string.IsNullOrWhiteSpace(txtNomeCadastro.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                string.IsNullOrWhiteSpace(mktTelefone.Text) ||
                string.IsNullOrWhiteSpace(msktxtCNPJ.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de continuar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação do Email
            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("Email inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            // Validação do número de telefone
            if (!ValidarTelefone(mktTelefone.Text))
            {
                MessageBox.Show("Número de telefone inválido! Deve conter exatamente 11 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação do CNPJ
            if (!ValidarCNPJ(msktxtCNPJ.Text))
            {
                MessageBox.Show("CNPJ inválido! Verifique o número e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se CNPJ já existe no banco
            if (CnpjExiste(msktxtCNPJ.Text))
            {
                MessageBox.Show("CNPJ já cadastrado! Por favor, insira um CNPJ diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inserção no banco de dados
            InserirCliente();
        }

        private void InserirCliente()
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();

                    string query = "INSERT INTO tblCliente (Nome, Email, Endereco, Telefone, CNPJ) VALUES (@Nome, @Email, @Endereco, @Telefone, @CNPJ)";

                    using (SqlCommand cmd = new SqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txtNomeCadastro.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                        cmd.Parameters.AddWithValue("@Telefone", mktTelefone.Text);
                        cmd.Parameters.AddWithValue("@CNPJ", msktxtCNPJ.Text);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos(); // Limpa os campos após o sucesso
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Função para validar o CNPJ
        public bool ValidarCNPJ(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"\D", ""); // Remove caracteres não numéricos
            return cnpj.Length == 14; // CNPJ deve ter exatamente 14 dígitos
        }

        // Função para validar o Email
        public bool ValidarEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@(gmail\.com|outlook\.com|icloud\.com)$");
        }

        // Função para validar o número de telefone (11 dígitos)
        public bool ValidarTelefone(string telefone)
        {
            telefone = Regex.Replace(telefone, @"\D", ""); // Remove caracteres não numéricos
            return telefone.Length == 11; // Telefone deve ter exatamente 11 dígitos
        }

        // Função para verificar se o CNPJ já existe no banco
        public bool CnpjExiste(string cnpj)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    string query = "SELECT COUNT(*) FROM tblCliente WHERE CNPJ = @CNPJ";

                    using (SqlCommand cmd = new SqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@CNPJ", cnpj);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Se count > 0, significa que o CNPJ já existe no banco
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao verificar CNPJ: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Função para limpar os campos após o cadastro
        private void LimparCampos()
        {
            txtNomeCadastro.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            mktTelefone.Text = string.Empty;
            msktxtCNPJ.Text = string.Empty;
        }
    }
}
