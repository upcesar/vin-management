using VIN.Domain.Enum;
using VIN.Domain.Validations;

namespace VIN.Domain.Commands
{
    public class InsertVehicleCommand : VehiclesCommand
    {
        public InsertVehicleCommand(string chassisNumber, VehicleType vehicleType, string color)
        {
            ChassisNumber = chassisNumber;
            VehicleType = vehicleType;
            Color = color;
            NumPassengers = vehicleType.Equals(VehicleType.TRUCK) ? (byte)42 : (byte)2;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertVehicleValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
