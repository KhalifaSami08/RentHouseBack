using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_RentHouse_Khalifa_Sami.Model.Property
{
    public class BasicInfoProperty
    {
        [Required]
        public string adress { get; set; }
        [Required]
        public string type { get; set; }
        public byte? floor { get; set; }
        [Required]
        public float rentCost { get; set; }
        [Required]
        public float fixedChargesCost { get; set; }
        public DateTime signatureDate { get; set; } //defaut
    }
}