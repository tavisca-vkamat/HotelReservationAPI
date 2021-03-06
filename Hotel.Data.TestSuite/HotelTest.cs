﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelOperation.Data;

namespace Hotel.Data.TestSuite
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void TestHotelInsert()
        {
            HotelDBImpl hotelDBImpl = new HotelDBImpl();
            int result = hotelDBImpl.InsertHotel("Hyatt", "hyatt.com", "0123456789", "Pune", "100");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestHotelSelect()
        {
            HotelDBImpl hotelDBImpl = new HotelDBImpl();
            HotelReservation.Entity.Hotel hotel =  hotelDBImpl.SelectHotel(1);

            Assert.AreEqual(hotel.hotelName,"Hyatt");
        }

        [TestMethod]
        public void TestHotelDelete()
        {
            HotelDBImpl hotelDBImpl = new HotelDBImpl();
            bool result = hotelDBImpl.DeleteHotel(1);
            Assert.AreEqual(true, result);
        }

    }
}
