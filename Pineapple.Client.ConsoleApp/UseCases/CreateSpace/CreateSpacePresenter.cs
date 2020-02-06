using System;
using Pineapple.Application.Boundaries.CreateSpace;

namespace Pineapple.Client.ConsoleApp.UseCases.CreateSpace
{
    /// <inheritdoc cref="IOutputPort"/>
    public sealed class CreateSpacePresenter : IOutputPort
    {
        /// <inheritdoc />
        public void Standard(CreateSpaceOutput output) => Console.WriteLine($"Created space {output.Space.Name}.");

        /// <inheritdoc />
        public void SpaceAlreadyExists(string message) => Console.WriteLine($"ERROR: {message}");

        /// <inheritdoc />
        public void UnableToCreateSpace(string message) => Console.WriteLine($"ERROR: {message}");
    }
}
