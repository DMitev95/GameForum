using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class seedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "48bd96bb-2788-4c76-b00b-0b923d692a48", new DateTime(2022, 12, 15, 20, 36, 30, 684, DateTimeKind.Local).AddTicks(1104), null, "Admin", "ADMIN" },
                    { "2", "42fbe6ab-ad2c-4665-b771-5348207664b0", new DateTime(2022, 12, 15, 20, 36, 30, 684, DateTimeKind.Local).AddTicks(1469), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Country", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1", 0, "cac78b32-932a-4b68-99e7-305d9b64c0cd", null, new DateTime(2022, 12, 15, 20, 36, 30, 678, DateTimeKind.Local).AddTicks(4474), "admin@gmail.bg", false, "Admin", "Admin", false, null, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEN7E4JhnXGZ0RGY4OFdb3E9eiDtcJSAysCTm9YOzWLejnfqyDWs0ehkoosPo6radzQ==", null, false, "812c4f32-959e-4130-a820-a679016a83bd", false, "admin" });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedOn", "Description", "ImageUrl", "IsDeleted", "ModifiedOn", "Rating", "Studio", "Title" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(1833), null, "World of Warcraft: Dragonflight is the ninth expansion pack for the massively multiplayer online role-playing game (MMORPG) World of Warcraft, following Shadowlands. It was announced in April 2022 and released on November 28, 2022.", "https://assets-prd.ignimgs.com/2022/04/19/wow-dragonflight-button-1-1650398895381.jpg", false, null, 10m, "Blizzrd", "World of Warcraft: Dragonflight" },
                    { 2, 1, new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(1995), null, "Minecraft is a sandbox video game developed by Mojang Studios. The game was created by Markus \"Notch\" Persson in the Java programming language. Following several early private testing versions, it was first made public in May 2009 before being fully released in November 2011, with Notch stepping down and Jens \"Jeb\" Bergensten taking over development. Minecraft has since been ported to several other platforms and is the best-selling video game of all time, with over 238 million copies sold and nearly 140 million monthly active players as of 2021.", "https://www.minecraft.net/content/dam/games/minecraft/key-art/CC-Update-Part-II_600x360.jpg", false, null, 10m, "Mojang", "Minecraft" },
                    { 3, 9, new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(1998), null, "Ride and fight into a deadly, post pandemic America. Play as Deacon St. John, a drifter and bounty hunter who rides the broken road, fighting to survive while searching for a reason to live in this open-world action-adventure game.", "https://assets1.ignimgs.com/2017/08/11/days-gone---button-2-1502413280476.jpg", false, null, 10m, "Sony Interactive Entertainment", "Days Gone " },
                    { 4, 9, new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(2001), null, "Red Barrels invites you to experience mind-numbing terror, this time with friends. Whether you go through the trials alone or in teams, if you survive long enough and complete the therapy, Murkoff will happily let you leave… but will you be the same?", "https://static.dir.bg/uploads/images/2021/08/26/2243277/1920x1080.jpg?_=1629985277", false, null, 8m, "Red Barrels", "The Outlast Trials" },
                    { 5, 9, new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(2003), null, "The virus won and civilization has fallen back to the Dark Ages. The City, one of the last human settlements, is on the brink of collapse. Use your agility and combat skills to survive, and reshape the world. Your choices matter.", "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_DyingLight2StayHuman_Techland_S3_2560x1440-f1dcd15207f091674615ccb4bd9dc3c7", false, null, 10m, "Techland", "Dying Light 2 Stay Human" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedOn", "GameId", "IsDeleted", "ModifiedOn", "Title", "UserId" },
                values: new object[] { 1, "I am on quest to kill some frogs and one is missing?!", new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(3970), null, 1, false, null, "I got stuck in Northrend! Help me plox!!!", "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[] { 1, "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1" });

            migrationBuilder.InsertData(
                table: "PostsComments",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedOn", "IsDeleted", "PostId", "UpdatedDate", "UserId" },
                values: new object[] { 1, "I need Help please help me!", new DateTime(2022, 12, 15, 20, 36, 30, 685, DateTimeKind.Local).AddTicks(6702), null, false, 1, null, "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1" });

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
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { 1, "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1");

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
