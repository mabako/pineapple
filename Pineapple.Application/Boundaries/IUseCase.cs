using System.Threading.Tasks;

namespace Pineapple.Application.Boundaries
{
    /// <summary>
    /// Use Case.
    /// </summary>
    /// <typeparam name="TInput">The type of the input message.</typeparam>
    public interface IUseCase<in TInput>
        where TInput : IUseCaseInput
    {
        /// <summary>
        /// Executes the given use case.
        /// </summary>
        /// <param name="input">The input message to process.</param>
        /// <returns>Task.</returns>
        Task Execute(TInput input);
    }
}
