using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ViewModel
{
    public class CustomerDB : BaseEntityDB
    {
        static private CustomerList list = new CustomerList();
        public CustomerDB() : base() { }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer customer = entity as Customer;
            customer.AccountNumber = int.Parse(reader["AccountNumber"].ToString());
            int branch = int.Parse(reader["Branch"].ToString());
            customer.Branch = BranchDB.SelectById(branch);
            customer.FirstName = reader["PrivateName"].ToString();
            customer.LastName = reader["LastName"].ToString();
            customer.PhoneNumber = reader["PhoneNumber"].ToString();
            customer.Mail = reader["Mail"].ToString();
            int city = int.Parse(reader["City"].ToString());
            customer.City = CityDB.SelectById(city);
            customer.Street = reader["Street"].ToString();
            customer.StreetNumber = int.Parse(reader["StreetNumber"].ToString());
            customer.MoneyAmount = int.Parse(reader["MoneyAmount"].ToString());
            base.CreateModel(entity);
            return customer;
        }
        protected override BaseEntity NewEntity()
        {
            return new Customer();
            
        }

        public CustomerList SelectAll()
        {
            command.CommandText = $"SELECT * FROM  Customer";
            CustomerList sList = new CustomerList(base.Select());
            return sList;

        }
        public static Customer SelectById(int id)
        {
            if (list.Count == 0)
            {
                CustomerDB db = new CustomerDB();
                list = db.SelectAll();
            }
            Customer customer = list.Find(item => item.Id == id);
            return customer;
        }
        

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Customer customer = entity as Customer;
            if (customer != null)
            {
                string sqlStr = $"INSERT INTO Customer (PrivateName, LastName, AccountNumber, Branch, City, PhoneNumber, Street, StreetNumber, Mail, MoneyAmount ) " +
                    " VALUES(@PrivateName, @LastName, @AccountNumber, @Branch, @City, @PhoneNumber, @Street, @StreetNumber, @Mail, @MoneyAmount)";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@PrivateName", customer.FirstName));
                cmd.Parameters.Add(new OleDbParameter("@LastName", customer.LastName));
                cmd.Parameters.Add(new OleDbParameter("@AccountNumber", customer.AccountNumber));
                cmd.Parameters.Add(new OleDbParameter("@Branch", customer.Branch.Id));
                cmd.Parameters.Add(new OleDbParameter("@City", customer.City.Id));
                cmd.Parameters.Add(new OleDbParameter("@PhoneNumber", customer.PhoneNumber));
                cmd.Parameters.Add(new OleDbParameter("@Street", customer.Street));
                cmd.Parameters.Add(new OleDbParameter("@StreetNumber", customer.StreetNumber));
                cmd.Parameters.Add(new OleDbParameter("@Mail", customer.Mail));
                cmd.Parameters.Add(new OleDbParameter("@MoneyAmount", customer.MoneyAmount));
            }
            
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Customer customer = entity as Customer;
            if (customer != null)
            {
                string sqlStr = $"UPDATE Customer SET AccountNumber=@AccountNumber, Branch=@Branch, PrivateName=@PrivateName," +
                $"LastName=@LastName, PhoneNumber=@PhoneNumber, Mail=@Mail ,City=@City ,Street=@Street, StreetNumber=@StreetNumber,MoneyAmount=@MoneyAmount " +
                $"WHERE Id = @Id";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@AccountNumber", customer.AccountNumber));
                cmd.Parameters.Add(new OleDbParameter("@Branch", customer.Branch.Id));
                cmd.Parameters.Add(new OleDbParameter("@PrivateName", customer.FirstName));
                cmd.Parameters.Add(new OleDbParameter("@LastName", customer.LastName));
                cmd.Parameters.Add(new OleDbParameter("@PhoneNumber", customer.PhoneNumber));
                cmd.Parameters.Add(new OleDbParameter("@Mail", customer.Mail));
                cmd.Parameters.Add(new OleDbParameter("@City", customer.City.Id));
                cmd.Parameters.Add(new OleDbParameter("@Street", customer.Street));
                cmd.Parameters.Add(new OleDbParameter("@StreetNumber", customer.StreetNumber));
                cmd.Parameters.Add(new OleDbParameter("@MoneyAmount", customer.MoneyAmount));
                cmd.Parameters.Add(new OleDbParameter("@Id", customer.Id));
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Customer customer = entity as Customer;
            if (customer != null)
            {
                string sqlStr = $"DELETE FROM Customer WHERE Id = @Id";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", customer.Id));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            Customer customer = entity as Customer;
            if (customer != null)
            { 
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, customer)); 
            }

        }
        public override void Update(BaseEntity entity)
        {
            Customer customer = entity as Customer;
            if (customer != null)
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
        }
        public override void Delete(BaseEntity entity)
        {
            Customer customer = entity as Customer;
            if (customer != null)
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
        }
    }
}
//namespace Controller
//{
//    public class CustomerDB : BaseEntityDB
//    {
//        public CustomerDB() : base() { }

//        protected override BaseEntity CreateModel(BaseEntity entity)
//        {
//            Customer student = entity as Customer;
//            student.FirstName = reader["PrivateName"].ToString();
//            student.LastName = reader["LastName"].ToString();
//            student.PhoneNumber = reader["PhoneNumber"].ToString();
//            int city = (int)reader["City"];
//            student.City = CityDB.SelectById(city);
//            base.CreateModel(entity);
//            return student;
//        }

//        public override void Insert(BaseEntity entity)
//        {
//            BaseEntity reqEntity = this.NewEntity();
//            if (entity != null & entity.GetType() == reqEntity.GetType())
//            {
//                //inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity)); ;
//                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); ;
//            }
//        }

