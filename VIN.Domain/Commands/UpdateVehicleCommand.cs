using System;
using VIN.Domain.Enum;
using VIN.Domain.Validations;

namespace VIN.Domain.Commands
{
    public class UpdateVehicleCommand : VehiclesCommand
    {
        public UpdateVehicleCommand(Guid id, string chassisNumber, VehicleType vehicleType, string color)
        {
            Id = id;
            ChassisNumber = chassisNumber;
            VehicleType = vehicleType;
            Color = color;
            NumPassengers = vehicleType.Equals(VehicleType.TRUCK) ? (byte)42 : (byte)2;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateVehicleValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
