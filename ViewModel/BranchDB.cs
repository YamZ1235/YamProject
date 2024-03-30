using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BranchDB : BaseEntityDB
    {
        //private string connectionString = @"";
        //private OleDbConnection connection;
        //private OleDbCommand command;
        //private OleDbDataReader reader;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Branchs branch = entity as Branchs;
            branch.BranchNumber = int.Parse(reader["BranchNumber"].ToString());
            int cityId = int.Parse(reader["BranchCity"].ToString());
            branch.BranchCity = CityDB.SelectById(cityId);
            base.CreateModel(entity);
            return branch;
        }

        private static BranchsList list = new BranchsList();

     

        protected override BaseEntity NewEntity()
        {
            return new Branchs();
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

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Branchs branch = entity as Branchs;
            if (branch != null)
            {
                string sqlStr = $"INSERT INTO Branchs (BranchNumber,BranchCity) " +
                    "Values(@BranchNumber, @BranchCity)";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@BranchNumber", branch.BranchNumber));
                cmd.Parameters.Add(new OleDbParameter("@BranchCity", branch.BranchCity.Id));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Branchs branch = entity as Branchs;
            if (branch != null)
            {
                string sqlStr = $"UPDATE Branchs SET BranchNumber=@BranchNumber,BranchCity=@BranchCity " +
                $"WHERE Id =@Id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@BranchNumber", branch.BranchNumber));
                cmd.Parameters.Add(new OleDbParameter("@BranchCity", branch.BranchCity.Id));
                cmd.Parameters.Add(new OleDbParameter("@Id", branch.Id));

            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Branchs branch = entity as Branchs;
            if (branch != null)
            {
                string sql_builder = $"DELETE FROM Branchs WHERE ID = @Id";
                cmd.CommandText = sql_builder;
                cmd.Parameters.Add(new OleDbParameter("@Id", branch.Id));
            }
        }

        public override void Insert(BaseEntity entity)
        {
            Branchs branch = entity as Branchs;
            if (branch != null)
            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, branch));
            }
        }

        public override void Update(BaseEntity entity)
        {
            Branchs branch = entity as Branchs;
            if (branch != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, branch));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            Branchs branch = entity as Branchs;
            if (branch != null)
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, branch));
        }
    }
}