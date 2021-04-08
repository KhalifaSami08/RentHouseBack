using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Dto
{
    public class Profiles : Profile
    {
        public Profiles(){

            // source -> destination
            CreateMap<Contract,ContractDto>().ReverseMap();
        }
    }
}