using System;
using Backend_RentHouse_Khalifa_Sami.Model.Client;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

namespace Backend_RentHouse_Khalifa_Sami.Dtos
{
    //Je change les ID propriétés et clients en objets
    public class ContractDto
    {
        public int idContract { get; set; }
        public Client client { get; set; }
        public Property property { get; set; }
        public DateTime endContract { get; set; }
        public byte duration { get; set; } //durée en mois - par défaut
        public byte baseIndex { get; set; }
        public float garanteeAmount { get; set; } //2X Loyer - default

        public float beginIndexWater { get; set; }
        public float beginIndexGaz { get; set; }
        public float beginIndexElectricity { get; set; }
        public bool isGuaranteePaid { get; set; }
        public DateTime garanteePaidDate { get; set; }
        public bool isFirstMountPaid { get; set; }
        public DateTime releaseDate { get; set; }
        public float endIndexWater { get; set; }
        public float endIndexGaz { get; set; }
        public float endIndexElectricity { get; set; }

    }
}