using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pineapple.Client.DependencyInjection
{
    public abstract class CommonStartup
    {
        protected CommonStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures common services.
        /// </summary>
        /// <param name="services">service collection</param>
        protected virtual void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddUseCases();
            services.AddMediator();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddInMemoryPersistence();

            ConfigureCommonServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInMemoryPersistence();

            ConfigureCommonServices(services);
        }
    }
}
