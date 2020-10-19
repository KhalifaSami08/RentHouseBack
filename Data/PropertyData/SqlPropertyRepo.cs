using System;
using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

namespace Backend_RentHouse_Khalifa_Sami.Data.PropertyData
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
            // je veux gerer les erreurs dans le controller
            // if(property == null)
            //     throw new ArgumentNullException(nameof(property));
            
            _context.CommandProperty.Add(property);
            SaveChanges();
        }

        public void DeleteProperty(int id)
        {
            Property property = GetPropertyById(id);
            
            // je veux gerer les erreurs dans le controller
            // if(property == null)
            //     throw new Exception(nameof(property));
            
            _context.CommandProperty.Remove(property);
            SaveChanges();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.CommandProperty.ToList();
        }

        public Property GetPropertyById(int id)
        {
            Property p = _context.CommandProperty.FirstOrDefault(p => p.idProperty == id);
            return p;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProperty(Property property)
        {
            // je veux gerer les erreurs dans le controller
            // if(property==null)
            //     throw new ArgumentNullException(nameof(property));

            _context.CommandProperty.Update(property);
            SaveChanges();
            
        }
    }
}