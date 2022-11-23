namespace HouseRenting.Services.Infrastructure
{
    using AutoMapper;

    using Data.Entities;
    using Houses.Models;
    using Agents.Models;
    using Services.Models;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<House, HouseServiceModel>()
                .ForMember(h => h.IsRented, cfg => cfg.MapFrom(h => h.RenterId != null));

            this.CreateMap<House, HouseDetailsServiceModel>()
                .ForMember(h => h.IsRented, cfg => cfg.MapFrom(h => h.RenterId != null))
                .ForMember(h => h.Category, cfg => cfg.MapFrom(h => h.Category.Name));

            this.CreateMap<Agent, AgentServiceModel>()
                .ForMember(a => a.Email, cfg => cfg.MapFrom(a => a.User.Email));

            this.CreateMap<House, HouseIndexServiceModel>();

            this.CreateMap<Category, HouseCategoryServiceModel>();
        }
    }
}
