using Microsoft.VisualStudio.TestTools.UnitTesting;
using O2matic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models.Tests
{
    [TestClass()]
    public class RelayCommandTests
    {
        [TestMethod()]
        public void CanExecuteTest()
        {

            RelayCommand relayCommand = new((obj) =>  Print());
            bool result = relayCommand.CanExecute(null);

            Assert.IsTrue(result);

        }

        private void Print()
        {
            Console.WriteLine("asdf");
        }

    }
}