using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.DAL
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .Property(p => p.SignatureDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Contract>()
                .Property(p => p.BeginContract)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Contract>()
                .Property(p => p.EntryDate)
                .HasDefaultValueSql("getdate()");
        }
        public DbSet<Property> CommandProperty {get; set;}
        public DbSet<Client> CommandClient {get; set;}
        public DbSet<Contract> CommandContract {get; set;}

    }
}