using System;
using VIN.Domain.Enum;
using VIN.Domain.Validations;

namespace VIN.Domain.Commands
{
    public class DeleteVehicleCommand : VehiclesCommand
    {
        public DeleteVehicleCommand(string id) => Id = id;

        public override bool IsValid()
        {
            ValidationResult = new DeleteVehicleValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
