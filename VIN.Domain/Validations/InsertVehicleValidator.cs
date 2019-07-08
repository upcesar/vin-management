using VIN.Domain.Commands;

namespace VIN.Domain.Validations
{
    public class InsertVehicleValidator : VehiclesValidator<InsertVehicleCommand>
    {
        public InsertVehicleValidator()
        {
            ValidateChassisNumber();
            ValidateColor();
            ValidateVehicleType();
        }
    }
}
