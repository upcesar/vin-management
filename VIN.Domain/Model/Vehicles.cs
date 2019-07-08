using System;

namespace VIN.Domain.Model
{
    public class Vehicles : EntityRoot
    {
        public Vehicles(string id)
        {
            this.Id = id;
        }
        public Vehicles(string id, string chassisNumber, int type, string color, byte NumPassengers): 
            this (chassisNumber, type, color, NumPassengers)
        {
            this.Id = id;
        }

        public Vehicles(string chassisNumber, int type, string color, byte NumPassengers)
        {
            this.ChassisNumber = chassisNumber;
            this.VehicleType = type;
            this.Color = color;
            this.NumPassengers = NumPassengers;
        }


        // Empty constructor for EF
        public Vehicles() { }

        public string ChassisNumber { get; private set; }
        public int VehicleType { get; private set; }
        public string Color { get; private set; }
        public byte NumPassengers { get; private set; }

    }
}
