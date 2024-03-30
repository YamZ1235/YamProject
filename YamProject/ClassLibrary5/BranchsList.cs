﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class BranchsList : List<Branchs>
    {
        public BranchsList() { }

        public BranchsList(IEnumerable<City> list) : base((IEnumerable<Branchs>)list) { }

        public BranchsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Branchs>().ToList()) { }

    }
}
