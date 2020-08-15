using Microsoft.EntityFrameworkCore.Migrations;

namespace Finance.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    PMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanHolderName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LoanType = table.Column<string>(type: "varchar(16)", nullable: false),
                    LoanDate = table.Column<string>(type: "varchar(8)", nullable: false),
                    InsuranceDate = table.Column<string>(type: "varchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.PMId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finances");
        }
    }
}
