using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class ChargeType : BaseEntity
    {
        private string charge_Type;

        public string Charge_Type { get => charge_Type; set => charge_Type = value; }
    }
}
