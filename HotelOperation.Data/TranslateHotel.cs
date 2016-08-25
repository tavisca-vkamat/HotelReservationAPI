using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Entity;
using System.Data;

namespace HotelOperation.Data
{
    class TranslateHotel
    {
        public static Hotel PaserHotel(System.Data.DataSet hoteldataset)
        {
            if (hoteldataset == null)
                return null;
            if (hoteldataset.Tables.Count > 0)
            {
                if (hoteldataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = hoteldataset.Tables[0].Rows[0];
                    Hotel hotel = new Hotel();

                    hotel.hotelId = Convert.ToInt32(row["HotelId"]);
                    hotel.hotelName = row["HotelName"].ToString();
                    hotel.emailId = row["EmailId"].ToString();
                    hotel.phoneNumber = row["PhoneNumber"].ToString();
                    hotel.city = row["City"].ToString();
                    hotel.totalRooms = row["TotalRooms"].ToString();

                    return hotel;
                }
            }
            return null;
        }
    }
}
