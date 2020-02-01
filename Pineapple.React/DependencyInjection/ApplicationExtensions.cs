using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Spaces;
using Boundaries = Pineapple.Application.Boundaries;
using UseCases = Pineapple.Application.UseCases;

namespace Pineapple.React.DependencyInjection
{
    /// <summary>
    /// Adds Use Cases.
    /// </summary>
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Boundaries.CreateSpace.IUseCase, UseCases.CreateSpace>();

            services.AddScoped<SpaceService, SpaceService>();

            return services;
        }
    }
}
