using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            this.Firstname = firstName;
            this.LastName = lastName;
        }

        public string Firstname { get; private set; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"{this.Firstname} {this.LastName}";
        }
    }
}
