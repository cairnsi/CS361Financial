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
        public decimal marketCap;
        public decimal ptoe;
        public decimal week52high;
        public decimal week52low;
        public decimal returnsYTD;
        public decimal returns1Y;
        public decimal returns2Y;
        public decimal returns5Y;
        public decimal returns10Y;
        public string description;
    }
}
