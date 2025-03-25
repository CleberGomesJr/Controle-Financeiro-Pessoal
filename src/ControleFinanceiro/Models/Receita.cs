using System;

namespace ControleFinanceiro.Models{
    public class Receita{
        public static int _idCounter = 1;
        public int Id{get;}
        public string Descricao{ get; set; }
        public decimal Valor {get; set; }
        public string Categoria{get; set; }
        public DateTime Data {get; set; }

        public Receita(string descricao, decimal valor, string categoria){
            if(valor <= 0)
                throw new ArgumentException("O valor da Receita não pode ser negativo ou nulo.");
            Valor = valor;
            Categoria = categoria;
            Descricao = descricao;
            Id = _idCounter++;
            Data = DateTime.Today;
        }
    }
}