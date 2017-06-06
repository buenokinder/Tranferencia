using AutoMapper;
using Dockway.Application.Interfaces;
using Dockway.Application.Services;
using Docway.Domain.CommandHandlers;
using Docway.Domain.Commands.Patient;
using Docway.Domain.Core.Bus;
using Docway.Domain.Core.Events;
using Docway.Domain.Core.Notifications;
using Docway.Domain.EventHandlers;
using Docway.Domain.Events.Patient;
using Docway.Domain.Interfaces;
using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using Docway.Infra.CrossCutting.Identity;
using Docway.Infra.Data.Context;
using Docway.Infra.Data.EventSourcing;
using Docway.Infra.Data.Repository;
using Docway.Infra.Data.Repository.EventSourcing;
using Docway.Infra.Data.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Docway.Api
{
    public class DocwayInjectorBootStrapper
    {

        private static readonly Func<IServiceProvider, DocwayContext> repoFactory = (_) =>
        {
            return new DocwayContext(@"Integrated Security=SSPI;Persist Security Info=False;User ID=SA;Initial Catalog=Docway;Data Source=localhost\SQLEXPRESS");
        };


        private static readonly Func<IServiceProvider, EventStoreSQLContext> repoFactoryEvent = (_) =>
        {
            return new EventStoreSQLContext(@"Integrated Security=SSPI;Persist Security Info=False;User ID=SA;Initial Catalog=DocwayEvent;Data Source=localhost\SQLEXPRESS");
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
            services.AddScoped<IPatientAppService, PatientAppService>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<PatientRegisteredEvent>, PatientEventHandler>();
            services.AddScoped<IHandler<PatientUpdatedEvent>, PatientEventHandler>();
            services.AddScoped<IHandler<PatientRemovedEvent>, PatientEventHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<RegisterNewPatientCommand>, PatientCommandHandler>();
            services.AddScoped<IHandler<AddDependentCommand>, PatientCommandHandler>();
            services.AddScoped<IHandler<UpdatePatientCommand>, PatientCommandHandler>();
            services.AddScoped<IHandler<RemovePatientCommand>, PatientCommandHandler>();

            // Infra - Data
            services.AddScoped<IPatientRepository, PatientRepository>();
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
