using MySql.Data.MySqlClient;
using Projeto_Vendas_Fatec.br.com.projeto.con;
using Projeto_Vendas_Fatec.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vendas_Fatec.br.com.projeto.dao
{
    class FornecedorDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método que Cadastra um Fornecedor

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"insert into tb_fornecedores (nome, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado) 
                               values (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",         fornecedor.Nome);
                executasql.Parameters.AddWithValue("@cnpj",         fornecedor.Cnpj);
                executasql.Parameters.AddWithValue("@email",        fornecedor.Email);
                executasql.Parameters.AddWithValue("@telefone",     fornecedor.Telefone);
                executasql.Parameters.AddWithValue("@celular",      fornecedor.Celular);
                executasql.Parameters.AddWithValue("@cep",          fornecedor.Cep);
                executasql.Parameters.AddWithValue("@endereco",     fornecedor.Endereco);
                executasql.Parameters.AddWithValue("@numero",       fornecedor.Numero);
                executasql.Parameters.AddWithValue("@complemento",  fornecedor.Complemento);
                executasql.Parameters.AddWithValue("@bairro",       fornecedor.Bairro);
                executasql.Parameters.AddWithValue("@cidade",       fornecedor.Cidade);
                executasql.Parameters.AddWithValue("@estado",       fornecedor.Estado);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Altera um Fornecedor
        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"update tb_fornecedores set nome = @nome, cnpj = @cnpj, email = @email, telefone = @telefone, celular = @celular, cep = @cep, endereco = @endereco, 
                                                          numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";
                ;

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",         fornecedor.Nome);
                executasql.Parameters.AddWithValue("@cnpj",         fornecedor.Cnpj);
                executasql.Parameters.AddWithValue("@email",        fornecedor.Email);
                executasql.Parameters.AddWithValue("@telefone",     fornecedor.Telefone);
                executasql.Parameters.AddWithValue("@celular",      fornecedor.Celular);
                executasql.Parameters.AddWithValue("@cep",          fornecedor.Cep);
                executasql.Parameters.AddWithValue("@endereco",     fornecedor.Endereco);
                executasql.Parameters.AddWithValue("@numero",       fornecedor.Numero);
                executasql.Parameters.AddWithValue("@complemento",  fornecedor.Complemento);
                executasql.Parameters.AddWithValue("@bairro",       fornecedor.Bairro);
                executasql.Parameters.AddWithValue("@cidade",       fornecedor.Cidade);
                executasql.Parameters.AddWithValue("@estado",       fornecedor.Estado);

                executasql.Parameters.AddWithValue("@id", fornecedor.Id);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do Fornecedor alterados com Sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Exclui um Fornecedor
        public void ExcluirFornecedor(int idFornecedor)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"delete from tb_fornecedores where id = @id";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idFornecedor);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluído com Sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Lista todos os Fornecedores
        public DataTable ListarTodosFornecedores()
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaFornecedor = new DataTable();
                string sql = @"select * from tb_fornecedores";

                //2° Passo - Organizaro comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFornecedor);

                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Lista Fornecedor por Nome
        public DataTable ConsultarFornecedorNome(string nome)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaFornecedor = new DataTable();
                string sql = @"select * from tb_fornecedores where nome = @nome";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFornecedor);

                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Lista Fornecedor por CNPJ
        public DataTable ConsultarFornecedorCnpj(string cnpj)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaFornecedor = new DataTable();
                string sql = @"select * from tb_fornecedores where cnpj = @cnpj";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cnpj", cnpj);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFornecedor);

                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion
    }
}
