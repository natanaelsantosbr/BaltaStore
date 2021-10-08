using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document _validDocument;
        private Document _invalidDocument;

        public DocumentTests()
        {
            this._invalidDocument = new Document("11132112395");
            this._validDocument = new Document("03753828106");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {            
            Assert.AreEqual(false,  this._invalidDocument.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {            
            Assert.AreEqual(true, this._validDocument.IsValid);
        }

    }
}
