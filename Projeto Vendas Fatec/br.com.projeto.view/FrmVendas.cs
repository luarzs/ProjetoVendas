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
    public partial class FrmVendas : Form
    {
        //Objetos
        Cliente cliente = new Cliente();
        ClienteDAO clientedao = new ClienteDAO();

        Produto produto = new Produto();
        ProdutoDAO produtodao = new ProdutoDAO();

        //Variáveis
        int qtd;
        decimal preco;
        decimal subtotal, total;

        //Carrinho
        DataTable carrinho = new DataTable();

        public FrmVendas()
        {
            InitializeComponent();

            //Montar o DataGridView
            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Quantidade", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            //Definir que o DataGridView irá utilizar o DataTable
            dgProdutos.DataSource = carrinho;
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            //Pegando a Data atual do Sistema
            txtData.Text = DateTime.Now.ToShortDateString();
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Consulta de Cliente por CPF
            if (e.KeyChar == 13)
            {
                cliente = clientedao.RetornaClienteporCpf(txtCpf.Text);

                if (cliente != null)
                {
                    //Colocar o nome do Cliente no campo
                    txtNome.Text = cliente.Nome;

                    txtCodigo.Focus();
                }
                else
                {
                    //Limpar os Campos
                    txtCpf.Clear();
                    txtCpf.Focus();

                    txtNome.Clear();
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Botão Adicionar no Carrinho
            try
            {
                //1° Passo - Receber os Valores
                qtd     = int.Parse(txtQuantidade.Text);
                preco   = decimal.Parse(txtPreco.Text);

                //Calcular o Subtotal
                subtotal = qtd * preco;

                //Calcular o Total
                total           += subtotal;
                txtTotal.Text   = total.ToString();

                //Adicionar Produto no Carrinho
                carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDescricao.Text, qtd, preco, subtotal);

                txtCodigo       .Clear();
                txtDescricao    .Clear();
                txtPreco        .Clear();
                txtQuantidade   .Clear();

                txtCodigo       .Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Pesquise um Produto!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botão Remover Item
            try
            {
                decimal subproduto = decimal.Parse(dgProdutos.CurrentRow.Cells[4].Value.ToString());

                //Excluir item do carrinho
                int indice      = dgProdutos.CurrentRow.Index;
                DataRow linha   = carrinho.Rows[indice];

                //Remover a linha do DataTable Carrinho
                carrinho.Rows.Remove(linha);
                carrinho.AcceptChanges();

                //Recalcular o total
                total -= subproduto;

                //Exibe o total
                txtTotal.Text = total.ToString();
                MessageBox.Show("Item removido do carrinho com sucesso!");
            }
            catch (Exception)
            {
                MessageBox.Show("Selecione o Item para Excluir!");
            }
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            //Botão Pagamento
            FrmPagamento tela = new FrmPagamento(cliente, carrinho, DateTime.Parse(txtData.Text));

            //Passar o conteúdo do txttotal para a tela pagamento
            tela.txtTotal.Text = total.ToString();

            tela.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Consulta de Cliente por Código
            if (e.KeyChar == 13)
            {
                produto = produtodao.RetornaProdutoporId(int.Parse(txtCodigo.Text));

                if (produto != null)
                {
                    //Colocar a Descrição e Preço do Produto no campo
                    txtDescricao.Text   = produto.descricao;
                    txtPreco.Text       = produto.preco.ToString();

                    txtQuantidade.Focus();
                }
                else
                {
                    //Limpar os Campos
                    txtCodigo.Clear();
                    txtCodigo.Focus();

                    txtPreco.Clear();

                    txtDescricao.Clear();
                }
            }
        }
    }
}
