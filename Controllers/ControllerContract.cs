using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Data.ContractData;
using Backend_RentHouse_Khalifa_Sami.Data.HistoryData;
using Backend_RentHouse_Khalifa_Sami.Dtos;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Property;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RentHouse_Khalifa_Sami.Controllers
{

    [Route("api/contract")]
    [ApiController]
    public class ControllerContract : ControllerBase
    {

        //repository = source de données
        private readonly IContractRepo _repository;
        private readonly IHistoryRepo _repoHistory;

        public ControllerContract(IContractRepo repository, IHistoryRepo repoHistory)
        {
            _repository = repository;
            _repoHistory = repoHistory;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Contract>> GetAllContracts()
        {
            return Ok(_repository.GetAllContracts());
        }

        [HttpGet("{id}", Name="GetContractById")]
        public ActionResult<Contract> GetContractById(int id)
        {
            Contract c = _repository.GetContractById(id);
            if(c == null)
                return NotFound();

            return Ok(c);
        }

        [HttpPost]
        public ActionResult<Contract> CreateContract(Contract c)
        {
            if(c == null)
                return NotFound();

            _repository.CreateContract(c);

            History his = new History();
                his.isCurrentlyRented = true;
                his.begin = c.begin;
                his.end = c.end;

            _repoHistory.createHistory(his);
            return Ok(c);
        }
        
        // Le patch permet de changer un seul champ au lieu de changer toute la table
        [HttpPatch("{id}")]
        public ActionResult<Contract> UpdateContract(int id, JsonPatchDocument<Contract> patchDoc)
        {

            Contract c = _repository.GetContractById(id);            
            if(c==null)
                return NotFound();
            
            
            if(patchDoc != null){
                patchDoc.ApplyTo(c, ModelState);

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

            _repository.UpdateContract(c);    
            return Ok(c);
            }
            
            return BadRequest();            
        }

        [HttpPut("{id}")]
        public ActionResult<Contract> UpdateContract(Contract c)
        {
            
            if(c==null)
                return NotFound();

            _repository.UpdateContract(c);    
            return Ok(c);            
        }

        [HttpDelete("{id}")]
        public ActionResult<Contract> DeleteContract(int id)
        {
            Contract c = _repository.GetContractById(id);
            if(c == null)
                return NotFound();

            _repository.DeleteContract(id);    
            return Ok();
        }
      
    }
}