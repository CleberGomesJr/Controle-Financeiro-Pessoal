using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ControleFinanceiro.Repositories
{
    public class FaturaRepository
    {
        private readonly string _caminhoArquivo = "faturas.json";

        private List<T> Carregar<T>(string caminho)
        {
            if (!File.Exists(caminho)) return new List<T>();

            var json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void Salvar(List<Fatura> faturas)
        {
            var json = JsonSerializer.Serialize(faturas);
            File.WriteAllText(_caminhoArquivo, json);
        }

        public List<Fatura> ObterTodas()
        {
            return Carregar<Fatura>(_caminhoArquivo);
        }

        public void AdicionarFatura(Fatura fatura)
        {
            var faturas = ObterTodas();
            faturas.Add(fatura);
            Salvar(faturas);
        }

        public Fatura BuscarPorId(int id)
        {
            var faturas = ObterTodas();
            return faturas.FirstOrDefault(f => f.Id == id);
        }

        public void RemoverFatura(int id)
        {
            var faturas = ObterTodas();
            var fatura = faturas.FirstOrDefault(f => f.Id == id);
            if (fatura != null)
            {
                faturas.Remove(fatura);
                Salvar(faturas);
            }
        }
    }
}
