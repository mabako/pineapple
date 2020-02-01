using Microsoft.Extensions.DependencyInjection;
using Pineapple.Domain.Spaces;

namespace Pineapple.React.DependencyInjection
{
    /// <summary>
    /// Adds Use Cases.
    /// </summary>
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<SpaceService, SpaceService>();

            return services;
        }
    }
}
