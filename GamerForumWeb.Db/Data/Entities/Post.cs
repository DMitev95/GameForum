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


        
        public string UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } 

      
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; } = null!;

        public List<PostComment> Comments { get; set; } = new List<PostComment>();
        
    }
}
