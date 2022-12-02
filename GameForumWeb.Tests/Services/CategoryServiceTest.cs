using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Services;
using NUnit.Framework;

namespace GameForumWeb.Tests.Services
{
    [TestFixture]
    public class CategoryServiceTest : UnitTestBase
    {
        private ICategoryService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new CategoryService(this.repo, this.mapper);
        }

        [Test]
        public async Task Get_All_Categories()
        {
            //Arrange
            var categories = this.dbContext.Categories.Count();
            //Act
            var result = service.GetAllCategory();
            //Assert
            Assert.AreEqual(categories, result.Result.Count());
        }
    }
}
