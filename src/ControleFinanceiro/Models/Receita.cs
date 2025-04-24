namespace ControleFinanceiro.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }

        public Receita() { }

        public Receita(string descricao, decimal valor, string categoria)
        {
            Descricao = descricao;
            Valor = valor;
            Categoria = categoria;
        }
    }
}
