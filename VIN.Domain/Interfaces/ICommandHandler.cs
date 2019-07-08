using System;
using System.Collections.Generic;
using System.Text;
using VIN.Domain.Commands;

namespace VIN.Domain.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Handle(TCommand command);
    }
}
