namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using CarDealer.Data;
    using CarDealer.DTO.Supplier;
    using CarDealer.DTO.Part;
    using CarDealer.DTO.Car;
    using CarDealer.DTO.Customer;
    using CarDealer.DTO.Sale;
    using CarDealer.Models;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;

    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));
            CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("Database copy was created.");

            //InitializeInputFilePath("sales.json");
            //string inputJson = File.ReadAllText(filePath);

            //Console.WriteLine(ImportSuppliers(dbContext, inputJson));     //Problem 9
            //Console.WriteLine(ImportParts(dbContext, inputJson));         //Problem 10
            //Console.WriteLine(ImportCars(dbContext, inputJson));          //Problem 11
            //Console.WriteLine(ImportCustomers(dbContext, inputJson));     //Problem 12
            //Console.WriteLine(ImportSales(dbContext, inputJson));         //Problem 13

            InitializeOutputFilePath("sales-discounts.json");

            string json = GetSalesWithAppliedDiscount(dbContext);
            File.WriteAllText(filePath, json);
        }

        //Problem 9 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
            ICollection<Supplier> suppliers = new List<Supplier>();

            foreach (var sDto in supplierDtos)
            {
                Supplier supplier = Mapper.Map<Supplier>(sDto);
                suppliers.Add(supplier);
            }

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ImportPartDto[] partsDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            var supplierIds = context
                .Suppliers
                .Select(s => s.Id)
                .ToArray();

            var parts = Mapper.Map<Part[]>(partsDtos)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        //Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            Car[] cars = new Car[carDtos.Length];

            for (int i = 0; i < carDtos.Length; i++)
            {
                Car car = new Car
                {
                    Make = carDtos[i].Make,
                    Model = carDtos[i].Model,
                    TravelledDistance = carDtos[i].TravelledDistance
                };

                foreach (int partId in carDtos[i].PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars[i] = car;
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        //Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            ICollection<Customer> customers = new List<Customer>();

            foreach (var cDto in customerDtos)
            {
                Customer customer = Mapper.Map<Customer>(cDto);
                customers.Add(customer);
            }

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSaleDto[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
            ICollection<Sale> sales = new List<Sale>();

            foreach (var sDto in saleDtos)
            {
                Sale sale = Mapper.Map<Sale>(sDto);
                sales.Add(sale);
            }

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 14 - Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            ExportOrderedCustomerDto[] customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver ? 1 : 0)
                .ProjectTo<ExportOrderedCustomerDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        //Problem 15 - Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            ExportCarsFromMakeToyotaDto[] cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportCarsFromMakeToyotaDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        //Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        { 
            ExportLocalSupplierDto[] suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSupplierDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }

        //Problem 17 - Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2")
                        })
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        //Problem 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(sm => sm.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        //Problem 19 - Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleWithDiscountDto[] sales = context
                .Sales
                .ProjectTo<ExportSaleWithDiscountDto>()
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return json;
        }

        private static void InitializeInputFilePath(string fileName)
        {
            filePath
                = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }

        private static void InitializeOutputFilePath(string fileName)
        {
            filePath
                = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }
    }
}