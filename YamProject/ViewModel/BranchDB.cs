using ClassLibrary5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BranchDB : BaseEntityDB
    {
        static private BranchsList list = new BranchsList();
        public override BaseEntity NewEntity()
        {
            return new Branchs();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Branchs b = entity as Branchs;
            b.BranchName = reader["BranchNumber"].ToString();
            int x = int.Parse(reader["BranchCity"].ToString());
            b.BranchCity = CityDB.SelectById(x);
            base.CreateModel(entity);
            return b;
        }
        public BranchsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Branchs";
            BranchsList bList = new BranchsList(base.Select());
            return bList;

        }


        public static Branchs SelectById(int id)
        {
            if (list.Count == 0)
            {
                BranchDB db = new BranchDB();
                list = db.SelectAll();
            }
            Branchs branch = list.Find(item => item.Id == id);
            return branch;
        }
    }
}
