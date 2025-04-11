using System.Windows;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using ControleFinanceiro.Services;

namespace ControleFinanceiro
{
    public partial class MainWindow : Window
    {
        public ResumoFinanceiro Resumo { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var receitaRepo = new ReceitaRepository("Data/receitas.json");
            var faturaRepo = new FaturaRepository("Data/faturas.json");
            var investimentoRepo = new InvestimentoRepository("Data/investimentos.json");

            // Gera o resumo real com base nos dados dos arquivos
            var resumoService = new ResumoFinanceiroService(receitaRepo, faturaRepo, investimentoRepo);
            Resumo = resumoService.GerarResumo();

            DataContext = Resumo;
        }
    }
}
