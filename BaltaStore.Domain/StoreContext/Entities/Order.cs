using BaltaStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public Order(Customer customer)
        {
            this.Customer = customer;
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this.Items = new List<OrderItem>();
            this.Deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; } //Coleção somente leitura
        public IReadOnlyCollection<Delivery> Deliveries { get; private set; }

        public void AddItem(OrderItem item)
        {

        }

        // To Place An Order
        public void Place()
        {

        }
    }
}