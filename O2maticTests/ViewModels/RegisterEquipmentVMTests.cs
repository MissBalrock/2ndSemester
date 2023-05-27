using Microsoft.VisualStudio.TestTools.UnitTesting;
using O2maticTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.ViewModels.Tests
{
    [TestClass()]
    public class RegisterEquipmentVMTests
    {
        [TestMethod()]
        public void ValidateSerialNumber_InvalidStringInput()
        {
            RegisterEquipmentVM registerEquipmentVM = new RegisterEquipmentVM();
            int? result = registerEquipmentVM.ValidateSerialNumber("djkfgjghj");
            Assert.IsNull(result);
            
        }

        [TestMethod()]
        public void ValidateSerialNumber_ValidStringInput()
        {
            RegisterEquipmentVM registerEquipmentVM = new RegisterEquipmentVM();
            int? result = registerEquipmentVM.ValidateSerialNumber("3456789");
            Assert.AreEqual(3456789, result);

        }


        [TestMethod()]
        public void ValidateSerialNumber_EmptyStringInput()
        {
            RegisterEquipmentVM registerEquipmentVM = new RegisterEquipmentVM();
            int? result = registerEquipmentVM.ValidateSerialNumber("");
            Assert.IsNull(result);

        }

        [TestMethod()]
        public void ValidateSerialNumber_LeadingAndTrailingWhiteSpace()
        {
            RegisterEquipmentVM registerEquipmentVM = new RegisterEquipmentVM();
            int? result = registerEquipmentVM.ValidateSerialNumber(" 23 ");
            Assert.AreEqual(23, result);
        }

        
        [TestMethod()]
        public void ValidateSerialNumber_ActualSerialNumber()
        {
            RegisterEquipmentVM registerEquipmentVM = new RegisterEquipmentVM();
            int? result = registerEquipmentVM.ValidateSerialNumber("020101204500003");
            Assert.AreEqual(020101204500003, result);
        }








    }
}