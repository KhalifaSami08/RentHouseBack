using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.DAL
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt, DbSet<Property> commandProperty, DbSet<Client> commandClient, DbSet<Contract> commandContract) : base(opt)
        {
            this.commandProperty = commandProperty;
            this.commandClient = commandClient;
            this.commandContract = commandContract;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .Property(p => p.signatureDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Contract>()
                .Property(p => p.beginContract)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Contract>()
                .Property(p => p.entryDate)
                .HasDefaultValueSql("getdate()");
        }
        public DbSet<Property> commandProperty {get;}
        public DbSet<Client> commandClient {get;}
        public DbSet<Contract> commandContract {get;}

    }
}