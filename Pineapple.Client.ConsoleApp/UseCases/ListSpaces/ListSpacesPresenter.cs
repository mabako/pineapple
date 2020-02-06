using System;
using System.Linq;
using Pineapple.Application.Boundaries.ListSpaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp.UseCases.ListSpaces
{
    /// <inheritdoc />
    public sealed class ListSpacesPresenter : IOutputPort
    {
        public void Standard(ListSpacesOutput output)
        {
            var spaces = output.ExistingSpaces.GetSpaceNames();
            if (spaces.Any())
            {
                foreach (SpaceName spaceName in spaces)
                    Console.WriteLine($"* {spaceName}");
            }
            else
            {
                Console.WriteLine("No spaces exist.");
            }
        }
    }
}
