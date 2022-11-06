using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Post;


namespace GamerForumWeb.Db.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxContentLenght)]
        public string Content { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; } = null!;

        public List<PostComment> Comments { get; set; } = new List<PostComment>();

        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
    }
}
