using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gremy.ovh.Infrastructure.Migrations;
public partial class InitialMigration : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Posts",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
          Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
          Body = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
          CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Posts", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "Comments",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
          Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
          Body = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
          CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
          PostId = table.Column<int>(type: "INTEGER", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Comments", x => x.Id);
          table.ForeignKey(
                    name: "FK_Comments_Posts_PostId",
                    column: x => x.PostId,
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "ContentData",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
          FileName = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
          PostId = table.Column<int>(type: "INTEGER", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ContentData", x => x.Id);
          table.ForeignKey(
                    name: "FK_ContentData_Posts_PostId",
                    column: x => x.PostId,
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_Comments_PostId",
        table: "Comments",
        column: "PostId");

    migrationBuilder.CreateIndex(
        name: "IX_ContentData_PostId",
        table: "ContentData",
        column: "PostId");
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Comments");

    migrationBuilder.DropTable(
        name: "ContentData");

    migrationBuilder.DropTable(
        name: "Posts");
  }
}
