using System;
using Pineapple.Application.Boundaries.CreatePage;

namespace Pineapple.Client.ConsoleApp.UseCases.CreatePage
{
    /// <inheritdoc cref="IOutputPort"/>
    public sealed class CreatePagePresenter : IOutputPort
    {
        /// <inheritdoc/>
        public void Standard(CreatePageOutput output) => Console.WriteLine($"Created page {output.Page.Name}.");

        /// <inheritdoc/>
        public void SpaceNotFound(string message) => Console.WriteLine($"ERROR: {message}");

        /// <inheritdoc/>
        public void PageAlreadyExists(string message) => Console.WriteLine($"ERROR: {message}");

        /// <inheritdoc/>
        public void UnableToCreatePage(string message) => Console.WriteLine($"ERROR: {message}");
    }
}
