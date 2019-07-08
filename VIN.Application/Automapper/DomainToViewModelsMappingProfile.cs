using AutoMapper;
using VIN.Application.ViewModel;
using VIN.Domain.Commands;
using VIN.Domain.Model;

namespace VIN.Application.Automapper
{
    public class DomainToViewModelsMappingProfile : Profile
    {
        public DomainToViewModelsMappingProfile()
        {
            CreateMap<Vehicles, VehicleViewModel>()
                .ForAllOtherMembers(opt => opt.AllowNull());

        }
    }
}
