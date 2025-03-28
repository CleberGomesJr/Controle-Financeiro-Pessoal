using ControleFinanceiro.Services;
using ControleFinanceiro.Models;
using System;

namespace ControleFinanceiro.Controllers
{
    public class ReceitaController
    {
        private readonly ReceitaService _receitaService;

        public ReceitaController()
        {
            _receitaService = new ReceitaService();
        }

        public void AdicionarReceita()
        {
            Console.Write("Descrição da Receita: ");
            string descricao = Console.ReadLine();

            Console.Write("Valor: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            try
            {
                _receitaService.AdicionarReceita(descricao, valor, categoria);
                Console.WriteLine("Receita adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void ListarReceitas()
        {
            var receitas = _receitaService.ListarReceitas();

            if (receitas.Count == 0)
            {
                Console.WriteLine("Nenhuma receita cadastrada.");
                return;
            }

            foreach (var receita in receitas)
            {
                Console.WriteLine($"ID: {receita.Id} | Descrição: {receita.Descricao} | Valor: {receita.Valor}");
            }
        }
    }
}
