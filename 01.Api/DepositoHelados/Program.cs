
using DepositoHelados.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionDefault"]));

builder.Services
    .AddHttpContextAccessor()
    .AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization()
    .UseAuthorization()
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

app.Run();
