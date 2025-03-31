using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Repositories{
    public class InvestimentoRepository{
        private statis List<Investimento> _investimentos = new Investimento();
        public void AdicionarInvestimento(Investimento investimento){
            _investimetos.Add = investimento;
        }
        public List<Investimento> ListarInvestimentos(){
            return _investimentos;
        }
        public Investimento BuscaPorId(int id){
            return _investimentos.FirstOrDefault(r => r.Id == id)
        }
        public void RemoverInvestimento(int id){
            var investimento = BuscaPorId(id);
            if (investimento !+ null){
                _investimento.Remove(investimento);
            }
        }
    }
}
