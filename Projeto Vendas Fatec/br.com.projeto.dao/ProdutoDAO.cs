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
    public class ProdutoDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public ProdutoDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método que Cadastra um Produto
        public void CadastrarProduto(Produto produto)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"insert into tb_produtos (descricao, preco, qtd_estoque, for_id) 
                               values (@descricao, @preco, @qtd_estoque, @for_id)";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@descricao",    produto.descricao);
                executasql.Parameters.AddWithValue("@preco",        produto.preco);
                executasql.Parameters.AddWithValue("@qtd_estoque",  produto.qtd_estoque);
                executasql.Parameters.AddWithValue("@for_id",       produto.for_id);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Altera um Produto
        public void AlterarProduto(Produto produto)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"update tb_produtos set descricao = @descricao, preco = @preco, 
                                                      qtd_estoque = @qtd_estoque, for_id = @for_id
                                                      where id = @id";
                ;

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@descricao",    produto.descricao);
                executasql.Parameters.AddWithValue("@preco",        produto.preco);
                executasql.Parameters.AddWithValue("@qtd_estoque",  produto.qtd_estoque);
                executasql.Parameters.AddWithValue("@for_id",       produto.for_id);

                executasql.Parameters.AddWithValue("@id", produto.id);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do Produto alterados com Sucesso!");
                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region Método que Exclui um Produto
        public void ExcluirProduto(Produto produto)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"delete from tb_produtos where id = @id";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", produto.id);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Produto excluído com Sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Lista todos os Produtos
        public DataTable ListarTodosProdutos()
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaProduto = new DataTable();
                string sql = @"SELECT p.id as 'Código',
                                      p.descricao as 'Descrição',
                                      p.preco as 'Preço',
                                      p.qtd_estoque as 'Qtd',
                                      f.nome as 'Fornecedor' FROM tb_produtos as p
                                      join tb_fornecedores as f on (p.for_id = f.id);";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaProduto);

                conexao.Close();

                return tabelaProduto;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Lista todos os Produtos por Nome
        public DataTable ListarTodosProdutosporNome(string nome)
        {
            try
            {
                //1° Passo - Criar comando SQL e o DataTable
                DataTable tabelaProduto = new DataTable();
                string sql = @"SELECT p.id as 'Código',
                                      p.descricao as 'Descrição',
                                      p.preco as 'Preço',
                                      p.qtd_estoque as 'Qtd',
                                      f.nome as 'Fornecedor' FROM tb_produtos as p
                                      join tb_fornecedores as f on (p.for_id = f.id)
                                      WHERE p.descricao like @nome;";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3° Passo - Abrir a conexao e executa o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaProduto);

                conexao.Close();

                return tabelaProduto;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                return null;
            }
        }
        #endregion

        #region Método que Retorna um Objeto Produto por Código
        public Produto RetornaProdutoporId(int id)
        {
            try
            {
                //1° Passo - Criar o Comando SQL e o Objeto Cliente
                Produto produto = new Produto();
                string sql = @"select * from tb_Produtos where id = @id";

                //2° Passo - Organizar o comando SQL e Executar
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", id);

                //3° Passo - Abrir a conexão e Executar o comando SQL
                conexao.Open();

                //4° Passo - Montar o Objeto Cliente para ser Retornado
                MySqlDataReader rs = executasql.ExecuteReader();

                if (rs.Read())
                {
                    //Monte o Objeto
                    produto.id = rs.GetInt32("id");
                    produto.descricao = rs.GetString("descricao");
                    produto.preco = rs.GetDecimal("preco");

                    conexao.Close();

                    return produto;
                }
                else
                {
                    //Não encontrou ninguém
                    MessageBox.Show("Produto não encontrado no Banco de Dados!");

                    conexao.Close();
                    
                    return null;
                }

                return produto;
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