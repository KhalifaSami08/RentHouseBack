using System.Collections.Generic;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Data.ClientData;
using Backend_RentHouse_Khalifa_Sami.Data.ContractData;
using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RentHouse_Khalifa_Sami.Controllers
{

    [Route("api/client")]
    [ApiController]
    public class ControllerClient : ControllerBase
    {

        //repository = source de données
        private readonly IClientRepo _repository;
        private readonly IContractRepo _contractRepo;
        private readonly IMapper _mapper;

        public ControllerClient(IClientRepo repository, IContractRepo contractRepo, IMapper mapper)
        {
            _repository = repository;
            _contractRepo = contractRepo;
            _mapper = mapper;

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

        /* [Route("winforms")]
        [HttpGet]
        public ActionResult <IEnumerable<ClientReaderWinformsDto>> GetAllClientsWinforms()
        {
            return Ok(_mapper.Map<IEnumerable<ClientReaderWinformsDto>>(_repository.GetAllClients()));
        } */

        [HttpPost]
        public ActionResult<Client> CreateClient(Client c)
        {
            if(c == null)
                return NotFound();

            _repository.CreateClient(c);
            return Ok(c);
        }
        
        // Le patch permet de changer un seul champ au lieu de changer toute la table
        [HttpPatch("{id}")]
        public ActionResult<Client> UpdateClient(int id, JsonPatchDocument<Client> patchDoc)
        {

            Client c = _repository.GetClientById(id);            
            if(c==null)
                return NotFound();
            
            
            if(patchDoc != null){
                patchDoc.ApplyTo(c, ModelState);

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

            _repository.UpdateClient(c);    
            return Ok(c);
            }
            
            return BadRequest();            
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