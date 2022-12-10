using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Core.Services;
using NUnit.Framework;

namespace GameForumWeb.Tests.Services
{
    public class CommentTest : UnitTestBase
    {
        private ICommentService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new CommentService(this.repo, this.mapper);
        }

        [Test]
        public async Task Add_Post_Comment()
        {
            //Arrange
            var comments = this.dbContext.PostsComments.Count();
            var commentModel = new CommentModel
            {
                Content = "gogogogogogogogogogoogogogogog",
                PostId = this.PostOne.Id,
                UserId = this.GuestUser.Id,
            };

            //Act
            var addComment = service.AddComment(commentModel, commentModel.UserId);
            //Assert
            var count = this.dbContext.PostsComments.Count();
            Assert.AreEqual(comments + 1, count);
        }

        [Test]
        public async Task Add_Post_Comment_Invalid_Post()
        {
            //Arrange
            var comments = this.dbContext.PostsComments.Count();
            var commentModel = new CommentModel
            {
                Content = "gogogogogogogogogogoogogogogog",
                PostId = 12341234,
                UserId = this.GuestUser.Id,
            };

            //Act
            var addComment = service.AddComment(commentModel, commentModel.UserId);
            //Assert
            var count = this.dbContext.PostsComments.Count();
            Assert.That(() => service.AddComment(commentModel, commentModel.UserId), Throws.ArgumentException);
        }

        [Test]
        public async Task Add_Post_Comment_Invalid_User()
        {
            //Arrange
            var comments = this.dbContext.PostsComments.Count();
            var commentModel = new CommentModel
            {
                Content = "gogogogogogogogogogoogogogogog",
                PostId = this.PostOne.Id,
                UserId = "äsdgsdfhsfgasdf",
            };

            //Act
            var addComment = service.AddComment(commentModel, commentModel.UserId);
            //Assert
            var count = this.dbContext.PostsComments.Count();
            Assert.That(() => service.AddComment(commentModel, commentModel.UserId), Throws.ArgumentException);
        }

        [Test]
        public async Task All_Comments()
        {
            //Arrange
            var comment = this.dbContext.PostsComments.Where(c=>c.Id == this.PostOne.Id).Count();
            //Act
            var result = service.AllComments(this.PostOne.Id);
            //Assert
            Assert.AreEqual(comment + 1, result.Result.Comments.Count());
        }

        [Test]
        public async Task All_Comments_Must_Throw()
        {
            //Arrange
            var commentId = 21324;
            //Act
            var result = service.AllComments(21324);
            //Assert
            Assert.That(() => service.GetCommentById(commentId), Throws.ArgumentException);
        }

        [Test]
        public async Task Delete_Comment()
        {
            var comment = this.dbContext.PostsComments.Where(c => c.Id == this.PostOne.Id && c.IsDeleted == false).Count();
            //Act
            var result = service.DeleteComment(this.PostOne.Id);
            //Assert
            var commentResult = this.dbContext.PostsComments.Where(c => c.Id == this.PostOne.Id && c.IsDeleted == true).Count();
            Assert.AreEqual(comment, commentResult);
        }

        [Test]
        public async Task Delete_Comment_Must_Throw()
        {
            var commentId = 1232134;
            //Act
            var result = service.DeleteComment(commentId);
            //Assert
            Assert.That(() => service.GetCommentById(commentId), Throws.ArgumentException);
        }
        [Test]
        public async Task Get_Comment_By_Id()
        {
            //Arrange
            var comment = this.dbContext.PostsComments.Where(c => c.Id == this.CommentOne.Id).FirstOrDefault();
            //Act
            var result = service.GetCommentById(this.CommentOne.Id).Result;
            //Assert
            Assert.AreEqual(comment.Content, result.Content);
        }

        [Test]
        public async Task Get_Comment_By_Id_MustThrow_Exeption()
        {
            //Arrange
            var commentId = 1232342;
            //Act
            var result = service.GetCommentById(commentId);
            //Assert
            Assert.That(() => service.GetCommentById(commentId), Throws.ArgumentException);
        }

        [Test]
        public async Task Update_Comment()
        {
            //Arrange
            var comment = this.dbContext.PostsComments.Where(c => c.Id == this.CommentOne.Id).FirstOrDefault();
            var model = new CommentModel() { Content = "GAGAGAGAGAGAGAGAGAGAGAGAGA" };
            //Act
            var result = service.UpdateComment(comment.Id, model);
            //Assert
            Assert.AreEqual(comment.Content, "GAGAGAGAGAGAGAGAGAGAGAGAGA");
        }

        [Test]
        public async Task Update_Comment_MustThrow_Exeption()
        {
            //Arrange
            var comment = 123;
            var model = new CommentModel() { Content = "GAGAGAGAGAGAGAGAGAGAGAGAGA" };
            //Act
            var result = service.UpdateComment(comment, model);
            //Assert
            AssertionException.ReferenceEquals(result, null);
        }
    }
}
