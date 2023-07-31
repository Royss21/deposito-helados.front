using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepositoHelados.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "EmployeeOrderProduct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrderProduct_OrderId",
                table: "EmployeeOrderProduct",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOrderProduct_Order_OrderId",
                table: "EmployeeOrderProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOrderProduct_Order_OrderId",
                table: "EmployeeOrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeOrderProduct_OrderId",
                table: "EmployeeOrderProduct");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "EmployeeOrderProduct");
        }
    }
}
