namespace HouseRenting.Services.Houses
{
    using Data;
    using Services.Models;
    using Services.Houses.Models;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;

        public HouseService(HouseRentingDbContext _data)
        {
            data = _data;
        }

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
        {
            return this.data.Houses
                .OrderByDescending(c => c.Id)
                .Select(c => new HouseIndexServiceModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl
                }).Take(3);
        }

        public IEnumerable<HouseCategoryServiceModel> AllCategories()
        {
            return this.data.Categories
                .Select(c => new HouseCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
        }
    }
}
