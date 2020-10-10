using System.Collections.Generic;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Data.ContractData;
using Backend_RentHouse_Khalifa_Sami.Data.PropertyData;
// using Backend_RentHouse_Khalifa_Sami.Data.HistoryData;
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
        private readonly IMapper _mapper;
        private readonly IPropertyRepo _propertyRepo;

        // private readonly IHistoryRepo _repoHistory;

        public ControllerContract(IContractRepo repository,IMapper mapper, IPropertyRepo propertyRepo) // , IHistoryRepo repoHistory)
        {
            _repository = repository;
            _mapper = mapper;
            _propertyRepo = propertyRepo;
            // _repoHistory = repoHistory;
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
            
            Property p = _propertyRepo.GetPropertyById(c.propertyId);
                p.isCurrentlyRented = true;
            _propertyRepo.UpdateProperty(p);
           /*  HistoryCRDto crHis = new HistoryCRDto();
                crHis.contractId = c.idContract;
                crHis.clientId = c.clientId;
                crHis.propertyId = c.propertyId;
                crHis.beginContract = c.beginContract;
                crHis.endContract = c.endContract;
                crHis.baseIndex = c.baseIndex;
                crHis.duration = c.duration;
                crHis.garanteeAmount = c.garanteeAmount;

            _repoHistory.createHistory(_mapper.Map<HistoryContract>(crHis)); */
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

            Property p = _propertyRepo.GetPropertyById(c.propertyId);
                p.isCurrentlyRented = false;
            _propertyRepo.UpdateProperty(p);

            _repository.DeleteContract(id);    
            return Ok();
        }
      
    }
}