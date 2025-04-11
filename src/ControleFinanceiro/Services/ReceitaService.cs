using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using System.Collections.Generic;

namespace ControleFinanceiro.Services
{
    public class ReceitaService
    {
        private List<Receita> _receitas;

        public ReceitaService()
        {
            _receitas = DataStorage.CarregarReceitas();
        }

        public void AdicionarReceita(string descricao, decimal valor, string categoria)
        {
            var receita = new Receita(descricao, valor, categoria);
            _receitas.Add(receita);
            DataStorage.SalvarReceitas(_receitas);
        }

        public List<Receita> ListarReceitas()
        {
            return _receitas;
        }
        public void RemoverReceita(int index)
        {
            if (index >= 0 && index < _receitas.Count)
            {
                _receitas.RemoveAt(index);
                DataStorage.SalvarReceitas(_receitas);
            }
        }
        

    }
}
