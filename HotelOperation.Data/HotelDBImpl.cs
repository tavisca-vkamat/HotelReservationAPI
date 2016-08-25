using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Entity;
using System.Data;

namespace HotelOperation.Data
{
    public class HotelDBImpl
    {
        private const string DBName = "HotelReservationSystem";
        public bool InsertCustomer(string hotelName,  string emailId, string phoneNumber, string city, string totalRooms)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spInsertHotel");
            database.AddInParameter(dbcommand, "HotelName", System.Data.DbType.String, hotelName);
            database.AddInParameter(dbcommand, "EmailId", System.Data.DbType.String, emailId);
            database.AddInParameter(dbcommand, "PhoneNumber", System.Data.DbType.String, phoneNumber);
            database.AddInParameter(dbcommand, "City", System.Data.DbType.String, city);
            database.AddInParameter(dbcommand, "TotalRooms", System.Data.DbType.String, totalRooms);

            int rowsAffected = database.ExecuteNonQuery(dbcommand);

            if (rowsAffected == -1)
                return true;
            else
                return false;
        }

        public Hotel SelectHotel(int id)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spSelectHotel");
            database.AddInParameter(dbcommand, "HotelId", System.Data.DbType.Int32, id);

            DataSet dataset = database.ExecuteDataSet(dbcommand);

            return TranslateHotel.PaserHotel(dataset);
        }

        public bool DeleteHotel(int id)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spDeleteHotel");
            database.AddInParameter(dbcommand, "HotelId", System.Data.DbType.Int32, id);

            int rowsAffected = database.ExecuteNonQuery(dbcommand);

            if (rowsAffected == -1)
                return true;
            else
                return false;
        }
    }
}
