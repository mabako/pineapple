using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Pineapple.Infrastructure.DataAccess.InMemory.Repositories;

namespace Pineapple.Client.DependencyInjection
{
    /// <summary>
    /// Sets up in-memory-backed infrastructure.
    /// </summary>
    public static class InMemoryInfrastructureExtension
    {
        /// <summary>
        /// Adds in-memory-based persistence implementations.
        /// </summary>
        /// <param name="services">The service collection to add the in-memory-based to.</param>
        public static void AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<ISpaceFactory, InMemoryEntityFactory>();
            services.AddScoped<IPageFactory, InMemoryEntityFactory>();

            services.AddSingleton<InMemoryContext, InMemoryContext>();

            services.AddScoped<ISpaceRepository, SpaceRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
        }
    }
}
