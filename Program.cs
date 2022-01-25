using Meta.IntroApp.FixedValues;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Meta.IntroApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //Initialize application
            InitializeDb(host);
            InitConstantValues(host);

            //Run Application
            host.Run();
        }

        /// <summary>
        /// initializ the database
        /// </summary>
        /// <param name="host"></param>
        private static void InitializeDb(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MetaITechDbContext>();
                context.Database.Migrate();
                //DataSeed.Seed(context);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .ConfigureLogging((logging) =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                 })
                .UseStartup<Startup>()
            ;

        /// <summary>
        /// Initialize contant values in the application
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        private static Task InitConstantValues(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var appSettings = services.GetRequiredService<IConfiguration>();
                AppRuntimeConstants.ImagesSiteUrl = appSettings.GetValue<string>("ContentUrl");
                AppRuntimeConstants.ContentFolderPhysicalPath = appSettings.GetValue<string>("ContentFolder");
                AppRuntimeConstants.ContentFilesFolderPhysicalPath = appSettings.GetValue<string>("ContentFilesFolder");
            }

            return Task.CompletedTask;
        }

    }
}