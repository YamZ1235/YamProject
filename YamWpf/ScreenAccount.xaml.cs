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
using MyApiService;
using ViewModel;
namespace YamWpf
{
    /// <summary>
    /// Interaction logic for ScreenAccount.xaml
    /// </summary>
    public partial class ScreenAccount : Page
    {
        Customer c;
        Customer customer = new Customer();
        public IShow activetor1 { get; set; }

        public Customer GetCustomer {  get; set; }

        public ScreenAccount(Model.Customer customers)
        {
            InitializeComponent();
            activetor1 = Active.Instance;
            this.DataContext = activetor1;
            List<Customer> list = new List<Customer>();
            list.Add(customers);
            GetCustomer = customers;
            table.ItemsSource = list;
            //table.ItemsSource = (System.Collections.IEnumerable)customers;
            c = customers;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //List<Customer> customer = new List<Customer>();
            //customer.Add(c);
            //table.ItemsSource = c;
            table.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            table.Visibility = Visibility.Visible;
        }

        private void BacktoCustomer(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new BankDetails(c));
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Stack.Visibility = Visibility.Visible;
            Updater.Visibility = Visibility.Visible;
            this.accountNumber.Text = c.AccountNumber.ToString();
            this.mail.Text = c.Mail.ToString();
            this.firstName.Text = c.FirstName.ToString();
            this.branch.Text = c.Branch.BranchCity.CityName.ToString();
            this.lastName.Text = c.LastName.ToString();
            this.phoneNumber.Text = c.PhoneNumber.ToString();
            this.cityName.Text = c.City.CityName.ToString();
            this.street.Text = c.Street.ToString();
            this.streetNumber.Text = c.StreetNumber.ToString();

        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateDeatils(object sender, RoutedEventArgs e)
        {
            customer.AccountNumber = int.Parse(accountNumber.Text.ToString());
            MessageBox.Show(branch.Text);
            customer.Branch.BranchCity.CityName = branch.Text.ToString();
            customer.FirstName = firstName.Text.ToString();
            customer.LastName = lastName.Text.ToString();
            customer.PhoneNumber = phoneNumber.Text.ToString();
            customer.Mail = mail.Text.ToString();
            customer.City.CityName = cityName.Text.ToString();
            customer.Street = street.Text.ToString();
            customer.StreetNumber = int.Parse(streetNumber.Text.ToString());
            MyService s = new MyService();
            s.UpdateCustomer(customer);
            Stack.Visibility = Visibility.Collapsed;
            Updater.Visibility = Visibility.Collapsed;
        }
    }
}
