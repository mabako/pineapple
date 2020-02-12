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
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration to set up the environment with.</param>
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        protected override void ConfigureCommonServices(IServiceCollection services)
        {
            base.ConfigureCommonServices(services);

            services.AddPresenters();
            services.AddCommands();
            services.AddSingleton<CommandMapper>();
        }
    }
}
