using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //we ensures that the database for the context exists
            var host  = CreateHostBuilder(args).Build();
            using (var scope  = host.Services.CreateScope())
            {

                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<Models.JobBoardContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService <ILogger<Program>> ();
                    logger.LogError(ex, "An Error ocurred creating the Database");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
