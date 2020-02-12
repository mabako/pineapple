using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Pineapple.Client.ConsoleApp
{
    /// <summary>
    /// Host environment implementation for the console app.
    /// </summary>
    internal sealed class ConsoleHostEnvironment : IHostEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHostEnvironment"/> class.
        /// </summary>
        /// <param name="configuration">The configuration of the console app.</param>
        public ConsoleHostEnvironment(IConfiguration configuration)
        {
            EnvironmentName = configuration.GetValue<string>("ENVIRONMENT");
            ApplicationName = AppDomain.CurrentDomain.FriendlyName;
            ContentRootPath = AppDomain.CurrentDomain.BaseDirectory;
            ContentRootFileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <inheritdoc/>
        public string EnvironmentName { get; set; }

        /// <inheritdoc/>
        public string ApplicationName { get; set; }

        /// <inheritdoc/>
        public string? ContentRootPath { get; set; }

        /// <inheritdoc/>
        public IFileProvider ContentRootFileProvider { get; set; }
    }
}
