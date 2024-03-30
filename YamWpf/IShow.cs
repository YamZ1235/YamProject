using Model;
using MyApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YamWpf
{
    public class IShow
    {
        public IShow()
        {
            this.BranchNums = new List<int>();
            this.CityNames = new List<string>();
        }

        public async Task init()
        {
            var service = new MyService();

            var branchs = await service.GetBranchListAsync() as List<Branchs>;

            foreach (var num in branchs.Select(x => x.BranchNumber))
            {
                BranchNums.Add(num);
            }

            var cities = await service.GetCitysListAsync() as List<City>;

            foreach (var name in cities.Select(x => x.CityName))
            {
                CityNames.Add(name);
            }
        }

        public List<int> BranchNums { get; set; }

        public List<string> CityNames { get; set; }

        public int SelectedBranch { get; set; }
        public string SelectedCity { get; set; }
    }

    public class Active
    {
        public Active() { }
        private static readonly object a = new object ();
        private static IShow instance = null;
        public static IShow Instance
        {
            get
            {
                lock (a)
                    {
                        if (instance == null)
                        {
                            instance = new IShow();
                            Task.Run(() => instance.init()).Wait();
                        }
                        return instance;
                    }
            }
        }
    }
}
