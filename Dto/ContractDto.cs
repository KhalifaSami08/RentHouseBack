using System;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Dto
{
    //Je change les ID propriétés et clients en objets
    public class ContractDto
    {
        public int IdContract { get; set; }

        public int PropertyId { get; set; }
        public int ClientId { get; set; }
        
        public Property Property { get; set; }
        public Client Client { get; set; }

        public DateTime BeginContract { get; set; } // date actuelle par défaut
        public DateTime EndContract { get; set; }
        public byte Duration { get; set; } // durée en mois - par defaut géré dans le Front
        
        public byte BaseIndex { get; set; }
        public float GuaranteedAmount { get; set; } // 2X Loyer - par defaut géré dans le Front
        public DateTime SignatureDate { get; set; } // date actuelle par défaut

        public float BeginIndexWater { get; set; }
        public float BeginIndexGaz { get; set; }
        public float BeginIndexElectricity { get; set; }

        public bool IsGuaranteePaid { get; set; }
        public DateTime GaranteePaidDate { get; set; }
        public bool IsFirstMountPaid { get; set; }
        public DateTime EntryDate { get; set; } // date actuelle par défaut
        public DateTime ReleaseDate { get; set; }
        
        public float EndIndexWater { get; set; }
        public float EndIndexGaz { get; set; }
        public float EndIndexElectricity { get; set; }

    }
}