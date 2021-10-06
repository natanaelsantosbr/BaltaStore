using BaltaStore.Domain.StoreContext.ValueObjects;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        //Solid

        /*
        S. Principio da responsabilidade unica (Organização)
        O. Esta aberto para extensão (sem sealed), mas esta fechado para modificação (private set)
        LID        
        */

        public Customer(Name name, Document document, Email email, string phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this.Addresses = new List<Address>();
        }
        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public string Phone { get; private set; }

        public IReadOnlyCollection<Address> Addresses { get; private set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }

    }
}