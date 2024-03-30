using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ManagementDB : CustomerDB
    {
        static private ManagementList list = new ManagementList();
        public ManagementDB() : base() { }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Management manager = entity as Management;
            int branch = (int)reader["BranchId"];
            manager.BranchId = BranchDB.SelectById(branch);
            base.CreateModel(entity);
            return manager;
        }
        protected override BaseEntity NewEntity()
        {
            return new Management();
        }

        public ManagementList SelectAll()
        {
            command.CommandText = $"SELECT Management.Id, Management.Id as Id,Management.BranchId,Customer.Id,Customer.AccountNumber, " +
                $"Customer.Branch, Customer.PrivateName,Customer.LastName,Customer.PhoneNumber,Customer.Mail,Customer.City,Customer.Street,Customer.StreetNumber " +
                $"FROM (Management INNER JOIN Customer ON Management.Id = Customer.Id)";
            ManagementList managementList = new ManagementList(base.Select());
            return managementList;
        }
        public static Management SelectById(int id)
        {
            if (list.Count == 0)
            {
                ManagementDB db = new ManagementDB();
                list = db.SelectAll();
            }
            Management management = list.Find(item => item.Id == id);
            return management;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Management manager = entity as Management;
            if (manager != null)
            {
                string sqlStr = "INSERT INTO Management (BranchId) " +
                    "Values(@BranchId)";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@BranchId", manager.BranchId));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Management manager = entity as Management;
            if (manager != null)
            {
                string sqlStr = $"UPDATE Management SET BranchId=@BranchId," +
                $"WHERE Id =@Id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@BranchId", manager.BranchId));
                cmd.Parameters.Add(new OleDbParameter("@Id", manager.Id));

            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Management manager = entity as Management;
            if (manager != null)
            {
                string sql_builder = "DELETE FROM Management WHERE Id = @Id";

                cmd.CommandText = sql_builder;

                cmd.Parameters.Add(new OleDbParameter("@Id", manager.Id));
            }
        }

        public override void Insert(BaseEntity entity)
        {
            Management manager = entity as Management;
            if (manager != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, manager));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, manager));
            }
        }

        public override void Update(BaseEntity entity)
        {
            Management manager = entity as Management;
            if (manager != null)
            {
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, manager));
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, manager));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            Management manager = entity as Management;
            if (manager != null)
            {
                deleted.Add(new ChangeEntity(base.CreateDeleteSQL, manager));
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, manager));
            }
        }

    }
}

