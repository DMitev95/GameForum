using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.User;

namespace GamerForumWeb.Db.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(MaxUserFirstNameLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(MaxUserLastNameLenght)]
        public string LastName { get; set; } = null!;

        [MaxLength(MaxCountryNameLenght)]
        public string? Country { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();

        public List<PostComment> Comments { get; set; } = new List<PostComment>();

        public List<UserGames> Games { get; set; } = new List<UserGames>();

    }
}
