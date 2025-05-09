using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public frmRelatorio()
        {
            InitializeComponent();
        }

        private void lbRelatorio_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiretorio frmDiretorio = new frmDiretorio();
            frmDiretorio.ShowDialog();
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {

            chart1.Series["Series1"].Points.AddXY("andamento", 20);
            chart1.Series["Series1"].Points.AddXY("concluido", 50);
            chart1.Series["Series1"].Points.AddXY("aberto", 30);


            chart2.Series["Series1"].Points.AddXY("Alta", 50);
            chart2.Series["Series1"].Points.AddXY("Media", 20);
            chart2.Series["Series1"].Points.AddXY("Baixa", 30);


            chart1.Titles.Add("Status dos Chamados");
            chart2.Titles.Add("Prioridade");






        }
    }
}
