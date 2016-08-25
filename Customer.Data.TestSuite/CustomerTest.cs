using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerOperation.Data;


namespace Customer.Data.TestSuite
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomerInsert()
        {
            CustomerDBImpl customerDBImpl = new CustomerDBImpl();
            customerDBImpl.InsertCustomer("vivek","kamat","vkamat@tavisca.com","8975025201");
        }

        [TestMethod]
        public void TestCustomerSelect()
        {
            CustomerDBImpl customerDBImpl = new CustomerDBImpl();
            HotelReservation.Entity.Customer customer = customerDBImpl.SelectCustomer(1);
            Assert.AreEqual(customer.firstName,"vivek");
            
        }
    }
}
