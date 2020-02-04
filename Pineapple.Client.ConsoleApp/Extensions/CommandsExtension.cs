﻿using Microsoft.Extensions.DependencyInjection;
using Pineapple.Client.ConsoleApp.UseCases.Spaces;

namespace Pineapple.Client.ConsoleApp.Extensions
{
    /// <summary>
    /// Extends the service collection with individual commands.
    /// </summary>
    public static class CommandsExtension
    {
        /// <summary>
        /// Initializes all registered commands.
        /// </summary>
        /// <param name="services">services collection</param>
        /// <returns>the same services collection</returns>
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<SpacesCommands>();

            return services;
        }
    }
}
