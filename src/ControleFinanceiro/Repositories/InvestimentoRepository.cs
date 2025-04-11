using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ControleFinanceiro.Repositories
{
    public class InvestimentoRepository
    {
        private readonly string _caminhoArquivo = "investimentos.json";

        private List<T> Carregar<T>(string caminho)
        {
            if (!File.Exists(caminho)) return new List<T>();

            var json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void Salvar(List<Investimento> investimentos)
        {
            var json = JsonSerializer.Serialize(investimentos);
            File.WriteAllText(_caminhoArquivo, json);
        }

        public List<Investimento> ObterTodos()
        {
            return Carregar<Investimento>(_caminhoArquivo);
        }

        public void AdicionarInvestimento(Investimento investimento)
        {
            var investimentos = ObterTodos();
            investimentos.Add(investimento);
            Salvar(investimentos);
        }

        public Investimento BuscarPorId(int id)
        {
            var investimentos = ObterTodos();
            return investimentos.FirstOrDefault(i => i.Id == id);
        }

        public void RemoverInvestimento(int id)
        {
            var investimentos = ObterTodos();
            var investimento = investimentos.FirstOrDefault(i => i.Id == id);
            if (investimento != null)
            {
                investimentos.Remove(investimento);
                Salvar(investimentos);
            }
        }
    }
}
