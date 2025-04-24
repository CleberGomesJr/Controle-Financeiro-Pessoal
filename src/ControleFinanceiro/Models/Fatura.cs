namespace ControleFinanceiro.Models
{
    public class Fatura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }

        public Fatura() { }

        public Fatura(string nome, decimal valor, int parcelas)
        {
            Nome = nome;
            Valor = valor;
            Parcelas = parcelas;
        }
    }
}
