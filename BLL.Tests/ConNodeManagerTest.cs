using BuisnesLogicLayer.Concrete;
using DAL.Intefaces;
using Moq;
using System.Data.SqlTypes;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestFixture]
    class ConNodeManagerTest
    {
        private Mock<IConnectionNodeDAL> conNodDAL;
        private ConNodeManager manager;

        [SetUp]
        public void Setup()
        {
            conNodDAL = new Mock<IConnectionNodeDAL>(MockBehavior.Strict);

            manager = new ConNodeManager(conNodDAL.Object);
        }

        public void AddNodeTest()
        {
            ConnectionNodeDTO inConNode = new ConnectionNodeDTO
            {
                CustomerDataId = 1,
                ItemId = 1,
                QuantityOfItem = 5,
                TimeOfReceipt = SqlDateTime.MinValue,
                SendingTime = SqlDateTime.Null,
                StatusId = 1
            };

            var res = manager.AddNode(inConNode);

            Assert.IsNotNull(res);
        }

    }
}
