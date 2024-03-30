using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class CardForCustomers : BaseEntity
    {
        private Customer accountNumber;
        private string CardNumber;
        private int PeriodDateMonth;
        private int PeriodDateYear;
        private int cvc;
        private int lineCredit;

        public Customer AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string CardNumber1 { get => CardNumber; set => CardNumber = value; }
        public int PeriodDateMonth1 { get => PeriodDateMonth; set => PeriodDateMonth = value; }
        public int PeriodDateYear1 { get => PeriodDateYear; set => PeriodDateYear = value; }
        public int Cvc { get => cvc; set => cvc = value; }
        public int LineCredit { get => lineCredit; set => lineCredit = value; }
    }
}
