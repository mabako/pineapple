using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Pineapple.Client.Web.React
{
    /// <summary>
    /// Starting point for the asp.net app.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Starts the web server.
        /// </summary>
        /// <param name="args">The arguments to pass to the host builder.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
