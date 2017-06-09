using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using IdentityServer4.Validation;
using Microsoft.AspNet.Identity;
using IdentityServer4.Services;
using IdentityServer4.AspNetIdentity;
using Dockway.Presentation.Authentication.Core;
using Docway.Application.Authentication.Interfaces;
using Docway.Application.Authentication.Services;
using Docway.Infra.Data.Repository;
using Docway.Domain.Interfaces;
using Docway.Domain.Interfaces.Repository;
using Docway.Infra.Data.Context;

namespace Dockway.Presentation.Authentication
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
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            var cart = new X509Certificate2(Path.Combine(_env.ContentRootPath, "idsrv3test.pfx"), "idsrv3test");

            services.AddMvc();

            services.AddIdentityServer()
              .AddSigningCredential(cart)
              .AddInMemoryPersistedGrants()
              .AddInMemoryApiResources(Config.GetApiResources())
              .AddInMemoryClients(Config.GetClients());

            services
                .AddTransient<IResourceOwnerPasswordValidator, DocwayPasswordValidator>()
                .AddTransient<IUserAppService, UserAppService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddScoped<DocwayContext>(repoFactory)
                .AddTransient<IProfileService, ProfileService>();
        }


        private static readonly Func<IServiceProvider, DocwayContext> repoFactory = (_) =>
        {
            return new DocwayContext(@"Integrated Security=SSPI;Persist Security Info=False;User ID=SA;Initial Catalog=Docway;Data Source=localhost\SQLEXPRESS");
        };

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentityServer();
        }
    }
}
