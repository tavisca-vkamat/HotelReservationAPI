using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Entity;
using System.Data;
using System.Collections;

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

        public static ArrayList ConvertDataSetToArrayList(DataSet dataset)
        {
            if (dataset == null)
                return null;
            if (dataset.Tables.Count > 0)
            {
                ArrayList hotelDataArray = new ArrayList();
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    Hotel hotel = new Hotel();
                    hotel.hotelId = Convert.ToInt32(dr["HotelId"]);
                    hotel.hotelName = dr["HotelName"].ToString();
                    hotel.emailId = dr["EmailId"].ToString();
                    hotel.phoneNumber = dr["PhoneNumber"].ToString();
                    hotel.city = dr["City"].ToString();
                    hotel.totalRooms = dr["TotalRooms"].ToString();

                    hotelDataArray.Add(hotel);
                }
                return hotelDataArray;
            }
            return null;
        }
    }
}
