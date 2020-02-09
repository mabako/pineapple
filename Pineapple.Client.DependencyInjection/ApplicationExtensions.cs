using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Boundaries = Pineapple.Application.Boundaries;
using AppUseCases = Pineapple.Application.UseCases;

namespace Pineapple.Client.DependencyInjection
{
    /// <summary>
    /// Adds Use Cases.
    /// </summary>
    public static class ApplicationExtensions
    {
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
