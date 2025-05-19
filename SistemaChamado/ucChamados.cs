using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaChamado
{
    public partial class ucChamados : UserControl
    {
        public int IdChamado { get; set; }
        public ucChamados()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(65, 103, 174);

            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.ForeColor = Color.White;
                }
            }

            EditarBotão();

        }

        public void SetDados(string nome, string descricao, DateTime data, string status, string prioridade, int idChamado)
        {
            lblNome.Text = $"Cliente: {nome}";
            lblDescricao.Text = $"Descrição: {descricao}";
            lblData.Text = $"Data: {data.ToShortDateString()}";
            lblStatus.Text = $"Status: {status}";
            lblPrioridade.Text = $"Prioridade: {prioridade}";

            this.IdChamado = idChamado;


        }

        private void EditarBotão() {
            btnAlterar.BackColor = Color.White;
            btnAlterar.ForeColor = Color.FromArgb(65, 103, 174);
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.FlatAppearance.BorderColor = Color.FromArgb(65, 103, 174); // Borda azul
            btnAlterar.FlatAppearance.BorderSize = 1;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            // // Pega o ID do chamado atual
            // int idChamado = this.IdChamado;

            // // Fecha o formulário atual (frmRelatorio)
            //// this.Hide();

            // // Cria o formulário de registro
            // frmRegistro frmRegistro = new frmRegistro();

            // // Passa o ID do chamado
            // frmRegistro.CarregarChamadoPorId(idChamado);

            // // Exibe o formulário como modal
            // frmRegistro.ShowDialog();

            // // Após o fechamento do frmRegistro, reabre e atualiza o frmRelatorio
            // this.Show();

            int idChamado = this.IdChamado;

            // Obtem o formulário pai da UserControl
            Form frmRelatorio = this.FindForm();

            // Oculta o formulário pai
            frmRelatorio.Hide();

            // Cria e exibe o formulário de registro
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.CarregarChamadoPorId(idChamado);
            frmRegistro.ShowDialog();

            // Reexibe o formulário pai após o fechamento do frmRegistro
            frmRelatorio.Show();

        }
    }
}
