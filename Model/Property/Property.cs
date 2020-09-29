using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Backend_RentHouse_Khalifa_Sami.Model.Property
{
    public class Property : BasicInfoProperty
    {
        [Key]
        public int idProperty { get; set; }
        
        public string description { get; set; }
        [Required]
        public byte nbRoom { get; set; }
        [Required]
        public ICollection<Room> roomsDetails { get; set;}

        [Required]
        public int totalArea { get; set; } //superficie totale en m2
        [Required]
        public int diningRoomArea { get; set; }
        // [Column("kitchenArea")]
        [Required]
        public int kitchenArea { get; set; }
        public string imageLink { get; set; }
    
    }
}