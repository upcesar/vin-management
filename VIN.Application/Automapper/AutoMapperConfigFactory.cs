using System;
using VIN.Application.Interfaces;

namespace VIN.Application.Automapper
{
    public static class AutoMapperConfigFactory<T>
        where T : class, IAutoMapperConfig, new()
    {
        private static T instance;

        public static T Create()
        {
            instance = instance ?? Activator.CreateInstance<T>();
            return instance;
        }
    }
}
