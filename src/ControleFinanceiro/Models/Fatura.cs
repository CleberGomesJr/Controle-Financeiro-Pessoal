using System;

/* 2. Classe FaturaCartao

Responsabilidade: Registra compras feitas no cartão de crédito.

Propriedades:

Id: Identificador único da fatura.

NomeCartao: Nome do cartão utilizado.

Valor: Valor da compra feita no cartão.

Parcelas: Número total de parcelas.

DataCompra: Data da compra. */

namespace ControleFinanceiro.Models{

    public class Fatura{
        private static int _idCounter = 1;
        public int Id{get;}
        public string NomeCartao{get; set;}
        public decimal Valor{get;}
        public int Parcelas{get;set;}
        public DateTime Data{get;set;}

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
