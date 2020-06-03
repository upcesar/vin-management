using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VIN.Application.ViewModel;
using VIN.Domain.Model;

namespace VIN.Application.Interfaces
{
    public interface IVehiclesService
    {
        IEnumerable<VehicleViewModel> GetAll();
        VehicleViewModel Get(string id);
        Task<bool> Insert(VehicleViewModel vehicle);
        Task<bool> Update(VehicleViewModel vehicle);
        Task<bool> Delete(string id);
    }
}
