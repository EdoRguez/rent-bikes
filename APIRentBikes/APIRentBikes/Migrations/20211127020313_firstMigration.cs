using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIRentBikes.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalWithDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_RentalType = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_RentalTypes_Id_RentalType",
                        column: x => x.Id_RentalType,
                        principalTable: "RentalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Bike = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBikes_Bikes_Id_Bike",
                        column: x => x.Id_Bike,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBikes_Orders_Id_Order",
                        column: x => x.Id_Order,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "IsAvailable", "SerialNumber" },
                values: new object[,]
                {
                    { new Guid("1c4a515a-56d1-43a8-8a80-39343fe2654f"), true, "U-35986859643" },
                    { new Guid("c8f84c17-23c2-4822-b611-80b05c945d17"), true, "F-95865965965" },
                    { new Guid("6fe98c41-f2fe-4d45-860e-3042dd182751"), true, "Y-24569875645" },
                    { new Guid("b8cb8aa8-97e3-4049-b31d-8cd5d15503e8"), true, "T-63232369569" },
                    { new Guid("c643797d-eb35-4abd-ac14-5bf3575256fe"), true, "Q-01258456985" },
                    { new Guid("d19fbc15-9c45-40af-97a4-4d4dec977ccd"), true, "O-52456985695" },
                    { new Guid("6c49fe76-22c2-4b72-8c3c-6e1a0f4233c8"), true, "C-55569865965" },
                    { new Guid("ae366b8f-471d-4677-9e52-9949d4836239"), true, "R-11122233345" },
                    { new Guid("c071c09a-8291-4f88-bb1b-021ab8fca3b0"), true, "J-99874563210" },
                    { new Guid("fb11168b-35de-4593-9809-1e54cc460bb6"), true, "Z-44455556677" }
                });

            migrationBuilder.InsertData(
                table: "RentalTypes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("b090a296-d3a3-4828-b2f9-0b6c360ad77b"), "Hour", 5m },
                    { new Guid("3cdb0ce0-6c5e-4c2d-9252-54ed5683b854"), "Day", 20m },
                    { new Guid("36346ebc-523d-4d0e-8c75-3bcc0f380da0"), "Week", 60m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderBikes_Id_Bike",
                table: "OrderBikes",
                column: "Id_Bike");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBikes_Id_Order",
                table: "OrderBikes",
                column: "Id_Order");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_RentalType",
                table: "Orders",
                column: "Id_RentalType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderBikes");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RentalTypes");
        }
    }
}
