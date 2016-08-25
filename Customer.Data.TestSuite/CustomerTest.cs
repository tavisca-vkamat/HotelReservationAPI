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
            bool result =  customerDBImpl.InsertCustomer("xyz","pqr","xyz@tavisca.com","1234567890");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestCustomerSelect()
        {
            CustomerDBImpl customerDBImpl = new CustomerDBImpl();
            HotelReservation.Entity.Customer customer = customerDBImpl.SelectCustomer(1);
            Assert.AreEqual(customer.firstName,"vivek");
            
        }
        
        [TestMethod]
        public void TestCustomerDelete()
        {
            CustomerDBImpl customerDBImpl = new CustomerDBImpl();
            bool result = customerDBImpl.DeleteCustomer(6);
            Assert.AreEqual(true, result);

        }
    }
}
