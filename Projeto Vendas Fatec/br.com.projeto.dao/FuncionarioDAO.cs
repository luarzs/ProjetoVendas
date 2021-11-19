using MySql.Data.MySqlClient;
using Projeto_Vendas_Fatec.br.com.projeto.con;
using Projeto_Vendas_Fatec.br.com.projeto.model;
using Projeto_Vendas_Fatec.br.com.projeto.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vendas_Fatec.br.com.projeto.dao
{
    public class FuncionarioDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método que Cadastra um Funcionario

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"insert into tb_funcionarios (nome, rg, cpf, email, senha, cargo, nivel_acesso, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado) 
                               values (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel_acesso, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",         funcionario.Nome);
                executasql.Parameters.AddWithValue("@rg",           funcionario.Rg);
                executasql.Parameters.AddWithValue("@cpf",          funcionario.Cpf);
                executasql.Parameters.AddWithValue("@email",        funcionario.Email);
                executasql.Parameters.AddWithValue("@senha",        funcionario.Senha);
                executasql.Parameters.AddWithValue("@cargo",        funcionario.Cargo);
                executasql.Parameters.AddWithValue("@nivel_acesso", funcionario.Nivel);
                executasql.Parameters.AddWithValue("@telefone",     funcionario.Telefone);
                executasql.Parameters.AddWithValue("@celular",      funcionario.Celular);
                executasql.Parameters.AddWithValue("@cep",          funcionario.Cep);
                executasql.Parameters.AddWithValue("@endereco",     funcionario.Endereco);
                executasql.Parameters.AddWithValue("@numero",       funcionario.Numero);
                executasql.Parameters.AddWithValue("@complemento",  funcionario.Complemento);
                executasql.Parameters.AddWithValue("@bairro",       funcionario.Bairro);
                executasql.Parameters.AddWithValue("@cidade",       funcionario.Cidade);
                executasql.Parameters.AddWithValue("@estado",       funcionario.Estado);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Funcionário cadastrado com sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Altera um Funcionario
        public void AlterarFuncionario(Funcionario funcionario)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"update tb_funcionarios set nome = @nome, rg = @rg, cpf = @cpf, email = @email, senha = @senha, cargo = @cargo, nivel_acesso = @nivel_acesso,
                                                          telefone = @telefone, celular = @celular, cep = @cep, endereco = @endereco, numero = @numero, complemento = @complemento, 
                                                          bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";
                ;

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",         funcionario.Nome);
                executasql.Parameters.AddWithValue("@rg",           funcionario.Rg);
                executasql.Parameters.AddWithValue("@cpf",          funcionario.Cpf);
                executasql.Parameters.AddWithValue("@email",        funcionario.Email);
                executasql.Parameters.AddWithValue("@senha",        funcionario.Senha);
                executasql.Parameters.AddWithValue("@cargo",        funcionario.Cargo);
                executasql.Parameters.AddWithValue("@nivel_acesso", funcionario.Nivel);
                executasql.Parameters.AddWithValue("@telefone",     funcionario.Telefone);
                executasql.Parameters.AddWithValue("@celular",      funcionario.Celular);
                executasql.Parameters.AddWithValue("@cep",          funcionario.Cep);
                executasql.Parameters.AddWithValue("@endereco",     funcionario.Endereco);
                executasql.Parameters.AddWithValue("@numero",       funcionario.Numero);
                executasql.Parameters.AddWithValue("@complemento",  funcionario.Complemento);
                executasql.Parameters.AddWithValue("@bairro",       funcionario.Bairro);
                executasql.Parameters.AddWithValue("@cidade",       funcionario.Cidade);
                executasql.Parameters.AddWithValue("@estado",       funcionario.Estado);

                executasql.Parameters.AddWithValue("@id", funcionario.Id);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do Funcionário alterados com Sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Exclui um Funcionário
        public void ExcluirFuncionario(int idFuncionario)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"delete from tb_funcionarios where id = @id";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idFuncionario);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Funcionário excluído com Sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Lista todos os Funcionários
        public DataTable ListarTodosFuncionarios()
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select * from tb_funcionarios";

                //2° Passo - Organizaro comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFuncionario);

                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Lista Funcionario por Nome
        public DataTable ConsultarFuncionarioNome(string nome)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select * from tb_funcionarios where nome like @nome";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFuncionario);

                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Lista Funcionário por CPF
        public DataTable ConsultarFuncionarioCpf(string cpf)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select * from tb_funcionarios where cpf = @cpf";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cpf", cpf);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFuncionario);

                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Efetua Login
        public void EfetuarLogin(string email, string senha)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"SELECT * FROM tb_funcionarios WHERE email = @email and senha = @senha";

                //2° Passo - Organizar e Executar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                executasql.Parameters.AddWithValue("@email", email);
                executasql.Parameters.AddWithValue("@senha", senha);

                //3° Passo - Abrir a conexão e Executar o comando
                conexao.Open();
                MySqlDataReader rs = executasql.ExecuteReader(); //Pega o retorno da execução e guarda

                if(rs.Read())
                {
                    //Fez o Login
                    //Descobrir qual é o nível de acesso deste usuário
                    string nivel = rs.GetString("nivel_acesso");
                    string nome = rs.GetString("nome");

                    //Criando um Objeto da Tela de Menu
                    FrmMenu telamenu = new FrmMenu();

                    telamenu.lblLogado.Text = nome;

                    //Restrições
                    if(nivel.Equals("Administrador"))
                    {
                        MessageBox.Show("Bem Vindo ao Sistema: " + nome);

                        //Abre a Tela de Menu
                        telamenu.ShowDialog();
                    }
                    else if(nivel.Equals("Operador"))
                    {
                        MessageBox.Show("Bem Vindo ao Sistema: " + nome);

                        //Especificar as Permissões da Tela do Usuário
                        telamenu.menu_vendas.Visible        = false; // ou menu_vendas.Enabled para não conseguir clicar

                        //Abre a Tela de Menu
                        telamenu.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha Inválidos!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion
    }
}
