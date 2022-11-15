using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class creatingRolesAndSeedThem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "9197c5d4-8601-4afe-b457-7fc09fe04c57", new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(360), null, "Admin", null },
                    { "2", "aa8ab4fd-d601-488f-9763-53ea825d6989", new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(366), null, "User", null }
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(165));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 13, 48, 3, 602, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 13, 48, 3, 602, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 13, 48, 3, 603, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 13, 48, 3, 603, DateTimeKind.Local).AddTicks(52));
        }
    }
}
