using HotelReservation.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsOperation.Data
{
    public class RoomsDbImpl
    {
        private const string DBName = "HotelReservationSystem";
        public static bool InsertRoomData(int hotelId,string roomType,int totalRooms, int availableRooms)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spInsertRoomData");
            database.AddInParameter(dbcommand, "HotelId", System.Data.DbType.Int32, hotelId);
            database.AddInParameter(dbcommand, "RoomType", System.Data.DbType.String, roomType);
            database.AddInParameter(dbcommand, "TotalRooms", System.Data.DbType.Int32, totalRooms);
            database.AddInParameter(dbcommand, "AvailableRooms", System.Data.DbType.Int32, availableRooms);
            

            int rowsAffected = database.ExecuteNonQuery(dbcommand);

            if (rowsAffected == -1)
                return true;
            else
                return false;
        }

        public static ArrayList SelectRoomData(string roomType)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spSelectRoomData");
            database.AddInParameter(dbcommand, "RoomType", System.Data.DbType.String, roomType);

            DataSet dataset = database.ExecuteDataSet(dbcommand);

            return TranslateRoomsData.ConvertDataSetToArrayList(dataset);
        }
        public static bool BookRoom(int roomId, int customerId)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spUpdateBookRoomData");
            database.AddInParameter(dbcommand, "Idroom", System.Data.DbType.Int32, roomId);
            database.AddInParameter(dbcommand, "CustomerId", System.Data.DbType.Int32, customerId);
            database.AddOutParameter(dbcommand, "bookingId",System.Data.DbType.Int32,Int32.MaxValue);

            int rowsAffected = database.ExecuteNonQuery(dbcommand);

            int bookingId = int.Parse(string.Format("{0}", database.GetParameterValue(dbcommand, "bookingId")));
            
            if (rowsAffected == -1)
            {
                Console.WriteLine("Booking ID : "+bookingId);
                return true;
            }
            
            else
                return false;

        }

        public static bool CheckOutRoom(int bookingId)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spUpdateCheckOutRoomData");
            
            database.AddInParameter(dbcommand, "bookingId", System.Data.DbType.Int32, bookingId);

            database.ExecuteScalar(dbcommand);

            return true;

        }
    }
}
