using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendas_Fatec.br.com.projeto.model
{
    public class Funcionario : Cliente
    {
        //Atributos + Getters + Setters
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public string Nivel { get; set; }
    }
}
