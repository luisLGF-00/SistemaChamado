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
        }

        public void SetDados(string nome, string descricao, DateTime data, string status, string prioridade, string avaliacao)
        {
            lblNome.Text = $"Cliente: {nome}";
            lblDescricao.Text = $"Descrição: {descricao}";
            lblData.Text = $"Data: {data.ToShortDateString()}";
            lblStatus.Text = $"Status: {status}";
            lblPrioridade.Text = $"Prioridade: {prioridade}";
            //lblAvaliacao.Text = $"Avaliação: {(string.IsNullOrEmpty(avaliacao) ? "N/A" : avaliacao)}";
            //
        }
    }
}
