using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ViewModel
{
    public class BusinessDB : BaseEntityDB
    {
        static private BusinessList list = new BusinessList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Business business = entity as Business;
            business.BusinessName = reader["BusinessName"].ToString();
            business.Adress = reader["Adress"].ToString();
            business.PhoneNumber1 = reader["PhoneNumber"].ToString();
            int city = (int)reader["City"];
            business.City = CityDB.SelectById(city);
            base.CreateModel(entity);
            return business;
        }
        protected override BaseEntity NewEntity()
        {
            return new Business();
        }

        public BusinessList SelectAll()
        {
            this.command.CommandText = $"SELECT * FROM  Business";
            BusinessList businessesList = new BusinessList(base.Select());
            return businessesList;
        }
        public static Business SelectById(int id)
        {
            if (list.Count == 0)
            {
                BusinessDB db = new BusinessDB();
                list = db.SelectAll();
            }
            Business business = list.Find(item => item.Id == id);
            return business;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Business business = entity as Business;
            if (business != null)
            {
                string sqlStr = $"INSERT INTO Business (BusinessName, Adress, PhoneNumber,City) " +
                    " VALUES(@BusinessName, @Adress, @PhoneNumber, @City)";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@BusinessName", business.BusinessName));
                cmd.Parameters.Add(new OleDbParameter("@Adress", business.Adress));
                cmd.Parameters.Add(new OleDbParameter("@PhoneNumber", business.PhoneNumber1));
                cmd.Parameters.Add(new OleDbParameter("@City", business.City.Id));
            }

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Business business = entity as Business;
            if (business != null)
            {
                string sqlStr = $"UPDATE Business SET BusinessName=@BusinessName, Adress=@Adress, PhoneNumber=@PhoneNumber," +
                $"City=@City " +
                $"WHERE Id = @Id";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@BusinessName", business.BusinessName));
                cmd.Parameters.Add(new OleDbParameter("@Adress", business.Adress));
                cmd.Parameters.Add(new OleDbParameter("@PhoneNumber", business.PhoneNumber1));
                cmd.Parameters.Add(new OleDbParameter("@City", business.City.Id));
                cmd.Parameters.Add(new OleDbParameter("@Id", business.Id));
            }

        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Business business = entity as Business;
            if (business != null)
            {
                string sqlStr = $"DELETE FROM Business WHERE Id = @Id";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", business.Id));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            Business business = entity as Business;
            if (business != null)
            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, business));
            }
        }

        public override void Update(BaseEntity entity)
        {
            Business business = entity as Business;
            if (business != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, business));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            Business business = entity as Business;
            if (business != null)
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, business));
        }

    }
}
