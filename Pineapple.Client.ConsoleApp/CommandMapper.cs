using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using Pineapple.Client.ConsoleApp.UseCases.CreatePage;
using Pineapple.Client.ConsoleApp.UseCases.CreateSpace;
using Pineapple.Client.ConsoleApp.UseCases.ListSpaces;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp
{
    /// <summary>
    /// Mapping between command line and actual services.
    /// </summary>
    internal sealed class CommandMapper
    {
        private readonly RootCommand _rootCommand;

        public CommandMapper(CreateSpaceCommand createSpaceCommand, ListSpacesCommand listSpacesCommand,
            CreatePageCommand createPageCommand)
        {
            #region Spaces Commands

            Command createSpace = new Command("create-space")
            {
                new Argument<SpaceName>("name")
            };
            createSpace.Description = "Creates a new space.";
            createSpace.Handler = CommandHandler.Create<SpaceName>(createSpaceCommand.CreateSpace);

            Command listSpaces = new Command("list-spaces");
            listSpaces.Description = "Shows a list of all currently existing spaces.";
            listSpaces.Handler = CommandHandler.Create(listSpacesCommand.ListSpaces);

            #endregion

            #region Pages Command

            Command createPage = new Command("create-page")
            {
                new Argument<SpaceName>("space")
                {
                    Description = "parent space for the new page"
                },
                new Argument<PageName>("page")
                {
                    Description = "page name"
                },
                new Argument<FileInfo>("file")
                {
                    Description = "file to read the content from"
                },
            };
            createPage.Description = "Creates a new page within a space.";
            createPage.Handler = CommandHandler.Create<SpaceName, PageName, FileInfo>(createPageCommand.CreatePage);

            #endregion

            _rootCommand = new RootCommand()
            {
                // spaces
                createSpace,
                listSpaces,

                // pages
                createPage,
            };
        }

        public Task InvokeAsync(string[] args) => _rootCommand.InvokeAsync(args);
    }
}
