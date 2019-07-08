using VIN.Domain.Interfaces;
using VIN.Domain.Model;
using VIN.Infra.Data.Context.Interfaces;

namespace VIN.Infra.Data.Repository.DB
{
    /// <summary>
    /// Repository for Vehicles
    /// </summary>
    public class VehiclesRepository : BaseRepository<Vehicles>, IVehiclesRepository
    {
        public VehiclesRepository(IUnitOfWork uow) : base(uow) { }
    }
}
