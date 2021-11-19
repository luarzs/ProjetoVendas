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
    public class VendaDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public VendaDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método para Cadastrar uma Venda
        public void CadastrarVenda(Venda venda)
        {
            try
            {
                //1° Passo - Criar o comando SQL
                string sql = @"insert into tb_vendas (cliente_id, data_venda, total_venda, observacoes) 
                               values (@cliente_id, @data_venda, @total_venda, @obs)";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cliente_id",   venda.cliente_id);
                executasql.Parameters.AddWithValue("@data_venda",   venda.data_venda);
                executasql.Parameters.AddWithValue("@total_venda",  venda.total_venda);
                executasql.Parameters.AddWithValue("@obs",  venda.observacao);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Venda cadastrada com sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método que Retorna o ID da Última Venda
        public int RetornaIdUltimaVenda()
        {
            try
            {
                int idvenda = 0;

                //1° Passo - Criar o SQL
                string sql = @"select max(id) id from tb_vendas";

                //2° Passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3° Passo - Abrir a conexao e executar o comando SQL
                conexao.Open();

                //4° Passo - Montar o objeto Produto para ser retornado
                MySqlDataReader rs = executasql.ExecuteReader();

                if(rs.Read())
                {
                    idvenda = rs.GetInt32("id");
                }

                conexao.Close();
                return idvenda;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                conexao.Close();
                return 0;
            }
        }
        #endregion

        #region Método que Filtra as Vendas por Período
        public DataTable ListarVendasPorPeriodo(DateTime dtinicio, DateTime dtfim)
        {
            try
            {
                DataTable tabelaHistorico = new DataTable();

                //1 Passo - é criar o sql
                string sql = @"SELECT  v.id as 'Código da Venda', 
	                                   date_format(v.data_venda, '%d/%m/%y') as 'Data', 
                                       v.total_venda as 'Total', 
	                                   c.nome as 'Cliente',
                                       v.observacoes as 'Obs'
	                                FROM TB_VENDAS as v join TB_CLIENTES AS C ON (v.cliente_id = c.id)
                                    WHERE v.data_venda BETWEEN @datainicio AND @datafim";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@datainicio", dtinicio);
                executasql.Parameters.AddWithValue("@datafim", dtfim);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaHistorico);
                conexao.Close();

                return tabelaHistorico;


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }
        #endregion

        #region Método que Lista todas as Vendas
        public DataTable ListarVendas()
        {
            try
            {
                DataTable tabelaHistorico = new DataTable();

                //1 Passo - é criar o sql
                string sql = @"SELECT  v.id as 'Código da Venda', 
	                                   date_format(v.data_venda, '%d/%m/%y') as 'Data', 
                                       v.total_venda as 'Total', 
	                                   c.nome as 'Cliente',
                                       v.observacoes as 'Obs'
	                                   FROM TB_VENDAS as v join TB_CLIENTES AS C ON (v.cliente_id = c.id)";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaHistorico);
                conexao.Close();

                return tabelaHistorico;
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