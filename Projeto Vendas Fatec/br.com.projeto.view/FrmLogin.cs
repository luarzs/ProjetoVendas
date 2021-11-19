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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //if(txtEmail.Text == "")
            //{
                //txtEmail.Text = "Digite seu e-mail";
                //txtEmail.ForeColor = Color.Gray;
            //}
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão Entrar
                FuncionarioDAO dao = new FuncionarioDAO();

                string email, senha;

                email = txtEmail.Text;
                senha = txtSenha.Text;

                //Esconder a Tela de Login
                this.Hide();

                dao.EfetuarLogin(email, senha);
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha todos os Campos!");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
