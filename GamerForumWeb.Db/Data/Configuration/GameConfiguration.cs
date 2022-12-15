using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(CreateGames());
        }

        private List<Game> CreateGames()
        {
            List<Game> games = new List<Game>()
            {
                new Game
                {
                    Id = 1,
                    Title = "World of Warcraft: Dragonflight",
                    Studio = "Blizzrd",
                    CategoryId = 5,
                    ImageUrl = "https://assets-prd.ignimgs.com/2022/04/19/wow-dragonflight-button-1-1650398895381.jpg",
                    Description = "World of Warcraft: Dragonflight is the ninth expansion pack for the massively multiplayer online role-playing game (MMORPG) World of Warcraft, following Shadowlands. It was announced in April 2022 and released on November 28, 2022.",
                    Rating = 10,
                    CreatedDate= DateTime.Now,
                },
                new Game
                {
                    Id = 2,
                    Title = "Minecraft",
                    Studio = "Mojang",
                    CategoryId = 1,
                    ImageUrl = "https://www.minecraft.net/content/dam/games/minecraft/key-art/CC-Update-Part-II_600x360.jpg",
                    Description = "Minecraft is a sandbox video game developed by Mojang Studios. The game was created by Markus \"Notch\" Persson in the Java programming language. Following several early private testing versions, it was first made public in May 2009 before being fully released in November 2011, with Notch stepping down and Jens \"Jeb\" Bergensten taking over development. Minecraft has since been ported to several other platforms and is the best-selling video game of all time, with over 238 million copies sold and nearly 140 million monthly active players as of 2021.",
                    Rating = 10,
                    CreatedDate= DateTime.Now,
                },
                new Game
                {
                    Id = 3,
                    Title = "Days Gone ",
                    Studio = "Sony Interactive Entertainment",
                    CategoryId = 9,
                    ImageUrl = "https://assets1.ignimgs.com/2017/08/11/days-gone---button-2-1502413280476.jpg",
                    Description = "Ride and fight into a deadly, post pandemic America. Play as Deacon St. John, a drifter and bounty hunter who rides the broken road, fighting to survive while searching for a reason to live in this open-world action-adventure game.",
                    Rating = 10,
                    CreatedDate= DateTime.Now,
                },
                new Game
                {
                    Id = 4,
                    Title = "The Outlast Trials",
                    Studio = "Red Barrels",
                    CategoryId = 9,
                    ImageUrl = "https://static.dir.bg/uploads/images/2021/08/26/2243277/1920x1080.jpg?_=1629985277",
                    Description = "Red Barrels invites you to experience mind-numbing terror, this time with friends. Whether you go through the trials alone or in teams, if you survive long enough and complete the therapy, Murkoff will happily let you leave… but will you be the same?",
                    Rating = 8,
                    CreatedDate= DateTime.Now,
                },
                new Game
                {
                    Id = 5,
                    Title = "Dying Light 2 Stay Human",
                    Studio = "Techland",
                    CategoryId = 9,
                    ImageUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_DyingLight2StayHuman_Techland_S3_2560x1440-f1dcd15207f091674615ccb4bd9dc3c7",
                    Description = "The virus won and civilization has fallen back to the Dark Ages. The City, one of the last human settlements, is on the brink of collapse. Use your agility and combat skills to survive, and reshape the world. Your choices matter.",
                    Rating = 10,
                    CreatedDate= DateTime.Now,

                },
            };
            
            return games;
        }
    }
}
