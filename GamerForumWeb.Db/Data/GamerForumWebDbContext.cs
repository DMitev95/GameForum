using GamerForumWeb.Db.Data.Configuration;
using GamerForumWeb.Db.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Db.Data
{
    public class GamerForumWebDbContext : IdentityDbContext<User>
    {
        public GamerForumWebDbContext(DbContextOptions<GamerForumWebDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostsComments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGames>()
                .HasKey(x => new { x.UserId, x.GameId });

            builder.Entity<Post>()
                .HasOne(e => e.User)
                .WithMany(c => c.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Vote>()
                .HasOne(v => v.Comment)
                .WithMany(c => c.Votes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User);

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PostComentConfiguration());
            builder.ApplyConfiguration(new UserGamesConfiguration());
            //builder.ApplyConfiguration(new RoleConfiguration());


            builder.Entity<User>().Property(u => u.UserName).HasMaxLength(20).IsRequired();

            builder.Entity<User>().Property(u => u.Email).HasMaxLength(60).IsRequired();

            base.OnModelCreating(builder);
        }
    }
}