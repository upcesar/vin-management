using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VIN.Domain.Commands;
using VIN.Domain.Interfaces;

namespace VIN.Domain.CommandHandlers
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public async Task<bool> Handle(TCommand command, CancellationToken cancellationToken)
        {
            Prepare(command);
            
            if (command.IsValid())
                return await Execute(command);

            return false;

        }

        protected virtual void Prepare(TCommand command) { }

        protected abstract Task<bool> Execute(TCommand command);

    }
}
