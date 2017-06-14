using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Docway.Infra.CrossCutting.Identity;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Docway.Domain.Models;
using Docway.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNet.Identity.EntityFramework;
using Docway.Presentation.Appointment.Kernel;

namespace Docway.Presentation.Appointment
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            this._env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            if (!_env.IsDevelopment())
                services.Configure<MvcOptions>(o => o.Filters.Add(new RequireHttpsAttribute()));


            services.AddAutoMapper();

            RegisterServices(services);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "https://docwayauthdev.azurewebsites.net",
                RequireHttpsMetadata = false,
                ApiName = "api1"
            });

            // app.UseHsts(h => h.MaxAge(days: 20).Preload());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc();

            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }



        private static void RegisterServices(IServiceCollection services)
        {
            DocwayInjectorBootStrapper.RegisterServices(services);
        }

    }
}
