using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIN.Application.Interfaces;

namespace VIN.Application.Automapper
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        private static AutoMapperConfig instance;

        public static AutoMapperConfig GetInstance()
        {
            instance = instance ?? new AutoMapperConfig();
            return instance;
        }

        public MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                var profileMappingList = new List<Profile>()
                {
                    new DomainToViewModelsMappingProfile(),
                    //new EntitiesToResultMappingProfile(),
                };

                profileMappingList.AsParallel().ToList().ForEach(profile => cfg.AddProfile(profile));

            });
        }
    }
}
