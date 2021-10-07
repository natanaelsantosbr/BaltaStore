using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Andre", "Baltieri");
            var document = new Document("12345678911");
            var email = new Email("hello@balta.io");
            var c = new Customer(name, document, email, "1999207414");
            var mouse = new Product("Mouse", "Rato", "image.png", 159.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image2.png", 359.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image5.png", 359.90M, 10); 
            var cadeira = new Product("Cadeira", "Cadeira", "image3.png", 559.90M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(cadeira, 5));
            //order.AddItem(new OrderItem(impressora, 5));

            //var oi = new OrderItem(impressora, 5);


            //realizar perdido
            order.Place();

            var valid = order.IsValid;


            //simular pagamento
            order.Pay();

            //simular envio
            order.Ship();

            //simular o cancelamento
            order.Cancel();

        }
    }
}
