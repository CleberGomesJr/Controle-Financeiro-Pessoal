using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Repositories
{
    public class ReceitaRepository{
        private static List<Receita> _receitas = new List<Receita>();

        public void AdicionarReceita(Receita receita){
            _receitas.Add(receita);
        }

        public List<Receita> ListarReceitas(){
            return _receitas;
        }

        public Receita BuscarPorId(int id){
            return _receitas.FirstOrDefault(r => r.Id == id);
        }

        public void RemoverReceita(int id){
            var receita = BuscarPorId(id);
            if (receita != null){
                _receitas.Remove(receita);
            }
        }
    }
}
