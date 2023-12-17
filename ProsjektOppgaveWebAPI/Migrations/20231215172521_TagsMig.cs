using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsjektOppgaveWebAPI.Migrations
{
    public partial class TagsMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTagRelations");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71d12dd0-d81b-4b0e-b51b-1a9deb3a0527");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tag",
                newName: "content");

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsPostId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Post_PostsPostId",
                        column: x => x.PostsPostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd2caaba-411f-4666-9836-a1c07b247c5a", 0, "25be6c84-4b9f-4b66-a08a-a1d65ad3647c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAELLuO8lQ+TXrhJ6Vc7hdfARQcmP7YL5mLnZDxeYSRwype03YZ0Og6u5KEV13s6rQBQ==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd2caaba-411f-4666-9836-a1c07b247c5a");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Tag",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "BlogTagRelations",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTagRelations", x => new { x.BlogId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogTagRelations_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTagRelations_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71d12dd0-d81b-4b0e-b51b-1a9deb3a0527", 0, "ee079c12-00e0-4ec2-85d8-e0b552720d88", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEPFAbfaWxWUEG60yse2wLNHmvofOtZHr+tEiIupTUsCHhX476jq3YWEPfjNdFSncUA==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTagRelations_TagId",
                table: "BlogTagRelations",
                column: "TagId");
        }
    }
}
