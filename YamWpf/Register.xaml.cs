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
using MyApiService;
using Model;
using System.Text.RegularExpressions;

namespace YamWpf
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public IShow yam1 { get; set; }

        public Register()
        {
            InitializeComponent();

            yam1 = Active.Instance;

            this.DataContext = yam1;
        }
        private readonly Regex regex1 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private readonly Regex regex2 = new Regex(@"^(\d{9})$");
        private readonly Regex regex3 = new Regex(@"05\d-\d{7}");

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            if (!regex1.IsMatch(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Mail must be in this format xxxx@gmail.com!");
                return;
            }
            if (!regex3.IsMatch(txtPhoneNumber.Text.ToString()))
            {
                MessageBox.Show("PhoneNumber must be in this format 05x-xxxxxxx!");
                return;
            }
            if(!regex2.IsMatch(txtAccountNumber.Text.ToString()))
            {
                MessageBox.Show("AccountNumber must contain 9 numbers!");
                return;
            }
            MyService s = new MyService();
            Customer c = new Customer();
            BranchsList b = await s.GetBranchListAsync();
            CitysList cl = await s.GetCitysListAsync();
            c.AccountNumber = int.Parse(txtAccountNumber.Text.ToString());
            c.Branch = b.Find(branch => branch.BranchNumber == yam1.SelectedBranch);
            c.FirstName = txtFirstName.Text.ToString();
            c.LastName = txtLastName.Text.ToString();
            c.PhoneNumber = txtPhoneNumber.Text.ToString();
            c.Mail = txtEmail.Text.ToString();
            c.City = cl.Find(city => city.CityName == yam1.SelectedCity);
            c.Street = txtStreet.Text.ToString();
            c.StreetNumber = int.Parse(txtStreetNumber.Text);
            int yamZada = await s.InsertCustomer(c);
            await Console.Out.WriteLineAsync(yamZada.ToString());

        }

        private void BranchBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
