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
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public sealed class Startup : CommonStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureCommonServices(IServiceCollection services)
        {
            services.Configure<GitConfiguration>(Configuration.GetSection("Git"));

            base.ConfigureCommonServices(services);

            services.AddControllers().AddControllersAsServices();
            services.AddMvcCore(options => options.Filters.Add(typeof(DomainExceptionFilter)));
            services.AddPresenters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "pineapple api", Version = "v1"});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.EnableAnnotations();
            });

            // the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
    }
}
