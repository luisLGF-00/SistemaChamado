using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SistemaChamado
{
    public partial class frmDiretorio : Form
    {
        private int usuarioId;

        public frmDiretorio(int idUsuario)
        {
            InitializeComponent();
            usuarioId = idUsuario;
        }

        private void frmDiretorio_Load(object sender, EventArgs e)
        {
            btnChamado.BackColor = Color.FromArgb(19, 83, 138);
            btnRelatorio.BackColor = Color.FromArgb(134, 234, 233);
            lbDiretorio.BackColor = Color.FromArgb(255, 255, 255);
            btnCliente.BackColor = Color.FromArgb(55, 201, 239);

        }


        private void lbDiretorio_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.ShowDialog();
            this.Close();
        }

        private void btnChamado_Click(object sender, EventArgs e)
        {
            
            int Verificador = 1;

            this.Hide();
            frmRegistro frmRegistro = new frmRegistro(Verificador, usuarioId);
            frmRegistro.ShowDialog();
            this.Close();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRelatorio frmRelatorio = new frmRelatorio(usuarioId);
            frmRelatorio.ShowDialog();
            this.Close();

        }

        private void ptbWhatsApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAvaliacaoAtendimento frmAvaliacaoAtendimento = new frmAvaliacaoAtendimento();
            frmAvaliacaoAtendimento.ShowDialog();
            this.Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            frmCadastro frmCadastro = new frmCadastro(usuarioId);
            frmCadastro.ShowDialog();
            this.Close();
        }
    }
}
