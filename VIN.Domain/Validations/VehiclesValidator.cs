using FluentValidation;
using System;
using VIN.Domain.Commands;

namespace VIN.Domain.Validations
{
    public class VehiclesValidator<T> : AbstractValidator<T> where T : VehiclesCommand
    {
        protected void ValidateId() => 
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

        protected void ValidateVehicleType() =>
            RuleFor(v => v.VehicleType)
                .NotNull()
                .NotEmpty()
                .WithMessage("Tipo veículo não deve estar vazio");

        protected void ValidateChassisNumber() =>
            RuleFor(v => v.ChassisNumber)
                .NotNull()
                .WithMessage("Chassis não deve estar vazio");

        protected void ValidateColor() =>
            RuleFor(v => v.Color)
                .NotNull()
                .WithMessage("Color não deve estar vazio");

    }
}
