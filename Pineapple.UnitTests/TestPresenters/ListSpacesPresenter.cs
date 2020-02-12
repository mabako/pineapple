using System.Collections.Generic;
using Pineapple.Application.Boundaries.ListSpaces;

namespace Pineapple.UnitTests.TestPresenters
{
    public sealed class ListSpacesPresenter : IOutputPort
    {
        public List<ListSpacesOutput> ListedSpaces { get; } = new List<ListSpacesOutput>();

        public void Standard(ListSpacesOutput output) => ListedSpaces.Add(output);
    }
}
