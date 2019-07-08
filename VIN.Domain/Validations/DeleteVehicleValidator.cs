using VIN.Domain.Commands;

namespace VIN.Domain.Validations
{
    public class DeleteVehicleValidator : VehiclesValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleValidator()
        {
            ValidateId();
        }
    }
}
