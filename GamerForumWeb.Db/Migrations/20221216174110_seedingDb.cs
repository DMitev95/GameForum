using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class seedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "e718fdc2-6367-4617-b03d-4dc0b900f967", new DateTime(2022, 12, 16, 19, 41, 10, 286, DateTimeKind.Local).AddTicks(637) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "a0b50cfc-2bdb-4536-8ed2-9ab686c66d87", new DateTime(2022, 12, 16, 19, 41, 10, 286, DateTimeKind.Local).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0057e4a8-8169-42a4-b3f6-8c52c6dfbbd4", new DateTime(2022, 12, 16, 19, 41, 10, 279, DateTimeKind.Local).AddTicks(9690), "AQAAAAEAACcQAAAAEEK2YdJTwo+fqzEDk59BeMlLvaN1w0AfcZdbztv0+swNKPHRkHGI9MZGMZlmJUbQ2g==", "7540badd-cb79-4de8-a3fb-7d51ae076ee6" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 41, 10, 287, DateTimeKind.Local).AddTicks(8847));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "a6ed2e9f-79ed-4f7c-8c30-e4c4cb7613d9", new DateTime(2022, 12, 16, 19, 40, 42, 558, DateTimeKind.Local).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "e0e03065-cc3c-4f15-87fe-eafd5dc2be1b", new DateTime(2022, 12, 16, 19, 40, 42, 558, DateTimeKind.Local).AddTicks(6151) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5156a0-d46a-4627-bbc5-6175536c3c16", new DateTime(2022, 12, 16, 19, 40, 42, 551, DateTimeKind.Local).AddTicks(518), "AQAAAAEAACcQAAAAECOaKaeomm4YnO2oJzeKXwmf0TsNDEHlm3jBHjQTDiu9vab0sFV+SqPpKqgBlkJatA==", "bfe801be-e491-46ba-b9a1-2d5dca71318a" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 559, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 559, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 559, DateTimeKind.Local).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 559, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 559, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 560, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 19, 40, 42, 560, DateTimeKind.Local).AddTicks(5473));
        }
    }
}
