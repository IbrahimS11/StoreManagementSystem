using AutoMapper;
using StoreManagementSystem.DTOs.Products.Product;
using StoreManagementSystem.DTOs.Products.Category;
using StoreManagementSystem.DTOs.Products.ProductFlavor;
using StoreManagementSystem.DTOs.Products.ProductUnitPrice;

namespace StoreManagementSystem.AutoMapper.Products
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<Category, CatetgoryReadDto>();
            CreateMap<ProductFlavor, ProductFlavorReadDto>();
            CreateMap<ProductUnitPrice, ProductUnitPriceReadDto>();
        }
    }
}
