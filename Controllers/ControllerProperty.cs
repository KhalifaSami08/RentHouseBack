using System;
using System.Collections.Generic;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Data;
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
        //mapper = liste de données a recuperer

        public ControllerProperty(IPropertyRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Property>> GetAllProperties()
        {
            IEnumerable<Property> commandItem = _repository.GetAllProperties();
            return Ok(commandItem);
        }

        [HttpGet("{id}", Name="GetPropertyById")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            Property commandItem = _repository.GetPropertyById(id);
            if(commandItem != null)
                return Ok(commandItem);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Property> CreateProperty(Property property)
        {
            _repository.CreateProperty(property);
            return Ok(property);
            // return CreatedAtRoute(nameof(GetPropertyById), new {idProperty = property.idProperty}, property);
        }

        [HttpPatch("{id}")]
        public ActionResult<Property> UpdateProperty(int id, JsonPatchDocument<Property> patchDoc)
        {
            //Erreur déja géré dans le SQLPropertyRepo
            // Property p = _repository.GetPropertyById(id);
            
            // if(p==null)
            // {
            //     return NotFound();
            // }
            
            if(patchDoc != null){
                Property p = _repository.GetPropertyById(id);
                patchDoc.ApplyTo(p, ModelState);

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.UpdateProperty(p);    
                return Ok(p);
            }
            
            return BadRequest();
            
        }

        [HttpDelete("{id}")]
        public ActionResult<Property> DeleteProperty(int id)
        {
            _repository.DeleteProperty(id);    
            return Ok();
        }


      
    }
}