using FluentValidation.Results;
using System;
using VIN.Domain.Interfaces;

namespace VIN.Domain.Commands
{
    public abstract class Command : ICommand
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
