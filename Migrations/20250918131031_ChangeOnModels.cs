using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Tracker_V4.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Tbl_Task");

            migrationBuilder.AlterColumn<int>(
                name: "WeekNumber",
                table: "Tbl_Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Notifications",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "WeekNumber",
                table: "Tbl_Task",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "Tbl_Task",
                type: "date",
                nullable: true);
        }
    }
}
