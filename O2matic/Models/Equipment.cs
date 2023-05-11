using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int EquipmentTypeId { get; set; }
        public int SerialNumber { get; set; }
        public int LocationId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Equipment(int id, int equipmentTypeId, int serialNumber, DateTime registrationDate, int locationId)
        {
            Id = id;
            EquipmentTypeId = equipmentTypeId;
            SerialNumber = serialNumber;
            LocationId = locationId;
            RegistrationDate = registrationDate;
        }
    }
}
