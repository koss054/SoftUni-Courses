namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("Database reset successfully");

            //InitializeInputFilePath("sales.xml");
            //string xml = File.ReadAllText(filePath);

            //string result = ImportSales(dbContext, xml);
            //Console.WriteLine(result);

            InitializeOutputtFilePath("sales-discounts.xml");
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
        }

        //Problem 9 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportSupplierDto[] supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            Supplier[] suppliers = supplierDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        //Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRool = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRool);

            using StringReader reader = new StringReader(inputXml);
            ImportPartDto[] partDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);

            ICollection<Part> parts = new List<Part>();
            foreach (var pDto in partDtos)
            {
                if (context.Suppliers.Any(s => s.Id == pDto.SupplierId))
                {
                    Part part = new Part()
                    {
                        Name = pDto.Name,
                        Price = pDto.Price,
                        Quantity = pDto.Quantity,
                        SupplierId = pDto.SupplierId
                    };

                    parts.Add(part);
                }
            }


            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);

            ICollection<Car> cars = new List<Car>();
            foreach (var cDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = cDto.Make,
                    Model = cDto.Model,
                    TravelledDistance = cDto.TraveledDistance
                };

                ICollection<PartCar> currentCarParts = new List<PartCar>();
                foreach (var partId in cDto.Parts.Select(p => p.Id).Distinct())
                {
                    if (context.Parts.Any(p => p.Id == partId))
                    {
                        currentCarParts.Add(new PartCar()
                        {
                            Car = car,
                            PartId = partId
                        });
                    }
                }

                car.PartCars = currentCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRool = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), xmlRool);

            using StringReader reader = new StringReader(inputXml);
            ImportCustomerDto[] customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Customer> customers = new List<Customer>();
            foreach (var cDto in customerDtos)
            {
                Customer customer = new Customer()
                {
                    Name = cDto.Name,
                    BirthDate = cDto.BirthDate,
                    IsYoungDriver = cDto.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRool = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), xmlRool);

            using StringReader reader = new StringReader(inputXml);
            ImportSaleDto[] saleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(reader);

            ICollection<Sale> sales = new List<Sale>();
            foreach (var sDto in saleDtos)
            {
                if (context.Cars.Any(c => c.Id == sDto.CarId))
                {
                    Sale sale = new Sale()
                    {
                        CarId = sDto.CarId,
                        CustomerId = sDto.CustomerId,
                        Discount = sDto.Discount
                    };

                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 14 - Export Cars with Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();

            ExportCarsWithDistanceDto[] carDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, carDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 15 - Export Cars from Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();

            ExportBMWCarsDto[] carsDtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportBMWCarsDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBMWCarsDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, carsDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var sb = new StringBuilder();

            ExportLocalSuppliersDto[] supplierDtos = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, supplierDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 17 - Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sb = new StringBuilder();

            ExportCarsWithListOfPartsDto[] carDtos = context
                .Cars
                .Select(c => new ExportCarsWithListOfPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(cp => new ExportCarPartsDto()
                        {
                            Name = cp.Part.Name,
                            Price = cp.Part.Price
                        })
                        .OrderByDescending(cp => cp.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            return Serialize(carDtos, "cars");
        }

        //Problem 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomerSalesDto[] customerDtos = context
                .Customers
                .Select(c => new ExportCustomerSalesDto()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .Select(s => s.Car)
                            .SelectMany(c => c.PartCars)
                            .Sum(pc => pc.Part.Price)
                })
                .Where(c => c.BoughtCars > 0)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            return Serialize(customerDtos, "customers");
        }

        //Problem 19 - Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesWithDiscountDto[] saleDtos = context
                .Sales
                .Select(s => new ExportSalesWithDiscountDto()
                {
                    Car = new ExportCarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars
                        .Sum(pc => pc.Part.Price),
                    PriceWithDiscount 
                    = (s.Car.PartCars.Sum(pc => pc.Part.Price)) 
                    - ((s.Car.PartCars.Sum(pc => pc.Part.Price)) * (s.Discount / 100))
                })
                .ToArray();

            return Serialize(saleDtos, "sales");
        }

        private static void InitializeInputFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }

        private static void InitializeOutputtFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
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
    }
}