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
            cb1.BackColor = Color.FromArgb(134, 232, 232);
            cb2.BackColor = Color.FromArgb(63, 216, 215);
            cb3.BackColor = Color.FromArgb(62, 198, 237);
            cb4.BackColor = Color.FromArgb(54, 143, 210);
            cb5.BackColor = Color.FromArgb(28, 81, 136);
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
