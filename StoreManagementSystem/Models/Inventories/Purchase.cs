namespace StoreManagementSystem.Models.Inventories
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Note { get; set; } = null!;
        public PurchaseStatus Status { get; set; }
        

        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;



        public Guid InitialPaymentId { get; set; }
        public SupplierPayment InitialPayment { get; set; } = null!;

        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

        public void MakePurchaseStatusCompleted()
        {
            if (Status != PurchaseStatus.Pending)
                throw new InvalidOperationException($"Order cannot move from {Status} to Completed");

            Status = PurchaseStatus.Completed;
        }

    }

       
    }
