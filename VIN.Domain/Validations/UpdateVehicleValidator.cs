using VIN.Domain.Commands;

namespace VIN.Domain.Validations
{
    public class UpdateVehicleValidator : VehiclesValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleValidator()
        {
            ValidateId();
            ValidateChassisNumber();
            ValidateColor();
            ValidateVehicleType();
        }
    }
}
