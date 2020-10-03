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
                CategoryName = "Some Name"
            });
            Assert.IsTrue(result.CategoryId != 0, "somethig goes wong...");
        }

        [Test]
        public void GetAllCategoriesTest()
        {
            CategoryDAL dal = new CategoryDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);
            var result = dal.CreateCategory(new CategoryDTO
            {
                CategoryName = "Some Name"
            });
            var categories = dal.GetAllCategories();
            Assert.AreEqual(1, categories.Count(x=>x.CategoryName == "Some Name"));
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
