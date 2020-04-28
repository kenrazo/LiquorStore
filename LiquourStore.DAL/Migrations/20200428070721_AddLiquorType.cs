using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquorStore.DAL.Migrations
{
    public partial class AddLiquorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiquorType",
                table: "Liquors");

            migrationBuilder.AddColumn<int>(
                name: "LiquorTypeId",
                table: "Liquors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LiquorType",
                columns: table => new
                {
                    LiquorTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquorTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquorType", x => x.LiquorTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Liquors_LiquorTypeId",
                table: "Liquors",
                column: "LiquorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Liquors_LiquorType_LiquorTypeId",
                table: "Liquors",
                column: "LiquorTypeId",
                principalTable: "LiquorType",
                principalColumn: "LiquorTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liquors_LiquorType_LiquorTypeId",
                table: "Liquors");

            migrationBuilder.DropTable(
                name: "LiquorType");

            migrationBuilder.DropIndex(
                name: "IX_Liquors_LiquorTypeId",
                table: "Liquors");

            migrationBuilder.DropColumn(
                name: "LiquorTypeId",
                table: "Liquors");

            migrationBuilder.AddColumn<string>(
                name: "LiquorType",
                table: "Liquors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
