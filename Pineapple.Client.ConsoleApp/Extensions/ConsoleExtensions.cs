using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.ConsoleApp.UseCases.CreatePage;
using Pineapple.Client.ConsoleApp.UseCases.CreateSpace;
using Pineapple.Client.ConsoleApp.UseCases.ListSpaces;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.ConsoleApp.Extensions
{
    /// <summary>
    /// Initializes all output ports.
    /// </summary>
    public static class ConsoleExtensions
    {
        /// <summary>
        /// Initializes all presenters/output ports for console commands.
        /// </summary>
        /// <param name="services">The service collection to add the presenters to.</param>
        public static void AddPresenters(this IServiceCollection services)
        {
            services.AddUseCase<Boundaries.CreateSpace.IOutputPort, CreateSpacePresenter>();
            services.AddUseCase<Boundaries.ListSpaces.IOutputPort, ListSpacesPresenter>();
            services.AddUseCase<Boundaries.CreatePage.IOutputPort, CreatePagePresenter>();
        }

        private static void AddUseCase<TOutputPort, [MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] TPresenter>(this IServiceCollection services)
            where TOutputPort : class
            where TPresenter : class, TOutputPort
        {
            services.AddTransient<TPresenter, TPresenter>();
            services.AddTransient<TOutputPort>(x => x.GetRequiredService<TPresenter>());
        }
    }
}
