using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Collections.Generic;

namespace ControleFinanceiro.Services
{
    public class ReceitaService{
        private readonly ReceitaRepository _receitaRepository;

        public ReceitaService(){
            _receitaRepository = new ReceitaRepository();
        }

        public void AdicionarReceita(string descricao, decimal valor, string categoria){
            if (valor <= 0)
                throw new ArgumentException("O valor da receita deve ser positivo.");

            var receita = new Receita(descricao, valor, categoria);
            _receitaRepository.AdicionarReceita(receita);
        }

        public List<Receita> ListarReceitas(){
            return _receitaRepository.ListarReceitas();
        }
        public void RemoverReceita(int id)
        {
            _receitaRepository.RemoverReceita(id);
        }
    }
}
