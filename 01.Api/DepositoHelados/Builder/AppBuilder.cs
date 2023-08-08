using DepositoHelados.Application;
using DepositoHelados.Converters;
using DepositoHelados.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DepositoHelados.Builder;

public static class AppBuilder
{
    public static WebApplication GetApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionDefault"]))
            .AddMemoryCache()
            .AddApplicationConfig();


        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddHttpContextAccessor()
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DatetimeConverter());
                options.JsonSerializerOptions.Converters.Add(new TrimStringConverter());
            });

        builder.Services.AddSignalR();

        return builder.Build();
    }
}

