using DepositoHelados.Middlewares;

namespace DepositoHelados.Builder;

public static class AppConfigure
{
    public static void Configure(WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthorization()
            .UseAuthorization()
            .UseRouting()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}