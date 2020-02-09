using System;
using Pineapple.Application.Boundaries.CreatePage;

namespace Pineapple.Client.ConsoleApp.UseCases.CreatePage
{
    /// <inheritdoc cref="IOutputPort"/>
    public sealed class CreatePagePresenter : IOutputPort
    {
        public void Standard(CreatePageOutput output) => Console.WriteLine($"Created page {output.Page.Name}.");

        public void SpaceNotFound(string message) => Console.WriteLine($"ERROR: {message}");

        public void PageAlreadyExists(string message) => Console.WriteLine($"ERROR: {message}");

        public void UnableToCreatePage(string message) => Console.WriteLine($"ERROR: {message}");
    }
}
