using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Application.ViewModel
{
    public class VehicleViewModel
    {
        public Guid Id { get; set; }
        public string ChassisNumber { get; set; }
        public int VehicleType { get; set; }
        public string Color { get; set; }
        public byte NumPassengers { get; set; }
    }
}
