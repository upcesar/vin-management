﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VIN_Management
{
    public class Program
    {
        public static void Main(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                      .ConfigureAppConfiguration((hostingContext, config) 
                            => config.SetBasePath(Directory.GetCurrentDirectory())
                                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
                      .UseStartup<Startup>()
                      .Build()
                      .Run();
    }
}
