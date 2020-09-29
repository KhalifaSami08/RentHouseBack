using System.ComponentModel.DataAnnotations;

namespace Backend_RentHouse_Khalifa_Sami.Model.Client
{
    //Contient les données communes des Garants et des locataires 
    public class Client
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string civility { get; set; }
        public char gender { get; set; } //Par défaut en fonction de civility
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
        public string email { get; set; }
        [Required]
        public string phoneNumer { get; set; }//string pour pas echaper le '0' si index local ainsi que pour l'indicatif
        
    }


}