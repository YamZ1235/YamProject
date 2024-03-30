using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class Operations : BaseEntity
    {
        private CardForCustomers creditNumber;
        private int moneyAmount;
        private DateTime OperationDate;
        private Business businessName;

        public CardForCustomers CreditNumber { get => creditNumber; set => creditNumber = value; }
        public int MoneyAmount { get => moneyAmount; set => moneyAmount = value; }
        public DateTime OperationDate1 { get => OperationDate; set => OperationDate = value; }
        public Business BusinessName { get => businessName; set => businessName = value; }
    }
}
