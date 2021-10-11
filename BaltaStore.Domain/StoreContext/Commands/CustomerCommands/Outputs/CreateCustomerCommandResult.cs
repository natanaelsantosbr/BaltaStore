using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult()
        {

        }

        public CreateCustomerCommandResult(Guid id, string name, string document, string email)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }
    }
}
