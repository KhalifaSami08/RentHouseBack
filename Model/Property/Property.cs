using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Backend_RentHouse_Khalifa_Sami.Model.Property
{
    public class Property
    {
        [Key]
        public int idProperty { get; set; }
        [Required]
        public string description { get; set; }

        [Required]
        public string adress { get; set; }
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
    
    }
}