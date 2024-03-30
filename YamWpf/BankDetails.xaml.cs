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
using Model;
using ViewModel;
namespace YamWpf
{
    /// <summary>
    /// Interaction logic for BankDetails.xaml
    /// </summary>
    public partial class BankDetails : Page
    {
        Customer c;

        public Customer GetCustomer { get; set; }

        public BankDetails(Model.Customer customers)
        {
            InitializeComponent();
            c = customers;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new ScreenAccount(c));
        }

        private void ButtonMoney(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Bank Balance is now: " + c.MoneyAmount + "₪");
        }

        private void BackLink(object sender, RoutedEventArgs e)
        {
            MainWindow.MFrame.Navigate(new Login());
        }

        private void ButtonCharges(object sender, RoutedEventArgs e)
        {
            MainWindow.MFrame.Navigate(new CreditCharges());
        }
    }
}
