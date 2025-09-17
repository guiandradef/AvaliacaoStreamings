using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AvaliacaoStreaming
{
    public partial class FrmPrincipal : Form
    {
        Thread ntBotaoVolaraoCadastro,ntBotaoPesquisarconteudo3;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            ntBotaoVolaraoCadastro = new Thread(novoBtnVoltar02);
            ntBotaoVolaraoCadastro.SetApartmentState(ApartmentState.STA);
            ntBotaoVolaraoCadastro.Start();

        }

        private void novoBtnVoltar02()
        {
            Application.Run(new FrmCadastroUsuario());
        }

        private void btnPesquisarConteudoPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            ntBotaoPesquisarconteudo3 = new Thread(novoBtnpesquisarcont03);
            ntBotaoPesquisarconteudo3.SetApartmentState(ApartmentState.STA);
            ntBotaoPesquisarconteudo3.Start();
        }

        private void novoBtnpesquisarcont03()
        {
            Application.Run(new FrmPesquisarConteudo());
        }
    }
}
