using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "PostsComments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PostsComments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "2c535183-b07e-42f3-9f59-682ab896e89d", new DateTime(2022, 12, 10, 18, 34, 10, 27, DateTimeKind.Local).AddTicks(5621) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "138e0f23-25e7-418f-8ad8-1f3318ce637a", new DateTime(2022, 12, 10, 18, 34, 10, 27, DateTimeKind.Local).AddTicks(5909) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 10, 18, 34, 10, 24, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 10, 18, 34, 10, 26, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 10, 18, 34, 10, 26, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 10, 18, 34, 10, 27, DateTimeKind.Local).AddTicks(280), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PostsComments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostsComments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PostsComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "PostsComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "9197c5d4-8601-4afe-b457-7fc09fe04c57", new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "aa8ab4fd-d601-488f-9763-53ea825d6989", new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(366) });

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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 15, 18, 34, 53, 915, DateTimeKind.Local).AddTicks(165), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
