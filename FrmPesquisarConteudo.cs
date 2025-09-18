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

        private void FormatarGrid()
        {
            if (dgv.ColumnCount > 0)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.Columns["ID"].HeaderText = "ID";
                dgv.Columns["titulo"].HeaderText = "Título";
                dgv.Columns["genero"].HeaderText = "Categoria";
                dgv.Columns["ano"].HeaderText = "Ano";
                dgv.Columns["nota_media"].HeaderText = "Nota Média";

                dgv.Columns["ID"].Visible = false;
            }
        }


        private void BtnLimpar_Click_Click(object sender, EventArgs e)
        {
            txtBusca.Clear();
            cmbCampo.SelectedIndex = -1;
            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Refresh();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string titulo = dgv.Rows[e.RowIndex].Cells["titulo"].Value.ToString();
                MessageBox.Show("Selecionado: " + titulo);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnPesquisar_Click_Click(object sender, EventArgs e)
        {
            string campo = "";
            if (cmbCampo.SelectedItem != null)
            {
                switch (cmbCampo.SelectedItem.ToString())
                {
                    case "Título": campo = "titulo"; break;
                    case "Categoria": campo = "genero"; break;
                    case "Ano": campo = "ano"; break;
                    case "Nota": campo = "nota_media"; break;
                    case "ID": campo = "ID"; break;
                }
            }
            else
            {
                MessageBox.Show("Selecione um campo de pesquisa.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string criterio = txtBusca.Text.Trim();

            AcessoDados db = new AcessoDados();
            dgv.DataSource = db.PesquisarConteudo(campo, criterio);

            FormatarGrid();
        }
    }
}
