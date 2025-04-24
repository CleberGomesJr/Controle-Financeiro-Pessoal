namespace ControleFinanceiro.Models
{
    public class Investimento
    {
        public int Id { get; set; }
        public string NomeAtivo { get; set; }
        public decimal Valor { get; set; }

        public Investimento() { }

        public Investimento(string nomeAtivo, decimal valor)
        {
            NomeAtivo = nomeAtivo;
            Valor = valor;
        }
    }
}
