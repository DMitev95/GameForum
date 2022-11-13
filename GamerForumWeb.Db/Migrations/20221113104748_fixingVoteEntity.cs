using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerForumWeb.Db.Migrations
{
    public partial class fixingVoteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_PostsComments_PostCommentId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "PostCommentId",
                table: "Votes",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_PostCommentId",
                table: "Votes",
                newName: "IX_Votes_CommentId");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 12, 47, 48, 644, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 12, 47, 48, 644, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 12, 47, 48, 644, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 13, 12, 47, 48, 644, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_PostsComments_CommentId",
                table: "Votes",
                column: "CommentId",
                principalTable: "PostsComments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_PostsComments_CommentId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Votes",
                newName: "PostCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_CommentId",
                table: "Votes",
                newName: "IX_Votes_PostCommentId");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "PostsComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 12, 20, 38, 30, 650, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_PostsComments_PostCommentId",
                table: "Votes",
                column: "PostCommentId",
                principalTable: "PostsComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
