using System;

namespace Backend_RentHouse_Khalifa_Sami.Dtos
{
    public class HistoryReaderDto
    {
        public bool isCurrentlyRented { get; set ;}
        public DateTime begin { get; set; }
        public DateTime end { get; set; }
    }
}