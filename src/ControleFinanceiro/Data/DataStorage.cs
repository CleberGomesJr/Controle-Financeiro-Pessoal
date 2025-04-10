using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Data
{
    public static class DataStorage
    {
        private static string receitasPath = "Data/receitas.json";
        private static string faturasPath = "Data/faturas.json";
        private static string investimentosPath = "Data/investimentos.json";

        public static void SalvarDados<T>(List<T> dados, string caminho)
        {
            try
            {
                string json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminho, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar dados: {ex.Message}");
            }
        }

        public static List<T> CarregarDados<T>(string caminho)
        {
            try
            {
                if (File.Exists(caminho))
                {
                    string json = File.ReadAllText(caminho);
                    return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");
            }
            return new List<T>();
        }

        public static void SalvarReceitas(List<Receita> receitas) => SalvarDados(receitas, receitasPath);
        public static List<Receita> CarregarReceitas() => CarregarDados<Receita>(receitasPath);

        public static void SalvarFaturas(List<Fatura> faturas) => SalvarDados(faturas, faturasPath);
        public static List<Fatura> CarregarFaturas() => CarregarDados<Fatura>(faturasPath);

        public static void SalvarInvestimentos(List<Investimento> investimentos) => SalvarDados(investimentos, investimentosPath);
        public static List<Investimento> CarregarInvestimentos() => CarregarDados<Investimento>(investimentosPath);
    }
}
