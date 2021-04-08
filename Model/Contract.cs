using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    //Lease
    public class Contract
    {
        public Contract(int idContract, int propertyId, int clientId, DateTime beginContract, DateTime endContract, byte duration, float guaranteeAmount, DateTime signatureDate, float beginIndexWater, float beginIndexGaz, float beginIndexElectricity, bool isGuaranteePaid, DateTime garanteePaidDate, bool isFirstMountPaid, DateTime entryDate, DateTime releaseDate, float endIndexWater, float endIndexGaz, float endIndexElectricity)
        {
            this.idContract = idContract;
            this.propertyId = propertyId;
            this.clientId = clientId;
            this.beginContract = beginContract;
            this.endContract = endContract;
            this.duration = duration;
            this.guaranteeAmount = guaranteeAmount;
            this.signatureDate = signatureDate;
            this.beginIndexWater = beginIndexWater;
            this.beginIndexGaz = beginIndexGaz;
            this.beginIndexElectricity = beginIndexElectricity;
            this.isGuaranteePaid = isGuaranteePaid;
            this.garanteePaidDate = garanteePaidDate;
            this.isFirstMountPaid = isFirstMountPaid;
            this.entryDate = entryDate;
            this.releaseDate = releaseDate;
            this.endIndexWater = endIndexWater;
            this.endIndexGaz = endIndexGaz;
            this.endIndexElectricity = endIndexElectricity;
        }

        [Key]
        public int idContract { get; }

        [ForeignKey("Property")]
        public int propertyId { get; }

        [ForeignKey("Client")]
        public int clientId { get; }
        public DateTime beginContract { get; } // date actuelle par défaut
        public DateTime endContract { get; }
        public byte duration { get; } // durée en mois - par defaut géré dans le Front
        public byte baseIndex { get; set; }
        public float guaranteeAmount { get; } // 2X Loyer - par defaut géré dans le Front
        public DateTime signatureDate { get; } // date actuelle par défaut

        public float beginIndexWater { get; }
        public float beginIndexGaz { get; }
        public float beginIndexElectricity { get; }

        public bool isGuaranteePaid { get; }
        public DateTime garanteePaidDate { get; }
        public bool isFirstMountPaid { get; }
        public DateTime entryDate { get; } // date actuelle par défaut
        public DateTime releaseDate { get; }
        
        public float endIndexWater { get; }
        public float endIndexGaz { get; }
        public float endIndexElectricity { get; }
    }
}