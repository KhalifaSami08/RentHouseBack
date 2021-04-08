using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    public class Property
    {
        [Key]
        public int idProperty { get; set; }
        public string description { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string type { get; set; }
        public byte floor { get; set; }

        [Required]
        public float rentCost { get; set; }
        [Required]
        public float fixedChargesCost { get; set; }
        public byte nbRoom { get; set; }
        public ICollection<Room> roomsDetails { get; set;}

        public int totalArea { get; set; } //superficie totale en m2
        public int diningRoomArea { get; set; }
        public int kitchenArea { get; set; }
        public string imageLink { get; set; }

        public int nbLocator { get; set ; }
        
        //Mobile uniquement
        public int idProprio { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
    
     [Owned] 
     public class Room
    {
        [Key]
        public int idRoom { get; set; }
        [Required]
        string nameRoom { get; set; }
        [Required]
        int area { get; set; }
    }
}