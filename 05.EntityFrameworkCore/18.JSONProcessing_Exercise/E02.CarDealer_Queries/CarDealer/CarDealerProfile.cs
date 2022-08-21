namespace CarDealer
{
    using System.Linq;

    using CarDealer.DTO.Supplier;
    using CarDealer.DTO.Part;
    using CarDealer.DTO.Customer;
    using CarDealer.DTO.Sale;
    using CarDealer.DTO.Car;
    using CarDealer.Models;

    using AutoMapper;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Problem 9
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Problem 10
            this.CreateMap<ImportPartDto, Part>();

            //Problem 12
            this.CreateMap<ImportCustomerDto, Customer>();

            //Problem 13
            this.CreateMap<ImportSaleDto, Sale>();

            //Problem 14
            this.CreateMap<Customer, ExportOrderedCustomerDto>()
                .ForMember(d => d.BirthDate,
                    mo => mo.MapFrom(s => $"{s.BirthDate:dd/MM/yyyy}"));

            //Problem 15
            this.CreateMap<Car, ExportCarsFromMakeToyotaDto>();

            //Problem 16
            this.CreateMap<Supplier, ExportLocalSupplierDto>();

            //Problem 19
            this.CreateMap<Car, ExportCarDto>();

            this.CreateMap<Sale, ExportSaleWithDiscountDto>()
                .ForMember(d => d.Discount,
                    mo => mo.MapFrom(s => s.Discount.ToString("F2")))
                .ForMember(d => d.Price,
                    mo => mo.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2")));
        }
    }
}
