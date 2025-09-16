using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvaliacaoStreaming
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text;
            string senha = txtSenhaLogin.Text;

            
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha os campos de email e senha.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            AcessoDados db = new AcessoDados();

            
            if (db.VerificarLoginUsuario(email, senha))
            {
                
                MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                FrmPrincipal frmPrincipal = new FrmPrincipal();

                
                frmPrincipal.Show();   
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos. Tente novamente.", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltarLogin_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuario frmCadastroUsuario = new FrmCadastroUsuario();
            frmCadastroUsuario.Show();
            this.Hide();
        }
    }
}
