using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;        

        private Customer _customer;
        private Order _order;


        public OrderTests()
        {
            var name = new Name("Andre", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            this._customer = new Customer(name, document, email, "551154564");
            this._order = new Order(this._customer);

            this._mouse = new Product("_mouse", "_mouse", "_mouse.jpg", 120M, 10);
            this._keyboard = new Product("_keyboard", "_keyboard", "_keyboard.jpg", 130M, 10);
            this._chair = new Product("_chair", "_chair", "_chair.jpg", 140M, 10);
            this._monitor = new Product("_monitor", "_monitor", "_monitor.jpg", 1011M, 10);


        }

        //Consigo criar um novo
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            var order = new Order(this._customer);
            Assert.AreEqual(true, order.IsValid);
        }

        //Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, this._order.Status);
        }

        //Ao Adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            this._order.AddItem(this._monitor, 5);
            this._order.AddItem(this._mouse, 5);
            Assert.AreEqual(2, this._order.Items.Count);
        }

        //Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            this._order.AddItem(this._monitor, 5);
            Assert.AreEqual(this._monitor.QuantityOnHand, 5);
        }

        //Ao confirmar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            this._order.Place();
            Assert.AreNotEqual("", this._order.Number);
        }

        //Ao pagar um pedido, o status deve ser pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            this._order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, this._order.Status);
        }

        //Dados mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.Ship();
            Assert.AreEqual(2, this._order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            this._order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, this._order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.Ship();
            this._order.Cancel();

            foreach (var x in this._order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }            
        }

        public void CreateCustomer()
        {
            //Verifica se o CPF ja existe
            //Verifica se o E-mail ja existe
            //Criar os VOs
            //Criar a entidades
            //Validar as entidades e VO
            // Inserir o cliente no banco
            // Envia o convite do Slack
            // Envia um e-mail de boas vindas

        }


    }
}
