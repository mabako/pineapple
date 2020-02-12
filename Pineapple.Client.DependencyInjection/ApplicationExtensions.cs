using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using AppUseCases = Pineapple.Application.UseCases;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.DependencyInjection
{
    /// <summary>
    /// Configures all use cases to their implementation types.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Adds all use case implementations as implementations of their interface types.
        /// </summary>
        /// <param name="services">The service collection to to configure.</param>
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Boundaries.CreateSpace.IUseCase, AppUseCases.CreateSpace>();
            services.AddScoped<Boundaries.ListSpaces.IUseCase, AppUseCases.ListSpaces>();
            services.AddScoped<Boundaries.CreatePage.IUseCase, AppUseCases.CreatePage>();

            services.AddScoped<SpaceService, SpaceService>();
            services.AddScoped<PageService, PageService>();
        }
    }
}
