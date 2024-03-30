using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Branchs : BaseEntity
    {
        private int branchNumber;
        private City branchCity;
        
        public City BranchCity { get => branchCity; set => branchCity = value; }
        public int BranchNumber { get => branchNumber; set => branchNumber = value; }
    }
}
