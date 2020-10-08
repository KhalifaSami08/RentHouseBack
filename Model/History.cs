using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    public class History
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Property")]
        public int propertyId { get; set; }
        [ForeignKey("Client")]
        public int clientId { get; set; }
        [ForeignKey("Contract")]
        public int contractId { get; set; }
        [Required]
        public bool isCurrentlyRented { get; set ;}
        public DateTime begin { get; set; }
        public DateTime end { get; set; }

    }
}