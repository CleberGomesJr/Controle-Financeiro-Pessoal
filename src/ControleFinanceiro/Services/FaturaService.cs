using System;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using System.Collections.Generic;

namespace ControleFinanceiro.Services{
    public class FaturaService{
        private readonly FaturaRepository _faturaRepository;

        public FaturaService(){
            _faturaRepository = new FaturaRepository();
        }

        public void AdicionarFatura(string nome, decimal valor, int parcelas){
            if (valor <= 0)
                throw new ArgumentException("O valor da fatura deve ser positivo. ");
            if (parcelas <= 0)
                throw new ArgumentException("O número de parcelas deve ser maior que 0.");
            var fatura = new Fatura(nome, valor, parcelas);
            _faturaRepository.AdicionarFatura(fatura);
        }

        public List<Fatura> ListarFaturas(){
            return _faturaRepository.ListarFaturas();
        }
    }
}