using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            this.Address = address;

            this.AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(this.Address, "Email", "O E-mail é invalido"));
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return this.Address;
        }
    }
}
