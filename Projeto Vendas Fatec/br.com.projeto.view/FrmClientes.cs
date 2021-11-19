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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            //Botão Cadastrar
            //1° Passo - Receber os dados em um objeto Model de Cliente
            Cliente cliente = new Cliente();

            cliente.Nome        = txtNome.Text;
            cliente.Rg          = txtRg.Text;
            cliente.Cpf         = txtCpf.Text;
            cliente.Email       = txtEmail.Text;
            cliente.Telefone    = txtTelefone.Text;
            cliente.Celular     = txtCelular.Text;
            cliente.Cep         = txtCep.Text;
            cliente.Endereco    = txtEndereco.Text;
            cliente.Numero      = int.Parse(txtNumero.Text);
            cliente.Complemento = txtComplemento.Text;
            cliente.Bairro      = txtBairro.Text;
            cliente.Cidade      = txtCidade.Text;
            cliente.Estado      = cbEstado.Text;

            //2° Passo - Criar o objeto ClienteDAO para chamar o método CadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.CadastrarCliente(cliente);

            // Carrega a Tela
            dgCliente.DataSource = dao.ListarTodosCliente();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Carrega a Tela
            ClienteDAO dao = new ClienteDAO();
            dgCliente.DataSource = dao.ListarTodosCliente();
        }

        private void dgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os Dados da Linha Selecionada
            txtCodigo.Text          = dgCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text            = dgCliente.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text              = dgCliente.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text             = dgCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text           = dgCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text        = dgCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text         = dgCliente.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text             = dgCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text        = dgCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text          = dgCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text     = dgCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text          = dgCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text          = dgCliente.CurrentRow.Cells[12].Value.ToString();
            cbEstado.Text           = dgCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a Guia de Dados Pessoais
            tabControl1.SelectedTab = abaDados;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            //Botão Editar
            //1° Passo - Receber os dados em um objeto Model de Cliente
            Cliente cliente = new Cliente();

            cliente.Nome        = txtNome.Text;
            cliente.Rg          = txtRg.Text;
            cliente.Cpf         = txtCpf.Text;
            cliente.Email       = txtEmail.Text;
            cliente.Telefone    = txtTelefone.Text;
            cliente.Celular     = txtCelular.Text;
            cliente.Cep         = txtCep.Text;
            cliente.Endereco    = txtEndereco.Text;
            cliente.Numero      = int.Parse(txtNumero.Text);
            cliente.Complemento = txtComplemento.Text;
            cliente.Bairro      = txtBairro.Text;
            cliente.Cidade      = txtCidade.Text;
            cliente.Estado      = cbEstado.Text;

            //2° Passo - Receber o ID do Cliente
            cliente.Id = int.Parse(txtCodigo.Text);

            //3° Passo - Criar o objeto ClienteDAO para chamar o método EditarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.AlterarCliente(cliente);

            //Recarrega o DataGridView
            dgCliente.DataSource = dao.ListarTodosCliente();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            //Botão Excluir
            ClienteDAO dao = new ClienteDAO();
            dao.ExcluirCliente(int.Parse(txtCodigo.Text));

            //Recarregar o DataGridView
            dgCliente.DataSource = dao.ListarTodosCliente();
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
            ClienteDAO dao = new ClienteDAO();

            //Verificar qual a opção selecionada
            
            //Se for Nome
            if(cbFiltro.SelectedIndex == 0)
            {
                MessageBox.Show("Consulta por Nome");
                dgCliente.DataSource = dao.ConsultarClienteNome(dados);

                if(dgCliente.Rows.Count == 0)
                {
                    MessageBox.Show("Nome não encontrado");
                    dgCliente.DataSource = dao.ListarTodosCliente();
                }
            }
            //Se for CPF
            else if(cbFiltro.SelectedIndex == 1)
            {
                MessageBox.Show("Consulta por CPF");
                dgCliente.DataSource = dao.ConsultarClienteCpf(dados);

                if (dgCliente.Rows.Count == 0)
                {
                    MessageBox.Show("CPF não encontrado");
                    dgCliente.DataSource = dao.ListarTodosCliente();
                }
            }

        }
    }
}
