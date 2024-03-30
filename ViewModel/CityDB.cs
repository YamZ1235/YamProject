using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Model;
using System.Reflection.PortableExecutable;
using ViewModel;

namespace ViewModel
{
    public class CityDB : BaseEntityDB
    {
        //private string connectionString = @"";
        //private OleDbConnection connection;
        //private OleDbCommand command;
        //private OleDbDataReader reader;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.CityName = reader["CityName"].ToString();
            base.CreateModel(entity);
            return city;
        }
            static private CitysList list = new CitysList();

        public CityDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        protected override BaseEntity NewEntity()
        {
            return new City();
        }

        public CitysList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Citys";
            CitysList cList = new CitysList(base.Select());
            return cList;

        }
        public static City SelectById(int id)
        {
            if (list.Count == 0)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }
            City city = list.Find(item => item.Id == id);
            return city;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City ca = entity as City;
            if (ca != null)
            {
                string sqlStr = "INSERT INTO Citys (CityName) " +
                    "Values(@CityName)";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@CityName", ca.CityName));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City ca = entity as City;
            if (ca != null)
            {
                string sqlStr = $"UPDATE Citys SET CityName=@CityName " +
                $"WHERE Id =@Id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@CityName", ca.CityName));
                cmd.Parameters.Add(new OleDbParameter("@Id", ca.Id));

            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City ca = entity as City;

            string sql_builder = $"DELETE FROM Citys WHERE Id = @Id";

            cmd.CommandText = sql_builder;

            cmd.Parameters.Add(new OleDbParameter("@Id", ca.Id));
        }

        public override void Insert(BaseEntity entity)
        {
            City ca = entity as City;
            if (ca != null)
            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, ca));
            }
        }

        public override void Update(BaseEntity entity)
        {
            City ca = entity as City;
            if (ca != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, ca));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            City ca = entity as City;
            if (ca != null)
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, ca));
        }

    }
}
