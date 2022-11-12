using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sandbox" },
                    { 2, "Real-time strategy (RTS)" },
                    { 3, "Real-time strategy (RTS)" },
                    { 4, "Multiplayer online battle arena (MOBA)" },
                    { 5, "Role-playing (RPG, ARPG, and More)" },
                    { 6, "Simulation and sports" },
                    { 7, "Puzzlers and party games" },
                    { 8, "Action-adventure" },
                    { 9, "Survival and horror" },
                    { 10, "Platformer" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedOn", "Description", "ImageUrl", "IsDeleted", "ModifiedOn", "Rating", "Studio", "Title" },
                values: new object[] { 1, 5, new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1247), null, "Dog shit game!!!", "https://upload.wikimedia.org/wikipedia/en/6/65/World_of_Warcraft.png", false, null, 6m, "Blizzrd", "World of Warcraft" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedOn", "Description", "ImageUrl", "IsDeleted", "ModifiedOn", "Rating", "Studio", "Title" },
                values: new object[] { 2, 1, new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1279), null, "Great game", "https://www.minecraft.net/content/dam/games/minecraft/key-art/CC-Update-Part-II_600x360.jpg", false, null, 10m, "Mojang", "Minecraft" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "GameId", "ModifiedOn", "Title", "UserId" },
                values: new object[] { 1, "I am on quest to kill some dogshit frogs and one is missing?!", new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1327), 1, null, "I got stuck in Northrend! Help me plox!!!", "06df5d6a-ae43-4a1e-a3ad-0c9f6ddf777c" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[] { 1, "06df5d6a-ae43-4a1e-a3ad-0c9f6ddf777c" });

            migrationBuilder.InsertData(
                table: "PostsComments",
                columns: new[] { "Id", "Content", "CreatedDate", "Likes", "PostId", "UpdatedDate", "UserId" },
                values: new object[] { 1, "You suck, go fuck yoursef!!!", new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1381), 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "06df5d6a-ae43-4a1e-a3ad-0c9f6ddf777c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 1, "06df5d6a-ae43-4a1e-a3ad-0c9f6ddf777c" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
