using VIN.Domain.Enum;
using VIN.Domain.Validations;
using VIN.Helpers.Extensions;

namespace VIN.Domain.Commands
{
    public class InsertVehicleCommand : VehiclesCommand
    {
        public InsertVehicleCommand(string chassisNumber, string vehicleType, string color)
        {
            ChassisNumber = chassisNumber;
            VehicleType = vehicleType.ToEnum(VehicleType.INVALID);
            Color = color;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertVehicleValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
