using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Collections.Generic;

namespace ControleFinanceiro.Services
{
    public class InvestimentoService
    {
        private readonly InvestimentoRepository _investimentoRepository;

        public InvestimentoService()
        {
            _investimentoRepository = new InvestimentoRepository();
        }

        public void AdicionarInvestimento(string nome, decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do investimento deve ser positivo.");

            var investimento = new Investimento(nome, valor);
            _investimentoRepository.AdicionarInvestimento(investimento);
        }

        public List<Investimento> ListarInvestimentos()
        {
            return _investimentoRepository.ListarInvestimentos();
        }

        public Investimento BuscarPorId(int id)
        {
            return _investimentoRepository.BuscarPorId(id);
        }

        public void RemoverInvestimento(int id)
        {
            _investimentoRepository.RemoverInvestimento(id);
        }
    }
}
