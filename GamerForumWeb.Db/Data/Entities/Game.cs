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
        [StringLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxStudioLenght)]
        public string Studio { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public double Rating { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }   
        
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<UserGames> Users { get; set; } = new List<UserGames>();        
    }
}
