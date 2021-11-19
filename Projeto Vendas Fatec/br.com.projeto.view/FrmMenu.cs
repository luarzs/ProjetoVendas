using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Vendas_Fatec.br.com.projeto.view
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //Pegando a Data Atual
            lblData.Text = DateTime.Now.ToShortDateString();

            //Inicia o Timer
            timer1.Start();
           
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void menu_vendas_Click(object sender, EventArgs e)
        {
            
        }

        private void menu_histvendas_Click(object sender, EventArgs e)
        {
            //Abrir Histórico de Vendas
            FrmHistorico tela = new FrmHistorico();
            tela.ShowDialog();
        }

        private void menu_novavenda_Click(object sender, EventArgs e)
        {
            //Abrir Histórico de Vendas
            FrmVendas tela = new FrmVendas();
            tela.ShowDialog();
        }

        private void menu_cadclientes_Click(object sender, EventArgs e)
        {
            FrmClientes tela = new FrmClientes();
            tela.ShowDialog();
        }

        private void menu_consclientes_Click(object sender, EventArgs e)
        {
            FrmClientes tela = new FrmClientes();
            tela.ShowDialog();
        }

        private void menu_cadproduto_Click(object sender, EventArgs e)
        {
            FrmProdutos tela = new FrmProdutos();
            tela.ShowDialog();
        }

        private void menu_consproduto_Click(object sender, EventArgs e)
        {
            FrmProdutos tela = new FrmProdutos();
            tela.ShowDialog();
        }

        private void menu_cadfuncionarios_Click(object sender, EventArgs e)
        {
            FrmFuncionarios tela = new FrmFuncionarios();
            tela.ShowDialog();
        }

        private void menu_consfuncionarios_Click(object sender, EventArgs e)
        {
            FrmFuncionarios tela = new FrmFuncionarios();
            tela.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;user=root;password=1234;database=bdfatec;charset=utf8";

            string file = "C:\\Backup\\backup.sql";
            using(MySqlConnection con = new MySqlConnection(conexao))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = con;
                        con.Open();
                        mb.ExportToFile(file);
                        con.Close();
                    }
                }
            }
            MessageBox.Show("Backup realizado com Sucesso!");
        }
    }
}
