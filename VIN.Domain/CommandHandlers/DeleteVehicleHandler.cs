using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VIN.Domain.Commands;
using VIN.Domain.Interfaces;
using VIN.Domain.Model;

namespace VIN.Domain.CommandHandlers
{
    public class DeleteVehicleHandler : CommandHandler<DeleteVehicleCommand> 
    {
        private readonly IVehiclesRepository repository;

        public DeleteVehicleHandler(IVehiclesRepository repository) => this.repository = repository;

        protected override async Task<bool> Execute(DeleteVehicleCommand command)
        {
            var entity = new Vehicles(command.Id);
            return await repository.Delete(entity);
        }
    }
}