using Microsoft.EntityFrameworkCore;
using InnoloftAPI.Models;


namespace InnoloftAPI.Controllers
{
    public partial class EventsController
    {
        public class sqlLiteDbContext : DbContext
        {
            public DbSet<EventInfo> Events { get; set; }
            public DbSet<UserInfo> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("FileName=innodb", option =>
                {
                    option.MigrationsAssembly(System.Reflection.Assembly.GetExecutingAssembly().FullName);
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

                modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
                modelBuilder.Entity<UserInfo>(e =>
                {
                    e.HasKey(k => k.id);
                });
                base.OnModelCreating(modelBuilder);
            }
        }


    }
}
