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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            //Carregar Tela

            //Como carregar e configurar o ComboBox
            FornecedorDAO dao = new FornecedorDAO();
            cbFornecedor.DataSource = dao.ListarTodosFornecedores();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";

            //Recarregar DataGridView
            ProdutoDAO dao_produto = new ProdutoDAO();
            dgProduto.DataSource = dao_produto.ListarTodosProdutos();

        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão Cadastrar
                Produto produto = new Produto();

                //1° Passo - Receber os Dados
                produto.descricao   = txtDescricao.Text;
                produto.preco       = decimal.Parse(txtPreco.Text);
                produto.qtd_estoque = int.Parse(txtEstoque.Text);
                produto.for_id      = int.Parse(cbFornecedor.SelectedValue.ToString());

                //2° Passo - Cadastrar no Banco
                ProdutoDAO dao = new ProdutoDAO();
                dao.CadastrarProduto(produto);

                //Recarregar DataGridView
                dgProduto.DataSource = dao.ListarTodosProdutos();
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha todos os Campos!");
            }
        }

        private void dgProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os Dados de um Produto selecionado
            txtCodigo.Text      = dgProduto.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text   = dgProduto.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text       = dgProduto.CurrentRow.Cells[2].Value.ToString();
            txtEstoque.Text     = dgProduto.CurrentRow.Cells[3].Value.ToString();

            cbFornecedor.Text   = dgProduto.CurrentRow.Cells[4].Value.ToString();

            //Troca a Aba
            tabControl1.SelectedTab = abaDados;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão Excluir um Produto
                Produto produto = new Produto();
                produto.id = int.Parse(txtCodigo.Text);

                //Recarregar DataGridView
                ProdutoDAO dao = new ProdutoDAO();
                dgProduto.DataSource = dao.ListarTodosProdutos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão Editar
                //1° Passo - Receber os dados em um objeto Model
                Produto produto = new Produto();

                produto.descricao   = txtDescricao.Text;
                produto.preco       = decimal.Parse(txtPreco.Text);
                produto.qtd_estoque = int.Parse(txtEstoque.Text);
                produto.for_id      = int.Parse(cbFornecedor.SelectedValue.ToString());

                produto.id          = int.Parse(txtCodigo.Text);

                //3° Passo - Criar o objeto FuncionarioDAO para chamar o método EditarFuncionario
                ProdutoDAO dao = new ProdutoDAO();
                dao.AlterarProduto(produto);

                //Recarrega o DataGridView
                dgProduto.DataSource = dao.ListarTodosProdutos();
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha todas os Campos!");
            }
        }

        private void txtDados_TextChanged(object sender, EventArgs e)
        {
            //Listar Produtos por Descrição
            string nome = "%" + txtDados.Text + "%";
            ProdutoDAO dao = new ProdutoDAO();

            dgProduto.DataSource = dao.ListarTodosProdutosporNome(nome);
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}
