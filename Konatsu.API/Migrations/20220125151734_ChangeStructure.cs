using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Konatsu.API.Migrations
{
    public partial class ChangeStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Users",
                newName: "About");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "Habits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habits_UserEntityId",
                table: "Habits",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Users_UserEntityId",
                table: "Habits",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Users_UserEntityId",
                table: "Habits");

            migrationBuilder.DropIndex(
                name: "IX_Habits_UserEntityId",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Habits");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "Users",
                newName: "Patronymic");
        }
    }
}
