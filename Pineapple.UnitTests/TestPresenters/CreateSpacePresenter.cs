using System.Collections.Generic;
using Pineapple.Application.Boundaries.CreateSpace;

namespace Pineapple.UnitTests.TestPresenters
{
    public sealed class CreateSpacePresenter : IOutputPort
    {
        public List<CreateSpaceOutput> CreatedSpaces { get; } = new List<CreateSpaceOutput>();

        public List<string> AlreadyExisting { get; } = new List<string>();

        public List<string> UnableToCreate { get; } = new List<string>();

        public void Standard(CreateSpaceOutput output) => CreatedSpaces.Add(output);

        public void SpaceAlreadyExists(string message) => AlreadyExisting.Add(message);

        public void UnableToCreateSpace(string message) => UnableToCreate.Add(message);
    }
}
