using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.DependencyInjection
{
    /// <summary>
    /// Adds a mediator for the given messages.
    /// </summary>
    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.AddUseCase<Boundaries.CreateSpace.IUseCase, Boundaries.CreateSpace.CreateSpaceInput>();
                    builder.AddUseCase<Boundaries.ListSpaces.IUseCase, Boundaries.ListSpaces.ListSpacesInput>();
                }
            );

            return services;
        }

        private static void AddUseCase<TUseCase, TInput>(this IPipelineProviderBuilder builder)
            where TInput : Boundaries.IUseCaseInput
            where TUseCase : Boundaries.IUseCase<TInput>
        {
            builder.On<TInput>().PipelineAsync()
                .Call<TUseCase>((handler, request) => handler.Execute(request));
        }
    }
}
