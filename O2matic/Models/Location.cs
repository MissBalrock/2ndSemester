using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Location
    {
        public string Address { get; set; }
        public string Title { get; set; }
        public int EquiptmentId { get; set; }
        public int BussinestripId { get; set; }
        public int CustomerId { get; set; }
        public int OrderID { get; set; }
        public int StockID { get; set; }
    }
}
