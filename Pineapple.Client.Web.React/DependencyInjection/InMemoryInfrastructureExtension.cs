using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Pineapple.Infrastructure.DataAccess.InMemory.Repositories;

namespace Pineapple.Client.Web.React.DependencyInjection
{
    public static class InMemoryInfrastructureExtension
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<ISpaceFactory, InMemoryEntityFactory>();
            services.AddScoped<IPageFactory, InMemoryEntityFactory>();

            services.AddSingleton<InMemoryContext, InMemoryContext>();

            services.AddScoped<ISpaceRepository, SpaceRepository>();
            services.AddScoped<IPageRepository, PageRepository>();

            return services;
        }
    }
}
