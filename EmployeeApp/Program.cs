using EmployeeApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeApp;

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var serviceScope = host.Services.CreateScope();
        var services = serviceScope.ServiceProvider;

        var app = services.GetRequiredService<App>();
        app.Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(services=>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer("Server=localhost,1433;Database=employeeapp;User Id=aleksasd;Password=Password123!;TrustServerCertificate=True;"));
                services.AddTransient<App>();
            });
}