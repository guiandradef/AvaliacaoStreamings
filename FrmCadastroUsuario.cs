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
    public partial class FrmCadastroUsuario : Form
    {
        public FrmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrar_se_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string email = txtEmail.Text;
            string telefone = mskdTel_Cel.Text;
            string senha = txtSenha.Text;
            string cargo = txtCargo.Text;


            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Email e Senha são obrigatórios!");
                return;
            }

            AcessoDados db = new AcessoDados();
            bool sucesso = db.AdicionarFuncionario(login, email, telefone, senha, cargo);

            if (sucesso)
            {
                MessageBox.Show("Funcionário cadastrado com sucesso!");
                
            }
        }

        private void btnEntrarCadastUsuario_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
