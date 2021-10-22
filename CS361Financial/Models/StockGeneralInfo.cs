using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS361Financial.Models
{
    public class StockGeneralInfo
    {
        public string name;
        public string ticker;
        public decimal value;
        public decimal previousClose;
        public int marketCap;
    }
}
