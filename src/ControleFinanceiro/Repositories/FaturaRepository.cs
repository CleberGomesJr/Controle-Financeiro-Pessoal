using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Repositories
{
    public class FaturaRepository{
        private static List<Fatura> _faturas = new List<Fatura>();
        
        public void AdicionarFatura(Fatura fatura){
            _faturas.Add(fatura);
        }
        public Lista<Fatura> ListarFaturas(){
            return _faturas;
        }
        public Fatura BuscarPorId(int id){
            return _faturas.FirstOrDefault(r=>r.Id==id);
        }
        public void RemoverFatura(int id){
            var fatura = BuscarPorId(id);
            if (fatura != null){
                _faturas.Remove(fatura);
            }
        }
        
    }
}