//        public override void Delete(BaseEntity entity)
//        {
//            Customer customer = entity as Customer;
//            if (customer != null)
//                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));

//        }

//        public override void Update(BaseEntity entity)
//        {
//            Customer customer = entity as Customer;
//            if (customer != null)
//                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
//        }

//        /*public int Insert(People person)
//        {
//            int records = 0;
//            string sqlStr = string.Format("INSERT INTO PeopleTbl (FirstName,LastName,City,Telephone) " + " VALUES('{0}', '{1}', '{2}', '{3}')", person.FirstName.ToString(), person.LastName.ToString(),
//                person.City.Id, person.Telephone.ToString());
//            try
//            {
//                command.CommandText = sqlStr;
//                connection.Open();
//                records = command.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL : " + command.CommandText);
//            }
//            finally
//            {
//                if (connection.State == System.Data.ConnectionState.Open)
//                    connection.Close();
//            }

//            return records;
//        }

//        public int Update(People person)
//        {
//            int records = 0;
//            string sqlStr = $"UPDATE PeopleTbl SET FirstName='{person.FirstName}'," +
//                $"LastName='{person.LastName}',City={person.City.Id},Telephone='{person.Telephone}'" +
//                $"WHERE ID={person.Id}";
//            try
//            {
//                command.CommandText = sqlStr;
//                connection.Open();
//                records = command.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL: " + command.CommandText);
//            }
//            finally
//            {
//                if (connection.State == System.Data.ConnectionState.Open)
//                    connection.Close();
//            }

//            return records;
//        }

//        public int Delete(People person)
//        {
//            int records = 0;
//            string sqlStr = $"DELETE FROM " +
//                $"PeopleTbl WHERE ID={person.Id}";
//            try
//            {
//                command.CommandText = sqlStr;
//                connection.Open();
//                records = command.ExecuteNonQuery();
//            }

//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL: " + command.CommandText);

//            }
//            finally
//            {
//                if (connection.State == System.Data.ConnectionState.Open)
//                    connection.Close();
//            }

//            return records;
//        }*/

//        public int SaveChanges(string command_text)
//        {
//            int records = 0;
//            try
//            {
//                command.CommandText = command_text;
//                connection.Open();
//                records = command.ExecuteNonQuery();
//            }
//            catch (Exception e)
//            {
//                System.Diagnostics.Debug.Write(e.Message + "\nSQL:" + command.CommandText);
//            }
//            finally
//            {
//                if (connection.State == ConnectionState.Open)
//                    connection.Close();
//            }

//            return records;
//        }

//        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand command)
//        {
//            Customer customer = entity as Customer;
//            string sqlStr = "INSERT INTO Customer (PrivateName, LastName, AccountNumber, Branch, City, PhoneNumber, Street, StreetNumber, Mail) " +
//                " VALUES(@FirstName, @LastName, @AccountNumber, @Branch, @City, @Telephone, @Street, @StreetNumber)";

//            command.Parameters.Add(new OleDbParameter("@FirstName", customer.FirstName));
//            command.Parameters.Add(new OleDbParameter("@LastName", customer.LastName));
//            command.Parameters.Add(new OleDbParameter("@City", customer.City.Id));
//            command.Parameters.Add(new OleDbParameter("@Telephone", customer.PhoneNumber));
//            command.Parameters.Add(new OleDbParameter("@AccountNumber", customer.FirstName));
//            command.Parameters.Add(new OleDbParameter("@Branch", customer.LastName));
//            command.Parameters.Add(new OleDbParameter("@Mail", customer.Mail));
//            command.Parameters.Add(new OleDbParameter("@Street", customer.StreetNumber));
//            command.Parameters.Add(new OleDbParameter("@StreetNumber", customer.StreetNumber));

//            command.CommandText = sqlStr;
//            //return sqlStr;
//        }

//        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand command)
//        {
//            Customer customer = entity as Customer;

//            string sqlStr = $"UPDATE PeopleTbl SET FirstName=@FirstName," +
//                $"LastName=@LastName, City=@City, Telephone=@Telephone " +
//                $"WHERE ID =@Id";

//            command.Parameters.Add(new OleDbParameter("@FirstName", customer.FirstName));
//            command.Parameters.Add(new OleDbParameter("@LastName", customer.LastName));
//            command.Parameters.Add(new OleDbParameter("@City", customer.City.Id));
//            command.Parameters.Add(new OleDbParameter("@Telephone", customer.PhoneNumber));
//            command.Parameters.Add(new OleDbParameter("@AccountNumber", customer.FirstName));
//            command.Parameters.Add(new OleDbParameter("@Branch", customer.LastName));
//            command.Parameters.Add(new OleDbParameter("@Mail", customer.Mail));
//            command.Parameters.Add(new OleDbParameter("@Street", customer.StreetNumber));
//            command.Parameters.Add(new OleDbParameter("@StreetNumber", customer.StreetNumber));

//            command.CommandText = sqlStr;
//            //return sqlStr;
//        }


//        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand command)
//        {
//            Customer customer = entity as Customer;
//            StringBuilder sql_builder = new StringBuilder();
//            string sqlStr = "DELETE FROM PeopleTbl WHERE ID = @Id";
//            command.Parameters.Add(new OleDbParameter("@Id", customer.Id));
//            command.CommandText = sqlStr;
//            //return sql_builder.ToString();
//        }



//        protected override BaseEntity NewEntity()
//        {
//            return new Customer();
//        }
//    }
//}
