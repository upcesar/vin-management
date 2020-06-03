using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VIN.Domain.Commands;
using VIN.Domain.Interfaces;
using VIN.Domain.Model;

namespace VIN.Domain.CommandHandlers
{
    public class InsertVehicleHandler : CommandHandler<InsertVehicleCommand> 
    {
        private readonly IVehiclesRepository repository;

        public InsertVehicleHandler(IVehiclesRepository repository) => this.repository = repository;

        protected override void Prepare(InsertVehicleCommand command) => command.SetNumberOfPassenger();

        protected override async Task<bool> Execute(InsertVehicleCommand command)
        {
            var entity = new Vehicles(command.ChassisNumber,
                                      command.VehicleType.GetHashCode(),
                                      command.Color,
                                      command.NumPassengers);
            
            return await repository.Insert(entity);
        }
    }
}