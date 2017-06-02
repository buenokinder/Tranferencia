using System.IO;
using Docway.Domain.Core.Events;
using Docway.Infra.Data.Mappings;
using Docway.Infra.Data.Extensions;
using System.Data.Entity;

namespace Docway.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }


        public EventStoreSQLContext(string connectionString) : base(connectionString) {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

   
    }
}
