using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer : BaseEntity
    {
        private int accountNumber;
        private Branchs branch;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string mail;
        private City city;
        private string street;
        private int streetNumber;
        private int moneyAmount;

        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public Branchs Branch { get => branch; set => branch = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Mail { get => mail; set => mail = value; }
        public City City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int StreetNumber { get => streetNumber; set => streetNumber = value; }
        public int MoneyAmount { get => moneyAmount; set => moneyAmount = value; }

        public override string ToString()
        {
            return "Account number: " + accountNumber +
                "Branch: " + branch +
                "PrivateName: " + firstName +
                "LastName: " + lastName +
                "PhoneNumber: " + phoneNumber +
                "Mail: " + Mail+
                "City: " + City+
                "Street: " +Street+
                "StreetNumber: "+ StreetNumber +
               "MoneyAmount: " + MoneyAmount;
        }
    }
}
