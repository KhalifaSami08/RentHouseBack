using Backend_RentHouse_Khalifa_Sami.Model.Property;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }

        public DbSet<Property> CommandProp {get;set;}
    }
}