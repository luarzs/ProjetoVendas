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
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            //Botão Cadastrar
            //1° Passo - Receber os dados em um objeto Model de Fornecedor
            Fornecedor fornecedor = new Fornecedor();

            fornecedor.Nome         = txtNome.Text;
            fornecedor.Cnpj         = txtCnpj.Text;
            fornecedor.Email        = txtEmail.Text;
            fornecedor.Telefone     = txtTelefone.Text;
            fornecedor.Celular      = txtCelular.Text;
            fornecedor.Cep          = txtCep.Text;
            fornecedor.Endereco     = txtEndereco.Text;
            fornecedor.Numero       = int.Parse(txtNumero.Text);
            fornecedor.Complemento  = txtComplemento.Text;
            fornecedor.Bairro       = txtBairro.Text;
            fornecedor.Cidade       = txtCidade.Text;
            fornecedor.Estado       = cbEstado.Text;

            //2° Passo - Criar o objeto FornecedorDAO para chamar o método CadastrarFornecedor
            FornecedorDAO dao = new FornecedorDAO();
            dao.CadastrarFornecedor(fornecedor);

            //Recarrega o DataGridView
            dgFornecedor.DataSource = dao.ListarTodosFornecedores();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            //Botão Excluir
            FornecedorDAO dao = new FornecedorDAO();
            dao.ExcluirFornecedor(int.Parse(txtCodigo.Text));

            //Recarregar o DataGridView
            dgFornecedor.DataSource = dao.ListarTodosFornecedores();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            //Botão Editar
            //1° Passo - Receber os dados em um objeto Model de Fornecedor
            Fornecedor fornecedor = new Fornecedor();

            fornecedor.Nome         = txtNome.Text;
            fornecedor.Cnpj         = txtCnpj.Text;
            fornecedor.Email        = txtEmail.Text;
            fornecedor.Telefone     = txtTelefone.Text;
            fornecedor.Celular      = txtCelular.Text;
            fornecedor.Cep          = txtCep.Text;
            fornecedor.Endereco     = txtEndereco.Text;
            fornecedor.Numero       = int.Parse(txtNumero.Text);
            fornecedor.Complemento  = txtComplemento.Text;
            fornecedor.Bairro       = txtBairro.Text;
            fornecedor.Cidade       = txtCidade.Text;
            fornecedor.Estado       = cbEstado.Text;

            //2° Passo - Receber o ID do Fornecedor
            fornecedor.Id = int.Parse(txtCodigo.Text);

            //3° Passo - Criar o objeto FornecedorDAO para chamar o método CadastrarFornecedor
            FornecedorDAO dao = new FornecedorDAO();
            dao.AlterarFornecedor(fornecedor);

            //Recarrega o DataGridView
            dgFornecedor.DataSource = dao.ListarTodosFornecedores();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            // Carrega a Tela
            FornecedorDAO dao = new FornecedorDAO();
            dgFornecedor.DataSource = dao.ListarTodosFornecedores();
        }

        private void dtFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os Dados da Linha Selecionada
            txtCodigo.Text      = dgFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text        = dgFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtCnpj.Text        = dgFornecedor.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text       = dgFornecedor.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text    = dgFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text     = dgFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtCep.Text         = dgFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text    = dgFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text      = dgFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = dgFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text      = dgFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text      = dgFornecedor.CurrentRow.Cells[11].Value.ToString();
            cbEstado.Text       = dgFornecedor.CurrentRow.Cells[12].Value.ToString();

            //Alterar para a Guia de Dados Pessoais
            tabControl1.SelectedTab = abaDados;
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            //Botão que Consulta CEP
            try
            {
                //1° Passo - Receber CEP
                string cep = txtCep.Text;

                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                //2° Passo - Exibir os Dados nos Campos
                txtEndereco.Text    = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text      = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text      = dados.Tables[0].Rows[0]["localidade"].ToString();
                cbEstado.Text       = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Endereço não encontrado, favor digitar Manualmente.");
            }
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            //Botão Consultar
            string dados = txtDados.Text;
            FornecedorDAO dao = new FornecedorDAO();

            //Verificar qual a opção selecionada

            //Se for Nome
            if (cbFiltro.SelectedIndex == 0)
            {
                MessageBox.Show("Consulta por Nome");
                dgFornecedor.DataSource = dao.ConsultarFornecedorNome(dados);

                if (dgFornecedor.Rows.Count == 0)
                {
                    MessageBox.Show("Nome não encontrado");
                    dgFornecedor.DataSource = dao.ListarTodosFornecedores();
                }
            }
            //Se for CNPJ
            else if (cbFiltro.SelectedIndex == 1)
            {
                MessageBox.Show("Consulta por CNPJ");
                dgFornecedor.DataSource = dao.ConsultarFornecedorCnpj(dados);

                if (dgFornecedor.Rows.Count == 0)
                {
                    MessageBox.Show("CNPJ não encontrado");
                    dgFornecedor.DataSource = dao.ListarTodosFornecedores();
                }
            }
        }
    }
}
