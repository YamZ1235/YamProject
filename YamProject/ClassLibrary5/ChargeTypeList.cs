using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class ChargeTypeList : List<ChargeType>
    {
        public ChargeTypeList() { }

        public ChargeTypeList(IEnumerable<City> list) : base((IEnumerable<ChargeType>)list) { }

        public ChargeTypeList(IEnumerable<BaseEntity> list)
            : base(list.Cast<ChargeType>().ToList()) { }
    }
}
