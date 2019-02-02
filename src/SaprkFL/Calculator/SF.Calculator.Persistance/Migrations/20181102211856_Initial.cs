using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Calculator.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseValuesDictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValuesDictionaries", x => x.Id);
                });

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
                table: "BaseValuesDictionaries",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("35b3126f-b13e-4ac9-acf0-50ae38fec915"), "HealthBaseAmount", "3554.93" },
                    { new Guid("307c9908-343e-4cda-9535-2108ca10cc23"), "InsuranceBaseAmount", "2665.8" },
                    { new Guid("4f4ddde4-a469-49d1-873c-20f64f7b275b"), "InsuranceBaseAmountWithDiscount", "630" },
                    { new Guid("E85ADA5D-CD4E-4815-B302-270E34BC2969"), "InsuranceBaseAmountWithStartDiscount", "0" },
                    { new Guid("f48b9f46-8269-4b1e-a81a-b075b459985e"), "MonthlyTaxFreeAmount", "46.34" },
                    { new Guid("f65d9257-43c6-499c-878d-bccd32f83374"), "VATTaxRate", "0.23" }
                });

            migrationBuilder.InsertData(
                table: "IncomeTaxThresholds",
                columns: new[] { "Id", "FromAmount", "Percentage", "TaxationForm", "ThresholdNumber", "ToAmount" },
                values: new object[,]
                {
                    { new Guid("519e0805-b997-49a5-af8e-a8b6b3137e03"), 0m, 0.19m, 2, 1, 2147483647m },
                    { new Guid("2b22e3a1-b65f-4c53-b714-0e5e64a1a844"), 0m, 0.18m, 1, 1, 85528m },
                    { new Guid("61d3991a-aef6-4282-a85f-b966e4e3717e"), 85528m, 0.32m, 1, 2, 2147483647m }
                });

            migrationBuilder.InsertData(
                table: "InsuranceContributionsPercentages",
                columns: new[] { "Id", "Accident", "Disability", "Health", "HealthToDiscount", "IsActive", "LaborFound", "Medical", "Retirement" },
                values: new object[] { new Guid("2a952b22-89eb-4bd2-b9d4-1978a0771ea7"), 0m, 0.08m, 0.09m, 0.0775m, true, 0.0245m, 0.0245m, 0.1952m });

            migrationBuilder.CreateIndex(
                name: "IX_SelfEmployeeCalculations_InsuranceContributionId",
                table: "SelfEmployeeCalculations",
                column: "InsuranceContributionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseValuesDictionaries");

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
