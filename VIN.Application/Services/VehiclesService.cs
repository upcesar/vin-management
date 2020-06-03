using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIN.Application.Interfaces;
using VIN.Application.ViewModel;
using VIN.Domain.Commands;
using VIN.Domain.Interfaces;
using VIN.Domain.Model;

namespace VIN.Application.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IMapper mapper;
        private readonly IVehiclesRepository repository;
        private readonly IMediator mediator;

        public VehiclesService(IMapper mapper, IVehiclesRepository repository, IMediator mediator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.mediator = mediator;
        }

        public IEnumerable<VehicleViewModel> GetAll()
        {
            var vehicles = repository.GetAll().ToList();

            return mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);
        }

        public VehicleViewModel Get(string id)
        {
            var vehicle = repository.GetById(id);

            return mapper.Map<VehicleViewModel>(vehicle);
        }

        public async Task<bool> Insert(VehicleViewModel vehicle)
        {
            var vehicleCommand = mapper.Map<InsertVehicleCommand>(vehicle);

            return await mediator.Send(vehicleCommand);
        }

        public async Task<bool> Update(VehicleViewModel vehicle)
        {
            var vehicleCommand = mapper.Map<UpdateVehicleCommand>(vehicle);
            
            return await mediator.Send(vehicleCommand);
        }

        public async Task<bool> Delete(string id)
        {
            var vehicleCommand = new DeleteVehicleCommand(id);

            return await mediator.Send(vehicleCommand);
        }
    }
}
