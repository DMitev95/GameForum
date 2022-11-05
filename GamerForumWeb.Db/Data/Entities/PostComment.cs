using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.PostComment;


namespace GamerForumWeb.Db.Data.Entities
{
    public class PostComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxContentLenght)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; }

        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
