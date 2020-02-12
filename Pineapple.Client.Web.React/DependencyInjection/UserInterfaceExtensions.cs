using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.Web.React.UseCases.V1.CreatePage;
using Pineapple.Client.Web.React.UseCases.V1.CreateSpace;
using Pineapple.Client.Web.React.UseCases.V1.ListSpaces;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.Web.React.DependencyInjection
{
    /// <summary>
    /// Sets up the web-based user interface.
    /// </summary>
    public static class UserInterfaceExtensions
    {
        /// <summary>
        /// Adds all presenters for the web-based output.
        /// </summary>
        /// <param name="services">The service collection to add the presenters to.</param>
        public static void AddPresenters(this IServiceCollection services)
        {
            services.AddUseCase<Boundaries.CreateSpace.IOutputPort, CreateSpacePresenter>();
            services.AddUseCase<Boundaries.ListSpaces.IOutputPort, ListSpacesPresenter>();
            services.AddUseCase<Boundaries.CreatePage.IOutputPort, CreatePagePresenter>();
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
