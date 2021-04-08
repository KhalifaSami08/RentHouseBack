using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.DAL.ClientData;
using Backend_RentHouse_Khalifa_Sami.DAL.ContractData;
using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RentHouse_Khalifa_Sami.Controllers
{

    [Route("api/client")]
    [ApiController]
    public class ControllerClient : ControllerBase
    {
        //repository = dataSource
        private readonly IClientRepo _repository;
        private readonly IContractRepo _contractRepo;

        public ControllerClient(IClientRepo repository, IContractRepo contractRepo)
        {
            _repository = repository;
            _contractRepo = contractRepo;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Client>> GetAllClients()
        {
            return Ok(_repository.GetAllClients());
        }
        
        [HttpGet("{id}", Name="GetClientById")]
        public ActionResult<Client> GetClientById(int id)
        {
            Client c = _repository.GetClientById(id);
            if(c == null)
                return NotFound();

            return Ok(c);
        }
        
        [HttpPost]
        public ActionResult<Client> CreateClient(Client c)
        {
            if(c == null)
                return NotFound();

            _repository.CreateClient(c);
            return Ok(c);
        }
        
        // patch allow to change one attribute instead of all object 
        [HttpPatch("{id}")]
        public ActionResult<Client> UpdateClient(int id, JsonPatchDocument<Client> patchDoc)
        {
            Client c = _repository.GetClientById(id);            
            if(c==null)
                return NotFound();


            if (patchDoc == null) return BadRequest();
            
            patchDoc.ApplyTo(c, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.UpdateClient(c);    
            return Ok(c);
        }
        // Exemple de requete patch 
        /* 
            [
                
                {
                    "opt" : "replace",
                    "path": "/phoneNumber",
                    "value": "0477582533"
                }

            ]   
        */

        [HttpPut("{id}")]
        public ActionResult<Client> UpdateClient(Client c)
        {
            if(c==null)
                return NotFound();

            _repository.UpdateClient(c);    
            return Ok(c);            
        }

        [HttpDelete("{id}")]
        public ActionResult<Client> DeleteClient(int id)
        {
            Client c = _repository.GetClientById(id);
            if(c == null)
                return NotFound();

            Contract contract = _contractRepo.GetClientContractById(c.idClient);
            
            if(contract != null)
                _contractRepo.DeleteContract(contract.idContract);

            _repository.DeleteClient(id);    
            return Ok();
        }
    }
}