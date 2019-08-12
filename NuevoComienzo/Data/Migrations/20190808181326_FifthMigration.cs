using Microsoft.EntityFrameworkCore.Migrations;

namespace NuevoComienzo.Data.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "Relacion",
                columns: table => new
                {
                    RelacionId = table.Column<byte>(nullable: false),
                    DescRelacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacion", x => x.RelacionId);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "Relacion");*/
        }
    }
}
