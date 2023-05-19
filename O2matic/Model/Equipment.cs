using O2matic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Model
{
    public class Equipment

    {
        public int Id { get; set; }
        public int EquipmentTypeId { get; set; }
        public int SerialNumber { get; set; }
        public int LocationId { get; set; }
        public string DeviceStatus { get; set; } // hvis solgt, kaseeres eller til rep.
        public DateTime RegistrationDate { get; set; }

     
        public Equipment(int id, int equipmentTypeId, int serialNumber, int locationId, string deviceStatus, DateTime registrationDate)
        {
            Id = id;
            EquipmentTypeId = equipmentTypeId;  
            SerialNumber = serialNumber;    
            LocationId = locationId;
            DeviceStatus = deviceStatus;
            RegistrationDate = registrationDate;
           
        }

        public Equipment(int id, int equipmentTypeId, int serialNumber, DateTime registrationDate, int locationId)
        {
            Id = id;
            EquipmentTypeId = equipmentTypeId;
            SerialNumber = serialNumber;
            RegistrationDate = registrationDate;
            LocationId = locationId;
        }
    }
}
