using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_RentHouse_Khalifa_Sami.Model.Client
{
    public class Tenant : Client
    {
        [Required]
        public DateTime dateOfBirth { get; set; }
        public int age { get; set; } //par défaut en fonction de la DDN
        [Required]
        public string placeOfBirth { get; set; }
        [Required]
        public string nationalRegister { get; set; }
    }
}