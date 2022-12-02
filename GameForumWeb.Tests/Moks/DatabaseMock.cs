using GamerForumWeb.Db.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForumWeb.Tests.Moks
{
    public class DatabaseMock
    {
        public static GamerForumWebDbContext Instance
        {
            get
            {
                DbContextOptionsBuilder<GamerForumWebDbContext> optionsBuilder =
                        new DbContextOptionsBuilder<GamerForumWebDbContext>();

                optionsBuilder.UseInMemoryDatabase($"GameForum-TestDb-{DateTime.Now.Ticks}");

                return new GamerForumWebDbContext(optionsBuilder.Options, false);
            }
        }
    }
}
