namespace HouseRenting.Web.Infrastructure
{
    using AutoMapper;

    using Web.Models.Houses;
    using Services.Houses.Models;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<HouseDetailsServiceModel, HouseFormModel>();
            this.CreateMap<HouseDetailsServiceModel, HouseDetailsViewModel>();
        }
    }
}
