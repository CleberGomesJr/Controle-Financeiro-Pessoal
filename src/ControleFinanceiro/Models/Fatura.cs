using System;

namespace ControleFinanceiro.Models{

    public class Fatura{
        private static int _idCounter = 1;
        public int Id{get;}
        public string NomeCartao{get; set;}
        public decimal Valor{get;}
        public int Parcelas{get;set;}
        public DateTime Data{get;set;}
        public decimal ValorTotal => Valor * Parcelas;


        public Fatura(string nome, decimal valor, int parcelas){
            if (valor <= 0 || parcelas <= 0)
                throw new ArgumentException("O valor da Parcela e da Fatura não pode ser negativo ou nulo.");
            NomeCartao = nome;
            Valor = valor;
            Parcelas = parcelas;
            Data = DateTime.Today;
            Id = _idCounter++;
        }
    }
}
