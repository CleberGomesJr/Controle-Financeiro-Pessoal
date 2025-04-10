using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using System.Collections.Generic;

namespace ControleFinanceiro.Services
{
    public class InvestimentoService
    {
        private List<Investimento> _investimentos;

        public InvestimentoService()
        {
            _investimentos = DataStorage.CarregarInvestimentos();
        }

        public void AdicionarInvestimento(string nomeAtivo, decimal valor)
        {
            var investimento = new Investimento(nomeAtivo, valor);
            _investimentos.Add(investimento);
            DataStorage.SalvarInvestimentos(_investimentos);
        }

        public List<Investimento> ListarInvestimentos()
        {
            return _investimentos;
        }
    }
}
