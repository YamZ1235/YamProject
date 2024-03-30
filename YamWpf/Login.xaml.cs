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
namespace YamWpf
{


    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Customer Customers { get; set; }
        public static Management management { get; set; }
        public IShow yam1 { get; set; }
        public Login()
        {
            InitializeComponent();

            yam1 = Active.Instance;

            this.DataContext = yam1;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            MyService s = new MyService();
            List<Customer> cList = await s.GetCustomerListAsync() as List<Customer>;
            List<Management> mList = await s.GetManagementListAsync() as List<Management>;
            BranchsList b = await s.GetBranchListAsync();
            var accountNumber = txtAccountNumber.Text;
            var phoneNumber = txtPhoneNumber.Text;

            Customer c = cList.Find(item => item.Branch.BranchNumber == yam1.SelectedBranch && item.AccountNumber.ToString() == accountNumber && item.PhoneNumber == phoneNumber);
            Management m = mList.Find(item => item.Id.ToString() == c.Id.ToString());
            if (m != null)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                management = m;
                nav.Navigate(new Managers(management));
            }
            else
            {
                if (c == null)
                {
                    MessageBox.Show("not found");
                }
                else
                {
                    MessageBox.Show("found");
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    Customers = c;
                    nav.Navigate(new BankDetails(Customers));

                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MFrame.Navigate(new Register());
        }
    }
}