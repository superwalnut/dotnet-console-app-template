using System;
namespace DotnetConsoleDemo.Modules
{
    using Autofac;
    using AutofacSerilogIntegration;
    using DotnetConsoleDemo.AutoMapper;
    using global::AutoMapper.Contrib.Autofac.DependencyInjection;
    using System.Linq;

    public class ConsoleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // To register dependencies
            builder.AddAutoMapper(x=>x.AddProfile<MyAutoMapperProfile>());
         }
    }
}
