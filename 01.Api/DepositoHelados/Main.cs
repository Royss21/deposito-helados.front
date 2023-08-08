using DepositoHelados.Builder;

namespace DepositoHelados;

public static class Main
{
    public static void Run(string[] args)
    {
        var app = AppBuilder.GetApp(args);

        AppConfigure.Configure(app);

        //app.MapGet("/", (ApplicationSetting s) => $"{s.Environment}");
        ProductController.RegisterEndpoints(app);
        EmployeeOrderProductController.RegisterEndpoints(app);
        OrderController.RegisterEndpoints(app);

        app.Run();
    }
}

