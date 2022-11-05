using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.User;

namespace GamerForumWeb.Db.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstNameLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxUserLastNameLenght)]
        public string LastName { get; set; }

        [MaxLength(MaxCountryNameLenght)]
        public string? Country { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }


        public List<Post> Posts = new List<Post>();


        public List<UserGames> Games = new List<UserGames>();

    }
}
