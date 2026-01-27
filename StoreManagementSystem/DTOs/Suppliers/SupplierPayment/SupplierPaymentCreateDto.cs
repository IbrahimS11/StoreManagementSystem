namespace StoreManagementSystem.DTOs.Suppliers.SupplierPayment
{
    public class SupplierPaymentCreateDto
    {
        
        public decimal Amount { get; set; }
        public string? Note { get; set; } = null!;
       
        public Guid SupplierId { get; set; }

        public Guid? PurchaseId { get; set; }
    }
}
