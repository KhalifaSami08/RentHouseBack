using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    //Contain common data between guarantor and tenant
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        
        /*
         [ForeignKey("IdContract")]
          public int IdContract { get; set; }
          public Contract Contract { get; set; }
        */
        
        [Required]
        public string Civility { get; set; }
        public string Gender { get; set; } //Par défaut en fonction de civility
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; } //string car format international
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }//string pour pas echaper le '0' si index local ainsi que pour l'indicatif
        

        [Required]
        public bool IsClient { get; set; } //Client ou Guarantor
        
        //Uniquement pour le client

        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; } //par défaut en fonction de la DDN
        public string PlaceOfBirth { get; set; }
        public string NationalRegister { get; set; }    

        //Un client ne peux avoir qu'une seule location
        public bool HaveAlreadyRentedHouse { get; set; }

    }
}