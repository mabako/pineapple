using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Boundaries.CreateSpace.IUseCase, AppUseCases.CreateSpace>();

            services.AddScoped<SpaceService, SpaceService>();

            return services;
        }
    }
}
