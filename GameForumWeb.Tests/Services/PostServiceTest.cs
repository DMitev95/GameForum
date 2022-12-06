using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Core.Services;
using NUnit.Framework;

namespace GameForumWeb.Tests.Services
{
    [TestFixture]
    public class PostServiceTest : UnitTestBase
    {
        private IPostService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new PostService(this.repo, this.mapper);
        }

        [Test]
        public async Task Add_Post()
        {
            //Arrange
            var posts = this.dbContext.Posts.Count();
            var postModel = new PostModel
            {
                Title = "TESTETETETETETETETETETETETE",

                Content = "TESTETETETETETETETETETETETE",

                CreatedDate = DateTime.Now,

                GameId = this.GameOne.Id,
            };

            //Act
            var addComment = service.AddPost(postModel, this.GuestUser.Id);
            //Assert
            var count = this.dbContext.Posts.Count();
            Assert.AreEqual(count, posts + 1);
        }

        [Test]
        public async Task Add_Post_Invalid_Game()
        {
            //Arrange
            var posts = this.dbContext.Posts.Count();
            var postModel = new PostModel
            {
                Title = "TESTETETETETETETETETETETETE",

                Content = "TESTETETETETETETETETETETETE",

                CreatedDate = DateTime.Now,

                GameId = 123412,
            };

            //Act
            
            //Assert            
            Assert.That(() => service.AddPost(postModel, this.GuestUser.Id), Throws.ArgumentException);
        }

        [Test]
        public async Task Add_Post_Invalid_User()
        {
            //Arrange
            var posts = this.dbContext.Posts.Count();
            var postModel = new PostModel
            {
                Title = "TESTETETETETETETETETETETETE",

                Content = "TESTETETETETETETETETETETETE",

                CreatedDate = DateTime.Now,

                GameId = this.GameOne.Id,
            };

            //Act

            //Assert            
            Assert.That(() => service.AddPost(postModel, "1234141324"), Throws.ArgumentException);
        }

        [Test]
        public async Task Delete_Post()
        {
            //Arrange
            var posts = this.dbContext.Posts.Count();
            var postForDelete = this.dbContext.Posts.Where(p=>p.Id == this.PostOne.Id).FirstOrDefault();

            //Act
            var result = await service.DeletePost(postForDelete.Id);
            //Assert            
            Assert.AreEqual(this.GameOne.Id, result);
        }

        [Test]
        public async Task Delete_Post_Invalid_Post_Id()
        {
            //Arrange
            var posts = this.dbContext.Posts.Count();
            var postForDelete = this.dbContext.Posts.Where(p => p.Id == this.PostOne.Id).FirstOrDefault();

            //Act
            
            //Assert            
            Assert.That(() => service.DeletePost(123443), Throws.ArgumentException);
        }

        [Test]
        public async Task Get_All_Game_Post()
        {
            //Arrange
            var games = this.dbContext.Posts.Where(p => p.IsDeleted == false && p.GameId == this.GameTwo.Id).Count();

            //Act
            var result = this.service.GetAllGamePost(this.GameTwo.Id).Result;

            //Assert
            Assert.AreEqual(games, result.Count());
        }
    }
}
