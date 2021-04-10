using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.DAL.PropertyData;
using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc; // using Backend_RentHouse_Khalifa_Sami.Data.HistoryData;

namespace Backend_RentHouse_Khalifa_Sami.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        //repository = dataSource
        private readonly IPropertyRepo _repository;
        public PropertyController(IPropertyRepo repository) 
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Property>> GetAllProperties()
        {
            IEnumerable<Property> propertyReaders = _repository.GetAllProperties();
            return Ok(propertyReaders);
        }

        [HttpGet("{id}", Name="GetPropertyById")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            Property p = _repository.GetPropertyById(id);

            if(p == null)
                return NotFound();

            return Ok(p);
        }

        [HttpPost]
        public ActionResult<Property> CreateProperty(Property property)
        {
            if(property == null)
                return NotFound();

            _repository.CreateProperty(property);
            return Ok(property);
        }
        
        [HttpPatch("{id}")]
        public ActionResult<Property> UpdateProperty(int id, JsonPatchDocument<Property> patchDoc)
        {
            Property p = _repository.GetPropertyById(id);            
            if(p==null)
                return NotFound();

            if (patchDoc == null) return BadRequest();
            
            patchDoc.ApplyTo(p, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.UpdateProperty(p);    
            return Ok(p);
        }

        [HttpPut("{id}")]
        public ActionResult<Property> UpdateProperty(Property p)
        {
            if(p==null)
                return NotFound();

            _repository.UpdateProperty(p);    
            return Ok(p);            
        }

        [HttpDelete("{id}")]
        public ActionResult<Property> DeleteProperty(int id)
        {
            Property p = _repository.GetPropertyById(id);
            if(p == null)
                return NotFound();

            _repository.DeleteProperty(id);    
            return Ok();
        }
    }
}