using GamerForumWeb.Db.Data.Configuration;
using GamerForumWeb.Db.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GamerForumWeb.Db.Data
{
    public class GamerForumWebDbContext : IdentityDbContext<User, Role, string>
    {
        private bool seedDb;
        public GamerForumWebDbContext(DbContextOptions<GamerForumWebDbContext> options, bool seed = true)
            : base(options)
        {
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }
            this.seedDb = seed;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostsComments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Game> Games { get; set; }

        private User GuestUser { get; set; }

        private User GuestUserTwo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGames>()
                .HasKey(x => new { x.UserId, x.GameId });

            builder.Entity<Post>()
                .HasOne(e => e.User)
                .WithMany(c => c.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PostComment>()
                .HasMany(pc => pc.Votes)
                .WithOne(c => c.Comment)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PostComentConfiguration());
            builder.ApplyConfiguration(new UserGamesConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());


            builder.Entity<User>().Property(u => u.UserName).HasMaxLength(20).IsRequired();

            builder.Entity<User>().Property(u => u.Email).HasMaxLength(60).IsRequired();

            if (this.seedDb)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                this.GuestUser = new User
                {
                    Id = "1",
                    UserName = "guest",
                    NormalizedUserName = "GUEST",
                    Email = "guest@mail.com",
                    NormalizedEmail = "GUEST@MAIL.COM",
                    FirstName = "Guest",
                    LastName = "User",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };
                this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guestPassword");

                this.GuestUserTwo = new User
                {
                    Id = "2",
                    UserName = "guestTwo",
                    NormalizedUserName = "GUESTTWO",
                    Email = "guestTwo@mail.com",
                    NormalizedEmail = "GUESTTWO@MAIL.COM",
                    FirstName = "GuestTwo",
                    LastName = "UserTwo",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };
                this.GuestUserTwo.PasswordHash = hasher.HashPassword(this.GuestUserTwo, "guestPasswordTwo");

                builder.Entity<User>().HasData(this.GuestUser, this.GuestUserTwo);

                builder.Entity<Category>().HasData(new Category
                {
                    Id = 1,
                    Name = "Horror"
                });

                builder.Entity<Game>().HasData(new Game
                {
                    Id = 1,

                    Title = null!,

                    Studio = null!,

                    Description = null!,

                    Rating = 10,

                    ImageUrl = null!,

                    CreatedDate = DateTime.Now,

                    ModifiedOn = null,

                    IsDeleted = false,

                    DeletedOn = null,

                    CategoryId = 1
                });

                builder.Entity<Post>().HasData(new Post
                {

                    Id = 1,

                    Title = "Dayz Gone ",

                    Content = "Prety good game! I love it!",

                    CreatedDate = DateTime.Now,

                    ModifiedOn = null,

                    IsDeleted = false,

                    DeletedOn = null,

                    UserId = this.GuestUserTwo.Id,


                    GameId = 1,


                });

                builder.Entity<PostComment>().HasData(new PostComment
                {
                    Id = 1,
                    Content = "Tova e test! Tova e test! Tova e test! Tova e test!",

                    CreatedDate = DateTime.Now,

                    UpdatedDate = null,

                    IsDeleted = false,

                    DeletedOn = null,

                    PostId = 1,

                    UserId = this.GuestUserTwo.Id
                });
            }

            base.OnModelCreating(builder);
        }
    }
}