using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialPremisesRent.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentType",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredSquare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "IndustrialPremise",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSquare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialPremise", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustrialPremiseCode = table.Column<int>(type: "int", nullable: false),
                    EquipmentTypeCode = table.Column<int>(type: "int", nullable: false),
                    EquipmentAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_EquipmentType_EquipmentTypeCode",
                        column: x => x.EquipmentTypeCode,
                        principalTable: "EquipmentType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_IndustrialPremise_IndustrialPremiseCode",
                        column: x => x.IndustrialPremiseCode,
                        principalTable: "IndustrialPremise",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EquipmentTypeCode",
                table: "Contract",
                column: "EquipmentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IndustrialPremiseCode",
                table: "Contract",
                column: "IndustrialPremiseCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "IndustrialPremise");
        }
    }
}
