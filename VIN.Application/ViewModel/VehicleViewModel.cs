using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Application.ViewModel
{
    public class VehicleViewModel
    {
        public string Id { get; set; }
        public string ChassisNumber { get; set; }
        public string VehicleType { get; set; }
        public string Color { get; set; }
        public byte NumPassengers { get; set; }
    }
}
