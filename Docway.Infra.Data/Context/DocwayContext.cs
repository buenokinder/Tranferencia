﻿using System.IO;
using Docway.Domain.Models;
using Docway.Infra.Data.Mappings;
using Docway.Infra.Data.Extensions;

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Docway.Domain.Conventions;

namespace Docway.Infra.Data.Context
{
  
    public class DocwayContext :   IdentityDbContext<UserBase>
    {
        public DocwayContext(string connectionString) : base(connectionString) {

        }



        public DbSet<Colaborator> Colaborators { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Clinic> Clinics { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            


            modelBuilder.Conventions.Add(new StringProperties());
            modelBuilder.Conventions.Add(new NameProperties45());
            modelBuilder.Entity<Patient>().MapToStoredProcedures();
            modelBuilder.Entity<Doctor>().MapToStoredProcedures();
            modelBuilder.Entity<Colaborator>().MapToStoredProcedures();
            modelBuilder.Entity<ServiceProvider>().MapToStoredProcedures();
            
            modelBuilder.Entity<Appointment>().MapToStoredProcedures();
            modelBuilder.Entity<MedicalRecord>().MapToStoredProcedures();
            modelBuilder.Entity<Transaction>().MapToStoredProcedures();
            modelBuilder.Entity<Agenda>().MapToStoredProcedures();
            modelBuilder.Entity<CityAutoComplete>().MapToStoredProcedures();
            modelBuilder.Entity<Clinic>().MapToStoredProcedures();
            modelBuilder.Entity<CreditCard>().MapToStoredProcedures();
            modelBuilder.Entity<Document>().MapToStoredProcedures();
            modelBuilder.Entity<Medicine>().MapToStoredProcedures();
            modelBuilder.Entity<MobileInformation>().MapToStoredProcedures();

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserBase>().ToTable("Users");
        }
        
        
	}
}
