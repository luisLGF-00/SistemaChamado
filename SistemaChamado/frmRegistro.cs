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
    public partial class frmRegistro : Form
    {
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
    }
}
