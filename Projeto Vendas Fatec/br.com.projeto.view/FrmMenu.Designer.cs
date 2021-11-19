
namespace Projeto_Vendas_Fatec.br.com.projeto.view
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cadclientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_consclientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_funcionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cadfuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_consfuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_produtos = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cadproduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_consproduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_vendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_histvendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_novavenda = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataAtu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHoraAtu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnBackup = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_clientes,
            this.menu_funcionarios,
            this.menu_produtos,
            this.menu_vendas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_clientes
            // 
            this.menu_clientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cadclientes,
            this.menu_consclientes});
            this.menu_clientes.Name = "menu_clientes";
            this.menu_clientes.Size = new System.Drawing.Size(75, 24);
            this.menu_clientes.Text = "Clientes";
            // 
            // menu_cadclientes
            // 
            this.menu_cadclientes.Name = "menu_cadclientes";
            this.menu_cadclientes.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.menu_cadclientes.Size = new System.Drawing.Size(256, 26);
            this.menu_cadclientes.Text = "Cadastrar Cliente";
            this.menu_cadclientes.Click += new System.EventHandler(this.menu_cadclientes_Click);
            // 
            // menu_consclientes
            // 
            this.menu_consclientes.Name = "menu_consclientes";
            this.menu_consclientes.Size = new System.Drawing.Size(256, 26);
            this.menu_consclientes.Text = "Consulta de Clientes";
            this.menu_consclientes.Click += new System.EventHandler(this.menu_consclientes_Click);
            // 
            // menu_funcionarios
            // 
            this.menu_funcionarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cadfuncionarios,
            this.menu_consfuncionarios});
            this.menu_funcionarios.Name = "menu_funcionarios";
            this.menu_funcionarios.Size = new System.Drawing.Size(106, 24);
            this.menu_funcionarios.Text = "Funcionários";
            // 
            // menu_cadfuncionarios
            // 
            this.menu_cadfuncionarios.Name = "menu_cadfuncionarios";
            this.menu_cadfuncionarios.Size = new System.Drawing.Size(259, 26);
            this.menu_cadfuncionarios.Text = "Cadastro de Funcionários";
            this.menu_cadfuncionarios.Click += new System.EventHandler(this.menu_cadfuncionarios_Click);
            // 
            // menu_consfuncionarios
            // 
            this.menu_consfuncionarios.Name = "menu_consfuncionarios";
            this.menu_consfuncionarios.Size = new System.Drawing.Size(259, 26);
            this.menu_consfuncionarios.Text = "Consulta de Funcionários";
            this.menu_consfuncionarios.Click += new System.EventHandler(this.menu_consfuncionarios_Click);
            // 
            // menu_produtos
            // 
            this.menu_produtos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cadproduto,
            this.menu_consproduto});
            this.menu_produtos.Name = "menu_produtos";
            this.menu_produtos.Size = new System.Drawing.Size(82, 24);
            this.menu_produtos.Text = "Produtos";
            // 
            // menu_cadproduto
            // 
            this.menu_cadproduto.Name = "menu_cadproduto";
            this.menu_cadproduto.Size = new System.Drawing.Size(233, 26);
            this.menu_cadproduto.Text = "Cadastro de Produto";
            this.menu_cadproduto.Click += new System.EventHandler(this.menu_cadproduto_Click);
            // 
            // menu_consproduto
            // 
            this.menu_consproduto.Name = "menu_consproduto";
            this.menu_consproduto.Size = new System.Drawing.Size(233, 26);
            this.menu_consproduto.Text = "Consulta de Produtos";
            this.menu_consproduto.Click += new System.EventHandler(this.menu_consproduto_Click);
            // 
            // menu_vendas
            // 
            this.menu_vendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_histvendas,
            this.menu_novavenda});
            this.menu_vendas.Name = "menu_vendas";
            this.menu_vendas.Size = new System.Drawing.Size(70, 24);
            this.menu_vendas.Text = "Vendas";
            this.menu_vendas.Click += new System.EventHandler(this.menu_vendas_Click);
            // 
            // menu_histvendas
            // 
            this.menu_histvendas.Name = "menu_histvendas";
            this.menu_histvendas.Size = new System.Drawing.Size(224, 26);
            this.menu_histvendas.Text = "Histórico de Vendas";
            this.menu_histvendas.Click += new System.EventHandler(this.menu_histvendas_Click);
            // 
            // menu_novavenda
            // 
            this.menu_novavenda.Name = "menu_novavenda";
            this.menu_novavenda.Size = new System.Drawing.Size(224, 26);
            this.menu_novavenda.Text = "Nova Venda";
            this.menu_novavenda.Click += new System.EventHandler(this.menu_novavenda_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioLog,
            this.lblLogado,
            this.toolStripStatusLabel2,
            this.lblDataAtu,
            this.lblData,
            this.toolStripStatusLabel4,
            this.lblHoraAtu,
            this.lblHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuarioLog
            // 
            this.lblUsuarioLog.Name = "lblUsuarioLog";
            this.lblUsuarioLog.Size = new System.Drawing.Size(117, 20);
            this.lblUsuarioLog.Text = "Usuário Logado:";
            // 
            // lblLogado
            // 
            this.lblLogado.Name = "lblLogado";
            this.lblLogado.Size = new System.Drawing.Size(15, 20);
            this.lblLogado.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(33, 20);
            this.toolStripStatusLabel2.Text = "      ";
            // 
            // lblDataAtu
            // 
            this.lblDataAtu.Name = "lblDataAtu";
            this.lblDataAtu.Size = new System.Drawing.Size(44, 20);
            this.lblDataAtu.Text = "Data:";
            // 
            // lblData
            // 
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(15, 20);
            this.lblData.Text = "-";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(33, 20);
            this.toolStripStatusLabel4.Text = "      ";
            // 
            // lblHoraAtu
            // 
            this.lblHoraAtu.Name = "lblHoraAtu";
            this.lblHoraAtu.Size = new System.Drawing.Size(45, 20);
            this.lblHoraAtu.Text = "Hora:";
            // 
            // lblHora
            // 
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(15, 20);
            this.lblHora.Text = "-";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(12, 40);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(237, 62);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup do Banco de Dados";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 560);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmMenu";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_clientes;
        private System.Windows.Forms.ToolStripMenuItem menu_consclientes;
        private System.Windows.Forms.ToolStripMenuItem menu_funcionarios;
        private System.Windows.Forms.ToolStripMenuItem menu_consfuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menu_produtos;
        private System.Windows.Forms.ToolStripMenuItem menu_consproduto;
        public System.Windows.Forms.ToolStripMenuItem menu_cadfuncionarios;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioLog;
        public System.Windows.Forms.ToolStripStatusLabel lblLogado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblDataAtu;
        private System.Windows.Forms.ToolStripStatusLabel lblData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblHoraAtu;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.ToolStripMenuItem menu_cadproduto;
        public System.Windows.Forms.ToolStripMenuItem menu_vendas;
        private System.Windows.Forms.ToolStripMenuItem menu_cadclientes;
        public System.Windows.Forms.ToolStripMenuItem menu_histvendas;
        public System.Windows.Forms.ToolStripMenuItem menu_novavenda;
    }
}