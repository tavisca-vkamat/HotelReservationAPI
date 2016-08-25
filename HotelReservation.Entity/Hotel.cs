using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entity
{
    public class Hotel
    {
        public int hotelId { get; set; }

        public string hotelName { get; set; }

        public string emailId { get; set; }

        public string phoneNumber { get; set; }

        public string city { get; set; }

        public string totalRooms { get; set; }


    }
}
