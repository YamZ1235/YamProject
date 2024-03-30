using System;
using ViewModel;
using Model;
using System.Linq;
namespace Test
{
    public class Program
    { 
        static void Main(string[] args)
        {
            OperationsDB db = new OperationsDB();
            OperationsList list = db.SelectAll();
            foreach (var item in list)
            {
                Console.WriteLine(item.Id + "," + item.CreditNumber.CardNumber1 + ","+ item.OperationDate1 + " "
                    +item.MoneyAmount + "," + item.BusinessName.BusinessName);
            }

            //Customer yam = new Customer();
            //yam.Street = "Ha zoufim";
            //yam.StreetNumber = 69420;
            //yam.AccountNumber = 99899999;
            //yam.PhoneNumber = "0548078020";
            //yam.FirstName = "yam";
            //yam.LastName = "Zada";
            //yam.City = CityDB.SelectById(3);
            //yam.Branch = BranchDB.SelectById(2);
            //yam.Mail = "yam789423@gmail.com";
            //db.Insert(yam); 
            //int num = db.SaveChanges();
            //Console.WriteLine(num);

        }
    }
}
