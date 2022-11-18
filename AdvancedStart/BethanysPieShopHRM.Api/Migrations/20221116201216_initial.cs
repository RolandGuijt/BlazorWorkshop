using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShopHRM.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Premium = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.BenefitId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobCategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Zip = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Smoker = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaritalStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    JobCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BenefitId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "BenefitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "BenefitId", "Description", "Premium" },
                values: new object[] { 1, "Health Insurance", false });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "BenefitId", "Description", "Premium" },
                values: new object[] { 2, "Paid Time Off", false });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "BenefitId", "Description", "Premium" },
                values: new object[] { 3, "Wellness", true });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "BenefitId", "Description", "Premium" },
                values: new object[] { 4, "Education", true });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "BenefitId", "Description", "Premium" },
                values: new object[] { 5, "Store Discount", false });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 1, "Belgium" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 2, "Germany" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 3, "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 4, "USA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 5, "Japan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 6, "China" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 7, "UK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 8, "France" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 9, "Brazil" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 1, "Pie research" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 2, "Sales" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 3, "Management" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 4, "Store staff" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 5, "Finance" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 6, "QA" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 7, "IT" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 8, "Cleaning" });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 9, "Bakery" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "City", "Comment", "CountryId", "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "Latitude", "Longitude", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
                values: new object[] { 1, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "Lorem Ipsum", 1, "bethany@bethanyspieshop.com", null, "Bethany", 1, 1, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 50.850299999999997, 4.3517000000000001, 1, "324777888773", false, "Grote Markt 1", "1000" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_BenefitId",
                table: "EmployeeBenefits",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_EmployeeId",
                table: "EmployeeBenefits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeBenefits");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "JobCategories");
        }
    }
}
