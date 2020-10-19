using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_RentHouse_Khalifa_Sami.Model.Client
{
    //Contient les données communes des Garants et des locataires 
    public class Client
    {
        [Key]
        public int idClient { get; set; }
        [Required]
        public string civility { get; set; }
        public string gender { get; set; } //Par défaut en fonction de civility
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string adress { get; set; }
        [Required]
        public string postalCode { get; set; } //string car format international
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }//string pour pas echaper le '0' si index local ainsi que pour l'indicatif
        

        [Required]
        public bool isClient { get; set; } //Client ou Garant
        
        //Uniquement pour le client

        public DateTime dateOfBirth { get; set; }
        public int age { get; set; } //par défaut en fonction de la DDN
        public string placeOfBirth { get; set; }
        public string nationalRegister { get; set; }    

        //Un client ne peux avoir qu'une seule location
        public bool haveAlreadyRentedHouse { get; set; }

    }
}