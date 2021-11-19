using Projeto_Vendas_Fatec.br.com.projeto.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vendas_Fatec.br.com.projeto.view
{
    public partial class FrmHistorico : Form
    {
        public FrmHistorico()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            //Botão Pesquisar
            try
            {
                DateTime dtInicio, dtFim;

                //Pega a primeira data
                dtInicio = txtDataIni.Value;
                dtFim    = txtDataFim.Value;

                VendaDAO dao = new VendaDAO();

                dgHistorico.DataSource = dao.ListarVendasPorPeriodo(dtInicio, dtFim);

                //Se não retornar linhas no DataTable
                if (dgHistorico.Rows.Count == 0)
                {
                    MessageBox.Show("Não foram encontradas vendas neste período");
                    dgHistorico.DataSource = dao.ListarVendas();
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foram encontradas vendas neste período");
            }
        }

        private void FrmHistorico_Load(object sender, EventArgs e)
        {
            //Chamado o método que lista todas as vendas
            VendaDAO dao = new VendaDAO();
            dgHistorico.DataSource = dao.ListarVendas();
        }

        private void dgHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Clicando em uma venda

            //1° Passo - Criar os objetos e declaração de variáveis
            ItemVendaDAO itemdao = new ItemVendaDAO();
            int venda_id;

            //2° Passo - Pegar o ID de uma Venda
            venda_id = int.Parse(dgHistorico.CurrentRow.Cells[0].Value.ToString());

            //3° Passo - Passar os dados para a outra tela
            FrmDetalhes tela = new FrmDetalhes();

            tela.txtData.Text           = dgHistorico.CurrentRow.Cells[1].Value.ToString();
            tela.txtTotalVenda.Text     = dgHistorico.CurrentRow.Cells[2].Value.ToString();
            tela.txtCliente.Text        = dgHistorico.CurrentRow.Cells[3].Value.ToString();
            tela.txtObservacoes.Text    = dgHistorico.CurrentRow.Cells[4].Value.ToString();

            tela.dgItens.DataSource = itemdao.ListarItensPorVenda(venda_id);

            //4° Passo - Chamar a Tela
            tela.ShowDialog();

        }
    }
}
