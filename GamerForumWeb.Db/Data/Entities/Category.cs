using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Category;

namespace GamerForumWeb.Db.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxCategoryNameLenght)]
        public string Name { get; set; } = null!;

        public List<Game> GamesCategories { get; set; } = new List<Game>();


    }
}
