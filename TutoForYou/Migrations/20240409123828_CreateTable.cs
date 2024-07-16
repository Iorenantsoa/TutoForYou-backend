using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoForYou.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    FormationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.FormationID);
                });

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    PlayListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayListUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitreVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroVideo = table.Column<int>(type: "int", nullable: false),
                    FormationID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.PlayListID);
                    table.ForeignKey(
                        name: "FK_PlayList_Formations_FormationID",
                        column: x => x.FormationID,
                        principalTable: "Formations",
                        principalColumn: "FormationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_FormationID",
                table: "PlayList",
                column: "FormationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayList");

            migrationBuilder.DropTable(
                name: "Formations");
        }
    }
}
