using Microsoft.AspNetCore.Identity;

namespace GamerForumWeb.Db.Data.Entities
{
    public class Role : IdentityRole
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
