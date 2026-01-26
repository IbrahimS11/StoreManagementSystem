using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.DTOs.Inventories.Purchase;
using StoreManagementSystem.DTOs.Products.Product;
using StoreManagementSystem.Identity;
using StoreManagementSystem.Repositories.Interfaces.Inventories;
using StoreManagementSystem.Repositories.Interfaces.Products;
using StoreManagementSystem.Repositories.Interfaces.Suppliers;
using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;
using StoreManagementSystem.Services.Interfaces.Inventories;

namespace StoreManagementSystem.Services.Implementation.Inventories
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository purchaseRepo;
        private readonly IProductRepository productRepo;
        private readonly ILogger<PurchaseService> logger;
        private readonly ISupplierPaymentRepository supplierPaymentRepo;
        private readonly IInventoryRepository inventoryRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppIdentityUser> userManager;

        public PurchaseService(IPurchaseRepository _purchaseRepo , 
                               IProductRepository _productRepo , 
                               ILogger<PurchaseService> _logger ,
                               ISupplierPaymentRepository _supplierPaymentRepo , 
                               IInventoryRepository _inventoryRepo,
                               IUnitOfWork _unitOfWork,
                               UserManager<AppIdentityUser> _userManager)
        {
            purchaseRepo = _purchaseRepo;
            productRepo = _productRepo;
            logger = _logger;
            supplierPaymentRepo = _supplierPaymentRepo;
            inventoryRepo = _inventoryRepo;
            unitOfWork = _unitOfWork;
            userManager = _userManager;
        }
        public async Task<IEnumerable<PurchaseListDto>> GetPurchaseListAsync(Guid SupplierId, int page)
        {
            if (page < 1) page = 1;
            int take = 10;
            int skip = (page - 1) * take;
            return await purchaseRepo.GetPurchaseListAsync(SupplierId, skip, take);
        }

        public async Task<PurchaseReadDto?> GetPurchasesDetailsAsync(Guid Id)
        {
            return await purchaseRepo.GetPurchasesDetailsAsync(Id);
        }

        public async Task<ResultService> CreateByAdminAsync(PurchaseCreateDto model)
        {
             await unitOfWork.BeginTransactionAsync();

            try
            {
                bool SupplierExists = await userManager.Users.AnyAsync(u => u.SupplierId == model.SupplierId);
                if (SupplierExists == false)
                {
                    await unitOfWork.RollbackAsync();
                    return ResultService.Failure("SupplierId", "NotFound");
                }

                if (model.PurchaseItems == null || !model.PurchaseItems.Any())
                {
                    await unitOfWork.RollbackAsync();
                    return ResultService.Failure("PurchaseItems", "Purchase Not Contain Any Items");
                }

                List<int> productIdsFromConsumer = model.PurchaseItems.Select(p => p.ProductId).Distinct().ToList();

                List<ProductListDto> productListDtos = await productRepo.GetListDtosByIdsAsync(productIdsFromConsumer);



                if (productIdsFromConsumer.Count != productListDtos.Count)
                {
                    ResultService result = new();
                    var missingIds = productIdsFromConsumer.Except(productListDtos.Select(p => p.Id)).ToList();

                    foreach (var id in missingIds)
                    {
                        result.AddError("productId", $"this id {id} not exist");
                    }
                    await unitOfWork.RollbackAsync();
                    result.IsSuccess = false;
                    return result;
                }



                SupplierPayment? LastPayment = await supplierPaymentRepo.GetLastPaymentAsync(model.SupplierId);

                decimal BalanceBefore = LastPayment?.BalanceAfter ?? 0;
                decimal BalanceAfter = BalanceBefore - model.TotalAmount ;

                SupplierPayment newPayment = new()
                {
                    Id = Guid.NewGuid(),
                    SupplierId = model.SupplierId,
                    Date = DateTime.Now,
                    Amount = (decimal)(-1) * model.TotalAmount,
                    BalanceAfter = BalanceAfter,
                    Note = model.Note
                };

                Purchase newPurchase = new()
                {
                    Id = Guid.NewGuid(),
                    SupplierId = model.SupplierId,
                    Date = DateTime.Now,
                    TotalAmount = model.TotalAmount,
                    Note = model.Note ,
                    InitialPaymentId=newPayment.Id,
                    InitialPayment=newPayment,
                    PurchaseItems = model.PurchaseItems.Select(pi => new PurchaseItem()
                    {
                        Id = Guid.NewGuid(),
                        ProductId = pi.ProductId,
                        UnitPrice = pi.UnitPrice,
                        Quantity = pi.Quantity
                    }).ToList()

                };

                newPayment.PurchaseId=newPurchase.Id;

                
                supplierPaymentRepo.Add(newPayment);
                purchaseRepo.Add(newPurchase);

                int countChanges = await unitOfWork.SaveChangesAsync();

                

                if (countChanges == 0)
                {
                    await unitOfWork.RollbackAsync();
                    return ResultService.Failure("Purchase", "An error occurred while saving the purchase");
                }

                await unitOfWork.CommitAsync();
                return ResultService.Success(newPurchase.Id);
            }
            catch (Exception ex)
            {
               await unitOfWork.RollbackAsync();
                logger.LogError(ex, "An error occurred while saving the purchase");
                return ResultService.Failure("Purchase", "An error occurred while saving the purchase ");
            }

            }

        public async Task<ResultService> CompletePurchaseAsync(PurchaseCompleteDto purchaseCompleteDto )
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {

                Purchase? PendingPurchase = await purchaseRepo.FindAsync(purchaseCompleteDto.PurchaseId);
                if (PendingPurchase == null)
                {
                    await  unitOfWork.RollbackAsync();
                    return ResultService.Failure("purchaeId", "NotFound");
                }
                if (PendingPurchase.Status != PurchaseStatus.Pending)
                {
                    await unitOfWork.RollbackAsync();
                    return ResultService.Failure("purchase", $"this Purchae is {PendingPurchase.Status}");
                }

                PendingPurchase.MakePurchaseStatusCompleted();
                

                if (purchaseCompleteDto.AmountPaid > 0)
                {
                    SupplierPayment? LastPayment = await supplierPaymentRepo.GetLastPaymentAsync(PendingPurchase.SupplierId);

                    decimal BalanceBefore = LastPayment?.BalanceAfter ?? 0;
                    decimal BalanceAfter = BalanceBefore + purchaseCompleteDto.AmountPaid;

                    SupplierPayment newPayment = new()
                    {
                        Id = Guid.NewGuid(),
                        SupplierId = PendingPurchase.SupplierId,
                        Date = DateTime.Now,
                        Amount = purchaseCompleteDto.AmountPaid,
                        BalanceAfter = BalanceAfter,
                        Note = purchaseCompleteDto.Note
                    };
                    supplierPaymentRepo.Add(newPayment);
                }

                List<Inventory>? newInventories=await inventoryRepo.AddPurchaseItemsToInventoryAsync(PendingPurchase.Id);
                
                if(newInventories == null)
                {
                    await unitOfWork.RollbackAsync();
                    return ResultService.Failure("Inventory", "An error occurred while Add PurchaseItems to Inventory ");
                }
                foreach (var inv in newInventories) inventoryRepo.Add(inv);

                int countChange = await unitOfWork.SaveChangesAsync();

                if (countChange == 0)
                {
                    await unitOfWork.RollbackAsync();
                    return  ResultService.Failure("Purchase", "An error occurred while completed the purchase ");
                   
                }
                await unitOfWork.CommitAsync();
                return ResultService.Success("Completed Puchase");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.LogError($"An error occurred while completed the purchase {ex.Message}");
                return ResultService.Failure("Purchase", "An error occurred while completed the purchase ");
            }
            

        }
    }
}
