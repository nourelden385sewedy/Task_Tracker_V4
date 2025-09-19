using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Tracker_V4.Migrations
{
    /// <inheritdoc />
    public partial class TrySeedingDataTry1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BusinessEntity", "OrderNo", "RoleName" },
                values: new object[,]
                {
                    { 1L, "General", 1, "Super Admin" },
                    { 2L, "General", 2, "Admin" },
                    { 3L, "Task", 3, "Senior Engineer" },
                    { 4L, "Task", 4, "Engineer" },
                    { 5L, "Task", 5, "Senior Teacher" },
                    { 6L, "Task", 6, "Teacher" },
                    { 7L, "Task", 7, "Reviewer" },
                    { 8L, "General", 8, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "BusinessEntity", "OrderNo", "StatusName" },
                values: new object[,]
                {
                    { 1L, "General", 1, "Active" },
                    { 2L, "General", 2, "InActive" },
                    { 3L, "Task", 3, "Not Started" },
                    { 4L, "Task", 4, "In Progress" },
                    { 5L, "Task", 5, "Completed" },
                    { 6L, "Task", 6, "Read" },
                    { 7L, "Task", 7, "UnRead" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Created_at", "Email", "FullNameAR", "FullNameEN", "IsActive", "NationalId", "PasswordHash", "Phone", "ResetToken", "ResetTokenExpiry", "RoleId", "StatusId" },
                values: new object[,]
                {
                    { 1L, new DateOnly(2025, 9, 19), "superadmin@elsewedy.com", "مدير النظام", "Super Admin User", true, "29501011111111", "hashed_pass_sa", "01012345678", null, null, 1L, 1L },
                    { 2L, new DateOnly(2025, 9, 19), "admin@elsewedy.com", "مسؤول النظام", "Admin User", true, "29602022222222", "hashed_pass_a", "01123456789", null, null, 2L, 1L },
                    { 3L, new DateOnly(2025, 9, 19), "engineer1@elsewedy.com", "يارا ياسر", "Senior Engineer Yara Yasser", true, "29804043336666", "hashed_pass_e1", "01068745438", null, null, 3L, 1L },
                    { 4L, new DateOnly(2025, 9, 19), "engineer2@elsewedy.com", "سارة عواد", "Sara Awad", true, "29804043337878", "hashed_pass_e2", "01068145338", null, null, 4L, 1L },
                    { 5L, new DateOnly(2025, 9, 19), "teacher1@elsewedy.com", "رشا محمد", "Senior Rasha Mohamed", true, "29703033333333", "hashed_pass_t1", "01234567890", null, null, 5L, 1L },
                    { 6L, new DateOnly(2025, 9, 19), "teacher2@elsewedy.com", "أحمد كامل", "Ahmed Kamel", true, "29703034444444", "hashed_pass_t2", "01234567891", null, null, 6L, 1L },
                    { 7L, new DateOnly(2025, 9, 19), "reviewer1@elsewedy.com", "مقيم واحد", "Reviewer One", true, "29905057777777", "hashed_pass_r1", "01155555555", null, null, 7L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Task",
                columns: new[] { "Id", "AdminAccountId", "AssignedByID", "AssignedToID", "Class_Id", "CreatedAt", "GradeId", "StatusId", "TaskDeadline", "TaskDescription", "TaskName", "Team_Id", "WeekNumber" },
                values: new object[,]
                {
                    { 1L, null, 2L, 6L, null, new DateOnly(2025, 12, 1), null, 1L, new DateTime(2025, 12, 1, 17, 0, 0, 0, DateTimeKind.Utc), "Design the database schema for the new system.", "Database Design Document", null, null },
                    { 2L, null, 2L, 7L, null, new DateOnly(2025, 12, 15), null, 1L, new DateTime(2025, 12, 15, 17, 0, 0, 0, DateTimeKind.Utc), "Create a UI prototype for the student dashboard.", "Front-end Prototype", null, null },
                    { 3L, null, 1L, 2L, null, new DateOnly(2025, 12, 10), null, 1L, new DateTime(2025, 12, 10, 17, 0, 0, 0, DateTimeKind.Utc), "Review all user accounts and permissions.", "System Audit", null, null },
                    { 4L, null, 5L, 4L, null, new DateOnly(2025, 11, 20), null, 1L, new DateTime(2025, 11, 20, 17, 0, 0, 0, DateTimeKind.Utc), "Create the lesson plan for the next semester.", "Prepare Lesson Plan", null, null },
                    { 5L, null, 3L, 3L, null, new DateOnly(2025, 11, 25), null, 1L, new DateTime(2025, 11, 25, 17, 0, 0, 0, DateTimeKind.Utc), "Install and configure lab equipment.", "Lab Equipment Setup", null, null }
                });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "AccountId", "Email", "PasswordHash", "StatusId" },
                values: new object[,]
                {
                    { 1L, 1L, "superadmin@elsewedy.com", "hashed_pass_sa", 1L },
                    { 2L, 2L, "admin@elsewedy.com", "hashed_pass_a", 1L },
                    { 3L, 3L, "engineer1@elsewedy.com", "hashed_pass_e1", 1L },
                    { 4L, 5L, "teacher1@elsewedy.com", "hashed_pass_t1", 1L },
                    { 5L, 4L, "engineer2@elsewedy.com", "hashed_pass_e2", 1L },
                    { 6L, 6L, "teacher2@elsewedy.com", "hashed_pass_t2", 1L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "ID", "AccountId", "CreatedAt", "Message", "Read_statusID", "Title", "isActive" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5575), "System is running", 1L, "System Start", true },
                    { 2L, 2L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5581), "Welcome to the Elsewedy School System.", 2L, "Welcome!", true },
                    { 3L, 3L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5583), "SuperAdmin has assigned you the task: System Challange.", 7L, "New Task Assigned", true },
                    { 4L, 1L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5584), "Admin has completed the task: System Audit.", 7L, "Task Completed", true },
                    { 5L, 5L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5586), "Admin has assigned you the task: Prepare Lesson Plan.", 7L, "New Task Assigned", true },
                    { 6L, 3L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5647), "Admin has assigned you the task: Lab Equipment Setup.", 7L, "New Task Assigned", true },
                    { 7L, 4L, new DateTime(2025, 9, 19, 21, 41, 56, 282, DateTimeKind.Utc).AddTicks(5649), "System Audit has been marked as Pending", 6L, "Task Status Updated", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Tbl_Task",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tbl_Task",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tbl_Task",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tbl_Task",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Tbl_Task",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
