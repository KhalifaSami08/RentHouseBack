using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.DAL.PropertyData
{
    public interface IPropertyRepo
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(int id);
    }
}