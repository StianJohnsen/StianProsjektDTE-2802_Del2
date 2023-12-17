using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class TagsMig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ad3a295-69a7-4808-b14b-997c28d528ea");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "57592c00-63e8-4bb0-8171-05aa78695845", 0, "1d7c9fb4-0b22-46a7-a6bb-7c91e1efcfc6", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAECuKlUqVCaMUS5+9cMy3jKCbLJHas06eWVVHGFCWdmVv5/lVzL5KUV2rR3FM2+/2AQ==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57592c00-63e8-4bb0-8171-05aa78695845");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0ad3a295-69a7-4808-b14b-997c28d528ea", 0, "8bf1b30e-0e9d-4362-b1fb-013f226840ed", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEBUUT6JDVaAX8m2zmD2sM8uWGrTvXgW2Iw0xxCod6Lq2aF3EjegyHTSguB+RjX2MJA==", null, false, "", false, "admin" });
        }
    }
}
