using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.ConsoleApp.UseCases.CreatePage;
using Pineapple.Client.ConsoleApp.UseCases.CreateSpace;
using Pineapple.Client.ConsoleApp.UseCases.ListSpaces;

namespace Pineapple.Client.ConsoleApp.Extensions
{
    /// <summary>
    /// Extends the service collection with individual commands.
    /// </summary>
    public static class CommandsExtension
    {
        /// <summary>
        /// Initializes all known commands.
        /// </summary>
        /// <param name="services">The service collection to add the commands to.</param>
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<CreateSpaceCommand>();
            services.AddTransient<ListSpacesCommand>();
            services.AddTransient<CreatePageCommand>();
        }
    }
}
