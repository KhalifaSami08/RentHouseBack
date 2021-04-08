using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_RentHouse_Khalifa_Sami.Model
{
    //Contain common data between guarantor and tenant
    public class Client
    {
        public Client(string postalCode, string city, string surname, string name, int idClient, string address)
        {
            this.postalCode = postalCode;
            this.city = city;
            this.surname = surname;
            this.name = name;
            this.idClient = idClient;
            this.address = address;
        }

        [Key]
        public int idClient { get; }
        [Required]
        public string civility { get; set; }
        public string gender { get; set; } //Par défaut en fonction de civility
        [Required]
        public string name { get; }
        [Required]
        public string surname { get; }
        [Required]
        public string address { get; }
        [Required]
        public string postalCode { get; } //string car format international
        [Required]
        public string city { get; }
        [Required]
        public string country { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }//string pour pas echaper le '0' si index local ainsi que pour l'indicatif
        

        [Required]
        public bool isClient { get; set; } //Client ou Guarantor
        
        //Uniquement pour le client

        public DateTime dateOfBirth { get; set; }
        public int age { get; set; } //par défaut en fonction de la DDN
        public string placeOfBirth { get; set; }
        public string nationalRegister { get; set; }    

        //Un client ne peux avoir qu'une seule location
        public bool haveAlreadyRentedHouse { get; set; }

    }
}