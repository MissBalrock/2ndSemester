using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.Models
{
    public class Equipment
    {
        public Equipment(int id, int equipmentTypeId, int serialNumber, DateTime registrationDate, int locationId)
        {
            Id = id;
            EquipmentTypeId = equipmentTypeId;
            SerialNumber = serialNumber;
            RegistrationDate = registrationDate;
            LocationId = locationId;
        }

        public int Id { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public int SerialNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
