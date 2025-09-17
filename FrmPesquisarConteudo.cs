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
    public partial class FrmPesquisarConteudo : Form

    {
        Thread ntBotaoVoltarPesquisarConteudo;
        public FrmPesquisarConteudo()
        {
            InitializeComponent();
        }

        private void btnVoltarPesquisarConteudo_Click(object sender, EventArgs e)

        {
            this.Close();
            ntBotaoVoltarPesquisarConteudo = new Thread(novoBtnVoltarPescConteudo); 
            ntBotaoVoltarPesquisarConteudo.SetApartmentState(ApartmentState.STA);
            ntBotaoVoltarPesquisarConteudo.Start();

        }

        private void novoBtnVoltarPescConteudo()
        {
            Application.Run(new FrmPrincipal());
        }
    }
}
