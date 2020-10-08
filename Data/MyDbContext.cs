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
            modelBuilder.Entity<Property>()
                .Property(p => p.signatureDate)
                .HasDefaultValueSql("getdate()");
           
        }

        public DbSet<Property> CommandProp {get;set;}
        public DbSet<Client> CommandCli {get;set;}
        public DbSet<Contract> CommandContr {get;set;}
        public DbSet<History> CommandHistory {get;set;}
    }
}