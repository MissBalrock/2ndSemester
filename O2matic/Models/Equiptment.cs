using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Equiptment
    {
        public EquipmentType Type { get; set; }
        public int SerialNumber { get; set; }
        public int LocationId { get; set; }

        public Equiptment(EquiptmentType type, int serialNumber, int locationId)
        {
            Type = type;
            SerialNumber = serialNumber;
            LocationId = locationId;
        }
    }
}
