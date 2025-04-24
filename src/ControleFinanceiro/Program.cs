using ControleFinanceiro.Services;
using System;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro
{
    class Program
    {
        static void Main(string[] args)
        {
            var receitaService = new ReceitaService();
            var faturaService = new FaturaService();
            var investimentoService = new InvestimentoService();

            var resumoService = new ResumoFinanceiroService(
                new ReceitaRepository(),
                new FaturaRepository(),
                new InvestimentoRepository()
            );


            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Controle Financeiro Pessoal ===\n");
                Console.WriteLine("1. Adicionar Receita");
                Console.WriteLine("2. Remover Receita");
                Console.WriteLine("3. Adicionar Fatura");
                Console.WriteLine("4. Remover Fatura");
                Console.WriteLine("5. Adicionar Investimento");
                Console.WriteLine("6. Remover Investimento");
                Console.WriteLine("7. Visualizar Resumo Financeiro");
                Console.WriteLine("0. Sair");

                Console.Write("\nEscolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Descrição da Receita: ");
                        var descReceita = Console.ReadLine();
                        Console.Write("Valor: ");
                        decimal.TryParse(Console.ReadLine(), out decimal valorReceita);
                        Console.Write("Categoria: ");
                        var categoria = Console.ReadLine();

                        receitaService.AdicionarReceita(descReceita, valorReceita, categoria);
                        Console.WriteLine("Receita adicionada com sucesso!");
                        break;

                    case "2":
                        var receitas = receitaService.ListarReceitas();
                        Console.WriteLine("\n--- Receitas ---");
                        foreach (var r in receitas)
                            Console.WriteLine($"{r.Id}. {r.Descricao} - R${r.Valor}");

                        Console.Write("ID da receita para remover: ");
                        int.TryParse(Console.ReadLine(), out int idReceita);
                        receitaService.RemoverReceita(idReceita);
                        Console.WriteLine("Receita removida.");
                        break;

                    case "3":
                        Console.Write("Nome da Fatura: ");
                        var nomeFatura = Console.ReadLine();
                        Console.Write("Valor: ");
                        decimal.TryParse(Console.ReadLine(), out decimal valorFatura);
                        Console.Write("Parcelas: ");
                        int.TryParse(Console.ReadLine(), out int parcelas);

                        faturaService.AdicionarFatura(nomeFatura, valorFatura, parcelas);
                        Console.WriteLine("Fatura adicionada com sucesso!");
                        break;

                    case "4":
                        var faturas = faturaService.ListarFaturas();
                        Console.WriteLine("\n--- Faturas ---");
                        foreach (var f in faturas)
                            Console.WriteLine($"{f.Id}. {f.Nome} - R${f.Valor}");

                        Console.Write("ID da fatura para remover: ");
                        int.TryParse(Console.ReadLine(), out int idFatura);
                        faturaService.RemoverFatura(idFatura);
                        Console.WriteLine("Fatura removida.");
                        break;

                    case "5":
                        Console.Write("Nome do Ativo: ");
                        var nomeAtivo = Console.ReadLine();
                        Console.Write("Valor do Investimento: ");
                        decimal.TryParse(Console.ReadLine(), out decimal valorInvest);

                        investimentoService.AdicionarInvestimento(nomeAtivo, valorInvest);
                        Console.WriteLine("Investimento adicionado com sucesso!");
                        break;

                    case "6":
                        var investimentos = investimentoService.ListarInvestimentos();
                        Console.WriteLine("\n--- Investimentos ---");
                        foreach (var i in investimentos)
                            Console.WriteLine($"{i.Id}. {i.NomeAtivo} - R${i.Valor}");

                        Console.Write("ID do investimento para remover: ");
                        int.TryParse(Console.ReadLine(), out int idInvest);
                        investimentoService.RemoverInvestimento(idInvest);
                        Console.WriteLine("Investimento removido.");
                        break;

                    case "7":
                        Console.WriteLine("\n--- Resumo Financeiro ---");
                        var resumo = resumoService.GerarResumo();
                        Console.WriteLine($"Total de Receitas: R${resumo.TotalReceitas}");
                        Console.WriteLine($"Total de Faturas: R${resumo.TotalFaturas}");
                        Console.WriteLine($"Total de Investimentos: R${resumo.TotalInvestimentos}");
                        break;

                    case "0":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
