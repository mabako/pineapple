using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Infrastructure.DataAccess.Git;
using Pineapple.Infrastructure.DataAccess.Git.Repositories;

namespace Pineapple.Client.DependencyInjection
{
    /// <summary>
    /// Sets up the git-backed infrastructure.
    /// </summary>
    public static class GitInfrastructureExtension
    {
        /// <summary>
        /// Adds git-based persistence implementations.
        /// </summary>
        /// <param name="services">The service collection to add the git-based persistence to.</param>
        public static void AddGitPersistence(this IServiceCollection services)
        {
            services.AddScoped<ISpaceFactory, GitEntityFactory>();
            services.AddScoped<IPageFactory, GitEntityFactory>();

            services.AddScoped<ISpaceRepository, SpaceRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
        }
    }
}
