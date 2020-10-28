using System.Collections.Generic;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Data.ClientData;
using Backend_RentHouse_Khalifa_Sami.Data.ContractData;
using Backend_RentHouse_Khalifa_Sami.Data.PropertyData;
using Backend_RentHouse_Khalifa_Sami.Dtos;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Client;
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
        private readonly IClientRepo _clientRepo;

        // private readonly IHistoryRepo _repoHistory;

        public ControllerContract(IContractRepo repository,IMapper mapper, IPropertyRepo propertyRepo, IClientRepo clientRep)
        {
            _repository = repository;
            _mapper = mapper;
            _propertyRepo = propertyRepo;
            _clientRepo = clientRep;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<ContractDto>> GetAllContracts()
        {

            IEnumerable<Contract> allContrats = _repository.GetAllContracts();
            List<ContractDto> allContratsDto = new List<ContractDto>();

            foreach(Contract c in allContrats)
            {
                // Client cli = _clientRepo.GetClientById(c.clientId);
                // Property p = _propertyRepo.GetPropertyById(c.propertyId);

                ContractDto contractDto = _mapper.Map<ContractDto>(c);
                    /* contractDto.client = cli;
                    contractDto.property = p; */
                
                allContratsDto.Add(contractDto);
            }

            return Ok(allContratsDto);
        }

        [HttpGet("{id}", Name="GetContractById")]
        public ActionResult<ContractDto> GetContractById(int id)
        {
            Contract initContrat = _repository.GetContractById(id);
            
            if(initContrat == null)
                return NotFound();
            
            
            // Client cli = _clientRepo.GetClientById(initContrat.clientId);
            // Property p = _propertyRepo.GetPropertyById(initContrat.propertyId);

            ContractDto contractDto = _mapper.Map<ContractDto>(initContrat);
               /*  contractDto.client = cli;
                contractDto.property = p; */

            return Ok(contractDto);
        }

        [HttpPost]
        public ActionResult<Contract> CreateContract(Contract c)
        {
            if(c == null)
                return NotFound();

            _repository.CreateContract(c);
            
            Property p = _propertyRepo.GetPropertyById(c.propertyId);
                p.nbLocator += 1;
            _propertyRepo.UpdateProperty(p);
           
            Client cli = _clientRepo.GetClientById(c.clientId);
                cli.haveAlreadyRentedHouse = true;
            _clientRepo.UpdateClient(cli);

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
                if(p != null){
                    p.nbLocator -=  1 ;
                    _propertyRepo.UpdateProperty(p);
                }
               

            Client cli = _clientRepo.GetClientById(c.clientId);
               if(cli != null){
                    cli.haveAlreadyRentedHouse = false;
                    _clientRepo.UpdateClient(cli);
                }
                

            _repository.DeleteContract(id);    
            return Ok();
        }
      
    }
}