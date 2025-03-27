using System;

namespace ControleFinanceiro.Models
{
    public class Investimento
    {
        private static int _idCounter = 1;
        public int Id { get; }
        public string NomeAtivo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public Investimento(string nome, decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do investimento deve ser maior que zero!");

            NomeAtivo = nome;
            Valor = valor;
            Id = _idCounter++;
            Data = DateTime.Today;
        }
    }
}
