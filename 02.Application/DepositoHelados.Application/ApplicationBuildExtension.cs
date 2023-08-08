

using DepositoHelados.Application.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DepositoHelados.Application;

public static class ApplicationBuildExtension
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(typeof(MappingConfiguration).GetTypeInfo().Assembly);
        services.AddValidatorsFromAssembly(typeof(Assembly).Assembly);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
