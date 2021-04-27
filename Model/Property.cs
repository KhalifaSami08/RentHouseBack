using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Type { get; set; }
        public byte Floor { get; set; }
        [Required]
        public float RentCost { get; set; }
        [Required]
        public float FixedChargesCost { get; set; }
        public byte NbRoom { get; set; }
        public ICollection<Room> RoomsDetails { get; set;}
        
        public int TotalArea { get; set; } //superficie totale en m2
        public int DiningRoomArea { get; set; }
        public int KitchenArea { get; set; }
        public string ImageLink { get; set; }
        public int NbLocator { get; set ; }
        
        /*
         * Mobile uniquement
         */
        
        public int IdProprio { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
    
    [Owned] 
     public class Room
    {
        [Key]
        public int IdRoom { get; set; }
        [Required]
        string NameRoom { get; set; }
        [Required]
        int Area { get; set; }
    }
}