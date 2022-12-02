using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Core.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GameForumWeb.Tests.Services
{
    [TestFixture]
    public class GameServiceTest : UnitTestBase
    {
        private IGameService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new GameService(this.repo, this.mapper);
        }

        [Test]
        public async Task Add_New_Game()
        {
            //Arrange
            var games = this.dbContext.Games.Count();
            var gameModel = new GameModel
            {
                Title = "Test Test Test Test Test Test Test",
                Studio = "Test Test Test Test Test Test Test",
                Rating = 5,
                Description = "Test Test Test Test Test Test Test",
                ImageUrl = "Test Test Test Test Test Test Test",
                CategoryId = 1,

            };

            //Act
            var addGame = this.service.AddNewGame(gameModel);
            //Assert
            var count = this.dbContext.Games.Count();
            Assert.AreEqual(count, games + 1);
        }

        [Test]
        public async Task All_Games()
        {
            //Arrange
            var games = this.dbContext.Games.Where(g => g.IsDeleted == false).Count();

            //Act
            var result = this.service.AllGames().Result;

            //Assert
            Assert.AreEqual(games, result.Count());
        }

        [Test]
        public async Task Delete_Game()
        {
            //Arrange
            var games = this.dbContext.Games.Where(g => g.IsDeleted == false).Count();
            var gameId = this.dbContext.Games.Where(g => g.Id == this.GameOne.Id).FirstOrDefault();

            //Act
            var result = this.service.DeleteGame(gameId.Id);
            var actualResult = this.dbContext.Games.Where(g => g.IsDeleted == false).Count();

            //Assert
            Assert.AreEqual(games - 1, actualResult);

        }

        [Test]
        public async Task Delete_Game_Must_Throw()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => service.DeleteGame(234143), Throws.ArgumentException);

        }

        [Test]
        public async Task Delete_Game_Must_Throw_Invalid_game()
        {
            //Arrange
            var game = this.dbContext.Games.Where(g => g.Id == this.GameOne.Id).FirstOrDefault();
            game.IsDeleted = true;
            this.dbContext.Update(game);
            this.dbContext.SaveChanges();
            //Act

            //Assert
            Assert.That(() => service.DeleteGame(game.Id), Throws.ArgumentException);

        }

        [Test]
        public async Task Finde_Game_By_Name()
        {
            //Arrange
            var game = this.dbContext.Games.Where(g => g.Id == this.GameTwo.Id).FirstOrDefault();

            //Act
            var result = this.service.FindeGameByName(game.Title).Result;

            //Assert
            Assert.AreEqual(game.Title, result.Title);
        }

        [Test]
        public async Task Get_Categories()
        {
            //Arrange
            var categories = this.dbContext.Categories.Count();

            //Act
            var result = this.service.GetCategories().Result;

            //Assert
            Assert.AreEqual(categories, result.Count());
        }

        [Test]
        public async Task Get_Game_Model_By_Id()
        {
            //Arrange
            var game = this.dbContext.Games.Where(g => g.Id == this.GameTwo.Id).FirstOrDefault();

            //Act
            var result = this.service.GetGameModelById(game.Id).Result;

            //Assert
            Assert.AreEqual(game.Title, result.Title);
        }

        [Test]
        public async Task Get_Game_Model_By_Id_Must_Throw()
        {
            //Arrange
            var game = this.dbContext.Games.Where(g => g.Id == this.GameTwo.Id).FirstOrDefault();

            //Act

            //Assert
            Assert.That(() => this.service.GetGameModelById(123134), Throws.ArgumentException);
        }

        [Test]
        public async Task Get_Game_Model_By_Id_Must_Throw_Deleted_Game()
        {
            //Arrange
            var game = this.dbContext.Games.Where(g => g.Id == this.GameOne.Id).FirstOrDefault();

            //Act

            //Assert
            Assert.That(() => this.service.GetGameModelById(game.Id), Throws.ArgumentException);
        }

        [Test]
        public async Task Get_Games_By_Category()
        {
            //Arrange
            var category = this.dbContext.Categories.Where(c => c.Id == this.CategoryTwo.Id).FirstOrDefault();

            //Act
            var result = await this.service.GetGamesByCategory(category.Id);

            //Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task Get_Top_Games()
        {
            //Arrange
            var category = this.dbContext.Games.OrderBy(x => x.Rating).Take(3).ToList();

            //Act
            var result = await this.service.GetTopGames();

            //Assert
            Assert.AreEqual(category.Count, result.Count());
        }

        [Test]
        public async Task Update_Game()
        {
            //Arrange
            var game = this.dbContext.Games.Where(c => c.Id == this.CommentOne.Id).FirstOrDefault();
            var model = new GameModel()
            {
                Title = "TESTETETETETETETETETETE",
                Description = "TESTETETETETETETETETETE",
                Studio = "TESTETETETETETETETETETE",
                Rating = 10,
                CategoryId = this.CategoryOne.Id,
                ImageUrl = "TESTETETETETETETETETETE",
            };
            //Act
            var result = service.UpdateGame(game.Id, model);
            var comment1 = this.dbContext.Games.Where(c => c.Id == this.CommentOne.Id).FirstOrDefault();
            //Assert
            Assert.AreEqual(comment1.Title, "TESTETETETETETETETETETE");
        }

        [Test]
        public async Task Update_Game_Must_Throw()
        {
            //Arrange
            var game = this.dbContext.Games.Where(c => c.Id == this.CommentOne.Id).FirstOrDefault();
            var model = new GameModel()
            {
                Title = "TESTETETETETETETETETETE",
                Description = "TESTETETETETETETETETETE",
                Studio = "TESTETETETETETETETETETE",
                Rating = 10,
                CategoryId = this.CategoryOne.Id,
                ImageUrl = "TESTETETETETETETETETETE",
            };
            //Act
           
            //Assert
            Assert.That(() => service.UpdateGame(21342134, model), Throws.ArgumentException);
        }
    }
}
