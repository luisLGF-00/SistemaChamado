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
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            lbSenha.Visible = false;
            txtSenha.Visible= false;
            lbTipoCadastro.Text = "Cliente";
            btnCadastrar.BackColor =Color.FromArgb(149, 190, 254);
        }

        private void lbDiretorio_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiretorio frmDiretorio = new frmDiretorio();
            frmDiretorio.ShowDialog();
        }
    }
}
