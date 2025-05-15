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
    public partial class frmRegistro : Form
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbChamado;Integrated Security=True";

        public frmRegistro()
        {
            InitializeComponent();
            
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiretorio frmDiretorio = new frmDiretorio();
            frmDiretorio.ShowDialog();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            txtCliente.BackColor = Color.FromArgb(242, 242, 242);
            txtData.BackColor = Color.FromArgb(242, 242, 242);
            txtDescricao.BackColor = Color.FromArgb(242, 242, 242);
            cbStatus.BackColor = Color.FromArgb(242, 242, 242);
            cbPrioridade.BackColor = Color.FromArgb(242, 242, 242);
            btnSalvar.BackColor = Color.FromArgb(242, 242, 242);
            lbLogin.BackColor = Color.FromArgb(255,255,255);

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Salvo Com Sucesso");
            this.Close();
        }

        public void CarregarChamadoPorId(int idChamado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Consulta SQL para pegar os dados de um chamado específico pelo ID
                    string query = "SELECT Nome, Descricao, Dt, Stts, Prioridade, Avaliacao FROM tblChamado WHERE idChamado = @IdChamado";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdChamado", idChamado);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Preenche os controles do frmRelatorio com os dados do banco
                            txtCliente.Text = $"Cliente: {reader.GetString(0)}";
                            txtDescricao.Text = $"Descrição: {reader.GetString(1)}";
                            txtData.Text = $"Data: {reader.GetDateTime(2).ToShortDateString()}";
                            cbStatus.Text = $"Status: {reader.GetString(3)}";
                            cbPrioridade.Text = $"Prioridade: {reader.GetString(4)}";

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
