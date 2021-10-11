using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            this.OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }

        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            this.AddNotifications(new ValidationContract()
                            .HasLen(this.Customer.ToString(), 36, "Customer", "Identificador do Cliente Invalido")
                            .IsGreaterThan(this.OrderItems.Count(), 0, "Itens", "Nenhum item do pedido foi encontrado"));

            return Valid();
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }

        public decimal Quantity { get; set; }
    }
}
