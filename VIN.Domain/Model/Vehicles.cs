using System;

namespace VIN.Domain.Model
{
    public class Vehicles : EntityRoot
    {
        public Vehicles(string id, string chassisNumber, int type, string color, byte NumPassengers)
        {
            this.Id = id;
            this.ChassisNumber = chassisNumber;
            this.VehicleType = type;
            this.Color = color;
            this.NumPassengers = NumPassengers;
        }

        // Empty constructor for EF
        public Vehicles() { }

        public string Id { get; private set; }
        public string ChassisNumber { get; private set; }
        public int VehicleType { get; private set; }
        public string Color { get; private set; }
        public byte NumPassengers { get; private set; }

    }
}
