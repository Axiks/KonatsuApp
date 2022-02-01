using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Konatsu.API.Migrations
{
    public partial class AddTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagEntityId",
                table: "Habits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserCreated = table.Column<Guid>(type: "uuid", nullable: true),
                    UserUpdated = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habits_TagEntityId",
                table: "Habits",
                column: "TagEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_TagEntity_TagEntityId",
                table: "Habits",
                column: "TagEntityId",
                principalTable: "TagEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_TagEntity_TagEntityId",
                table: "Habits");

            migrationBuilder.DropTable(
                name: "TagEntity");

            migrationBuilder.DropIndex(
                name: "IX_Habits_TagEntityId",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "TagEntityId",
                table: "Habits");
        }
    }
}
