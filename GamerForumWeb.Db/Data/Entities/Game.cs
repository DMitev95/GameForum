using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Game;



namespace GamerForumWeb.Db.Data.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxStudioLenght)]
        public string Studio { get; set; }

        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }   
        
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category ForumCategory { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<UserGames> Users { get; set; } = new List<UserGames>();        
    }
}
