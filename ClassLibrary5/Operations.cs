﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
        public override string ToString()
        {
            return "Credit Number: " + CreditNumber.Id +
                "Money Amount: " + MoneyAmount +
                "Operation Date: " + OperationDate1 +
                "Deal Name: " + BusinessName;
        }
    }
}
