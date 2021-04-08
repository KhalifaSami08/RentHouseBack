using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.DAL.PropertyData
{
    public class SqlPropertyRepo : IPropertyRepo
    {
        private readonly MyDbContext _context;
        public SqlPropertyRepo(MyDbContext context)
        {
            _context = context;
        }
        public void CreateProperty(Property property)
        {
            _context.commandProperty.Add(property);
            SaveChanges();
        }
        public void DeleteProperty(int id)
        {
            Property property = GetPropertyById(id);
            _context.commandProperty.Remove(property);
            SaveChanges();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.commandProperty.ToList();
        }

        public Property GetPropertyById(int id)
        {
            Property p = _context.commandProperty.FirstOrDefault(p => p.idProperty == id);
            return p;
        }

        private bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateProperty(Property property)
        {
            _context.commandProperty.Update(property);
            SaveChanges();
        }
    }
}