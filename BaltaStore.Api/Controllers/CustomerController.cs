using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Andre", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551154564");

            var customers = new List<Customer>
            {
                customer
            };

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Andre", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551154564");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetByOrders(Guid id)
        {
            var name = new Name("Andre", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551154564");
            var order = new Order(customer);

            var mouse = new Product("_mouse", "_mouse", "_mouse.jpg", 120M, 10);
            var monitor = new Product("_monitor", "_monitor", "_monitor.jpg", 1011M, 10);

            order.AddItem(mouse, 5);
            order.AddItem(monitor, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!" };
        }
    }
}
