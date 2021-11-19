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
    public class ClienteDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método que Cadastra um Cliente

        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"insert into tb_clientes (nome, rg, cpf, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado) 
                               values (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",        cliente.Nome);
                executasql.Parameters.AddWithValue("@rg",          cliente.Rg);
                executasql.Parameters.AddWithValue("@cpf",         cliente.Cpf);
                executasql.Parameters.AddWithValue("@email",       cliente.Email);
                executasql.Parameters.AddWithValue("@telefone",    cliente.Telefone);
                executasql.Parameters.AddWithValue("@celular",     cliente.Celular);
                executasql.Parameters.AddWithValue("@cep",         cliente.Cep);
                executasql.Parameters.AddWithValue("@endereco",    cliente.Endereco);
                executasql.Parameters.AddWithValue("@numero",      cliente.Numero);
                executasql.Parameters.AddWithValue("@complemento", cliente.Complemento);
                executasql.Parameters.AddWithValue("@bairro",      cliente.Bairro);
                executasql.Parameters.AddWithValue("@cidade",      cliente.Cidade);
                executasql.Parameters.AddWithValue("@estado",      cliente.Estado);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Altera um Cliente
        public void AlterarCliente(Cliente cliente)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"update tb_clientes set nome = @nome, rg = @rg, cpf = @cpf, email = @email, telefone = @telefone, celular = @celular, cep = @cep, endereco = @endereco, 
                                                      numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";
                ;

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",        cliente.Nome);
                executasql.Parameters.AddWithValue("@rg",          cliente.Rg);
                executasql.Parameters.AddWithValue("@cpf",         cliente.Cpf);
                executasql.Parameters.AddWithValue("@email",       cliente.Email);
                executasql.Parameters.AddWithValue("@telefone",    cliente.Telefone);
                executasql.Parameters.AddWithValue("@celular",     cliente.Celular);
                executasql.Parameters.AddWithValue("@cep",         cliente.Cep);
                executasql.Parameters.AddWithValue("@endereco",    cliente.Endereco);
                executasql.Parameters.AddWithValue("@numero",      cliente.Numero);
                executasql.Parameters.AddWithValue("@complemento", cliente.Complemento);
                executasql.Parameters.AddWithValue("@bairro",      cliente.Bairro);
                executasql.Parameters.AddWithValue("@cidade",      cliente.Cidade);
                executasql.Parameters.AddWithValue("@estado",      cliente.Estado);

                executasql.Parameters.AddWithValue("@id",          cliente.Id);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do Cliente alterados com Sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Exclui um Cliente
        public void ExcluirCliente(int idCliente)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"delete from tb_clientes where id = @id";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idCliente);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente excluído com Sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Lista todos os Cliente
        public DataTable ListarTodosCliente()
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);

                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                
                return null;
            }
        }
        #endregion

        #region Método que Lista Cliente por Nome
        public DataTable ConsultarClienteNome(string nome)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes where nome like @nome";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);

                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Lista Cliente por CPF
        public DataTable ConsultarClienteCpf(string cpf)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes where cpf = @cpf";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cpf", cpf);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);

                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Retorna um objeto do tipo Cliente por CPF
        public Cliente RetornaClienteporCpf(string cpf)
        {
            try
            {
                //1° Passo - Criar o Comando SQL e o Objeto Cliente
                Cliente cliente = new Cliente();
                string sql = @"select * from tb_Clientes where cpf = @cpf";

                //2° Passo - Organizar o comando SQL e Executar
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cpf", cpf);

                //3° Passo - Abrir a conexão e Executar o comando SQL
                conexao.Open();

                //4° Passo - Montar o Objeto Cliente para ser Retornado
                MySqlDataReader rs = executasql.ExecuteReader();

                if(rs.Read())
                {
                    //Monte o Objeto
                    cliente.Id      = rs.GetInt32("id");
                    cliente.Nome    = rs.GetString("nome");

                    conexao.Close();

                    return cliente;
                }
                else
                {
                    //Não encontrou ninguém
                    MessageBox.Show("Cliente não encontrado no Banco de Dados!");

                    conexao.Close();

                    return null;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro:" + erro);
                return null;
            }
        }
        #endregion
    }
}