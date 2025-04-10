using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using System.Collections.Generic;

namespace ControleFinanceiro.Services
{
    public class FaturaService
    {
        private List<Fatura> _faturas;

        public FaturaService()
        {
            _faturas = DataStorage.CarregarFaturas();
        }

        public void AdicionarFatura(string nome, decimal valor, int parcelas)
        {
            var fatura = new Fatura(nome, valor, parcelas);
            _faturas.Add(fatura);
            DataStorage.SalvarFaturas(_faturas);
        }

        public List<Fatura> ListarFaturas()
        {
            return _faturas;
        }
    }
}
