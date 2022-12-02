using AutoMapper;
using GameForumWeb.Tests.Moks;
using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace GameForumWeb.Tests.Services
{
    public class UnitTestBase
    {
        protected GamerForumWebDbContext dbContext;
        protected IMapper mapper;
        protected IRepository repo;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.dbContext = DatabaseMock.Instance;           
            this.mapper = MapperMock.Instance;
            this.repo = new RepositoryMock(this.dbContext);
            this.SeedDatabase();
        }

        public User GuestUser { get; set; }

        public User GuestUserTwo { get; set; }

        public Post PostOne { get; set; }
        public Post PostTwo { get; set; }

        public PostComment CommentOne { get; set; }
        public PostComment CommentTwo { get; set; }

        public Game GameOne { get; set; }
        public Game GameTwo { get; set; }

        public Category CategoryOne { get; set; }
        public Category CategoryTwo { get; set; }



        private void SeedDatabase()
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            this.GuestUser = new User
            {
                Id = "1",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guestPassword");

            this.GuestUserTwo = new User
            {
                Id = "2",
                UserName = "guestTwo",
                NormalizedUserName = "GUESTTWO",
                Email = "guestTwo@mail.com",
                NormalizedEmail = "GUESTTWO@MAIL.COM",
                FirstName = "GuestTwo",
                LastName = "UserTwo",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            this.GuestUserTwo.PasswordHash = hasher.HashPassword(this.GuestUserTwo, "guestPasswordTwo");
            this.dbContext.AddRange(this.GuestUser,this.GuestUserTwo);

            this.CategoryOne = new Category
            {
                Name = "Horror"
            };
            this.CategoryTwo = new Category
            {
                Name = "MMORPG"
            };
            this.dbContext.AddRange(this.CategoryOne, this.CategoryTwo);

            this.GameOne = new Game
            {
                Title = "Dayz Gone ",

                Studio = "Test Test Test Test Test Test Test",

                Description = "Test Test Test Test Test Test ",

                Rating = 10,

                ImageUrl = "Test Test Test Test Test Test Test Test",

                CreatedDate = DateTime.Now,

                ModifiedOn = null,

                IsDeleted = false,

                DeletedOn = null,

                CategoryId = this.CategoryOne.Id,
            };
            this.GameTwo = new Game
            {
                Title = "World of Warcraft",

                Studio = "Test Test Test Test Test Test Test",

                Description = "Test Test Test Test Test Test ",

                Rating = 10,

                ImageUrl = "Test Test Test Test Test Test Test Test",

                CreatedDate = DateTime.Now,

                ModifiedOn = null,

                IsDeleted = false,

                DeletedOn = null,

                CategoryId = this.CategoryTwo.Id,
            };
            this.dbContext.AddRange(this.GameOne, this.GameTwo);

            this.PostOne = new Post
            {

                Title = "Dayz Gone ",

                Content = "Prety good game! I love it!",

                CreatedDate = DateTime.Now,

                ModifiedOn = null,

                IsDeleted = false,

                DeletedOn = null,

                UserId = this.GuestUserTwo.Id,

                GameId = 1,

            };
            this.PostTwo = new Post
            {

                Title = "I need help for ICC!!! ",

                Content = "We are looking for good players!!",

                CreatedDate = DateTime.Now,

                ModifiedOn = null,

                IsDeleted = false,

                DeletedOn = null,

                UserId = this.GuestUser.Id,

                GameId = 2,

            };
            this.dbContext.AddRange(this.PostOne, this.PostTwo);

            this.CommentOne = new PostComment
            {
                Content = "Tova e test! Tova e test! Tova e test! Tova e test!",

                CreatedDate = DateTime.Now,

                UpdatedDate = null,

                IsDeleted = false,

                DeletedOn = null,

                PostId = 1,

                UserId = this.GuestUserTwo.Id
            };
            this.CommentTwo = new PostComment
            {
                Content = "Tova e test! Tova e test! Tova e test! Tova e test!",

                CreatedDate = DateTime.Now,

                UpdatedDate = null,

                IsDeleted = false,

                DeletedOn = null,

                PostId = 2,

                UserId = this.GuestUser.Id
            };
            this.dbContext.AddRange(this.CommentOne, this.CommentTwo);

            dbContext.SaveChanges();
        }
    }
}
