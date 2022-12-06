using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Users;
using GamerForumWeb.Core.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForumWeb.Tests.Services
{
    public class UserServiceTest : UnitTestBase
    {
        private IUserService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new UserService(this.repo, this.mapper);
        }

        [Test]
        public async Task Get_User_By_Id()
        {
            //Arrange
            var user = this.dbContext.Users.Where(u => u.Id == this.GuestUser.Id).FirstOrDefault();

            //Act
            var result = this.service.GetUserById(this.GuestUser.Id).Result;

            //Assert
            Assert.AreEqual(user.UserName, result.UserName);
        }

        [Test]
        public async Task Get_UserName_By_Id()
        {
            //Arrange
            var user = this.dbContext.Users.Where(u => u.Id == this.GuestUser.Id).FirstOrDefault();

            //Act
            var result = this.service.GetUserNameById(this.GuestUser.Id).Result;

            //Assert
            Assert.AreEqual(user.UserName, result);
        }

        [Test]
        public async Task Get_User_For_Edit()
        {
            //Arrange
            var user = this.dbContext.Users.Where(u => u.Id == this.GuestUser.Id).FirstOrDefault();

            //Act
            var result = this.service.GetUserForEdit(this.GuestUser.Id).Result;

            //Assert
            Assert.AreEqual(user.FirstName, result.FirstName);
        }

        [Test]
        public async Task Get_Users()
        {
            //Arrange
            var users = this.dbContext.Users.Count();

            //Act
            var result = this.service.GetUsers().Result;

            //Assert
            Assert.AreEqual(users, result.Count());
        }

        [Test]
        public async Task Update_User()
        {
            //Arrange
            var model = new UserEditModel()
            {
                Id = this.GuestUser.Id,
                FirstName = "Test",
                LastName = "Test",
            };

            //Act
            var result = this.service.UpdateUser(model).Result;

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task Update_User_Must_Return_False()
        {
            //Arrange
            var model = new UserEditModel()
            {
                Id = "324143214",
                FirstName = "Test",
                LastName = "Test",
            };

            //Act
            var result = this.service.UpdateUser(model).Result;

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
