using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entity
{
    public class RoomsData
    {
        public int id { get; set; }

        public int hotelId { get; set; }

        public string roomType { get; set; }

        public int totalRooms{get; set;}

        public int availableRooms { get; set; }

        public string rentOfRoom { get; set; }
    }
}
