using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Data
{
    public static class DataStorage
    {
        private static readonly string BasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly string ReceitaPath = Path.Combine(BasePath, "receitas.json");
        private static readonly string FaturaPath = Path.Combine(BasePath, "faturas.json");
        private static readonly string InvestimentoPath = Path.Combine(BasePath, "investimentos.json");


        // ---------------- Receitas ----------------
        public static List<Receita> CarregarReceitas()
        {
            return CarregarDados<Receita>(ReceitaPath);
        }

        public static void SalvarReceitas(List<Receita> receitas)
        {
            SalvarDados(ReceitaPath, receitas);
        }

        // ---------------- Faturas ----------------
        public static List<Fatura> CarregarFaturas()
        {
            return CarregarDados<Fatura>(FaturaPath);
        }

        public static void SalvarFaturas(List<Fatura> faturas)
        {
            SalvarDados(FaturaPath, faturas);
        }

        // ---------------- Investimentos ----------------
        public static List<Investimento> CarregarInvestimentos()
        {
            return CarregarDados<Investimento>(InvestimentoPath);
        }

        public static void SalvarInvestimentos(List<Investimento> investimentos)
        {
            SalvarDados(InvestimentoPath, investimentos);
        }

        // ---------------- Métodos Genéricos ----------------
        private static List<T> CarregarDados<T>(string caminho)
        {
            try
            {
                if (!File.Exists(caminho) || new FileInfo(caminho).Length == 0)
                {
                    File.WriteAllText(caminho, "[]"); // Evita erro de JSON vazio
                    return new List<T>();
                }

                string json = File.ReadAllText(caminho);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");
                return new List<T>();
            }
        }

        private static void SalvarDados<T>(string caminho, List<T> dados)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminho)!); // Cria a pasta se não existir
                string json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminho, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar dados: {ex.Message}");
            }
        }

    }
}
