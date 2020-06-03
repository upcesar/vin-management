using AutoMapper;
using VIN.Application.ViewModel;
using VIN.Domain.Commands;

namespace VIN.Application.Automapper
{
    public class ViewModelsToDomainMappingProfile : Profile
    {
        public ViewModelsToDomainMappingProfile()
        {
            CreateMap<VehicleViewModel, InsertVehicleCommand>()
                .ConstructUsing(c => new InsertVehicleCommand(c.ChassisNumber, c.VehicleType, c.Color))
                .ForMember(c => c.VehicleType, opt => opt.Ignore());

            CreateMap<VehicleViewModel, UpdateVehicleCommand>()
                .ConstructUsing(c => new UpdateVehicleCommand(c.Id, c.ChassisNumber, c.VehicleType, c.Color))
                .ForMember(c => c.VehicleType, opt => opt.Ignore());

        }
    }
}
