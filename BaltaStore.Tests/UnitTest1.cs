using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Andre", "Baltieri", "12345678911", "hello@balta.io", "199999999", "Rua dos Desenvolvedores");

            var order = new Order(c);

        }
    }
}
