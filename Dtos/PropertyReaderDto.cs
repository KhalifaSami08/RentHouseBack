using System;
using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

namespace Backend_RentHouse_Khalifa_Sami.Dtos
{
    public class PropertyReaderDto
    {
        public int idProperty { get; set; } 
        public string description { get; set; }
        
        public string adress { get; set; }
        public string type { get; set; }
        public byte? floor { get; set; }
        public float rentCost { get; set; }
        public float fixedChargesCost { get; set; }
    
        public byte nbRoom { get; set; }
        public ICollection<Room> roomsDetails { get; set;}
        public int totalArea { get; set; } //superficie totale en m2
        public int diningRoomArea { get; set; }
        public int kitchenArea { get; set; }
        public string imageLink { get; set; }
        public bool isCurrentlyRented { get; set; }
 
    }
}