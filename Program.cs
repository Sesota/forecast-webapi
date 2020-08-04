using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ForecastApi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      CreateDbIfNotExists(host);
      host.Run();
    }

    private static void CreateDbIfNotExists(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;

        try
        {
          var context = services.GetRequiredService<DatabaseContext>();
          // context.Database.EnsureCreated();  // For Production
          DatabaseInitializer.Initialize(context);  // For Testing
        }
        catch (Exception e)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(e, "An error occured creating the DB.");
        }
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}