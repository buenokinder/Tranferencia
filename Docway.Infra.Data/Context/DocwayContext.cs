using System.IO;
using Docway.Domain.Models;
using Docway.Infra.Data.Mappings;
using Docway.Infra.Data.Extensions;

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Docway.Infra.Data.Context
{
  
    public class DocwayContext :   IdentityDbContext<UserBase>
    {
        public DocwayContext(string connectionString) : base(connectionString) {

        }
      
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserBase>().ToTable("Users");
        }
        
        
	}
}
