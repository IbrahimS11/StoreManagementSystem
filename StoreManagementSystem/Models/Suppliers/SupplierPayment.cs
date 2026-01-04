using StoreManagementSystem.Models.Inventories;

namespace StoreManagementSystem.Models.Suppliers
{
    public class SupplierPayment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; } = null!;
        public decimal BalanceAfter { get; set; }



        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;



        public Guid? PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
    }
}
