using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Dtos
{
    public class HistoryProfile : Profile
    {
        public HistoryProfile(){

            //On map les classes de la source a la destination
            CreateMap<History, HistoryReaderDto>();
        
        }
    }
}