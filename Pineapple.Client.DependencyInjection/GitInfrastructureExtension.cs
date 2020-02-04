using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Infrastructure.DataAccess.Git;
using Pineapple.Infrastructure.DataAccess.Git.Repositories;

namespace Pineapple.Client.DependencyInjection
{
    public static class GitInfrastructureExtension
    {
        public static IServiceCollection AddGitPersistence(this IServiceCollection services)
        {
            services.AddScoped<ISpaceFactory, GitEntityFactory>();
            services.AddScoped<IPageFactory, GitEntityFactory>();

            services.AddScoped<ISpaceRepository, SpaceRepository>();
            services.AddScoped<IPageRepository, PageRepository>();

            return services;
        }
    }
}
