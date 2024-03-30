using ClassLibrary5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDB : BaseEntityDB
    {
        static private CitysList list = new CitysList();
        public override BaseEntity NewEntity()
        {
            return new City();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City c = entity as City;
            c.CityName = reader["CityName"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public CitysList SelectAll()
        {
            command.CommandText = $"SELECT * FROM City";
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
    }
}
