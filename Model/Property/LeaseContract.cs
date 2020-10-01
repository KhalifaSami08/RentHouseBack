using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_RentHouse_Khalifa_Sami.Model.Property
{
    //Bail
    public class LeaseContract  :BasicInfoProperty
    {
        [Key]
        public int idContract { get; set; }
        [ForeignKey("Property")]
        public int propertyId { get; set; }
        [ForeignKey("Client")]
        public int clientId { get; set; }
        
        [Required]
        public DateTime begin { get; set; }
        [Required]
        public DateTime end { get; set; }
        [Required]
        public byte duration { get; set; } //durée en mois
        [Required]
        public byte baseIndex { get; set; }
        public float garanteeAmount { get; set; } //2X Loyer - default

    }
}