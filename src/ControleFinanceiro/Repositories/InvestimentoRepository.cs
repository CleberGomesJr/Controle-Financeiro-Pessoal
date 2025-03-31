using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Repositories
{
    public class InvestimentoRepository
    {
        private static List<Investimento> _investimentos = new List<Investimento>();

        public void AdicionarInvestimento(Investimento investimento)
        {
            _investimentos.Add(investimento);
        }

        public List<Investimento> ListarInvestimentos()
        {
            return _investimentos;
        }

        public Investimento BuscarPorId(int id)
        {
            return _investimentos.FirstOrDefault(r => r.Id == id);
        }

        public void RemoverInvestimento(int id)
        {
            var investimento = BuscarPorId(id);
            if (investimento != null)
            {
                _investimentos.Remove(investimento);
            }
        }
    }
}
