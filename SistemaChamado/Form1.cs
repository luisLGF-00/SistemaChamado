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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lbLogin.BackColor = Color.FromArgb(76, 111, 191);
            btnAcessar.BackColor = Color.FromArgb(123, 150, 212);
            btnInscreva.BackColor = Color.FromArgb(123, 150, 212);
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiretorio frmDiretorio = new frmDiretorio(); 
            frmDiretorio.ShowDialog();
               
        }

        private void btnInscreva_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastro frmCadastro = new frmCadastro();
            frmCadastro.ShowDialog();
        }
    }
}
