using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pineapple.Client.DependencyInjection;
using Pineapple.Client.Web.React.DependencyInjection;
using Pineapple.Client.Web.React.Filters;
using Pineapple.Infrastructure.DataAccess.Git.Configuration;

namespace Pineapple.Client.Web.React
{
    /// <summary>
    /// Startup configuration for asp.net core.
    /// </summary>
    public sealed class Startup : CommonStartup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration to set up the environment with.</param>
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application to configure.</param>
        /// <param name="env">The environment that was set up by asp.net based on environment variables, configuration etc.</param>
        [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "This method gets called by the runtime only.")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger(c => { c.RouteTemplate = "$/swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "pineapple api";
                c.RoutePrefix = "$/swagger";
                c.SwaggerEndpoint("/$/swagger/v1/swagger.json", "pineapple api v1");
            });

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        /// <inheritdoc/>
        protected override void ConfigureCommonServices(IServiceCollection services)
        {
            services.Configure<GitConfiguration>(Configuration.GetSection("Git"));

            base.ConfigureCommonServices(services);

            services.AddControllers().AddControllersAsServices();
            services.AddMvcCore(options => options.Filters.Add(typeof(DomainExceptionFilter)));
            services.AddPresenters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "pineapple api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.EnableAnnotations();
            });

            // the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        }
    }
}
