﻿using GamerForumWeb.Db.Data.Configuration;
using GamerForumWeb.Db.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;

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
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<PostComment> PostsComments { get; set; } = null!;
        public DbSet<Vote> Votes { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;

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

            builder.Entity<User>().Property(u => u.UserName).HasMaxLength(20).IsRequired();

            builder.Entity<User>().Property(u => u.Email).HasMaxLength(60).IsRequired();

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new RoleConfiguration());
                builder.ApplyConfiguration(new UserRolesConfiguration());
                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new GameConfiguration());
                builder.ApplyConfiguration(new PostConfiguration());
                builder.ApplyConfiguration(new PostComentConfiguration());
                builder.ApplyConfiguration(new UserGamesConfiguration());            
            }

            base.OnModelCreating(builder);
        }
    }
}