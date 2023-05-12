using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Order
    {
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int EquiptmentId { get; set; }
        public int CustomerId { get; set; }

        public Order(int price, DateTime date, string customer, int equiptmentId, int customerId)
        {
            Price = price;
            Date = date;
            EquiptmentId = equiptmentId;
            CustomerId = customerId;
        }   
    }
}
