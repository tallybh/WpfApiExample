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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApiExample
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fact = ApiService.GetCatFact();
            if(fact != null )
            {
                FactBox.Text = fact.Fact;
            }

            else
            {
                FactBox.Text = "Error Getting fact!";
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = ApiService.TestCreditCard(cvvTB.Text, CardNumberTB.Text, datePicker.SelectedDate.Value);
            CreditResultLbl.Visibility = Visibility.Visible;
            if(result == true)
            {
                CreditResultLbl.Content = "Payment succeessful";
            }
            else
            {
                CreditResultLbl.Content = "Payment failed";
            }
             
        }
    }
}
