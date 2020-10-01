using System;
using System.Collections.Generic;
using System.Linq;
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
            
            _context.CommandProp.Add(property);
            SaveChanges();
        }

        public void DeleteProperty(int id)
        {
            Property property = GetPropertyById(id);
            
            // je veux gerer les erreurs dans le controller
            // if(property == null)
            //     throw new Exception(nameof(property));
            
            _context.CommandProp.Remove(property);
            SaveChanges();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.CommandProp.ToList();
        }

        public Property GetPropertyById(int id)
        {
            return _context.CommandProp.FirstOrDefault(p => p.idProperty == id);
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

            _context.CommandProp.Update(property);
            SaveChanges();
            
        }
    }
}