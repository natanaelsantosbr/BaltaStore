using BaltaStore.Domain.Handlers;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            this._repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return this._repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return this._repository.Get(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return this._repository.Get(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetByOrders(Guid id)
        {
            return this._repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)this._handler.Handle(command);

            if (_handler.IsValid)
                return BadRequest(_handler.Notifications);

            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!" };
        }
    }
}
