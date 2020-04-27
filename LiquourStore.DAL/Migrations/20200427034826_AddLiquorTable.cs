using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquorStore.DAL.Migrations
{
    public partial class AddLiquorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Liquors",
                columns: table => new
                {
                    LiquorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquorName = table.Column<string>(nullable: true),
                    LiquorType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquors", x => x.LiquorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Liquors");
        }
    }
}
