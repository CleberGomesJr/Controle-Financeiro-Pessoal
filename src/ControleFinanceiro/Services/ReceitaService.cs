using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Services
{
    public class ReceitaService
    {
        private ReceitaRepository _receitaRepository = new ReceitaRepository();

        public void AdicionarReceita(string descricao, decimal valor, string categoria)
        {
            var receita = new Receita
            {
                Id = GerarNovoId(),
                Descricao = descricao,
                Valor = valor,
                Categoria = categoria
            };

            _receitaRepository.AdicionarReceita(receita);
        }

        public List<Receita> ListarReceitas()
        {
            return _receitaRepository.ObterTodas();
        }

        public void RemoverReceita(int id)
        {
            _receitaRepository.RemoverReceita(id);
        }

        private int GerarNovoId()
        {
            var receitas = _receitaRepository.ObterTodas();
            return receitas.Any() ? receitas.Max(r => r.Id) + 1 : 1;
        }
    }
}
