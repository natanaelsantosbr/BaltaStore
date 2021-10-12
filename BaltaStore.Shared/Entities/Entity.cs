using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

    }
}
