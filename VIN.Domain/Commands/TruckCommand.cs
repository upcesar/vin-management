using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Application.Commands
{
    class TruckCommand : VehicleCommand
    {
        public TruckCommand()
        {
            Type = Enum.VehicleType.TRUCK;
            NumPassengers = 42;
        }
    }
}
