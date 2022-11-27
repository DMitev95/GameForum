using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerForumWeb.Core.Models.Users
{
    public class UsersRolesModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string[] RoleNames { get; set; }
    }
}
