using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class TagsMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Post_PostsPostId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tag_TagsId",
                table: "PostTag");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd2caaba-411f-4666-9836-a1c07b247c5a");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "PostTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "PostsPostId",
                table: "PostTag",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                newName: "IX_PostTag_TagId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "090d8c35-9857-4c4c-9f07-b57ed3f78fb9", 0, "5b121c51-f545-4904-8ba5-4461f00275c2", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEIB/J5dfrQDBOXp1vuJRB2fhgXI/LHFM1+DM4ND0sIqVkiV9sfZKpxxr1Y+A7rIBpQ==", null, false, "", false, "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tag_TagId",
                table: "PostTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tag_TagId",
                table: "PostTag");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "090d8c35-9857-4c4c-9f07-b57ed3f78fb9");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "PostTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "PostTag",
                newName: "PostsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_TagId",
                table: "PostTag",
                newName: "IX_PostTag_TagsId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd2caaba-411f-4666-9836-a1c07b247c5a", 0, "25be6c84-4b9f-4b66-a08a-a1d65ad3647c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAELLuO8lQ+TXrhJ6Vc7hdfARQcmP7YL5mLnZDxeYSRwype03YZ0Og6u5KEV13s6rQBQ==", null, false, "", false, "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post_PostsPostId",
                table: "PostTag",
                column: "PostsPostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tag_TagsId",
                table: "PostTag",
                column: "TagsId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
