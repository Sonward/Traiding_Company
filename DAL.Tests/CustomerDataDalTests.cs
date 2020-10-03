using System.Data.SqlTypes;
using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;
using System;
using System.Text;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    class CustomerDataDalTests
    {
        [Test]
        public void CreateTest()
        {
            CustomerDataDAL dal = new CustomerDataDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);
            var result = dal.CreateUser(new CustomerDataDTO
            {
                CustName = "Some Cust Name",
                CustSurname = "Surname",
                CustEmail = "e@gmail.com",
                CustPhone = 000000000,
                CustAddress = "Address",
                CustPassword = Encoding.ASCII.GetBytes("1234567"),
                RoleId = 1
            });
            Assert.IsTrue(result.CustomerDataId != 0, "somethig goes wong...");
        }

        [Test]
        public void GetAllCustomerTest()
        {
            CustomerDataDAL dal = new CustomerDataDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);
            var result = dal.CreateUser(new CustomerDataDTO
            {
                CustName = "SomeCustName",
                CustSurname = "Surname",
                CustEmail = "e@gmail.com",
                CustPhone = 000100000,
                CustAddress = "Address",
                CustPassword = Encoding.ASCII.GetBytes("1234567"),
                RoleId = 1
            });
            var categories = dal.GetAllUsers();
            Assert.AreEqual(1, categories.Count(x => x.CustName == "SomeCustName"));
        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }
    }
}

