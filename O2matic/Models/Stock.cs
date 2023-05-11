using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Stock
    {
        public string StockName { get; set; }
        public string Address { get; set; }

        public string Id { get; set; }

        public Stock(string stockName, string address, string id)
        {
            StockName = stockName;
            Address = address;
            Id = id;
        }
    }
    
}
