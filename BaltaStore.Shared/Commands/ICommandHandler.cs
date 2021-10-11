using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        //Retorna tanto input de entrada como de saida
        ICommandResult Handle(T command);
    }
}
