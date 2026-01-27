namespace StoreManagementSystem.DTOs.Suppliers.SupplierPayment
{
    public class SupplierPaymentReadDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; } = null!;
        public decimal BalanceAfter { get; set; }

        public Guid SupplierId { get; set; }

        public Guid? PurchaseId { get; set; }
    }
}
