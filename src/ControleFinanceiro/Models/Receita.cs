using System;

namespace ControleFinanceiro.Models{
    public class Receita{
        public string Nome{get; set;};
        public decimal Valor{get; set;};
        public DateTime Data{set;};

        public Receita(string nome, decimal valor){
            if (valor <= 0)
                throw new ArgumentException("O valor de uma receita não pode ser negativo.");
            Nome = nome;
            Valor = valor;
        }
    }
}