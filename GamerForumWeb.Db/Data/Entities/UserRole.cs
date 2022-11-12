using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamerForumWeb.Db.Data.Entities
{
    public class UserRole : IdentityUserRole
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;


        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;
    }
}
