using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CardForCustomers : BaseEntity
    {
        private Customer accountNumber;
        private string CardNumber;
        private string PeriodDateMonth;
        private string PeriodDateYear;
        private string cvc;
        private string lineCredit;

        public Customer AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string CardNumber1 { get => CardNumber; set => CardNumber = value; }
        public string PeriodDateMonth1 { get => PeriodDateMonth; set => PeriodDateMonth = value; }
        public string PeriodDateYear1 { get => PeriodDateYear; set => PeriodDateYear = value; }
        public string Cvc { get => cvc; set => cvc = value; }
        public string LineCredit { get => lineCredit; set => lineCredit = value; }
    }
}
