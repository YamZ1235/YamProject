using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Management : Customer
    {
        private Branchs branchId;

        public Branchs BranchId { get => branchId; set => branchId = value; }
    }
}
