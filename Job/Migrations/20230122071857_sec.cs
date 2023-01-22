using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAPIS.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareerId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Applicants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CareerId",
                table: "Jobs",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Careers_CareerId",
                table: "Jobs",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Careers_CareerId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CareerId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Applicants");
        }
    }
}
