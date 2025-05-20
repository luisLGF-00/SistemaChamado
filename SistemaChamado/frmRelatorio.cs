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
using System.Windows.Forms.DataVisualization.Charting;




namespace SistemaChamado
{
    public partial class frmRelatorio : Form
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";

        public frmRelatorio()
        {
            InitializeComponent();

        }

        // Método para carregar os chamados do banco de dados
        private void CarregarChamados()
        {
            flowLayoutPanel1.Controls.Clear(); // Limpa os controles anteriores

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                   string query = "SELECT idChamado, Nome, Descricao, Dt, Stts, Prioridade, Avaliacao FROM tblChamado ORDER BY Dt DESC";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Cria um novo ChamadoUC para cada chamado
                            ucChamados uc = new ucChamados();

                            // Passa os dados para o UserControl
                            uc.SetDados(
                            reader.GetString(1),  // Nome
                            reader.GetString(2),  // Descricao
                            reader.GetDateTime(3),// Dt
                            reader.GetString(4),  // Stts
                            reader.GetString(5),  // Prioridade
                            reader.GetInt32(0)    // idChamado
                            );

                            // Adiciona o ChamadoUC no FlowLayoutPanel
                            flowLayoutPanel1.Controls.Add(uc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os chamados: " + ex.Message);
            }
        }

        // Evento de clique para o link label lbRelatorio
        private void lbRelatorio_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiretorio frmDiretorio = new frmDiretorio();
            frmDiretorio.ShowDialog();
        }

        // Evento Load do formulário
        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            // Configura os gráficos
            chart1.Series["Series1"].Points.AddXY("andamento", 20);
            chart1.Series["Series1"].Points.AddXY("concluido", 50);
            chart1.Series["Series1"].Points.AddXY("aberto", 30);

            chart2.Series["Series1"].Points.AddXY("Alta", 50);
            chart2.Series["Series1"].Points.AddXY("Média", 20);
            chart2.Series["Series1"].Points.AddXY("Baixa", 30);

            chart1.Titles.Add("Status dos Chamados");
            chart2.Titles.Add("Prioridade");


            // OPÇÕES DO COMBOBOX FILTRO
            cbStatusFiltro.Items.Add("Todos");
            cbStatusFiltro.Items.Add("Aberto");
            cbStatusFiltro.Items.Add("Em andamento");
            cbStatusFiltro.Items.Add("Fechado");

            cbStatusFiltro.SelectedIndex = 0; // Default para "Todos"


            // Carrega os chamados ao abrir o formulário
            CarregarChamados();
        }

        private void CarregarChamados(string statusFiltro = null)
        {
            flowLayoutPanel1.Controls.Clear(); // Limpa os controles anteriores

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT idChamado, Nome, Descricao, Dt, Stts, Prioridade, Avaliacao FROM tblChamado";

                    if (!string.IsNullOrEmpty(statusFiltro))
                    {
                        query += " WHERE Stts = @Status";
                    }

                    query += " ORDER BY Dt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(statusFiltro))
                        {
                            cmd.Parameters.AddWithValue("@Status", statusFiltro);
                        }

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ucChamados uc = new ucChamados();
                            uc.SetDados(
                                reader.GetString(1),  // Nome
                                reader.GetString(2),  // Descrição
                                reader.GetDateTime(3),// Dt
                                reader.GetString(4),  // Stts
                                reader.GetString(5),  // Prioridade
                                reader.GetInt32(0)    // idChamado
                            );
                            flowLayoutPanel1.Controls.Add(uc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os chamados: " + ex.Message);
            }
        }

        private void cbStatusFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statusSelecionado = cbStatusFiltro.Text.Trim();


            if (statusSelecionado == "Todos")
            {
                CarregarChamados();
            }
            else
            {
                CarregarChamados(statusSelecionado);
            }
        }
    }

}
