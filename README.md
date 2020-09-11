# Project Template - .Net Core 3.1 Console app + Autofac + Serilog + AutoMapper

> This is a project template for .Net Core 3.1 Console app,
    pre-configured Autofac, Serilog, AutoMapper, Newtonsoft.Json
    using `dotnet new -i Superwalnut.NetCoreConsoleTemplate` to install project as a template,
    And using `dotnet new core-console-autofac` to create a project with the template.

**Pre-request**

- .Net Core 3.1
- [Autofac](https://autofac.org/)
- [Serilog](https://serilog.net/)
- [AutoMapper](https://automapper.org/)

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Support](#support)
- [License](#license)

---

## Features

> This is a development project template, it is NOT production ready. It only kickstarting your project so that you don't need to build from scratch.

1. pre-Configured Autofac 5.2.0 registrations setup.
2. pre-Configured Serilog 2.9.0 console sinks.
3. pre-Configured AutoMapper 10.0.0.
4. pre-Installed Newtonsoft.Json 12.0.3

---

## Installation

- Using `dotnet new -i <package>` to install the project template from nuget [Superwalnut.NetCoreConsoleTemplate](https://www.nuget.org/packages/Superwalnut.NetCoreConsoleTemplate/)

```shell
$ dotnet new -i Superwalnut.NetCoreConsoleTemplate
```

You should see '.Net Core Console Autofac+Serilog' in your template list by `dotnet new -l`

- Using `dotnet new core-console-autofac -n <your-project-name>` to create a project with your own project name using this template

```shell
$ dotnet new core-console-autofac -n NetCoreDemo -o NetCoreDemo
```

This creates a project in folder `NetCoreDemo`

---


## Documentation

### Pre-configured Autofac 

ContainerBuilder() that you can populate IServiceCollection and register your autofac modules in Startup.cs. Taking ApiModule from the template as an example, you can also create modules for your Service Layer, Repository Layer, etc.

```c#
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ...
            builder.RegisterModule<ConsoleModule>();

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
```

Serilog & Automapper are registered in the ApiModule,

```c#
    public class ConsoleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddAutoMapper(x=>x.AddProfile<MyAutoMapperProfile>());
        }
    }
```

### Pre-configured Serilog 

With console sinks in the appsettings.json

```json
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console" ],
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "Console"        
      }
    ]
  }
```

And Serilog configuration in the startup.cs

```c#
        public static void CreateLogger(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
```

### Pre-configured AutoMapper 

With created example profile,

```c#
    public class MyAutoMapperProfile : Profile
    {
        public MyAutoMapperProfile()
        {
            CreateMap<Foo, FooDto>();
            ...
        }
    }
```

And register the profile in ApiModule for AutoMapper,

```c#
    public class ConsoleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ...
            builder.AddAutoMapper(x=>x.AddProfile<MyAutoMapperProfile>());
        }
    }
```

## Support

Reach out to me at one of the following places!

- [Follow me @ Github](https://github.com/superwalnut)

- [Twitter](https://twitter.com/superwalnuts)

- [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z61I9HB)

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**

-------
