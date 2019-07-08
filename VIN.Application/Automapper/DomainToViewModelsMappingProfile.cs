using AutoMapper;
using System;
using VIN.Application.ViewModel;
using VIN.Domain.Commands;
using VIN.Domain.Enum;
using VIN.Domain.Model;

namespace VIN.Application.Automapper
{
    public class DomainToViewModelsMappingProfile : Profile
    {
        public DomainToViewModelsMappingProfile()
        {
            CreateMap<Vehicles, VehicleViewModel>()
                .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => Enum.GetName(typeof(VehicleType), src.VehicleType)))
                .ForAllOtherMembers(opt => opt.AllowNull());

        }
    }
}
