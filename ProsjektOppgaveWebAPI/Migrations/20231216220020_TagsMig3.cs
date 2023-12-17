using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class TagsMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "090d8c35-9857-4c4c-9f07-b57ed3f78fb9");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostTag",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0ad3a295-69a7-4808-b14b-997c28d528ea", 0, "8bf1b30e-0e9d-4362-b1fb-013f226840ed", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEBUUT6JDVaAX8m2zmD2sM8uWGrTvXgW2Iw0xxCod6Lq2aF3EjegyHTSguB+RjX2MJA==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_PostId",
                table: "PostTag",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.DropIndex(
                name: "IX_PostTag_PostId",
                table: "PostTag");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ad3a295-69a7-4808-b14b-997c28d528ea");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "090d8c35-9857-4c4c-9f07-b57ed3f78fb9", 0, "5b121c51-f545-4904-8ba5-4461f00275c2", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEIB/J5dfrQDBOXp1vuJRB2fhgXI/LHFM1+DM4ND0sIqVkiV9sfZKpxxr1Y+A7rIBpQ==", null, false, "", false, "admin" });
        }
    }
}
