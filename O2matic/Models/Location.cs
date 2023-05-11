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
        public int OrderId { get; set; }
        public int StockId { get; set; }

        public Location(string address, string title, int equiptmentId, int bussinestripId, int customerId, int orderId, int stockId)
        {
            Address = address;
            Title = title;
            EquiptmentId = equiptmentId;
            BussinestripId = bussinestripId;
            CustomerId = customerId;
            OrderId = orderId;
            StockId = stockId;
        }   
    }
}
