using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CreditChargesList : List<CreditCharges>
    {
        public CreditChargesList() { }

        public CreditChargesList(IEnumerable<CreditCharges> list) : base((IEnumerable<CreditCharges>)list) { }

        public CreditChargesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<CreditCharges>().ToList()) { }
    }
}
