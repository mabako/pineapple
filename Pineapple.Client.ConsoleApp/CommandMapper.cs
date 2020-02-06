using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Pineapple.Client.ConsoleApp.UseCases.CreateSpace;
using Pineapple.Client.ConsoleApp.UseCases.ListSpaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp
{
    /// <summary>
    /// Mapping between command line and actual services.
    /// </summary>
    internal sealed class CommandMapper
    {
        private readonly RootCommand _rootCommand;

        public CommandMapper(CreateSpaceCommand createSpaceCommand, ListSpacesCommand listSpacesCommand)
        {
            #region Spaces Commands

            Command createSpace = new Command("create-space")
            {
                new Argument<SpaceName>("name")
            };
            createSpace.Handler = CommandHandler.Create<SpaceName>(createSpaceCommand.CreateSpace);

            Command listSpaces = new Command("list-spaces");
            listSpaces.Handler = CommandHandler.Create(listSpacesCommand.ListSpaces);

            #endregion

            _rootCommand = new RootCommand()
            {
                createSpace,
                listSpaces,
            };
        }

        public Task InvokeAsync(string[] args) => _rootCommand.InvokeAsync(args);
    }
}
