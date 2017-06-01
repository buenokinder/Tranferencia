using System.IO;
using Docway.Domain.Core.Events;
using Docway.Infra.Data.Mappings;
using Docway.Infra.Data.Extensions;



namespace Docway.Infra.Data.Context
{
//    public class EventStoreSQLContext : DbContext
//    {
//        public DbSet<StoredEvent> StoredEvent { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.AddConfiguration(new StoredEventMap());

//            base.OnModelCreating(modelBuilder);
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            // get the configuration from the app settings
//            var config = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();

//            // define the database to use
//            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
//        }
//    }
}
