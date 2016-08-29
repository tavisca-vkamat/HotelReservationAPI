using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerOperation.Data;


namespace Customer.Data.TestSuite
{
    [TestClass]
    public class CustomerTest
    {
        CustomerDBImpl customerDBImpl;

        [TestInitialize]
        public void TestInitialize()
        {
            customerDBImpl = new CustomerDBImpl();
        }
        
        [TestMethod]
        public void TestCustomerInsert()
        {
            int result =  customerDBImpl.InsertCustomer("xyzzzzz","pqr","xyz@tavisca.com","1234567890");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestCustomerSelect()
        {
            HotelReservation.Entity.Customer customer = customerDBImpl.SelectCustomer(1);
            Assert.AreEqual(customer.firstName,"vivek");
        }
        
        [TestMethod]
        public void TestCustomerDelete()
        {
            bool result = customerDBImpl.DeleteCustomer(6);
            Assert.AreEqual(true, result);
        }
    }
}
