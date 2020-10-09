using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    //Bail
    public class Contract
    {
        [Key]
        public int idContract { get; set; }

        [ForeignKey("Property")]
        public int propertyId { get; set; }

        [ForeignKey("Client")]
        public int clientId { get; set; }

        public DateTime beginContract { get; set; }
        public DateTime endContract { get; set; }
        public byte duration { get; set; } //durée en mois
        public byte baseIndex { get; set; }
        public float garanteeAmount { get; set; } //2X Loyer - default


        public float beginIndexWater { get; set; }
        public float beginIndexGaz { get; set; }
        public float beginIndexElectricity { get; set; }
        public bool isGuaranteePaid { get; set; }
        public DateTime garanteePaidDate { get; set; }
        public bool isFirstMountPaid { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime releaseDate { get; set; }
        public float endIndexWater { get; set; }
        public float endIndexGaz { get; set; }
        public float endIndexElectricity { get; set; }


    }
}