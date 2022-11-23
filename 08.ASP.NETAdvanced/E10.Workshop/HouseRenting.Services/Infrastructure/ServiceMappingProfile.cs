namespace HouseRenting.Services.Infrastructure
{
    using AutoMapper;

    using Data.Entities;
    using Houses.Models;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<House, HouseServiceModel>()
                .ForMember(h => h.IsRented, cfg => cfg.MapFrom(h => h.RenterId != null)); 
        }
    }
}
