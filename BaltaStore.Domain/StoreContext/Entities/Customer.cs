using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Entities;
using FluentValidator;
using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;

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
            this._addresses = new List<Address>();
        }
        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public string Phone { get; private set; }

        public IReadOnlyCollection<Address> Addresses => this._addresses.ToArray();

        public void AddAddress(Address address)
        {
            this._addresses.Add(address);
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

    }
}