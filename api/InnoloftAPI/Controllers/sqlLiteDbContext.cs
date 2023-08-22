using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InnoloftAPI.Controllers
{
    public partial class EventsController
    {
        public class sqlLiteDbContext : DbContext
        {
            public DbSet<EventInfo> Events { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("FileName=innodb", option =>
                {
                    option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
                base.OnConfiguring(optionsBuilder);
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<EventInfo>().ToTable("EventInfo");
                modelBuilder.Entity<EventInfo>(e =>
                {
                    e.HasKey(k => k.EventID);
                });
                base.OnModelCreating(modelBuilder);
            }
        }


    }
}
