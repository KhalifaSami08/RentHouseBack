using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.Model.Property
{
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