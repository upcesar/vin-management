using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VIN.Application.Commands;

namespace VIN.Application.Validations
{
    public class VehicleValidator<T> : AbstractValidator<T> where T : VehicleCommand
    {
        private const byte ZERO = 0b0;

        protected void ValidateType() =>
            RuleFor(v => v.Type)
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

        protected void ValidatePassenger() =>
            RuleFor(v => v.NumPassengers)
                .NotNull().NotEmpty().WithMessage("Color não deve estar vazio")
                .GreaterThan(ZERO).WithMessage("Número passageiros deve ser maior a zero");

    }
}
