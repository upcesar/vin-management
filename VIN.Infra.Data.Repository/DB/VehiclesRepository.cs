using Dapper;
using System.Collections.Generic;
using System.Linq;
using VIN.Domain.Model;
using VIN.Infra.Data.Context.Interfaces;
using VIN.Infra.Data.Repository.DB.Interfaces;

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
