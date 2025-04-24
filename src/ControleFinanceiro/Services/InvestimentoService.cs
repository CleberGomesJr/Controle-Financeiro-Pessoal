using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Services
{
    public class InvestimentoService
    {
        private InvestimentoRepository _investimentoRepository = new InvestimentoRepository();

        public void AdicionarInvestimento(string nomeAtivo, decimal valor)
        {
            var investimento = new Investimento
            {
                Id = GerarNovoId(),
                NomeAtivo = nomeAtivo,
                Valor = valor
            };

            _investimentoRepository.AdicionarInvestimento(investimento);
        }

        public List<Investimento> ListarInvestimentos()
        {
            return _investimentoRepository.ObterTodos();
        }

        public void RemoverInvestimento(int id)
        {
            _investimentoRepository.RemoverInvestimento(id);
        }

        private int GerarNovoId()
        {
            var investimentos = _investimentoRepository.ObterTodos();
            return investimentos.Any() ? investimentos.Max(i => i.Id) + 1 : 1;
        }
    }
}
