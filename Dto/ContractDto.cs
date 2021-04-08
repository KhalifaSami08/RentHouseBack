using System;

namespace Backend_RentHouse_Khalifa_Sami.Dto
{
    //Je change les ID propriétés et clients en objets
    public abstract class ContractDto
    {
        public int idContract { get; set; }

        public int propertyId { get; set; }
        public int clientId { get; set; }

        public DateTime beginContract { get; set; } // date actuelle par défaut
        public DateTime endContract { get; set; }
        public byte duration { get; set; } // durée en mois - par defaut géré dans le Front
        
        public byte baseIndex { get; set; }
        public float guaranteedAmount { get; set; } // 2X Loyer - par defaut géré dans le Front
        public DateTime signatureDate { get; set; } // date actuelle par défaut

        public float beginIndexWater { get; set; }
        public float beginIndexGaz { get; set; }
        public float beginIndexElectricity { get; set; }

        public bool isGuaranteePaid { get; set; }
        public DateTime garanteePaidDate { get; set; }
        public bool isFirstMountPaid { get; set; }
        public DateTime entryDate { get; set; } // date actuelle par défaut
        public DateTime releaseDate { get; set; }
        
        public float endIndexWater { get; set; }
        public float endIndexGaz { get; set; }
        public float endIndexElectricity { get; set; }

    }
}