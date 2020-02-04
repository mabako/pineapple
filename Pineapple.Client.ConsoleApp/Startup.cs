using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.ConsoleApp.Extensions;
using Pineapple.Client.DependencyInjection;

namespace Pineapple.Client.ConsoleApp
{
    /// <summary>
    /// Startup configuration for the console app.
    /// </summary>
    public sealed class Startup : CommonStartup
    {
        /// <summary>
        /// Creates a new instance of <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">the configuration</param>
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        /// <inheritdoc />
        protected override void ConfigureCommonServices(IServiceCollection services)
        {
            base.ConfigureCommonServices(services);

            services.AddPresenters();
            services.AddCommands();
            services.AddScoped<CommandMapper>();
        }
    }
}
