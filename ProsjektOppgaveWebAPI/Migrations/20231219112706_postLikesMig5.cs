using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class postLikesMig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_Post_PostId1",
                table: "PostLike");

            migrationBuilder.DropIndex(
                name: "IX_PostLike_PostId1",
                table: "PostLike");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "722f1848-07ac-4e45-8871-7be591b1abd4");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "PostLike");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostLike",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11b3ed16-2da9-4678-bce1-821c514ce8c0", 0, "34076597-6b58-45a6-b02a-90d6917def42", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEFJ3I/p/mHmcjhWX5eA/wCopAfiWItp2/K5T8c7Qr54r997cpCYVaOWQoZnZ1dcZGw==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_PostId",
                table: "PostLike",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_Post_PostId",
                table: "PostLike",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_Post_PostId",
                table: "PostLike");

            migrationBuilder.DropIndex(
                name: "IX_PostLike_PostId",
                table: "PostLike");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11b3ed16-2da9-4678-bce1-821c514ce8c0");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "PostLike",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "PostLike",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "722f1848-07ac-4e45-8871-7be591b1abd4", 0, "0ed9547c-0d3f-490f-a8de-fbe71166632d", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEKEhUWxuTCXT1BrRWF+4pOHpzOfKFXRCNId3uqDJ1zMfM4CTXETl8lXURq4fV1w9Rw==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_PostId1",
                table: "PostLike",
                column: "PostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_Post_PostId1",
                table: "PostLike",
                column: "PostId1",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
