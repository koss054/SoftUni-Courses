namespace ProductShop
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using ProductShop.Data;
    using ProductShop.Dtos.Category;
    using ProductShop.Dtos.CategoryProduct;
    using ProductShop.Dtos.Product;
    using ProductShop.Dtos.User;
    using ProductShop.Models;

    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("Database reset successfully.");

            //InitializeInputFilePath("categories-products.xml");
            //string xml = File.ReadAllText(filePath);

            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
        }

        //Problem 1 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            ImportUserDto[] userDtos = Deserialize<ImportUserDto[]>("Users", inputXml);

            ICollection<User> users = new List<User>();
            foreach (var uDto in userDtos)
            {
                User user = new User()
                {
                    FirstName = uDto.FirstName,
                    LastName = uDto.LastName,
                    Age = uDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 2 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            ImportProductDto[] productDtos = Deserialize<ImportProductDto[]>("Products", inputXml);

            ICollection<Product> products = new List<Product>();
            foreach (var pDto in productDtos)
            {
                Product product = new Product()
                {
                    Name = pDto.Name,
                    Price = pDto.Price,
                    SellerId = pDto.SellerId,
                    BuyerId = pDto.BuyerId
                };

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 3 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            ImportCategoryDto[] categoryDtos = Deserialize<ImportCategoryDto[]>("Categories", inputXml);

            ICollection<Category> categories = new List<Category>();
            foreach (var cDto in categoryDtos)
            {
                if (cDto.Name != null)
                {
                    Category category = new Category()
                    {
                        Name = cDto.Name
                    };

                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 4 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            ImportCategoryProductDto[] categoryProductDtos = Deserialize<ImportCategoryProductDto[]>("CategoryProducts", inputXml);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (var cpDto in categoryProductDtos)
            {
                if (context.Categories.Any(c => c.Id == cpDto.CategoryId) &&
                    context.Products.Any(p => p.Id == cpDto.ProductId))
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = cpDto.CategoryId,
                        ProductId = cpDto.ProductId
                    };

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 5 - Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDto[] productDtos = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            return Serialize(productDtos, "Products");
        }

        //Problem 6 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUsersWithSoldItemsDto[] userDtos = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new ExportUsersWithSoldItemsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new ExportSoldProductsDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            return Serialize(userDtos, "Users");
        }

        //Problem 7 - Export Categories by Product Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductCountDto[] categoryDtos = context
                .Categories
                .Select(c => new ExportCategoriesByProductCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return Serialize(categoryDtos, "Categories");
        }

        //Problem 8 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUsersWithProductsDto[] usersWithoutCount = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ToArray()
                .Select(u => new ExportUsersWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    ProductsSold = new ExportSoldProductsIncludingCountDto()
                    {
                        ProductCount = u.ProductsSold.Count,
                        SoldProducts = u.ProductsSold
                            .Select(ps => new ExportSoldProductsDto()
                            {
                                Name = ps.Name,
                                Price = ps.Price
                            })
                            .OrderByDescending(ps => ps.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUsersCountAndProductsInfoDto users = new ExportUsersCountAndProductsInfoDto()
            {
                UserCount = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersWithoutCount
            };

            return Serialize(users, "Users");
        }


        private static T Deserialize<T>(string rootName, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader reader = new StringReader(inputXml);

            return (T)xmlSerializer.Deserialize(reader);
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            var sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static void InitializeInputFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }
    }
}