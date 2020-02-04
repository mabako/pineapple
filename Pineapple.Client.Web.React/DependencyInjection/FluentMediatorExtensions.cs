using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using Pineapple.Application.Boundaries.CreateSpace;
using Boundaries = Pineapple.Application.Boundaries;

namespace Pineapple.Client.Web.React.DependencyInjection
{
    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.AddUseCase<Boundaries.CreateSpace.IUseCase, CreateSpaceInput>();
                }
            );

            return services;
        }

        private static IPipelineProviderBuilder AddUseCase<TUseCase, TInput>(this IPipelineProviderBuilder builder)
            where TInput : Boundaries.IUseCaseInput
            where TUseCase : Boundaries.IUseCase<TInput>
        {
            builder.On<TInput>().PipelineAsync()
                .Call<TUseCase>((handler, request) => handler.Execute(request));

            return builder;
        }
    }
}
