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
    public class ItemVendaDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public ItemVendaDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método que Cadastra um Item Venda
        public void CadastrarItemVenda(ItemVenda itemVenda)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"insert into tb_itensvendas (venda_id, produto_id, qtd, subtotal)
                                 values (@venda_id, @produto_id, @qtd, @subtotal)";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@venda_id",     itemVenda.venda_id);
                executasql.Parameters.AddWithValue("@produto_id",   itemVenda.produto_id);
                executasql.Parameters.AddWithValue("@qtd",          itemVenda.qtd);
                executasql.Parameters.AddWithValue("@subtotal",     itemVenda.subtotal);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Item Cadastrado com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);

            }
        }
        #endregion

        #region Método que Lista os itens de uma Venda
        public DataTable ListarItensPorVenda(int venda_id)
        {
            try
            {
                DataTable tabelaItens = new DataTable();

                //1° Passo - Criar o comando SQL
                string sql = @"SELECT p.descricao AS 'Descrição',
                                      i.qtd AS 'Quantidade',
                                      p.preco AS 'Preço',
                                      i.subtotal AS 'Subtotal' from tb_itensvendas AS i
                                      INNER JOIN tb_produtos AS p on(i.produto_id = p.id) WHERE i.venda_id = @venda_id";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@venda_id", venda_id);

                //3° Passo - Abrir a conexão e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4° Passo - Preencher o DataTable com os dados do Select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaItens);

                return tabelaItens;
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
