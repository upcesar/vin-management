using System;
using VIN.Domain.Commands;
using VIN.Domain.Interfaces;
using VIN.Domain.Model;

namespace VIN.Domain.CommandHandlers
{
    public class InsertVehicleHandler : ICommandHandler<InsertVehicleCommand>
    {
        private readonly IVehiclesRepository repository;

        public InsertVehicleHandler(IVehiclesRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(InsertVehicleCommand command)
        {
            if (command.IsValid())
            {
                var vehicle = new Vehicles(Guid.NewGuid().ToString(), command.ChassisNumber, command.VehicleType.GetHashCode(), command.Color, command.NumPassengers);

                repository.Insert(vehicle);

            }
        }
    }
}
