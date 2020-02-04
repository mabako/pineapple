using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Pineapple.Domain;

namespace Pineapple.Client.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
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
                .Build();
        }

        private static ServiceProvider ConfigureServiceProvider(IConfiguration configuration, IHostEnvironment env)
        {
            Startup startup = new Startup(configuration);

            var services = new ServiceCollection();

            if (env.IsProduction())
                startup.ConfigureProductionServices(services);
            else
                startup.ConfigureServices(services);

            services.AddTransient<CommandMapper>();
            return services.BuildServiceProvider();
        }
    }

    internal sealed class ConsoleHostEnvironment : IHostEnvironment
    {
        public ConsoleHostEnvironment(IConfiguration configuration)
        {
            EnvironmentName = configuration.GetValue<string>("ENVIRONMENT");
            ApplicationName = AppDomain.CurrentDomain.FriendlyName;
            ContentRootPath = AppDomain.CurrentDomain.BaseDirectory;
            ContentRootFileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory);
        }

        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string ContentRootPath { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
    }
}
