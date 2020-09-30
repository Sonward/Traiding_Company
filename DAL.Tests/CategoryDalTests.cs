using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class CategoryDalTests : ServicedComponent
    {
        [Test]
        public void CreateTest()
        {
            CategoryDAL dal = new CategoryDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);
            var result = dal.CreateCategory(new CategoryDTO
            {
                Name = "Some Name"
            });
            Assert.IsTrue(result.Id != 0, "somethig goes wong...");
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
