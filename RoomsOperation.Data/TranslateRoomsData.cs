using HotelReservation.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsOperation.Data
{
    class TranslateRoomsData
    {
        public static ArrayList ConvertDataSetToArrayList(DataSet dataset)
        {
            if (dataset == null)
                return null;
            if (dataset.Tables.Count > 0)
            {
                ArrayList roomDataArray = new ArrayList();
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    RoomsData roomsdata = new RoomsData();
                    roomsdata.id = Convert.ToInt32(dr["Id"]);
                    roomsdata.hotelId = Convert.ToInt32(dr["HotelId"]);
                    roomsdata.roomType = dr["RoomType"].ToString();
                    roomsdata.totalRooms = Convert.ToInt32(dr["TotalRooms"]);
                    roomsdata.availableRooms = Convert.ToInt32(dr["AvailableRooms"]);
                    roomsdata.rentOfRoom = dr["Price"].ToString();
                    roomDataArray.Add(roomsdata);
                }
                return roomDataArray;
            }
            return null;
        }
    }
}
