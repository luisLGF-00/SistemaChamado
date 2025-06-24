using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SistemaChamado
{
    public partial class frmRegistro : Form
    {
        Dictionary<string, int> clientesDict = new Dictionary<string, int>();
        public int UsuarioId { get; set; }

        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";

        string strConexao = @"Data Source=.\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";
        SqlConnection objConexao;
        string dados = "";

        public int Verificador { get; set; }    

        public frmRegistro(int verificador, int usuarioId, double resultado = 0)

        {
            InitializeComponent();
            Verificador = verificador;
            UsuarioId = usuarioId;
            Resultado = resultado;

        }

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
            txtIdChamado.KeyDown += txtIdChamado_KeyDown;

            if (Verificador == 1) 
            {
                VerificarID();
            }

            cbNomeCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (Verificador == 1)
            {
                cbNomeCliente.Visible = true;
                txtCliente.Visible = false;



                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    try
                    {
                        conexao.Open();
                        string query = "SELECT   idCliente, Nome  FROM tblCliente";
                        SqlCommand cmd = new SqlCommand(query, conexao);
                        SqlDataReader reader = cmd.ExecuteReader();

                        clientesDict.Clear();
                        cbNomeCliente.Items.Clear();

                        while (reader.Read())
                        {
                            string nome = reader["Nome"].ToString();
                            int id = Convert.ToInt32(reader["idCliente"]);
                            cbNomeCliente.Items.Add(nome);
                            clientesDict[nome] = id;
                        }


                        if (cbNomeCliente.Items.Count > 0)
                        {
                            cbNomeCliente.SelectedIndex = 0; // Seleciona o primeiro item automaticamente
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar nomes: " + ex.Message);
                    }
                    finally
                    {
                        conexao.Close(); // Certifique-se de fechar a conexão
                    }
                }


                }
            else
            {
                cbNomeCliente.Visible = false;
            }
        }
        private void txtIdChamado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Verifica se a tecla pressionada foi "Enter"
            {
                e.SuppressKeyPress = true; // Evita o som padrão do "Enter" no campo de texto
                BuscarPorIdChamado(txtIdChamado.Text);
            }
        }
        //
        private void VerificarID()
        {
            string query = @"SELECT ISNULL (MAX(idChamado), 0) AS MaiorId FROM tblChamado";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query,conn))
            {
                conn.Open();
                object resultado = cmd.ExecuteScalar();
                int maiorId = Convert.ToInt32(resultado);
                maiorId = maiorId + 1;
                txtIdChamado.Text = maiorId.ToString();

            }
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
            txtIdChamado.Clear();
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
                                //cbStatus.Items.Clear();
                                //cbStatus.Items.Add(reader["Stts"].ToString());
                                //cbStatus.SelectedItem = reader["Stts"].ToString();

                                //cbPrioridade.Items.Clear();
                                //cbPrioridade.Items.Add(reader["Prioridade"].ToString());
                                //cbPrioridade.SelectedItem = reader["Prioridade"].ToString();

                                string status = reader["Stts"].ToString();
                                string prioridade = reader["Prioridade"].ToString();

                                if (cbStatus.Items.Contains(status))
                                    cbStatus.SelectedItem = status;
                                else
                                    cbStatus.Items.Add(status); cbStatus.SelectedItem = status;

                                if (cbPrioridade.Items.Contains(prioridade))
                                    cbPrioridade.SelectedItem = prioridade;
                                else
                                    cbPrioridade.Items.Add(prioridade); cbPrioridade.SelectedItem = prioridade;

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

            
            public double Resultado { get; set; }

            public frmRegistro(double resultado)
            {
                InitializeComponent();
                Resultado = resultado;
                
            }
        


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            

            this.Hide();

            if (cbStatus.Text == "Fechado")
            {
                frmAvaliacaoAtendimento avaliacaoForm = new frmAvaliacaoAtendimento();
                if (avaliacaoForm.ShowDialog() == DialogResult.OK)
                {
                    Resultado = avaliacaoForm.ResultadoFinal;
                    dados = "fim";
                }
                else
                {
                    MessageBox.Show("Avaliação não concluída.");
                    return;
                }
            }




            if (Verificador == 0)
            {
                // Atualiza os dados
                try
                {
                    objConexao = new SqlConnection(strConexao);
                    objConexao.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE tblChamado SET Nome = @Nome, Dt = @Dt, Descricao = @Descricao, Stts = @Stts, Prioridade = @Prioridade, Avaliacao = @Avaliacao WHERE idChamado = @idChamado",
                        objConexao);

                    cmd.Parameters.AddWithValue("@Nome", txtCliente.Text);

                    DateTime dataChamado;
                    if (DateTime.TryParse(txtData.Text, out dataChamado))
                        cmd.Parameters.AddWithValue("@Dt", dataChamado);
                    else
                        cmd.Parameters.AddWithValue("@Dt", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                    cmd.Parameters.AddWithValue("@Stts", string.IsNullOrWhiteSpace(cbStatus.Text) ? (object)DBNull.Value : cbStatus.Text);
                    cmd.Parameters.AddWithValue("@Prioridade", string.IsNullOrWhiteSpace(cbPrioridade.Text) ? (object)DBNull.Value : cbPrioridade.Text);


                    //Realiza o insert ou Update conforme avaliação
                    if (dados == "")
                    {
                        cmd.Parameters.AddWithValue("@Avaliacao", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Avaliacao", Resultado);
                    }
                    
                    cmd.Parameters.AddWithValue("@idChamado", int.Parse(txtIdChamado.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Chamado atualizado com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar chamado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (objConexao.State == ConnectionState.Open)
                        objConexao.Close();
                }


            }
            if (Verificador == 1)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = @"INSERT INTO tblChamado (idCliente, idUsuario, Nome, Dt, Descricao, Stts, Prioridade, Avaliacao) 
                                         VALUES (@idCliente, @idUsuario, @Nome, @Dt, @Descricao, @Stts, @Prioridade, @Avaliacao)";



                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            if (cbNomeCliente.SelectedItem != null && clientesDict.TryGetValue(cbNomeCliente.SelectedItem.ToString(), out int idCliente))
                            {
                                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            }
                            else
                            {
                                MessageBox.Show("Selecione um cliente válido.");
                                return;
                            }

                            cmd.Parameters.AddWithValue("@idUsuario", UsuarioId);
                            cmd.Parameters.AddWithValue("@Nome", cbNomeCliente.SelectedItem.ToString());

                            DateTime dataChamado;
                            if (DateTime.TryParse(txtData.Text, out dataChamado))
                            {
                                cmd.Parameters.AddWithValue("@Dt", dataChamado);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Dt", DBNull.Value);
                            }


                            cmd.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                            cmd.Parameters.AddWithValue("@Stts", cbStatus.SelectedItem?.ToString() ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Prioridade", cbPrioridade.SelectedItem?.ToString() ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Avaliacao", string.IsNullOrEmpty(dados) ? 0 : Resultado);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Chamado salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar chamado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            var frmDiretorio = new frmDiretorio(UsuarioId); // passa o ID corretamente
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
                            txtIdChamado.Text = idChamado.ToString();
                            txtCliente.Text = $"{reader["Nome"]}";
                            txtDescricao.Text = $"{reader["Descricao"]}";
                            txtData.Text = $"{Convert.ToDateTime(reader["Dt"]).ToShortDateString()}";
                            cbStatus.Text = $"{reader["Stts"]}";
                            cbPrioridade.Text = $"{reader["Prioridade"]}";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados do chamado: " + ex.Message);
            }
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
