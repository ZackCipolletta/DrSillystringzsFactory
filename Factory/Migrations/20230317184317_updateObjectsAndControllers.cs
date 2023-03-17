using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class updateObjectsAndControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Engineers",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Machines",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Engineers",
                newName: "Title");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Machines",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Machines",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
