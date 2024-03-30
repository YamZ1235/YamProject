using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.OleDb;

namespace ViewModel
{
    public class OperationsDB : BaseEntityDB
    {
        static private OperationsList list = new OperationsList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Operations operation = entity as Operations;
            int creditid = int.Parse(reader["CreditNumber"].ToString());
            operation.CreditNumber = CardsDB.SelectById(creditid);
            operation.MoneyAmount = int.Parse(reader["MoneyAmount"].ToString());
            operation.OperationDate1 = DateTime.Parse(reader["OperationDate"].ToString());
            int dealName = int.Parse(reader["DealName"].ToString());
            operation.BusinessName = BusinessDB.SelectById(dealName);
            base.CreateModel(entity);
            return operation;
        }
        protected override BaseEntity NewEntity()
        {
            return new Operations();
        }

        public OperationsList SelectAll()
        {
            this.command.CommandText = $"SELECT * FROM Operations";
            OperationsList operationList = new OperationsList(base.Select());
            return operationList;
        }
        public static Operations SelectById(int id)
        {
            if (list.Count == 0)
            {
                OperationsDB db = new OperationsDB();
                list = db.SelectAll();
            }
            Operations o = list.Find(item => item.Id == id);
            return o;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Operations o = entity as Operations;
            if (o != null)
            {
                string sqlStr = $"INSERT INTO Operations (CreditNumber,MoneyAmount,OperationDate,DealName)" +
                    "VALUES (@CCreditNumber,@MoneyAmount,@OperationDate,@DealName)";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("CreditNumber", o.CreditNumber));
                cmd.Parameters.Add(new OleDbParameter("MoneyAmount", o.MoneyAmount));
                cmd.Parameters.Add(new OleDbParameter("OperationDate", o.OperationDate1));
                cmd.Parameters.Add(new OleDbParameter("DealName", o.BusinessName));
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Operations o = entity as Operations;
            if (o != null)
            {
                string str = $"UPDATE Operations SET CreditNumber=@CreditNumber,MoneyAmount=@MoneyAmount,OperationDate=@OperationDate,DealName=@DealName " +
                    $"WHERE Id = @Id";
                cmd.CommandText = str;
                cmd.Parameters.Add(new OleDbParameter("CreditNumber", o.CreditNumber));
                cmd.Parameters.Add(new OleDbParameter("MoneyAmount", o.MoneyAmount));
                cmd.Parameters.Add(new OleDbParameter("OperationDate", o.OperationDate1));
                cmd.Parameters.Add(new OleDbParameter("DealName", o.BusinessName));
            }
        
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Operations o = entity as Operations;
            if (o != null)
            {
              string sqlStr = $"DELETE From Operations WHERE Id = @Id";
              cmd.CommandText = sqlStr;
              cmd.Parameters.Add(new OleDbParameter("@Id", o.Id));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            Operations o = entity as Operations;
            if (o != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, o));
            }
        }

        public override void Update(BaseEntity entity)
        {
            Operations o = entity as Operations;
            if (o != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, o));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            Operations o = entity as Operations;
            if (o != null)
                deleted.Add(new ChangeEntity(this.CreateUpdateSQL, o));
        }
    }
}

