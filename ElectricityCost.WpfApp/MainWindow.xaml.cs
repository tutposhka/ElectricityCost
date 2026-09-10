using ElectricityCost.Core;

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

namespace ElectricityCost.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "";
            ErrorTextBlock.Text = "";

            if (!decimal.TryParse(PowerTextBox.Text, out decimal powerWatts))
            {
                ErrorTextBlock.Text = "Võimsuse formaat on vale.";
                return;
            }

            if (!decimal.TryParse(HoursTextBox.Text, out decimal hoursPerDay))
            {
                ErrorTextBlock.Text = "Töötundide formaat on vale.";
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal pricePerKwh))
            {
                ErrorTextBlock.Text = "Elektri hinna formaat on vale.";
                return;
            }

            if (ElectricityCalculator.TryCalculate(
                powerWatts,
                hoursPerDay,
                pricePerKwh,
                out decimal energyKwh,
                out decimal cost,
                out string error))
            {
                ResultTextBlock.Text =
                    $"30 päeva energiakulu: {energyKwh:F2} kWh\n" +
                    $"30 päeva maksumus: {cost:F2} €";
            }
            else
            {
                ErrorTextBlock.Text = error;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PowerTextBox.Clear();
            HoursTextBox.Clear();
            PriceTextBox.Clear();
            ResultTextBlock.Text = "";
            ErrorTextBlock.Text = "";
            PowerTextBox.Focus();
        }
    }
}