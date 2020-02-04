using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.Web.React.UseCases.V1.CreateSpace;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.Web.React.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddUseCase<Boundaries.CreateSpace.IOutputPort, CreateSpacePresenter>();

            return services;
        }

        private static IServiceCollection AddUseCase<TOutputPort, TPresenter>(this IServiceCollection services)
            where TOutputPort : class
            where TPresenter : class, TOutputPort
        {
            services.AddScoped<TPresenter, TPresenter>();
            services.AddScoped<TOutputPort>(x => x.GetRequiredService<TPresenter>());

            return services;
        }
    }
}
