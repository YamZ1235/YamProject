using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CardsDB : BaseEntityDB
    {
        static private CardsList list = new CardsList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            CardForCustomers card = entity as CardForCustomers;
            int accountNumber = (int)reader["AccountNumber"];
            card.AccountNumber = CustomerDB.SelectById(accountNumber);
            card.CardNumber1 = reader["CardNumber"].ToString();
            card.PeriodDateMonth1 = reader["PeriodDateMonth"].ToString();
            card.PeriodDateYear1 = reader["PeriodDateYear"].ToString();
            card.Cvc = reader["CVC"].ToString();
            card.LineCredit = reader["LineCredit"].ToString();
            base.CreateModel(entity);
            return card;
        }
        protected override BaseEntity NewEntity()
        {
            return new CardForCustomers();
        }
        public CardsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM  CardsForCustomers ";
            CardsList cList = new CardsList(base.Select());
            return cList;

        }
        public static CardForCustomers SelectById(int id)
        {
            if (list.Count == 0)
            {
                CardsDB db = new CardsDB();
                list = db.SelectAll();
            }
            CardForCustomers card = list.Find(item => item.Id == id);
            return card;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CardForCustomers card = entity as CardForCustomers;
            if (card != null)
            {
                string sqlStr = "INSERT INTO CardForCustomers (AccountNumber,CardNumber,PeriodDateMonth,PeriodDateYear,CVC,LineCredit) " +
                    "Values(@AccountNumber, @CardNumber, @PeriodDateMonth, @PeriodDateYear, @CVC, @LineCredit)";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@AccountNumber", card.AccountNumber.Id));
                cmd.Parameters.Add(new OleDbParameter("@CardNumber", card.CardNumber1));
                cmd.Parameters.Add(new OleDbParameter("@PeriodDateMonth", card.PeriodDateMonth1));
                cmd.Parameters.Add(new OleDbParameter("@PeriodDateYear", card.PeriodDateYear1));
                cmd.Parameters.Add(new OleDbParameter("@CVC", card.Cvc));
                cmd.Parameters.Add(new OleDbParameter("@LineCredit", card.LineCredit));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CardForCustomers card = entity as CardForCustomers;
            if (card != null)
            {
                string str = $"Update CardForCustomers SET BranchId=({card.Id},{card.AccountNumber},{card.CardNumber1},{card.PeriodDateMonth1},{card.PeriodDateYear1},{card.Cvc},{card.LineCredit}) Where Id={card.Id} ";
                cmd.CommandText = str;
                cmd.Parameters.Add(new OleDbParameter("@AccountNumber", card.AccountNumber.Id));
                cmd.Parameters.Add(new OleDbParameter("@CardNumber", card.CardNumber1));
                cmd.Parameters.Add(new OleDbParameter("@PeriodDateMonth", card.PeriodDateMonth1));
                cmd.Parameters.Add(new OleDbParameter("@PeriodDateYear", card.PeriodDateYear1));
                cmd.Parameters.Add(new OleDbParameter("@CVC", card.Cvc));
                cmd.Parameters.Add(new OleDbParameter("@LineCredit", card.LineCredit));
                cmd.Parameters.Add(new OleDbParameter("@Id", card.Id));

            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CardForCustomers card = entity as CardForCustomers;
            if (card != null)
            {
                string sqlStr = $"DELETE FROM CardForCustomers WHERE ID = @Id";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", card.Id));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            CardForCustomers card = entity as CardForCustomers;
            if (card != null)
            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, card));
            }
        }

        public override void Update(BaseEntity entity)
        {
            CardForCustomers card = entity as CardForCustomers;
            if (card != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, card));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            CardForCustomers card = entity as CardForCustomers;
            if (card != null)
                deleted.Add(new ChangeEntity(this.CreateUpdateSQL, card));
        }
    }
}
