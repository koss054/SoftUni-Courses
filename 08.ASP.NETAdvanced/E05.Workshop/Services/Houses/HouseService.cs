namespace HouseRenting.Services.Houses
{
    using Data;
    using Data.Entities;
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

        public bool CategoryExists(int categoryId)
        {
            return this.data.Categories
                .Any(c => c.Id == categoryId);
        }

        public int Create(string title, 
            string address, string description, string imageUrl,
            decimal price, int categoryId, int agentId)
        {
            var house = new House()
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = price,
                CategoryId = categoryId,
                AgentId = agentId
            };

            this.data.Houses.Add(house);
            this.data.SaveChanges();
            return house.Id;
        }
    }
}
