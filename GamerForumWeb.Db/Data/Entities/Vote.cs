using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamerForumWeb.Db.Data.Entities
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int CommentId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public PostComment Comment { get; set; } = null!;

        
        public string UserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        public VoteType Type { get; set; }

    }
}
