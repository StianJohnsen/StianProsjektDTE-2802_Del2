using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class postLikesMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_AspNetUsers_UserId1",
                table: "PostLike");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "285a1a82-5379-4561-8fa9-0ec8e8443325");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "PostLike",
                newName: "OwnerId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PostLike",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_PostLike_UserId1",
                table: "PostLike",
                newName: "IX_PostLike_OwnerId1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eece69df-ad51-4176-a283-2358e003042e", 0, "a0ee4f50-863b-4bd5-8260-3f83344e4665", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEDB1tNgkLrya4wXr35AxWXXWrOopK8fBijjJ0AoktlHtQOngO7LcQx4qZbfhz9D8ig==", null, false, "", false, "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_AspNetUsers_OwnerId1",
                table: "PostLike",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_AspNetUsers_OwnerId1",
                table: "PostLike");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eece69df-ad51-4176-a283-2358e003042e");

            migrationBuilder.RenameColumn(
                name: "OwnerId1",
                table: "PostLike",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "PostLike",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostLike_OwnerId1",
                table: "PostLike",
                newName: "IX_PostLike_UserId1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "285a1a82-5379-4561-8fa9-0ec8e8443325", 0, "75104ced-373b-4c1d-a504-62283d24e002", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAECYHWTZn3t0ITpzJAsYUhaWXcBOSXTRVYHAvqXnhtYlhRWDGfSxMfiBiGKJqF4KpEA==", null, false, "", false, "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_AspNetUsers_UserId1",
                table: "PostLike",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
