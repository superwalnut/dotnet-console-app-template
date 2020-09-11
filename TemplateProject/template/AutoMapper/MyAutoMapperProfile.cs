using System;
using AutoMapper;
using DotnetConsoleDemo.Models;

namespace DotnetConsoleDemo.AutoMapper
{
    public class MyAutoMapperProfile : Profile
    {
        public MyAutoMapperProfile()
        {
            CreateMap<Foo, FooDto>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
