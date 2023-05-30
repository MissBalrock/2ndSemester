using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }

        public Location(int id, int addressId, string name)
        {
            Id = id;
            AddressId = addressId;
            Name = name;
        }

    }
}
