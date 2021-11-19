using Projeto_Vendas_Fatec.br.com.projeto.dao;
using Projeto_Vendas_Fatec.br.com.projeto.model;
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
    public partial class FrmPagamento : Form
    {
        //Criar os objetos que irão receber os dados
        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime dataAtual;


        public FrmPagamento(Cliente vcliente, DataTable vcarrinho, DateTime vdataAtual)
        {
            //Recebendo os dados
            this.cliente = vcliente;
            this.carrinho = vcarrinho;
            this.dataAtual = vdataAtual;

            InitializeComponent();
        }

        private void txtAvista_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmPagamento_Load(object sender, EventArgs e)
        {
            //Carregar tela
            txtTroco.Text = "0.00";
            txtAvista.Text = "0.00";
            txtCartao.Text = "0.00";
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Botão Finalizar venda
            try
            {
                //1° Passo - Declarar as variáveis
                decimal v_avista, v_cartao, troco, totalpago, total;

                //2° Passo - Receber os dados nas variaveis
                v_avista    = decimal.Parse(txtAvista.Text);
                v_cartao    = decimal.Parse(txtCartao.Text);
                total       = decimal.Parse(txtTotal.Text);

                //3° Passo - Calcular o total pago
                totalpago = v_cartao + v_avista;

                //4° Passo - Verificar o valor do total pago
                if(totalpago < total)
                {
                    MessageBox.Show("O total pago é menor que o valor da venda");
                }
                else
                {
                    //5° Passo - Salvar dados no BD / Calcular o troco
                    troco = totalpago - total;

                    //Montar o objeto Venda
                    Venda vendas = new Venda();
                    
                    vendas.cliente_id   = cliente.Id;
                    vendas.data_venda   = dataAtual;
                    vendas.total_venda  = total;
                    vendas.observacao   = txtObservacao.Text;

                    VendaDAO vdao = new VendaDAO();
                    vdao.CadastrarVenda(vendas);

                    txtTroco.Text = troco.ToString();

                    //Cadastrar os Itens da venda
                    //Percorrer e fazer para todos os Itens do Carrinho
                    foreach(DataRow linha in carrinho.Rows)
                    {
                        ItemVenda item = new ItemVenda();

                        item.produto_id = int.Parse(linha["Código"].ToString());
                        item.qtd        = int.Parse(linha["Quantidade"].ToString());
                        item.subtotal   = decimal.Parse(linha["Subtotal"].ToString());

                        item.venda_id = vdao.RetornaIdUltimaVenda();

                        //Criar um objeto Item Venda DAO
                        ItemVendaDAO itemdao = new ItemVendaDAO();
                        itemdao.CadastrarItemVenda(item);
                    }

                    MessageBox.Show("Venda Cadastrada com sucesso!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtCartao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
