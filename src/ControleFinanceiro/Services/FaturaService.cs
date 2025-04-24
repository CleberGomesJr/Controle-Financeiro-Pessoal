using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Services
{
    public class FaturaService
    {
        private FaturaRepository _faturaRepository = new FaturaRepository();

        public void AdicionarFatura(string nome, decimal valor, int parcelas)
        {
            var fatura = new Fatura
            {
                Id = GerarNovoId(),
                Nome = nome,
                Valor = valor,
                Parcelas = parcelas
            };

            _faturaRepository.AdicionarFatura(fatura);
        }

        public List<Fatura> ListarFaturas()
        {
            return _faturaRepository.ObterTodas();
        }

        public void RemoverFatura(int id)
        {
            _faturaRepository.RemoverFatura(id);
        }

        private int GerarNovoId()
        {
            var faturas = _faturaRepository.ObterTodas();
            return faturas.Any() ? faturas.Max(f => f.Id) + 1 : 1;
        }
    }
}
