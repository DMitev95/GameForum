using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class FixintVoteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Posts_PostId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Votes",
                newName: "PostCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_PostId",
                table: "Votes",
                newName: "IX_Votes_PostCommentId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "3a6a2874-efcb-4bef-90bc-f61ba3b4f7b0", new DateTime(2022, 11, 12, 12, 38, 34, 430, DateTimeKind.Local).AddTicks(3387) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "ea0c4424-dc2b-498d-b283-6a57c0d8fedc", new DateTime(2022, 11, 12, 12, 38, 34, 430, DateTimeKind.Local).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 12, 38, 34, 429, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 12, 38, 34, 429, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 12, 38, 34, 429, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 12, 38, 34, 429, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_PostsComments_PostCommentId",
                table: "Votes",
                column: "PostCommentId",
                principalTable: "PostsComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_PostsComments_PostCommentId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "PostCommentId",
                table: "Votes",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_PostCommentId",
                table: "Votes",
                newName: "IX_Votes_PostId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "edebbf8c-6d34-4085-ab24-db5e3a38f8e1", new DateTime(2022, 11, 12, 11, 18, 27, 492, DateTimeKind.Local).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedOn" },
                values: new object[] { "28c9f935-9eaf-4a9b-9820-450d4bce0c47", new DateTime(2022, 11, 12, 11, 18, 27, 492, DateTimeKind.Local).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 11, 18, 27, 492, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 11, 18, 27, 492, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 11, 18, 27, 492, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 11, 18, 27, 492, DateTimeKind.Local).AddTicks(3419));

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Posts_PostId",
                table: "Votes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
