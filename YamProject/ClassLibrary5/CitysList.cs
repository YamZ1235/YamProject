using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class CitysList : List<City>
    {
        public CitysList() { }

        public CitysList(IEnumerable<City> list) : base(list) { }

        public CitysList(IEnumerable<BaseEntity> list)
            : base(list.Cast<City>().ToList()) { }
    }
}
