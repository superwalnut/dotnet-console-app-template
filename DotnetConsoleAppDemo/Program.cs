using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using ManyConsole;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DotnetConsoleDemo
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var startup = new Startup();
            var serviceProvider = startup.BuildContainer();

            //TODO code
            var logger = serviceProvider.GetService<ILogger>();
            logger.Information("hello world");

            Console.WriteLine("to be continued...");
        }
    }
}
