using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Pineapple.Client.ConsoleApp.UseCases.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp
{
    /// <summary>
    /// Mapping between command line and actual services.
    /// </summary>
    internal sealed class CommandMapper
    {
        private readonly RootCommand _rootCommand;

        public CommandMapper(SpacesCommands spacesCommands)
        {
            #region Spaces Commands

            Command createSpace = new Command("create-space")
            {
                new Argument<SpaceName>("name")
            };
            createSpace.Handler = CommandHandler.Create<SpaceName>(spacesCommands.CreateSpace);

            #endregion

            _rootCommand = new RootCommand()
            {
                createSpace,
            };
        }

        public Task InvokeAsync(string[] args) => _rootCommand.InvokeAsync(args);
    }
}
