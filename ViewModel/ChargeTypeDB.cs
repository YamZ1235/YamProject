using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ViewModel
{
    public class ChargeTypeDB : BaseEntityDB
    {
        static private ChargeTypeList list = new ChargeTypeList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ChargeType ct = entity as ChargeType;
            ct.Charge_Type = reader["ChargeType"].ToString();
            base.CreateModel(entity);
            return ct;
        }
        protected override BaseEntity NewEntity()
        {
            return new ChargeType();
        }
        public ChargeTypeList SelectAll()
        {
            command.CommandText = $"SELECT * FROM ChargeType";
            ChargeTypeList ctList = new ChargeTypeList(base.Select());
            return ctList;
        }
        public static ChargeType SelectById(int id)
        {
            if (list.Count == 0)
            {
                ChargeTypeDB db = new ChargeTypeDB();
                list = db.SelectAll();
            }
            ChargeType ct = list.Find(item => item.Id == id);
            return ct;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ChargeType ct = entity as ChargeType;
            if (ct != null)
            {
                string sqlStr = "INSERT INTO ChargeType (ChargeType) " +
                        "Values(@ChargeType)";
                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@ChargeType", ct.Charge_Type));
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ChargeType ct = entity as ChargeType;
            if (ct != null)
            {
                string sqlStr = $"UPDATE ChargeType SET ChargeType=@ChargeType " +
                     $"WHERE Id =@Id";
                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@ChargeType", ct.Charge_Type));
                cmd.Parameters.Add(new OleDbParameter("@Id", ct.Id));
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ChargeType ct = entity as ChargeType;
            if (ct != null)
            {
                string sqlStr = $"DELETE FROM ChargeType WHERE Id = @Id";
                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", ct.Id));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            ChargeType ct = entity as ChargeType;
            if (ct != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, ct));
            }
        }

        public override void Update(BaseEntity entity)
        {
            ChargeType ct = entity as ChargeType;
            if (ct != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, ct));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            ChargeType ct = entity as ChargeType;
            if (ct != null)
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, ct));
        }
    }
}
