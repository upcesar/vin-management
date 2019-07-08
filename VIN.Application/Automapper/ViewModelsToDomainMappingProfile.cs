using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VIN.Application.ViewModel;
using VIN.Domain.Commands;
using VIN.Domain.Enum;
using VIN.Domain.Model;

namespace VIN.Application.Automapper
{
    public class ViewModelsToDomainMappingProfile : Profile
    {
        public ViewModelsToDomainMappingProfile()
        {
            CreateMap<VehicleViewModel, InsertVehicleCommand>()
                .ConstructUsing(c => new InsertVehicleCommand(c.ChassisNumber, (VehicleType)c.VehicleType, c.Color));

            CreateMap<VehicleViewModel, UpdateVehicleCommand>()
                .ConstructUsing(c => new UpdateVehicleCommand(c.Id, c.ChassisNumber, (VehicleType)c.VehicleType, c.Color));

        }
    }
}
