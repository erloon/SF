using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Calculator.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeTaxThresholds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TaxationForm = table.Column<int>(nullable: false),
                    ThresholdNumber = table.Column<int>(nullable: false),
                    FromAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ToAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(2,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTaxThresholds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceContributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsuranceBaseAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HealthBaseAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HealthInsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HealthInsuranceDiscount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MedicalInsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DisabilityInsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RetirementInsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AccidentInsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LaborFoundInsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    WithMedicalInsurance = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceContributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceContributionsPercentages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Accident = table.Column<decimal>(nullable: false),
                    Health = table.Column<decimal>(nullable: false),
                    Retirement = table.Column<decimal>(nullable: false),
                    HealthToDiscount = table.Column<decimal>(nullable: false),
                    Disability = table.Column<decimal>(nullable: false),
                    Medical = table.Column<decimal>(nullable: false),
                    LaborFound = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceContributionsPercentages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearlySelfEmployeeCalculations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TotalIncomes = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TotalCosts = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlySelfEmployeeCalculations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelfEmployeeCalculations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    NetPay = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    NetPayEstimate = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IncomeCostsAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TaxBaseAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    BaseAmount = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    InsuranceContributionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfEmployeeCalculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelfEmployeeCalculations_YearlySelfEmployeeCalculations_Id",
                        column: x => x.Id,
                        principalTable: "YearlySelfEmployeeCalculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelfEmployeeCalculations_InsuranceContributions_InsuranceCo~",
                        column: x => x.InsuranceContributionId,
                        principalTable: "InsuranceContributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IncomeTaxThresholds",
                columns: new[] { "Id", "FromAmount", "Percentage", "TaxationForm", "ThresholdNumber", "ToAmount" },
                values: new object[,]
                {
                    { new Guid("3e80aa7c-5bd2-40c0-8ab3-e76ea03be716"), 0m, 0.19m, 2, 1, 2147483647m },
                    { new Guid("216f62ca-6d50-4b3e-a148-60750fdac295"), 0m, 0.18m, 1, 1, 85528m },
                    { new Guid("ed67033f-6f53-4457-b7cd-b29395e232c5"), 85528m, 0.32m, 1, 2, 2147483647m }
                });

            migrationBuilder.InsertData(
                table: "InsuranceContributionsPercentages",
                columns: new[] { "Id", "Accident", "Disability", "Health", "HealthToDiscount", "IsActive", "LaborFound", "Medical", "Retirement" },
                values: new object[] { new Guid("37096404-0885-4228-8167-2d41259903e3"), 0m, 0.08m, 0.09m, 0.0775m, true, 0.0245m, 0.0245m, 0.1952m });

            migrationBuilder.CreateIndex(
                name: "IX_SelfEmployeeCalculations_InsuranceContributionId",
                table: "SelfEmployeeCalculations",
                column: "InsuranceContributionId");

            migrationBuilder.Sql(@"CREATE EXTENSION ""uuid-ossp"";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeTaxThresholds");

            migrationBuilder.DropTable(
                name: "InsuranceContributionsPercentages");

            migrationBuilder.DropTable(
                name: "SelfEmployeeCalculations");

            migrationBuilder.DropTable(
                name: "YearlySelfEmployeeCalculations");

            migrationBuilder.DropTable(
                name: "InsuranceContributions");
        }
    }
}
