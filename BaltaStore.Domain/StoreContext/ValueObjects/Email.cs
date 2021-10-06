using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string Address)
        {
            this.Address = Address;
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return this.Address;
        }
    }
}
