using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaChamado
{
    public partial class frmRegistro : Form
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";

        public frmRegistro()
        {
            InitializeComponent();

            // Eventos de saída dos campos
            txtIdChamado.Leave += txtIdChamado_Leave;
            
            cbPrioridade.SelectedIndexChanged += cbPrioridade_SelectedIndexChanged;
            pictureBox1.Click += pictureBox1_Click;

            // Opcional: definir cor dos campos logo aqui para evitar repetição
            var backColor = Color.FromArgb(242, 242, 242);
            txtCliente.BackColor = backColor;
            txtData.BackColor = backColor;
            txtDescricao.BackColor = backColor;
            cbStatus.BackColor = backColor;
            cbPrioridade.BackColor = backColor;
            btnSalvar.BackColor = backColor;
            lbLogin.BackColor = Color.White;
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            CarregarCombosIniciais();
        }

        private void CarregarCombosIniciais()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    cbStatus.Items.Clear();
                    cbPrioridade.Items.Clear();

                    // Carrega status distintos
                    using (SqlCommand cmdStatus = new SqlCommand("SELECT DISTINCT Stts FROM tblChamado", conn))
                    using (SqlDataReader reader = cmdStatus.ExecuteReader())
                    {
                        while (reader.Read())
                            cbStatus.Items.Add(reader["Stts"].ToString());
                    }

                    // Carrega prioridades distintas
                    using (SqlCommand cmdPrioridade = new SqlCommand("SELECT DISTINCT Prioridade FROM tblChamado", conn))
                    using (SqlDataReader reader = cmdPrioridade.ExecuteReader())
                    {
                        while (reader.Read())
                            cbPrioridade.Items.Add(reader["Prioridade"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar status e prioridades:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpa os campos, mas não apaga o ID quando ele está preenchido
        private void LimparCampos(bool limparIdChamado = true)
        {
            if (limparIdChamado)
                txtIdChamado.Clear();

            txtCliente.Clear();
            txtData.Clear();
            txtDescricao.Clear();
            cbStatus.SelectedIndex = -1;
            cbPrioridade.SelectedIndex = -1;
        }

        // Buscar e preencher os dados pelo ID do chamado
        private void BuscarPorIdChamado(string idChamado)
        {
            idChamado = idChamado.Trim();

            if (!int.TryParse(idChamado, out int id))
            {
                MessageBox.Show("ID inválido. Digite um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Nome, Dt, Descricao, Stts, Prioridade FROM tblChamado WHERE idChamado = @idChamado";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@idChamado", SqlDbType.Int).Value = id;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCliente.Text = reader["Nome"].ToString();

                                // Tratamento adequado de valores nulos
                                txtData.Text = reader["Dt"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["Dt"]).ToString("dd/MM/yyyy")
                                    : string.Empty;

                                txtDescricao.Text = reader["Descricao"].ToString();
                                

                                // Adicionando os valores ao ComboBox antes de selecionar
                                cbStatus.Items.Clear();
                                cbStatus.Items.Add(reader["Stts"].ToString());
                                cbStatus.SelectedItem = reader["Stts"].ToString();

                                cbPrioridade.Items.Clear();
                                cbPrioridade.Items.Add(reader["Prioridade"].ToString());
                                cbPrioridade.SelectedItem = reader["Prioridade"].ToString();
                            }
                            else
                            {
                                MessageBox.Show($"Chamado com ID {id} não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparCampos(limparIdChamado: false); // Limpa tudo, exceto o ID
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar chamado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIdChamado_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdChamado.Text))
            {
                BuscarPorIdChamado(txtIdChamado.Text);
            }
            else
            {
                // Limpa tudo só se o txtIdChamado estiver vazio
                LimparCampos();
            }
        }
        private void cbPrioridade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrioridade.SelectedItem != null);
               
        }

        // Limpar campos ao clicar na picturebox, respeitando o ID
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Limpa apenas se txtIdChamado estiver vazio (evita apagar dados se o ID está preenchido)
            if (string.IsNullOrWhiteSpace(txtIdChamado.Text))
            {
                LimparCampos();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // TODO: implementar lógica real de salvar
            MessageBox.Show("Salvo com sucesso!");
            this.Close();
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            var frmDiretorio = new frmDiretorio();
            frmDiretorio.Show();
        }


        public void CarregarChamadoPorId(int idChamado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Consulta SQL para pegar os dados de um chamado específico pelo ID
                    string query = "SELECT idChamado, Nome, Descricao, Dt, Stts, Prioridade, Avaliacao FROM tblChamado WHERE idChamado = @IdChamado";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdChamado", idChamado);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Preenche os controles do frmRelatorio com os dados do banco
                            txtIdChamado.Text = reader["idChamado"].ToString();
                            txtCliente.Text = $"Cliente: {reader["Nome"]}";
                            txtDescricao.Text = $"Descrição: {reader["Descricao"]}";
                            txtData.Text = $"Data: {Convert.ToDateTime(reader["Dt"]).ToShortDateString()}";
                            cbStatus.Text = $"Status: {reader["Stts"]}";
                            cbPrioridade.Text = $"Prioridade: {reader["Prioridade"]}";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados do chamado: " + ex.Message);
            }
        }



    }
}
