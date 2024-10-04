using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Migrations
{
    /// <inheritdoc />
    public partial class FirstModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaxCalculate");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "TaxCalculate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeTaxDates",
                schema: "TaxCalculate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeTaxDateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTaxDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTaxDates_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "TaxCalculate",
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaxRules",
                schema: "TaxCalculate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxRule_StartTime = table.Column<TimeOnly>(type: "TIME(0)", nullable: false),
                    TaxRule_EndTime = table.Column<TimeOnly>(type: "TIME(0)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "MONEY", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRules_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "TaxCalculate",
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "TaxCalculate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<byte>(type: "tinyint", nullable: false),
                    PlateNumber = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    LastTaxPassagePrice = table.Column<decimal>(type: "MONEY", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "MONEY", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "TaxCalculate",
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passages",
                schema: "TaxCalculate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    PassageDateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passages_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "TaxCalculate",
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Passages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "TaxCalculate",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "CitiesTable_CityNameColumn_Index",
                schema: "TaxCalculate",
                table: "Cities",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTaxDates_CityId",
                schema: "TaxCalculate",
                table: "FreeTaxDates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Passages_CityId",
                schema: "TaxCalculate",
                table: "Passages",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Passages_VehicleId",
                schema: "TaxCalculate",
                table: "Passages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "PassageTable_PassageDateTimeTable_Index",
                schema: "TaxCalculate",
                table: "Passages",
                column: "PassageDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRules_CityId",
                schema: "TaxCalculate",
                table: "TaxRules",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRules_TaxRule_StartTime_TaxRule_EndTime",
                schema: "TaxCalculate",
                table: "TaxRules",
                columns: new[] { "TaxRule_StartTime", "TaxRule_EndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CityId",
                schema: "TaxCalculate",
                table: "Vehicles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "VehiclesTable_ColumnPlateNumber_UniqueIndex",
                schema: "TaxCalculate",
                table: "Vehicles",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "VehiclesTable_ColumnTotalTaxAmount_Index",
                schema: "TaxCalculate",
                table: "Vehicles",
                column: "TotalTaxAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreeTaxDates",
                schema: "TaxCalculate");

            migrationBuilder.DropTable(
                name: "Passages",
                schema: "TaxCalculate");

            migrationBuilder.DropTable(
                name: "TaxRules",
                schema: "TaxCalculate");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "TaxCalculate");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "TaxCalculate");
        }
    }
}
