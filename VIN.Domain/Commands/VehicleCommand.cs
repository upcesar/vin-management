using System;
using System.Collections.Generic;
using System.Text;
using VIN.Application.Enum;

namespace VIN.Application.Commands
{
    public abstract class VehicleCommand
    {
        public Guid Id { get; protected set; }
        public VehicleType Type { get; protected set; }
        public string Color { get; protected set; }
        public byte NumPassengers { get; protected set; }
    }

}
