using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MyCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string NumberA { get; set; } = null;
        private string OperationCal { get; set; } = null;
        private bool TemporyResult { get; set; } = false;
        private readonly Operation Operation = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Convert content object button sender to string
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>String Button content</returns>
        private static string ElementPress(Button sender)
        {
            return sender.Content.ToString();
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            string number = ElementPress((Button)sender);

            if (TemporyResult)
            {
                Screen.Text = "0";
                TemporyResult = false;
            }

            if (Screen.Text != "0" || number == ".")
            {
                Screen.Text += number;
            }
            else
            {
                Screen.Text = number;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text.Length <= 1 ? "0" : Screen.Text.Remove(Screen.Text.Length - 1);
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "0";
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            BtnOP.Content = "NaN";
            NumberA = null;
            OperationCal = null;
            TemporyResult = false;
            Screen.Text = "0";
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            string operation = ElementPress((Button)sender);

            if (!TemporyResult)
            {
                if (NumberA != null && OperationCal != null)
                {
                    Screen.Text = Operation.ToDoOperation(NumberA, Screen.Text, OperationCal);
                }

                NumberA = Screen.Text;
                TemporyResult = true;
            }

            BtnOP.Content = operation;
            OperationCal = operation;
        }

        private void BtnToDo_Click(object sender, RoutedEventArgs e)
        {
            string value = ElementPress((Button)sender);
            _ = MessageBox.Show("ToDo: Méthode Pour Bouton " + value + " à Créer", "ToDo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnPlusMoins_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "0")
            {
                Screen.Text = Screen.Text.Contains("-") ? Screen.Text.Trim('-') : Screen.Text.Insert(0, "-");
            }
        }

        private void BtnEgale_Click(object sender, RoutedEventArgs e)
        {
            if (NumberA != null)
            {
                Screen.Text = NumberA = Operation.ToDoOperation(NumberA, Screen.Text, OperationCal);
                TemporyResult = false;
                OperationCal = null;
            }
        }
    }
}
