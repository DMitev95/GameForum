using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Post;

namespace GamerForumWeb.Core.Models.Post
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTitleLenght, MinimumLength = MinTitleLenght, ErrorMessage = "{0} lenght must be between {2} and {1} characters long!")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxContentLenght, MinimumLength = MinContentLenght, ErrorMessage = "{0} lenght must be between {2} and {1} characters long!")]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int GameId { get; set; }

    }
}
