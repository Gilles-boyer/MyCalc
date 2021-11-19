using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
using System.Windows.Input;
using System;
using RestSharp;

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
        private bool End { get; set; } = false;
        private readonly Operation Operation = new();

        public MainWindow()
        {
            InitializeComponent();
            TryLicenceCheck();
        }

        private void TryLicenceCheck()
        {
            try
            {
                string value = Environment.GetEnvironmentVariable("keyMyCalc", EnvironmentVariableTarget.User);
                value += " ";
                value = value.Trim(' ');

                if (value.Length > 3)
                {
                    LabelLicence.Content = "Votre Licence activée";
                    ScreenOp.Visibility = Visibility.Visible;
                    Screen.Visibility = Visibility.Visible;
                    ValidLicence.Visibility = Visibility.Hidden;
                    LicenceText.IsReadOnly = true;
                    LicenceText.Text = value;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }


        private static string GetApiResponse(string key)
        {
            RestClient client = new("https://apimycalc974.000webhostapp.com/")
            {
                Timeout = -1
            };
            RestRequest request = new(Method.POST)
            {
                AlwaysMultipartFormData = true
            };
            _ = request.AddParameter("key", key);

            IRestResponse response = client.Execute(request);

            return response.Content;
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
            ScreenOp.Text = "";
            BtnOP.Content = "NaN";
            NumberA = null;
            OperationCal = null;
            TemporyResult = false;
            Screen.Text = "0";
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            string operation = ElementPress((Button)sender);

            if (End)
            {
                ScreenOp.Text = Screen.Text + " " + operation;
                End = false;
            }
            else
            {
                if (NumberA != null && OperationCal != null)
                {
                    ScreenOp.Text += " " + Screen.Text;
                    End = true;
                }
                else
                {
                    ScreenOp.Text = Screen.Text + " " + operation;
                }
            }


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
                ScreenOp.Text += " " + Screen.Text;
                End = true;
                Screen.Text = NumberA = Operation.ToDoOperation(NumberA, Screen.Text, OperationCal);
                TemporyResult = false;
                OperationCal = null;
                BtnOP.Content = "=";
            }
        }
        private void WindowLicence_KeyDown(object sender, KeyEventArgs e)
        {
            LicenceText.Text = e.Key.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            e.Handled = true;
            switch (e.Key)
            {
                case Key.System:
                    LicenceBlock.Height = 150;
                    LicenceBlock.Visibility = Visibility.Visible;
                    calcWindows.KeyDown -= Window_KeyDown;
                    break;
                case Key.NumPad0:
                    BtnZero.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad1:
                    BtnUn.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad2:
                    BtnDeux.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad3:
                    BtnTrois.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad4:
                    BtnQuatre.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad5:
                    BtnCinq.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad6:
                    BtnSix.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad7:
                    BtnSept.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad8:
                    BtnHuit.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.NumPad9:
                    BtnNeuf.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Add:
                    BtnPlus.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Subtract:
                    BtnMoins.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Multiply:
                    BtnMul.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Divide:
                    BtnDiv.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Delete:
                    BtnC.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Back:
                    BtnBack.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Return:
                    BtnEgale.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
                case Key.Decimal:
                    BtnPoint.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    break;
            }
        }

        private void CloseLicence_Click(object sender, RoutedEventArgs e)
        {
            LicenceBlock.Height = 0;
            LicenceBlock.Visibility = Visibility.Hidden;
            calcWindows.KeyDown += Window_KeyDown;
        }

        private void ValidLicence_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LicenceText.Text))
            {
                LabelLicence.Content = "Error ! aucune licence n'a été saisie";
                return;
            }

            JObject response = JObject.Parse(GetApiResponse(LicenceText.Text));
            string status = response.GetValue("status").ToString();

            if (status == "success")
            {
                Environment.SetEnvironmentVariable("keyMyCalc", LicenceText.Text, EnvironmentVariableTarget.User);
                TryLicenceCheck();
                CloseLicence_Click(sender, e);
                return;
            }

            LabelLicence.Content = "Error ! Merci de vérifier votre licence";
        }
    }
}
