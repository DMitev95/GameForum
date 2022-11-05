using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class SeedingTheDataBaseWithDemoFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Games_GameId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                values: new object[] { 1, 5, new DateTime(2022, 11, 3, 22, 2, 42, 292, DateTimeKind.Local).AddTicks(6124), null, "Dog shit game!!!", "https://upload.wikimedia.org/wikipedia/en/6/65/World_of_Warcraft.png", false, null, 6.0, "Blizzrd", "World of Warcraft" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedOn", "Description", "ImageUrl", "IsDeleted", "ModifiedOn", "Rating", "Studio", "Title" },
                values: new object[] { 2, 1, new DateTime(2022, 11, 3, 22, 2, 42, 292, DateTimeKind.Local).AddTicks(6198), null, "Great game", "https://www.minecraft.net/content/dam/games/minecraft/key-art/CC-Update-Part-II_600x360.jpg", false, null, 10.0, "Mojang", "Minecraft" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedOn", "GameId", "IsDeleted", "ModifiedOn", "Title", "UserId" },
                values: new object[] { 1, "I am on quest to kill some dogshit frogs and one is missing?!", new DateTime(2022, 11, 3, 22, 2, 42, 292, DateTimeKind.Local).AddTicks(6396), null, 1, false, null, "I got stuck in Northrend! Help me plox!!!", "c080eac6-2f20-4f29-8717-d059c81f1195" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[] { 1, "c080eac6-2f20-4f29-8717-d059c81f1195" });

            migrationBuilder.InsertData(
                table: "PostsComments",
                columns: new[] { "Id", "Content", "CreatedDate", "Likes", "PostId", "UpdatedDate", "UserId" },
                values: new object[] { 1, "You suck, go fuck yoursef!!!", new DateTime(2022, 11, 3, 22, 2, 42, 292, DateTimeKind.Local).AddTicks(6598), 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c080eac6-2f20-4f29-8717-d059c81f1195" });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Games_GameId",
                table: "Posts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Games_GameId",
                table: "Posts");

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
                keyValues: new object[] { 1, "c080eac6-2f20-4f29-8717-d059c81f1195" });

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

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Games_GameId",
                table: "Posts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
