using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weddeberekening
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

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void hourlyWageTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            float defaultHourlyWage = 17.85F;
            int defaultNumberOfHours = 1686;
            hourlyWageTextBox.Text = $"{defaultHourlyWage}";
            numberOfHoursTextBox.Text = $"{defaultNumberOfHours}";
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeName = employeeTextBox.Text;
            bool isValidHourlyWage = float.TryParse(hourlyWageTextBox.Text, out float hourlyWage);
            bool isValidNumberOfHours = int.TryParse(numberOfHoursTextBox.Text, out int numberOfHours);

            if (isValidHourlyWage && isValidNumberOfHours)
            {
                float brutojaarwedde = numberOfHours * hourlyWage;
                float belasting = brutojaarwedde * 0.30F;
                float nettojaarwedde = brutojaarwedde - belasting;
                resultTextBox.Text = $"LOONFICHE VAN {employeeName}\n" +
                $"\n" +
                $"Aantal gewerkte uren: {numberOfHours}\n" +
                $"Uurloon: € {hourlyWage:N2}\n" +
                $"Brutojaarwedde: € {brutojaarwedde:N2}\n" +
                $"Belasting: € {belasting:N2}\n" +
                $"Nettojaarwedde: € {nettojaarwedde:N2}";
            } else
            {
                resultTextBox.Text = "Invalid input.";
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            employeeTextBox.Clear();
            resultTextBox.Clear();
            float defaultHourlyWage = 17.85F;
            int defaultNumberOfHours = 1686;
            hourlyWageTextBox.Text = $"{defaultHourlyWage}";
            numberOfHoursTextBox.Text = $"{defaultNumberOfHours}";
        }
    }
}
