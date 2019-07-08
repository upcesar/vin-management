using System;
using System.Collections.Generic;
using System.Text;
using VIN.Application.ViewModel;
using VIN.Domain.Model;

namespace VIN.Application.Interfaces
{
    public interface IVehiclesService
    {
        IEnumerable<VehicleViewModel> GetAll();
        VehicleViewModel Get(string id);
        bool Insert(Vehicles vehicle);
        bool Update(Vehicles vehicle);
        bool Delete(Vehicles vehicle);
    }
}
