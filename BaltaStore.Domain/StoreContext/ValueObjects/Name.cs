using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(this.FirstName, 40, "FirstName", "O nome deve conter no maximo 40 caracteres")
                .HasMinLen(this.LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(this.LastName, 40, "LastName", "O sobrenome deve conter no maximo 40 caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
