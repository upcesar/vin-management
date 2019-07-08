using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using VIN.Domain.Model;

namespace VIN.Domain.Commands
{
    public abstract class Command
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
