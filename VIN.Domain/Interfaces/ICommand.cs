using MediatR;

namespace VIN.Domain.Interfaces
{
    public interface ICommand: IRequest<bool>
    {
        bool IsValid();
    }
}
