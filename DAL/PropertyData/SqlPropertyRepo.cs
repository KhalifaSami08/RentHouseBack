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
            _context.CommandProperty.Add(property);
            SaveChanges();
        }
        public void DeleteProperty(int id)
        {
            Property property = GetPropertyById(id);
            _context.CommandProperty.Remove(property);
            SaveChanges();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.CommandProperty.ToList();
        }

        public Property GetPropertyById(int id)
        {
            Property p = _context.CommandProperty.FirstOrDefault(p => p.IdProperty == id);
            return p;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateProperty(Property property)
        {
            _context.CommandProperty.Update(property);
            SaveChanges();
        }
    }
}