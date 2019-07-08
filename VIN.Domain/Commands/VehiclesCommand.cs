using System;
using VIN.Domain.Enum;

namespace VIN.Domain.Commands
{
    public abstract class VehiclesCommand : Command
    {
        public Guid Id { get; protected set; }
        public string ChassisNumber { get; protected set; }
        public VehicleType VehicleType { get; protected set; }
        public string Color { get; protected set; }
        public byte NumPassengers { get; protected set; }
    }

}
