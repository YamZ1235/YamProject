using System;
using ClassLibrary5;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ViewModel
{
    public abstract class BaseEntityDB
    {
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path() +"\\BankProject.accdb";
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public BaseEntityDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }
        public abstract BaseEntity NewEntity();
        private static string Path()
        {
            String[] arguments =  Environment.GetCommandLineArgs();
            string s;
            if (arguments.Length == 1)
            {s = arguments[0];}
            else
            {
                s = arguments[1];
                s = s.Replace("/service", "");
            }
            string[] ss = s.Split('\\');

            int x = ss.Length - 4;
            ss[x] = "ViewModel";
            Array.Resize(ref ss, x + 1);
            string str = String.Join("\\",ss);
            return str;
        }    
        public virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["ID"];
            return entity;
        }

        public OleDbConnection GetConnection()
        {
            return connection;
        }

        public List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if(reader != null)
                    reader.Close();
                if(connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }
    }
}
