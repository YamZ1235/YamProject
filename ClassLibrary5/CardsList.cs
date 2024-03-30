using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CardsList : List<CardForCustomers>
    {
        public CardsList() { }

        public CardsList(IEnumerable<City> list) : base((IEnumerable<CardForCustomers>)list) { }

        public CardsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<CardForCustomers>().ToList()) { }
    }
}
