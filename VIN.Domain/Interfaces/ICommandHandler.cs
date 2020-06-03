using MediatR;

namespace VIN.Domain.Interfaces
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, bool> where TCommand : ICommand
    {
        
    }
}
