using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.DAL.ClientData;
using Backend_RentHouse_Khalifa_Sami.DAL.ContractData;
using Backend_RentHouse_Khalifa_Sami.DAL.PropertyData;
using Backend_RentHouse_Khalifa_Sami.Dto;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Documents;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Backend_RentHouse_Khalifa_Sami.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        //repository = dataSource
        private readonly IContractRepo _repository;
        private readonly IMapper _mapper;
        private readonly IPropertyRepo _propertyRepo;
        private readonly IClientRepo _clientRepo;
        
        public ContractController(IContractRepo repository,IMapper mapper, IPropertyRepo propertyRepo, IClientRepo clientRep)
        {
            _repository = repository;
            _mapper = mapper;
            _propertyRepo = propertyRepo;
            _clientRepo = clientRep;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<ContractDto>> GetAllContracts()
        {
            return Ok(_mapper.Map<IEnumerable<ContractDto>>(_repository.GetAllContracts()));
        }

        [HttpGet("{id}", Name="GetContractById")]
        public ActionResult<ContractDto> GetContractById(int id)
        {
            Contract initContract = _repository.GetContractById(id);
            
            if(initContract == null)
                return NotFound();
            
            ContractDto contractDto = _mapper.Map<ContractDto>(initContract);
            return Ok(contractDto);
        }

        [HttpGet("doc/{id}/{type}")]
        public FileStreamResult GetDocumentByIdType(int id,string type)
        {
            Contract initContract = _repository.GetContractById(id);
            
            if(initContract == null)
                return null;
            
            Client cli = _clientRepo.GetClientById(initContract.ClientId);
            Property p = _propertyRepo.GetPropertyById(initContract.PropertyId);

            Enum.TryParse(type, out TypeContract tp);
            
            Document doc = new Document(cli,tp);
            string filePath = doc.GenerateDocument(p, initContract);

            string fileName =  doc.GetFileName();
            const string mimeType ="application/vnd.ms-word"; 

            return new FileStreamResult(System.IO.File.OpenRead(filePath), mimeType)
            {
                FileDownloadName = fileName
            };
        }
        
        [HttpGet("ContractByClientID/{id}")]
        public ActionResult<int> GetIdContractByIdClient(int id)
        {
            Client cli = _clientRepo.GetClientById(id);
            
            if(cli == null)
                return NotFound();

            Contract contr = _repository.GetClientContractById(cli.IdClient);

            if (contr == null)
                return NotFound();
            
            return Ok(contr.IdContract);
        }
        
        [HttpPost]
        public ActionResult<Contract> CreateContract(Contract c)
        {
            if(c == null)
                return NotFound();

            _repository.CreateContract(c);
            
            Property p = _propertyRepo.GetPropertyById(c.PropertyId);
                p.NbLocator += 1;
            _propertyRepo.UpdateProperty(p);
           
            Client cli = _clientRepo.GetClientById(c.ClientId);
                cli.HaveAlreadyRentedHouse = true;
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

            if (patchDoc == null) return BadRequest();
            
            patchDoc.ApplyTo(c, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.UpdateContract(c);    
            return Ok(c);
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

            Property p = _propertyRepo.GetPropertyById(c.PropertyId);
                if(p != null){
                    p.NbLocator -=  1 ;
                    _propertyRepo.UpdateProperty(p);
                }

            Client cli = _clientRepo.GetClientById(c.ClientId);
            
            if(cli != null){
                cli.HaveAlreadyRentedHouse = false;
                _clientRepo.UpdateClient(cli);
            }
            
            _repository.DeleteContract(id);    
            return Ok();
        }
    }
}