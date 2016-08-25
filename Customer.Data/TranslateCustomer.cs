using HotelReservation.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOperation.Data
{
    public static class TranslateCustomer
    {
        public static Customer PaserCustomer(System.Data.DataSet customerdataset)
        {
            if (customerdataset == null)
                return null;
            if (customerdataset.Tables.Count > 0)
            {
                if (customerdataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = customerdataset.Tables[0].Rows[0];
                    Customer customer = new Customer();
                    customer.id = Convert.ToInt32(row["CustomerId"]);
                    customer.firstName = row["FirstName"].ToString();
                    customer.lastName = row["LastName"].ToString();
                    customer.emailId = row["EmailId"].ToString();
                    customer.phoneNumber = row["PhoneNumber"].ToString();
                    return customer;
                }
            }
            return null;
        }
    }
}
