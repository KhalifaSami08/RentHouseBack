using System;
using System.Collections.Generic;
using AutoMapper;
// using Backend_RentHouse_Khalifa_Sami.Data.HistoryData;
using Backend_RentHouse_Khalifa_Sami.Data.PropertyData;
using Backend_RentHouse_Khalifa_Sami.Dtos;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Property;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RentHouse_Khalifa_Sami.Controllers
{

    [Route("api/property")]
    [ApiController]
    public class ControllerProperty : ControllerBase
    {

        //repository = source de données
        private readonly IPropertyRepo _repository;
        private readonly IMapper _mapper;
        // private readonly IHistoryRepo _historyRepo;

        public ControllerProperty(IPropertyRepo repository,IMapper mapper) //,IHistoryRepo historyRepo)
        {
            _repository = repository;
            _mapper = mapper;
            // _historyRepo = historyRepo;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<PropertyReaderDto>> GetAllProperties()
        {
            IEnumerable<PropertyReaderDto> propertyReaders = _mapper.Map<IEnumerable<PropertyReaderDto>>(_repository.GetAllProperties());
            return Ok(propertyReaders);
        }

        [HttpGet("{id}", Name="GetPropertyById")]
        public ActionResult<PropertyReaderDto> GetPropertyById(int id)
        {
            PropertyReaderDto p = _mapper.Map<PropertyReaderDto>(_repository.GetPropertyById(id));

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
            // return CreatedAtRoute(nameof(GetPropertyById), new {idProperty = property.idProperty}, property);
        }
        
        // Le patch permet de changer un seul champ au lieu de changer toute la table
        [HttpPatch("{id}")]
        public ActionResult<Property> UpdateProperty(int id, JsonPatchDocument<Property> patchDoc)
        {

            Property p = _repository.GetPropertyById(id);            
            if(p==null)
                return NotFound();
            
            
            if(patchDoc != null){
                patchDoc.ApplyTo(p, ModelState);

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.UpdateProperty(p);    
                return Ok(p);
            }
            
            return BadRequest();            
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