using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControleFinanceiroWPF
{
    public partial class MainWindow : Window
    {
        public decimal TotalReceitas { get; set; } = 5000m;
        public decimal TotalDespesas { get; set; } = 2000m;
        public decimal TotalInvestimentos { get; set; } = 7500m;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Liga os dados à interface
        }
    }
}