using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public bool PaymentCondition { get; set; }

        public Customer(string name, string email, int phoneNumber, bool paymentCondition)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            PaymentCondition = paymentCondition;
        }
    }
}
