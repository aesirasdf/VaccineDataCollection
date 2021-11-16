using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineDataCollection.Migrations
{
    public partial class createClinicalTrialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicalTrial",
                columns: table => new
                {
                    TrialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrialName = table.Column<string>(maxLength: 250, nullable: true),
                    TrialDesc = table.Column<string>(maxLength: 5000, nullable: true),
                    TrialLocation = table.Column<string>(maxLength: 250, nullable: true),
                    VaccineID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalTrial", x => x.TrialID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicalTrial");
        }
    }
}
