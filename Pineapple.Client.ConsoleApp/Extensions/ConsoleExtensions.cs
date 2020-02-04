using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.ConsoleApp.UseCases.Spaces;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.ConsoleApp.Extensions
{
    /// <summary>
    /// Initializes all output ports.
    /// </summary>
    public static class ConsoleExtensions
    {
        /// <summary>
        /// Initializes all presenters/output ports for console.
        /// </summary>
        /// <param name="services">services collection</param>
        /// <returns>the same services collection</returns>
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddUseCase<Boundaries.CreateSpace.IOutputPort, CreateSpacePresenter>();

            return services;
        }

        private static void AddUseCase<TOutputPort, TPresenter>(this IServiceCollection services)
            where TOutputPort : class
            where TPresenter : class, TOutputPort
        {
            services.AddScoped<TPresenter, TPresenter>();
            services.AddScoped<TOutputPort>(x => x.GetRequiredService<TPresenter>());
        }
    }
}
