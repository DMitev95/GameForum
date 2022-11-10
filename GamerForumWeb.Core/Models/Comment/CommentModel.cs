using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.PostComment;
namespace GamerForumWeb.Core.Models.Comment
{
    public class CommentModel
    {
        [Required]
        [StringLength(MaxContentLenght, MinimumLength = MinContentLenght, ErrorMessage = "{0} lenght must be between {2} and {1} characters long!")]
        public string Content { get; set; } = null!;

        public int Likes { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; } = null!;
    }
}
