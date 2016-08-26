using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelReservation.Entity;

namespace CustomerOperation.Data
{
    public class CustomerDBImpl 
    {
        private const string DBName = "HotelReservationSystem";
        public Int32 InsertCustomer(string firstName, string lastName, string emailId, string phoneNumber)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spInsertCustomer");
            database.AddInParameter(dbcommand, "FirstName", System.Data.DbType.String, firstName);
            database.AddInParameter(dbcommand, "LastName", System.Data.DbType.String, lastName);
            database.AddInParameter(dbcommand, "EmailId", System.Data.DbType.String, emailId);
            database.AddInParameter(dbcommand, "PhoneNumber", System.Data.DbType.String, phoneNumber);
            database.AddOutParameter(dbcommand, "customerId", System.Data.DbType.Int32, Int32.MaxValue);

            int rowsAffected = database.ExecuteNonQuery(dbcommand);

            int custId = int.Parse(string.Format("{0}", database.GetParameterValue(dbcommand, "customerId")));


            if (rowsAffected == -1)
            {
                Console.WriteLine("\nNew customer ID : " + custId);
                return custId;
            }
            else
                return -1;
        }

        public Customer SelectCustomer(int id)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spSelectCustomer");
            database.AddInParameter(dbcommand, "CustomerId", System.Data.DbType.Int32, id);

            DataSet dataset =  database.ExecuteDataSet(dbcommand);

            return TranslateCustomer.PaserCustomer(dataset);
        }

        public bool DeleteCustomer(int id)
        {
            DatabaseProviderFactory dbPFactory = new DatabaseProviderFactory();
            Database defaultDb = dbPFactory.CreateDefault();
            Database database = dbPFactory.Create(DBName);
            DbCommand dbcommand = database.GetStoredProcCommand("spDeleteCustomer");
            database.AddInParameter(dbcommand, "CustomerId", System.Data.DbType.Int32, id);

            int rowsAffected = database.ExecuteNonQuery(dbcommand);

            if (rowsAffected == -1)
                return true;
            else
                return false;
        }
    }
}
