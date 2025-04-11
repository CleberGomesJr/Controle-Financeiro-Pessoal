using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ControleFinanceiro.Repositories
{
    public class ReceitaRepository
    {
        private readonly string _caminhoArquivo = "receitas.json";

        private List<T> Carregar<T>(string caminho)
        {
            if (!File.Exists(caminho)) return new List<T>();

            var json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void Salvar(List<Receita> receitas)
        {
            var json = JsonSerializer.Serialize(receitas);
            File.WriteAllText(_caminhoArquivo, json);
        }

        public List<Receita> ObterTodas()
        {
            return Carregar<Receita>(_caminhoArquivo);
        }

        public void AdicionarReceita(Receita receita)
        {
            var receitas = ObterTodas();
            receitas.Add(receita);
            Salvar(receitas);
        }

        public void RemoverReceita(int id)
        {
            var receitas = ObterTodas();
            var receita = receitas.FirstOrDefault(r => r.Id == id);
            if (receita != null)
            {
                receitas.Remove(receita);
                Salvar(receitas);
            }
        }
    }
}
