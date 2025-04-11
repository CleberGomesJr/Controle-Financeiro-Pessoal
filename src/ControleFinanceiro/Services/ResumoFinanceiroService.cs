using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Linq;

namespace ControleFinanceiro.Services
{
    public class ResumoFinanceiroService
    {
        private ReceitaRepository _receitaRepo;
        private FaturaRepository _faturaRepo;
        private InvestimentoRepository _investRepo;

        public ResumoFinanceiroService(
            ReceitaRepository receitaRepo,
            FaturaRepository faturaRepo,
            InvestimentoRepository investRepo)
        {
            _receitaRepo = receitaRepo;
            _faturaRepo = faturaRepo;
            _investRepo = investRepo;
        }

        public ResumoFinanceiro GerarResumo()
        {
            var totalReceitas = _receitaRepo.ObterTodas()?.Sum(r => r.Valor) ?? 0;
            var totalDespesas = _faturaRepo.ObterTodas()?.Sum(f => f.ValorTotal) ?? 0;
            var totalInvestimentos = _investRepo.ObterTodos()?.Sum(i => i.Valor) ?? 0;

            return new ResumoFinanceiro
            {
                TotalReceitas = totalReceitas,
                TotalDespesas = totalDespesas,
                TotalInvestimentos = totalInvestimentos
            };
        }
    }
}
