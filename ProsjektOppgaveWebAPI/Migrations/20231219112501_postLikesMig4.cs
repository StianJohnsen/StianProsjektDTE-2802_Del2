using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class postLikesMig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_AspNetUsers_OwnerId1",
                table: "PostLike");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_Post_PostId",
                table: "PostLike");

            migrationBuilder.DropIndex(
                name: "IX_PostLike_OwnerId1",
                table: "PostLike");

            migrationBuilder.DropIndex(
                name: "IX_PostLike_PostId",
                table: "PostLike");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eece69df-ad51-4176-a283-2358e003042e");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "PostLike");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "PostLike",
                newName: "PostId1");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "PostLike",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PostLike",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "722f1848-07ac-4e45-8871-7be591b1abd4", 0, "0ed9547c-0d3f-490f-a8de-fbe71166632d", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEKEhUWxuTCXT1BrRWF+4pOHpzOfKFXRCNId3uqDJ1zMfM4CTXETl8lXURq4fV1w9Rw==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_PostId1",
                table: "PostLike",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_UserId",
                table: "PostLike",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_AspNetUsers_UserId",
                table: "PostLike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_Post_PostId1",
                table: "PostLike",
                column: "PostId1",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_AspNetUsers_UserId",
                table: "PostLike");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_Post_PostId1",
                table: "PostLike");

            migrationBuilder.DropIndex(
                name: "IX_PostLike_PostId1",
                table: "PostLike");

            migrationBuilder.DropIndex(
                name: "IX_PostLike_UserId",
                table: "PostLike");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "722f1848-07ac-4e45-8871-7be591b1abd4");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostLike");

            migrationBuilder.RenameColumn(
                name: "PostId1",
                table: "PostLike",
                newName: "OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostLike",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "PostLike",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eece69df-ad51-4176-a283-2358e003042e", 0, "a0ee4f50-863b-4bd5-8260-3f83344e4665", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEDB1tNgkLrya4wXr35AxWXXWrOopK8fBijjJ0AoktlHtQOngO7LcQx4qZbfhz9D8ig==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_OwnerId1",
                table: "PostLike",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_PostId",
                table: "PostLike",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_AspNetUsers_OwnerId1",
                table: "PostLike",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_Post_PostId",
                table: "PostLike",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
