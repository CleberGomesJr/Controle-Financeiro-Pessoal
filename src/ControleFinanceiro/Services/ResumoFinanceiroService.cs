using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Services
{
    public class ResumoFinanceiroService
    {
        private ReceitaRepository _receitaRepo;
        private FaturaRepository _faturaRepo;
        private InvestimentoRepository _investimentoRepo;

        public ResumoFinanceiroService(ReceitaRepository receitaRepo, FaturaRepository faturaRepo, InvestimentoRepository investimentoRepo)
        {
            _receitaRepo = receitaRepo;
            _faturaRepo = faturaRepo;
            _investimentoRepo = investimentoRepo;
        }

        public ResumoFinanceiro GerarResumo()
        {
            var totalReceitas = _receitaRepo.ObterTodas().Sum(r => r.Valor);
            var totalFaturas = _faturaRepo.ObterTodas().Sum(f => f.Valor);
            var totalInvestimentos = _investimentoRepo.ObterTodos().Sum(i => i.Valor);

            return new ResumoFinanceiro
            {
                TotalReceitas = totalReceitas,
                TotalFaturas = totalFaturas,
                TotalInvestimentos = totalInvestimentos
            };
        }
    }
}
