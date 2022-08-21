namespace ProductShop
{
    using System.Linq;

    using DTOs.Category;
    using DTOs.CategoryProduct;
    using DTOs.Product;
    using DTOs.User;
    using Models;

    using AutoMapper;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.SellerFullName,
                    mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            //Inner Dto - users with sold products
            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.BuyerFirstName,
                    mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName,
                    mo => mo.MapFrom(s => s.Buyer.LastName));
            //Outer Dto = users with sold products
            this.CreateMap<User, ExportUsersWithSoldProductsDto>()
                .ForMember(d => d.SoldProducts,
                    mo => mo.MapFrom(s => s.ProductsSold
                        .Where(ps => ps.BuyerId.HasValue)));

            this.CreateMap<Category, ExportCategoryByProductCountDto>()
                .ForMember(d => d.ProductCount,
                    mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice,
                    mo => mo.MapFrom(s => s.CategoryProducts.Average(c => c.Product.Price)))
                .ForMember(d => d.TotalRevenue,
                    mo => mo.MapFrom(s => s.CategoryProducts.Sum(c => c.Product.Price)));
        }
    }
}
