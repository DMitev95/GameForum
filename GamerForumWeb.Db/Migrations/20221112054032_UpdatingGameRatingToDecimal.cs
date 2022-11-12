using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class UpdatingGameRatingToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rating" },
                values: new object[] { new DateTime(2022, 11, 12, 7, 40, 32, 632, DateTimeKind.Local).AddTicks(6259), 6m });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rating" },
                values: new object[] { new DateTime(2022, 11, 12, 7, 40, 32, 632, DateTimeKind.Local).AddTicks(6291), 10m });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 7, 40, 32, 632, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 7, 40, 32, 632, DateTimeKind.Local).AddTicks(6378));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Games",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rating" },
                values: new object[] { new DateTime(2022, 11, 6, 11, 51, 31, 320, DateTimeKind.Local).AddTicks(1762), 6.0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rating" },
                values: new object[] { new DateTime(2022, 11, 6, 11, 51, 31, 320, DateTimeKind.Local).AddTicks(1792), 10.0 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 6, 11, 51, 31, 320, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 6, 11, 51, 31, 320, DateTimeKind.Local).AddTicks(1877));
        }
    }
}
