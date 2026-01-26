using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPayments_Orders_OrderId",
                table: "CustomerPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPayments_Purchases_PurchaseId",
                table: "SupplierPayments");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPayments_PurchaseId",
                table: "SupplierPayments");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPayments_SupplierId",
                table: "SupplierPayments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPayments_OrderId",
                table: "CustomerPayments");

            migrationBuilder.RenameColumn(
                name: "SupplierPaymentId",
                table: "Purchases",
                newName: "InitialPaymentId");

            migrationBuilder.RenameColumn(
                name: "CustomerPaymentId",
                table: "Orders",
                newName: "InitialPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPayments_SupplierId",
                table: "SupplierPayments",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_InitialPaymentId",
                table: "Purchases",
                column: "InitialPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InitialPaymentId",
                table: "Orders",
                column: "InitialPaymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerPayments_InitialPaymentId",
                table: "Orders",
                column: "InitialPaymentId",
                principalTable: "CustomerPayments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_SupplierPayments_InitialPaymentId",
                table: "Purchases",
                column: "InitialPaymentId",
                principalTable: "SupplierPayments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerPayments_InitialPaymentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_SupplierPayments_InitialPaymentId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPayments_SupplierId",
                table: "SupplierPayments");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_InitialPaymentId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InitialPaymentId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "InitialPaymentId",
                table: "Purchases",
                newName: "SupplierPaymentId");

            migrationBuilder.RenameColumn(
                name: "InitialPaymentId",
                table: "Orders",
                newName: "CustomerPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPayments_PurchaseId",
                table: "SupplierPayments",
                column: "PurchaseId",
                unique: true,
                filter: "[PurchaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPayments_SupplierId",
                table: "SupplierPayments",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_OrderId",
                table: "CustomerPayments",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPayments_Orders_OrderId",
                table: "CustomerPayments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPayments_Purchases_PurchaseId",
                table: "SupplierPayments",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");
        }
    }
}
