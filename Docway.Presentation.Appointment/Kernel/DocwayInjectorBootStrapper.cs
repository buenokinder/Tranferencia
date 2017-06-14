using AutoMapper;
using Docway.Domain.Core.Bus;
using Docway.Domain.Core.Events;
using Docway.Domain.Interfaces;
using Docway.Domain.Interfaces.Repository;
using Docway.Infra.CrossCutting.Identity;
using Docway.Infra.Data.Context;
using Docway.Infra.Data.EventSourcing;
using Docway.Infra.Data.Repository.EventSourcing;
using Docway.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docway.Presentation.Appointment.Kernel
{
    public class DocwayInjectorBootStrapper
    {
        private static readonly Func<IServiceProvider, DocwayContext> repoFactory = (_) =>
        {
            return new DocwayContext(@"Server=tcp:docwaymicroservices.database.windows.net,1433;Initial Catalog=docway_microservices;Persist Security Info=False;User ID=docwaymicroservices;Password=@G08uCaEdDocW@yDev;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        };


        private static readonly Func<IServiceProvider, EventStoreSQLContext> repoFactoryEvent = (_) =>
        {
            return new EventStoreSQLContext(@"Server=tcp:docwaymicroservices.database.windows.net,1433;Initial Catalog=docway_microservices;Persist Security Info=False;User ID=docwaymicroservices;Password=@G08uCaEdDocW@yDev;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        };

        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            //services.AddScoped<IPatientAppService, PatientAppService>();

            //// Domain - Events
            //services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<IHandler<PatientRegisteredEvent>, PatientEventHandler>();
            //services.AddScoped<IHandler<PatientUpdatedEvent>, PatientEventHandler>();
            //services.AddScoped<IHandler<PatientRemovedEvent>, PatientEventHandler>();

            //// Domain - Commands
            //services.AddScoped<IHandler<RegisterNewPatientCommand>, PatientCommandHandler>();
            //services.AddScoped<IHandler<AddDependentCommand>, PatientCommandHandler>();
            //services.AddScoped<IHandler<UpdatePatientCommand>, PatientCommandHandler>();
            //services.AddScoped<IHandler<RemovePatientCommand>, PatientCommandHandler>();

            // Infra - Data
            // services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DocwayContext>(repoFactory);

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>(repoFactoryEvent);

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}

