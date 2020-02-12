using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pineapple.Domain;
using Pineapple.Infrastructure.DataAccess.Git.Configuration;

namespace Pineapple.Client.ConsoleApp
{
    /// <summary>
    /// Starting point for the console app.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Starts the program.
        /// </summary>
        /// <param name="args">The arguments to pass to the command.</param>
        /// <returns>Task.</returns>
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = LoadConfiguration();
            IHostEnvironment env = new ConsoleHostEnvironment(configuration);
            ServiceProvider serviceProvider = ConfigureServiceProvider(configuration, env);

            Task t = serviceProvider.GetService<CommandMapper>().InvokeAsync(args);
            try
            {
                await t;
            }
            catch (TargetInvocationException e) when (e.InnerException is DomainException de)
            {
                Console.WriteLine($"ERROR: {de.Message}");
            }
        }

        private static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        private static ServiceProvider ConfigureServiceProvider(IConfiguration configuration, IHostEnvironment env)
        {
            var services = new ServiceCollection();

            services.Configure<GitConfiguration>(configuration.GetSection("Git"));

            Startup startup = new Startup(configuration);
            if (env.IsProduction())
            {
                startup.ConfigureProductionServices(services);
            }
            else
            {
                startup.ConfigureServices(services);
            }

            services.AddTransient<CommandMapper>();
            return services.BuildServiceProvider();
        }
    }
}
