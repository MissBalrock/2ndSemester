using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EquipmentType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
