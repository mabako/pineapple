using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pineapple.Client.DependencyInjection
{
    /// <summary>
    /// Common startup configuration between web and console based clients.
    /// </summary>
    public abstract class CommonStartup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonStartup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration to set up the environment with.</param>
        protected CommonStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the environment configuration.
        /// </summary>
        protected IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services if in a production environment.
        /// </summary>
        /// <param name="services">The service collection to to configure.</param>
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddInMemoryPersistence();

            ConfigureCommonServices(services);
        }

        /// <summary>
        /// Configures the services if in a non-production environment, such as test or development.
        /// </summary>
        /// <param name="services">The service collection to to configure.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGitPersistence();

            ConfigureCommonServices(services);
        }

        /// <summary>
        /// Configures common services available in both production and non-production environments.
        /// </summary>
        /// <param name="services">The service collection to to configure.</param>
        protected virtual void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddUseCases();
            services.AddMediator();
        }
    }
}
