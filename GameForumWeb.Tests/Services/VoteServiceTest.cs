using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Services;
using NUnit.Framework;

namespace GameForumWeb.Tests.Services
{
    public class VoteServiceTest : UnitTestBase
    {
        private IVoteService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new VoteService(this.repo);
        }

        [Test]
        public async Task Add_New_Vote()
        {
            //Arrange
           

            //Act
            var result = await this.service.VoteAsync(this.CommentOne.Id,this.GuestUser.Id,true);

            //Assert
            var vote  = this.dbContext.Votes.FirstOrDefault(x => x.CommentId == this.CommentOne.Id);
            Assert.IsNotNull(vote);
            Assert.AreEqual("Up", vote.Type.ToString());
            Assert.That(result, Is.EqualTo(this.PostOne.Id));
        }

        [Test]
        public async Task Existing_Vote()
        {
            //Arrange


            //Act
            var result = await this.service.VoteAsync(this.CommentOne.Id, this.GuestUser.Id, false);

            //Assert
            var vote = this.dbContext.Votes.FirstOrDefault(x => x.CommentId == this.CommentOne.Id);
            Assert.IsNotNull(vote);
            Assert.AreEqual("Down", vote.Type.ToString());
            Assert.That(result, Is.EqualTo(this.PostOne.Id));
        }
    }
}
