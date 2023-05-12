using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Equiptment
    {
        internal int Id;

        public  EquipmentType Type { get; set; }
        public int SerialNumber { get; set; }
        public int LocationId { get; set; }
        public string EquiptmentType { get; internal set; }

        public Equiptment(EquiptmentType type, int serialNumber, int locationId)
        {
            Type = type;
            SerialNumber = serialNumber;
            LocationId = locationId;
        }

        public Equiptment()
        {
        }
    }

    public class EquiptmentType
    {
        public EquipmentType Hot{ get; set; }
        public EquipmentType Pro { get; set; }

        public EquiptmentType(EquipmentType type)
        {
           Hot = Hot;
           Pro = Pro;

        }

        public static implicit operator EquipmentType(EquiptmentType v)
        {
            throw new NotImplementedException();
        }
    }
}
