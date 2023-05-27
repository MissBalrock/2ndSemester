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
        public void ValidateSerialNumberTest()
        {


            RegisterEquipmentVM registerEquipmentVM = new RegisterEquipmentVM();
            int? result = registerEquipmentVM.ValidateSerialNumber("djkfgjghj");
            Assert.IsNull(result);
            
        }
    }
}