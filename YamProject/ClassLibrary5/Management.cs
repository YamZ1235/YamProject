﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class Management : BaseEntity
    {
        private Branchs branchId;

        public Branchs BranchId { get => branchId; set => branchId = value; }
    }
}
