using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineDataCollection.Migrations
{
    public partial class updateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClinicalTrial_VaccineID",
                table: "ClinicalTrial",
                column: "VaccineID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicalTrial_Vaccine_VaccineID",
                table: "ClinicalTrial",
                column: "VaccineID",
                principalTable: "Vaccine",
                principalColumn: "VaccineID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicalTrial_Vaccine_VaccineID",
                table: "ClinicalTrial");

            migrationBuilder.DropIndex(
                name: "IX_ClinicalTrial_VaccineID",
                table: "ClinicalTrial");
        }
    }
}
