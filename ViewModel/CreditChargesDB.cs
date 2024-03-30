using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CreditChargesDB : BaseEntityDB
    {
        static private CreditChargesList list = new CreditChargesList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            CreditCharges cc = entity as CreditCharges;
            int creditid = int.Parse(reader["CardId"].ToString());
            cc.CardId = CardsDB.SelectById(creditid);
            cc.ChargeDate1 = DateTime.Parse(reader["ChargeDate"].ToString());
            int business = int.Parse(reader["Business"].ToString());
            cc.BusinessName = BusinessDB.SelectById(creditid);
            cc.ChargeAmount1 = int.Parse(reader["ChargeAmount"].ToString());
            int ct = int.Parse(reader["ChargeType"].ToString());
            cc.ChargeType = ChargeTypeDB.SelectById(ct);
            base.CreateModel(entity);
            return cc;
        }
        protected override BaseEntity NewEntity()
        {
            return new CreditCharges();
        }
        public CreditChargesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM CreditCharges";
            CreditChargesList ctList = new CreditChargesList(base.Select());
            return ctList;
        }
        public static CreditCharges SelectById(int id)
        {
            if (list.Count == 0)
            {
                CreditChargesDB db = new CreditChargesDB();
                list = db.SelectAll();
            }
            CreditCharges cc = list.Find(item => item.Id == id);
            return cc;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CreditCharges cc = entity as CreditCharges;
            if (cc != null)
            {
                string sqlStr = $"INSERT INTO CreditCharges (CardId,ChargeDate,Business,ChargeAmount,ChargeType) " +
                    "Values(@CardId, @ChargeDate,@Business,@ChargeAmount,@ChargeType)";
                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@CardId", cc.CardId.Id));
                cmd.Parameters.Add(new OleDbParameter("@ChargeDate", cc.ChargeDate1));
                cmd.Parameters.Add(new OleDbParameter("@ChargeAmount", cc.BusinessName.Id));
                cmd.Parameters.Add(new OleDbParameter("@ChargeType", cc.ChargeType.Id));
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CreditCharges cc = entity as CreditCharges;
            if (cc != null)
            {
                string str = $"UPDATE CreditCharges SET CardId=@CardId,ChargeDate=@ChargeDate,Business=@Business,ChargeAmount=@ChargeAmount,ChargeType=@ChargeType "+
                    $"WHERE Id = @Id";
                command.CommandText = str;
                cmd.Parameters.Add(new OleDbParameter("@CardId", cc.CardId.Id));
                cmd.Parameters.Add(new OleDbParameter("@ChargeDate", cc.ChargeDate1));
                cmd.Parameters.Add(new OleDbParameter("@ChargeAmount", cc.BusinessName.Id));
                cmd.Parameters.Add(new OleDbParameter("@ChargeType", cc.ChargeType.Id));
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CreditCharges cc = entity as CreditCharges;
            if (cc != null)
            {
                string sqlStr = $"DELETE FROM CreditCharges WHERE Id = @Id";
                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", cc.Id));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            CreditCharges cc = entity as CreditCharges;
            if (cc != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, cc));
            }
        }

        public override void Update(BaseEntity entity)
        {
            CreditCharges cc = entity as CreditCharges;
            if (cc != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, cc));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            CreditCharges cc = entity as CreditCharges;
            if (cc != null)
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, cc));
        }
    }
}
