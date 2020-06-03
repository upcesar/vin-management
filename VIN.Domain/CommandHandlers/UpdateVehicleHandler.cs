using System;
using System.Threading.Tasks;
using VIN.Domain.Commands;
using VIN.Domain.Interfaces;
using VIN.Domain.Model;

namespace VIN.Domain.CommandHandlers
{
    public class UpdateVehicleHandler : CommandHandler<UpdateVehicleCommand>
    {
        private readonly IVehiclesRepository repository;

        public UpdateVehicleHandler(IVehiclesRepository repository) => this.repository = repository;

        protected override void Prepare(UpdateVehicleCommand command) => command.SetNumberOfPassenger();
        protected override async Task<bool> Execute(UpdateVehicleCommand command)
        {
            var entity = new Vehicles(command.Id,
                                      command.ChassisNumber,
                                      command.VehicleType.GetHashCode(),
                                      command.Color,
                                      command.NumPassengers);

            return await repository.Update(entity);
        }
    }
}