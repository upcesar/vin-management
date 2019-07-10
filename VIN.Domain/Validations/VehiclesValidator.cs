using FluentValidation;
using System;
using System.Collections.Generic;
using VIN.Domain.Commands;
using VIN.Domain.Enum;

namespace VIN.Domain.Validations
{
    public class VehiclesValidator<T> : AbstractValidator<T> where T : VehiclesCommand
    {
        protected void ValidateId() => 
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString());

        protected void ValidateVehicleType()
        {
            var listVehicleType = new List<VehicleType> { VehicleType.BUS, VehicleType.TRUCK };

            RuleFor(v => v.VehicleType)
                    .NotNull()
                    .NotEmpty()
                    .Must(i => listVehicleType.Contains(i))
                    .WithMessage("Tipo veículo inválido");
        }

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
