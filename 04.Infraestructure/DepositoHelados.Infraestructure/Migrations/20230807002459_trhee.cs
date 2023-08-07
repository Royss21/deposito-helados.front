using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepositoHelados.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class trhee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonAmountAccount_MasterDetail_MdStatusId",
                table: "PersonAmountAccount");

            migrationBuilder.DropIndex(
                name: "IX_PersonAmountAccount_MdStatusId",
                table: "PersonAmountAccount");

            migrationBuilder.DropColumn(
                name: "MdStatusId",
                table: "PersonAmountAccount");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "OrderDetail");

            migrationBuilder.AddColumn<bool>(
                name: "IsAmountCalculate",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountReceived",
                table: "Order",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OrderTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MdStatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTracking_MasterDetail_MdStatusId",
                        column: x => x.MdStatusId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderTracking_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_MdStatusId",
                table: "OrderTracking",
                column: "MdStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_OrderId",
                table: "OrderTracking",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTracking");

            migrationBuilder.DropColumn(
                name: "IsAmountCalculate",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "AmountReceived",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "MdStatusId",
                table: "PersonAmountAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PersonAmountAccount_MdStatusId",
                table: "PersonAmountAccount",
                column: "MdStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAmountAccount_MasterDetail_MdStatusId",
                table: "PersonAmountAccount",
                column: "MdStatusId",
                principalTable: "MasterDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
