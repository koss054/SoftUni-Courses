namespace ProductShop
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Data;
    using DTOs.Category;
    using DTOs.CategoryProduct;
    using DTOs.Product;
    using DTOs.User;
    using Models;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;

    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();
            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            InitializeOutputFilePath("users-and-products.json");

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("Database copy was created.");
            //Console.WriteLine(ImportUsers(dbContext, inputJson));
            //Console.WriteLine(ImportProducts(dbContext, inputJson));
            //Console.WriteLine(ImportCategories(dbContext, inputJson));
            //Console.WriteLine(ImportCategoryProducts(dbContext, inputJson));

            string json = GetUsersWithProducts(dbContext);
            File.WriteAllText(filePath, json);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            ICollection<User> users = new List<User>();

            foreach (ImportUserDto uDto in userDtos)
            {
                User user = Mapper.Map<User>(uDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            ICollection<Product> products = new List<Product>();

            foreach (ImportProductDto pDto in productDtos)
            {
                Product product = Mapper.Map<Product>(pDto);
                products.Add(product);
            }

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
            ICollection<Category> categories = new List<Category>();

            foreach (ImportCategoryDto cDto in categoryDtos)
            {
                if (cDto.Name != null)
                {
                    Category category = Mapper.Map<Category>(cDto);
                    categories.Add(category);
                }
            }

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);
            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (ImportCategoryProductDto cpDto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(cpDto);
                categoryProducts.Add(categoryProduct);
            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDto[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductsInRangeDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUsersWithSoldProductsDto[] users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUsersWithSoldProductsDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue))
                .ToArray()
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(ps => ps.BuyerId.HasValue),
                        products = u.ProductsSold
                            .Where(ps => ps.BuyerId.HasValue)
                            .Select(ps => new
                            {
                                name = ps.Name,
                                price = ps.Price
                            })
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var usersToSerialize = new
            {
                usersCount = users.Length,
                users
            };

            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(usersToSerialize, serializerSettings);
            return json;
        }

        private static void InitializeOutputFilePath(string fileName)
        {
            filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }
    }
}