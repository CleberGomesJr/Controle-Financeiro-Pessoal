using System;
using ControleFinanceiro.Services;

class Program{
    static ReceitaService receitaService = new ReceitaService();
    static FaturaService faturaService = new FaturaService();
    static InvestimentoService investimentoService = new InvestimentoService();

    static void Main(){
        while (true){
            Console.Clear();
            Console.WriteLine("=== Controle Financeiro Pessoal ===");
            Console.WriteLine("1 - Adicionar Receita");
            Console.WriteLine("2 - Listar Receitas");
            Console.WriteLine("3 - Remover Receita");
            Console.WriteLine("4 - Adicionar Fatura");
            Console.WriteLine("5 - Listar Faturas");
            Console.WriteLine("6 - Remover Fatura");
            Console.WriteLine("7 - Adicionar Investimento");
            Console.WriteLine("8 - Listar Investimentos");
            Console.WriteLine("9 - Remover Investimento");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            
            var opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao){
                case "1": AdicionarReceita(); break;
                case "2": ListarReceitas(); break;
                case "3": RemoverReceita(); break;
                case "4": AdicionarFatura(); break;
                case "5": ListarFaturas(); break;
                case "6": RemoverFatura(); break;
                case "7": AdicionarInvestimento(); break;
                case "8": ListarInvestimentos(); break;
                case "9": RemoverInvestimento(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida!"); break;
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void AdicionarReceita(){
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();
        Console.Write("Valor: ");
        decimal valor = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Categoria: ");
        string categoria = Console.ReadLine();
        
        receitaService.AdicionarReceita(descricao, valor, categoria);
        Console.WriteLine("Receita adicionada com sucesso!");
    }

    static void ListarReceitas(){
        var receitas = receitaService.ListarReceitas();
        if (receitas.Count == 0){
            Console.WriteLine("Nenhuma receita cadastrada.");
            return;
        }
        Console.WriteLine("=== Receitas ===");
        foreach (var r in receitas){
            Console.WriteLine($"ID: {r.Id} | Descrição: {r.Descricao} | Valor: {r.Valor:C} | Categoria: {r.Categoria} | Data: {r.Data.ToShortDateString()}");
        }
    }

    static void RemoverReceita(){
        ListarReceitas();
        Console.Write("\nInforme o ID da receita a remover: ");
        int id = Convert.ToInt32(Console.ReadLine());

        receitaService.RemoverReceita(id);
        Console.WriteLine("Receita removida com sucesso!");
    }

    static void AdicionarFatura(){
        Console.Write("Nome do Cartão: ");
        string nomeCartao = Console.ReadLine();
        Console.Write("Valor: ");
        decimal valor = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Parcelas: ");
        int parcelas = Convert.ToInt32(Console.ReadLine());

        faturaService.AdicionarFatura(nomeCartao, valor, parcelas);
        Console.WriteLine("Fatura adicionada com sucesso!");
    }

    static void ListarFaturas(){
        var faturas = faturaService.ListarFaturas();
        if (faturas.Count == 0){
            Console.WriteLine("Nenhuma fatura cadastrada.");
            return;
        }
        Console.WriteLine("=== Faturas ===");
        foreach (var f in faturas){
            Console.WriteLine($"ID: {f.Id} | Cartão: {f.NomeCartao} | Valor: {f.Valor:C} | Parcelas: {f.Parcelas} | Data: {f.Data.ToShortDateString()}");
        }
    }

    static void RemoverFatura(){
        ListarFaturas();
        Console.Write("\nInforme o ID da fatura a remover: ");
        int id = Convert.ToInt32(Console.ReadLine());

        faturaService.RemoverFatura(id);
        Console.WriteLine("Fatura removida com sucesso!");
    }

    static void AdicionarInvestimento(){
        Console.Write("Nome do Ativo: ");
        string nomeAtivo = Console.ReadLine();
        Console.Write("Valor: ");
        decimal valor = Convert.ToDecimal(Console.ReadLine());

        investimentoService.AdicionarInvestimento(nomeAtivo, valor);
        Console.WriteLine("Investimento adicionado com sucesso!");
    }

    static void ListarInvestimentos(){
        var investimentos = investimentoService.ListarInvestimentos();
        if (investimentos.Count == 0){
            Console.WriteLine("Nenhum investimento cadastrado.");
            return;
        }
        Console.WriteLine("=== Investimentos ===");
        foreach (var i in investimentos){
            Console.WriteLine($"ID: {i.Id} | Ativo: {i.NomeAtivo} | Valor: {i.Valor:C} | Data: {i.Data.ToShortDateString()}");
        }
    }

    static void RemoverInvestimento(){
        ListarInvestimentos();
        Console.Write("\nInforme o ID do investimento a remover: ");
        int id = Convert.ToInt32(Console.ReadLine());

        investimentoService.RemoverInvestimento(id);
        Console.WriteLine("Investimento removido com sucesso!");
    }
}
