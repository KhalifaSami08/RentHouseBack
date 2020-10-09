using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Dtos;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

namespace Backend_RentHouse_Khalifa_Sami.Data.PropertyData
{
    public interface IPropertyRepo
    {
        bool SaveChanges();
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(int id);
    }
}