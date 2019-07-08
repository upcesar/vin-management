using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VIN.Application.Interfaces;
using VIN.Application.ViewModel;
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

        public bool Insert(Vehicles vehicle) => throw new NotImplementedException();
        public bool Update(Vehicles vehicle) => throw new NotImplementedException();
        public bool Delete(Vehicles vehicle) => throw new NotImplementedException();
    }
}
