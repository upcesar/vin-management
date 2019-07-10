using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public VehiclesService(IMapper mapper, IVehiclesRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
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

        public bool Insert(VehicleViewModel vehicle)
        {
            var vehicleCommand = mapper.Map<InsertVehicleCommand>(vehicle);
            vehicleCommand.SetNumberOfPassenger();

            if (vehicleCommand.IsValid())
            {
                var entity = new Vehicles(vehicleCommand.ChassisNumber, vehicleCommand.VehicleType.GetHashCode(), vehicleCommand.Color, vehicleCommand.NumPassengers);
                var inserted = repository.Insert(entity);
                return inserted;
            }

            return false;
        }

        public bool Update(VehicleViewModel vehicle)
        {
            var vehicleCommand = mapper.Map<UpdateVehicleCommand>(vehicle);
            vehicleCommand.SetNumberOfPassenger();

            if (vehicleCommand.IsValid())
            {
                var entity = new Vehicles(vehicleCommand.Id, vehicleCommand.ChassisNumber, vehicleCommand.VehicleType.GetHashCode(), vehicleCommand.Color, vehicleCommand.NumPassengers);
                var updated = repository.Update(entity);
                return updated;
            }

            return false;
        }

        public bool Delete(string id)
        {
            var vehicleCommand = new DeleteVehicleCommand(id);

            if (vehicleCommand.IsValid())
            {
                var entity = new Vehicles(vehicleCommand.Id);
                var deleted = repository.Delete(entity);
                return deleted;
            }

            return false;
        }
    }
}
