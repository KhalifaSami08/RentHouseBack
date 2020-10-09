using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Model;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

namespace Backend_RentHouse_Khalifa_Sami.Dtos
{
    public class Profiles : Profile
    {
        public Profiles(){

            //On map les classes de la source a la destination
            
            /* 
                CreateMap<HistoryCRDto, HistoryContract>();
                CreateMap<HistoryContract, HistoryCRDto>();
            */
            
            CreateMap<Property,PropertyReaderDto>();
        }
    }
}