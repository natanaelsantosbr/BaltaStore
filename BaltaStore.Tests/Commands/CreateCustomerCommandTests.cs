using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Natanael",
                LastName = "Santos",
                Document = "02164315065",
                Email = "natanaelsantosbr@gmail.com",
                Phone = "61981145200"
            };

            Assert.AreEqual(true, command.Valid());



        }

    }
}
