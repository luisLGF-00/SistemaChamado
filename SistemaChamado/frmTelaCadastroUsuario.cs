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
    public partial class frmTelaCadastroUsuario : Form
    {
        public frmTelaCadastroUsuario()
        {
            InitializeComponent();
        }

        private void lbDiretorio_Click(object sender, EventArgs e)
        {
            
                this.Hide();
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.ShowDialog();
               

             
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}
