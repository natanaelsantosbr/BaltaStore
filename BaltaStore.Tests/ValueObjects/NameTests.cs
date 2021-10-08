using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Name _validDocument;
        private Name _invalidDocument;

        public NameTests()
        {
            this._invalidDocument = new Name("", "");
            this._validDocument = new Name("Natanael", "Santos");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, this._invalidDocument.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, this._validDocument.IsValid);
        }

    }
}
