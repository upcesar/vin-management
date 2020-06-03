using System;
using VIN.Domain.Enum;
using VIN.Domain.Validations;
using VIN.Helpers.Extensions;

namespace VIN.Domain.Commands
{
    public class UpdateVehicleCommand : VehiclesCommand
    {
        public UpdateVehicleCommand(string id, string chassisNumber, string vehicleType, string color)
        {
            Id = id;
            ChassisNumber = chassisNumber;
            VehicleType = vehicleType.ToEnum(VehicleType.INVALID);
            Color = color;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateVehicleValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
