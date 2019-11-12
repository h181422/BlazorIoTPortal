using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_IoTUser_IoTUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Employees_DeviceId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_IoTUser_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_Employees_DevId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_IoTUser_UserId",
                table: "Register");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IoTUser",
                table: "IoTUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "Registrations");

            migrationBuilder.RenameTable(
                name: "IoTUser",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_Register_UserId",
                table: "Registrations",
                newName: "IX_Registrations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Register_DevId",
                table: "Registrations",
                newName: "IX_Registrations_DevId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_IoTUserId",
                table: "Devices",
                newName: "IX_Devices_IoTUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Users_IoTUserId",
                table: "Devices",
                column: "IoTUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Devices_DeviceId",
                table: "Feedback",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Users_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Devices_DevId",
                table: "Registrations",
                column: "DevId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Users_UserId",
                table: "Registrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Users_IoTUserId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Devices_DeviceId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Users_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Devices_DevId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Users_UserId",
                table: "Registrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "IoTUser");

            migrationBuilder.RenameTable(
                name: "Registrations",
                newName: "Register");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_UserId",
                table: "Register",
                newName: "IX_Register_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_DevId",
                table: "Register",
                newName: "IX_Register_DevId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_IoTUserId",
                table: "Employees",
                newName: "IX_Employees_IoTUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IoTUser",
                table: "IoTUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_IoTUser_IoTUserId",
                table: "Employees",
                column: "IoTUserId",
                principalTable: "IoTUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Employees_DeviceId",
                table: "Feedback",
                column: "DeviceId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_IoTUser_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "IoTUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Employees_DevId",
                table: "Register",
                column: "DevId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_IoTUser_UserId",
                table: "Register",
                column: "UserId",
                principalTable: "IoTUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
