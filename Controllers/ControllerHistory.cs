using System.Collections.Generic;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Data.HistoryData;
using Backend_RentHouse_Khalifa_Sami.Dtos;
using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RentHouse_Khalifa_Sami.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class ControllerHistory : ControllerBase
    {
        private readonly IHistoryRepo _repository;
        private readonly IMapper _mapper;

        public ControllerHistory(IHistoryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<HistoryReaderDto> getAllHistories()
        {
            return Ok(_mapper.Map<IEnumerable<HistoryReaderDto>>(_repository.getAllHistories()));
        }

        public ActionResult<HistoryReaderDto> getHistoryById(int id)
        {
            History his = _repository.getHistoryById(id);
            if(his == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HistoryReaderDto>(his));
        }

    }
}