using GamerForumWeb.Db.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Game;

namespace GamerForumWeb.Core.Models.Game
{
    public class GameModel
    {
        [Required]
        [StringLength(MaxTitleLenght, MinimumLength = MinTitleLenght, ErrorMessage = "{0} lenght must be between {2} and {1} characters long!")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxStudioLenght, MinimumLength = MinStudioLenght, ErrorMessage = "{0} lenght must be between {2} and {1} characters long!")]
        public string Studio { get; set; }

        [Required]
        [StringLength(MaxDescriptionLenght, MinimumLength = MinDescriptionLenght, ErrorMessage = "{0} lenght must be between {2} and {1} characters long!")]
        public string Description { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
