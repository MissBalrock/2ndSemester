using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set;}
        public string CountryCode { get; set;}

    }
}
