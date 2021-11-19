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
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            // Carrega a Tela
            FuncionarioDAO dao = new FuncionarioDAO();
            dgFuncionario.DataSource = dao.ListarTodosFuncionarios();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {

        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btCadastrar_Click_1(object sender, EventArgs e)
        {
            //Botão Cadastrar
            //1° Passo - Receber os dados em um objeto Model de Funcionário
            Funcionario funcionario = new Funcionario();

            funcionario.Nome        = txtNome.Text;
            funcionario.Rg          = txtRg.Text;
            funcionario.Cpf         = txtCpf.Text;
            funcionario.Email       = txtEmail.Text;
            funcionario.Senha       = txtSenha.Text;
            funcionario.Cargo       = txtCargo.Text;
            funcionario.Nivel       = txtNivel.Text;
            funcionario.Telefone    = txtTelefone.Text;
            funcionario.Celular     = txtCelular.Text;
            funcionario.Cep         = txtCep.Text;
            funcionario.Endereco    = txtEndereco.Text;
            funcionario.Numero      = int.Parse(txtNumero.Text);
            funcionario.Complemento = txtComplemento.Text;
            funcionario.Bairro      = txtBairro.Text;
            funcionario.Cidade      = txtCidade.Text;
            funcionario.Estado      = cbEstado.Text;

            //2° Passo - Criar o objeto FuncionarioDAO para chamar o método CadastrarFuncionario
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.CadastrarFuncionario(funcionario);

            //Recarrega o DataGridView
            dgFuncionario.DataSource = dao.ListarTodosFuncionarios();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            //Botão Excluir
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.ExcluirFuncionario(int.Parse(txtCodigo.Text));

            //Recarregar o DataGridView
            dgFuncionario.DataSource = dao.ListarTodosFuncionarios();
        }

        private void btEditar_Click_1(object sender, EventArgs e)
        {
            //Botão Editar
            //1° Passo - Receber os dados em um objeto Model de Funcionário
            Funcionario funcionario = new Funcionario();

            funcionario.Nome        = txtNome.Text;
            funcionario.Rg          = txtRg.Text;
            funcionario.Cpf         = txtCpf.Text;
            funcionario.Email       = txtEmail.Text;
            funcionario.Senha       = txtSenha.Text;
            funcionario.Cargo       = txtCargo.Text;
            funcionario.Nivel       = txtNivel.Text;
            funcionario.Telefone    = txtTelefone.Text;
            funcionario.Celular     = txtCelular.Text;
            funcionario.Cep         = txtCep.Text;
            funcionario.Endereco    = txtEndereco.Text;
            funcionario.Numero      = int.Parse(txtNumero.Text);
            funcionario.Complemento = txtComplemento.Text;
            funcionario.Bairro      = txtBairro.Text;
            funcionario.Cidade      = txtCidade.Text;
            funcionario.Estado      = cbEstado.Text;

            //2° Passo - Receber o ID do Funcionário
            funcionario.Id = int.Parse(txtCodigo.Text);

            //3° Passo - Criar o objeto FuncionarioDAO para chamar o método EditarFuncionario
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.AlterarFuncionario(funcionario);

            //Recarrega o DataGridView
            dgFuncionario.DataSource = dao.ListarTodosFuncionarios();
        }

        private void dgFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os Dados da Linha Selecionada
            txtCodigo.Text      = dgFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text        = dgFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text          = dgFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text         = dgFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text       = dgFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text       = dgFuncionario.CurrentRow.Cells[5].Value.ToString();
            txtCargo.Text       = dgFuncionario.CurrentRow.Cells[6].Value.ToString();
            txtNivel.Text       = dgFuncionario.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text    = dgFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text     = dgFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtCep.Text         = dgFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text    = dgFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text      = dgFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = dgFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text      = dgFuncionario.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text      = dgFuncionario.CurrentRow.Cells[15].Value.ToString();
            cbEstado.Text       = dgFuncionario.CurrentRow.Cells[16].Value.ToString();

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
            FuncionarioDAO dao = new FuncionarioDAO();

            //Verificar qual a opção selecionada

            //Se for Nome
            if (cbFiltro.SelectedIndex == 0)
            {
                MessageBox.Show("Consulta por Nome");
                dgFuncionario.DataSource = dao.ConsultarFuncionarioNome(dados);

                if (dgFuncionario.Rows.Count == 0)
                {
                    MessageBox.Show("Nome não encontrado");
                    dgFuncionario.DataSource = dao.ListarTodosFuncionarios();
                }
            }
            //Se for CPF
            else if (cbFiltro.SelectedIndex == 1)
            {
                MessageBox.Show("Consulta por CPF");
                dgFuncionario.DataSource = dao.ConsultarFuncionarioCpf(dados);

                if (dgFuncionario.Rows.Count == 0)
                {
                    MessageBox.Show("CPF não encontrado");
                    dgFuncionario.DataSource = dao.ListarTodosFuncionarios();
                }
            }
        }
    }
}