using System;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Client;
using Backend_RentHouse_Khalifa_Sami.Model.Property;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {
            
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

        public DbSet<Property> CommandProperty {get;set;}
        public DbSet<Client> CommandClient {get;set;}
        public DbSet<Contract> CommandContract {get;set;}
        // public DbSet<HistoryContract> CommandHistory {get;set;}
    }
}