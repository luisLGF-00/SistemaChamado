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
    public partial class frmAvaliacaoAtendimento : Form
    {
        public frmAvaliacaoAtendimento()
        {
            InitializeComponent();
        }

        private void frmAvaliacaoAtendimento_Load(object sender, EventArgs e)
        {
            btnAvaliacao.BackColor = Color.FromArgb(28, 81, 136);
            lbLogin.BackColor = Color.FromArgb(255, 255, 255);

        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAvaliacao_Click(object sender, EventArgs e)
        {
            if (cb1.Text != "" && cb2.Text != "" && cb3.Text != "" && cb4.Text != "" && cb5.Text != "")
            {
                try
                {
                    // Converte os valores para double
                    double v1 = Convert.ToDouble(cb1.Text);
                    double v2 = Convert.ToDouble(cb2.Text);
                    double v3 = Convert.ToDouble(cb3.Text);
                    double v4 = Convert.ToDouble(cb4.Text);
                    double v5 = Convert.ToDouble(cb5.Text);

                    // Calcula a média
                    double media = (v1 + v2 + v3 + v4 + v5) / 5;

                    // Mostra a média

                    // inserir aqui para registrar no banco de dados os valor

                    MessageBox.Show("A média é: " + media.ToString("F2"));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Todos os valores devem ser numéricos.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }

            
        }
    }
}
