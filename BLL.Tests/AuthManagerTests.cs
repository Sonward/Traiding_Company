using BuisnesLogicLayer.Concrete;
using DAL.Intefaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestFixture]
    class AuthManagerTests
    {
        private Mock<ICustomerDataDAL> custDatDAl;
        private AuthManager manager;

        [SetUp]
        public void Setup()
        {
            custDatDAl = new Mock<ICustomerDataDAL>(MockBehavior.Strict);

            manager = new AuthManager(custDatDAl.Object);
        }

        [Test]
        public void LoginSellerTest()
        {
            string username = "user";
            string password = "pass";

            custDatDAl.Setup(d => d.Login(username, password)).Returns(true);
            var res = manager.Login(username, password);

            Assert.IsTrue(res);
        }
    }
}
