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
    public abstract class BaseEntityDB
    {
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\YamProject\ViewModel\BankProject.accdb";
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public static List<ChangeEntity> inserted = new List<ChangeEntity>();
        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
        public static List<ChangeEntity> updated = new List<ChangeEntity>();

        protected abstract void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd);

        public static string Path()
        {
            String[] arguments = Environment.GetCommandLineArgs();
            string s;
            if (arguments.Length == 1)
                s = arguments[0];
            else
            {
                s = arguments[1];
                s = s.Replace("/service:", "");
            }
            string[] ss = s.Split('\\');
            int x = ss.Length - 4;
            ss[x] = "ViewModel";

            Array.Resize(ref ss, x + 1);
            string str = String.Join("\\", ss);
            return str;
        }
        protected abstract BaseEntity NewEntity();

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }
        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
            }
        }

        protected List<BaseEntity> Select()
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
                System.Diagnostics.Debug.WriteLine(
                    e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }

        protected async Task<List<BaseEntity>> SelectAsync(string sqlStr)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
                command.Connection = connection;
                command.CommandText = sqlStr;
                connection.Open();
                this.reader = (OleDbDataReader)await command.ExecuteReaderAsync();


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
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }
        public BaseEntityDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public int SaveChanges()
        {
            int records_affected = 0;
            OleDbTransaction trans = null;



            try
            {
                connection.Open();
                trans = connection.BeginTransaction();
                command.Transaction = trans;

                foreach (var entity in inserted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateInsertSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.Entity.Id = (int)command.ExecuteScalar();
                }

                foreach (var entity in updated)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateUpdateSQL(entity.Entity);

                    records_affected += command.ExecuteNonQuery();
                }

                foreach (var entity in deleted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);

                    records_affected += command.ExecuteNonQuery();
                }

                Console.WriteLine("records:" +records_affected);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            //System.Diagnostics.Debug.WriteLine("records affected: " + records_affected);

            return records_affected;
        }

        public async Task<int> SaveChangesAsync()
        {
            int records_affected = 0;
            OleDbCommand command = new OleDbCommand();
            try
            {
                command.Connection = this.connection;
                this.connection.Open();

                foreach (var item in inserted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);

                    records_affected += await command.ExecuteNonQueryAsync();

                    command.CommandText = "Select @@Identity";
                    item.Entity.Id = (int)command.ExecuteScalarAsync().Result;
                }

                foreach (var item in updated)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();
                }

                foreach (var item in deleted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return records_affected;
        }
        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["Id"];
            return entity;
        }

    }
}
