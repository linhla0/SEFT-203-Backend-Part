using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Widget>().Ignore(e => e.Configs);
            modelBuilder.Entity<Report>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Dashboard> Dashboards { get; set; }
        //public DbSet<Entities.Task> Tasks { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Widget> Widgets { get; set; }
    }
}
