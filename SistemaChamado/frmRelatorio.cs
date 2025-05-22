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
            AtualizarGraficos(); // Atualiza ao iniciar o formulário

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

            // OPÇÕES DO COMBOBOX FILTRO
            cbStatusFiltro.Items.Add("Todos");
            cbStatusFiltro.Items.Add("Aberto");
            cbStatusFiltro.Items.Add("Em andamento");
            cbStatusFiltro.Items.Add("Fechado");

            //tbcBoard.BackColor = Color.FromArgb(65, 103, 164);

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


        //////////////////////CÓDIGO PARA ATUALIZAÇÃO DOS GRÁFICOS/////////////////////////////

        private void AtualizarGraficos()
        {
            AtualizarChart1();
            AtualizarChart2();
            AtualizarChart3();
            AtualizarChart4();
        }

        //Chamados por Status NO CHART2
        private void AtualizarChart1()
        {
            string query = "SELECT Stts, COUNT(*) AS Total FROM tblChamado GROUP BY Stts";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chart1.Series.Clear();
                Series serie = new Series("Chamados por Status");
                serie.ChartType = SeriesChartType.Pie;
                serie.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    serie.Points.AddXY(row["Stts"].ToString(), Convert.ToInt32(row["Total"]));
                }

                chart1.Series.Add(serie);
                chart1.Titles.Clear();
                chart1.Titles.Add("Chamados por Status");
                EstilizarChart(chart1);
                
            }
        }
        //Avaliação média por Prioridade NO CHART2
        private void AtualizarChart2()
        {
            string query = "SELECT Prioridade, AVG(Avaliacao) AS MediaAvaliacao FROM tblChamado WHERE Avaliacao IS NOT NULL GROUP BY Prioridade";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chart2.Series.Clear();
                Series serie = new Series("Média de Avaliação");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string prioridade = row["Prioridade"].ToString();
                    double media = Convert.ToDouble(row["MediaAvaliacao"]);
                    serie.Points.AddXY(prioridade, media);
                }

                chart2.Series.Add(serie);
                chart2.Titles.Clear();
                chart2.Titles.Add("Média de Avaliação por Prioridade");
                EstilizarChart(chart2);
                chart2.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                chart2.Legends.Clear();
            }
        }

        //CHAMADOS POR PRIORIDADE NO CHART3
        private void AtualizarChart3()
        {
            string query = "SELECT Prioridade, COUNT(*) AS Total FROM tblChamado GROUP BY Prioridade";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chart3.Series.Clear();
                Series serie = new Series("Chamados por Prioridade");
                serie.ChartType = SeriesChartType.Bar;
                serie.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    serie.Points.AddXY(row["Prioridade"].ToString(), Convert.ToInt32(row["Total"]));
                }

                chart3.Series.Add(serie);
                chart3.Titles.Clear();
                chart3.Titles.Add("Chamados por Prioridade");
                EstilizarChart(chart3);
                chart3.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                chart3.Legends.Clear();
            }
        }

        
        //CHAMADOS POR CLIENTE NO CHART3
        private void AtualizarChart4()
        {
            string query = @"
                SELECT c.Nome AS Cliente, COUNT(*) AS TotalChamados
                FROM tblChamado ch
                INNER JOIN tblCliente c ON ch.idCliente = c.idCliente
                GROUP BY c.Nome";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chart4.Series.Clear();
                Series serie = new Series("Chamados por Cliente");
                serie.ChartType = SeriesChartType.Column; 
                serie.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    serie.Points.AddXY(row["Cliente"].ToString(), Convert.ToInt32(row["TotalChamados"]));
                }

                chart4.Series.Add(serie);
                chart4.Titles.Clear();
                chart4.Titles.Add("Chamados por Cliente");
                EstilizarChart(chart4);
                chart4.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                chart4.Legends.Clear();
            }
        }

        //estilização dos graficos
        private void EstilizarChart(Chart chart)
        {
            // Remover linhas de grade
            foreach (ChartArea area in chart.ChartAreas)
            {
                area.BackColor = Color.White; // Fundo branco
                area.BorderWidth = 0;
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.Enabled = false;
                area.AxisX.LineWidth = 0;
                area.AxisY.LineWidth = 0;
                area.AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);
                area.AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            }

            // Remover bordas
            chart.BorderSkin.SkinStyle = BorderSkinStyle.None;
            chart.BackColor = Color.White;

            // Estilo das legendas
            foreach (Legend legend in chart.Legends)
            {
                legend.Font = new Font("Arial", 10, FontStyle.Regular);
                legend.BorderColor = Color.Transparent;
            }

            // Títulos mais destacados
            foreach (Title title in chart.Titles)
            {
                title.Font = new Font("Arial", 12, FontStyle.Bold);
            }

            // Ajuste padrão das séries
            foreach (Series s in chart.Series)
            {
                s.BorderWidth = 0;
                s.Font = new Font("Arial", 10, FontStyle.Bold);
                s.LabelForeColor = Color.Black;
                s.IsValueShownAsLabel = true;
            }
        }













    }
}
