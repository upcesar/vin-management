using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Application.Interfaces
{
    public interface IAutoMapperConfig
    {
        MapperConfiguration RegisterMappings();
    }
}
