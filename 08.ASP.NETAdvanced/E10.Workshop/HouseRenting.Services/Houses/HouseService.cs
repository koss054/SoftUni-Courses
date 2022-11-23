﻿namespace HouseRenting.Services.Houses
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Data.Entities;
    using Services.Users;
    using Services.Models;
    using Services.Houses.Models;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public HouseService(
            HouseRentingDbContext _data,
            IUserService _userService,
            IMapper _mapper)
        {
            data = _data;
            userService = _userService;
            mapper = _mapper;
        }

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
        {
            return this.data.Houses
                .OrderByDescending(c => c.Id)
                .ProjectTo<HouseIndexServiceModel>(this.mapper.ConfigurationProvider)
                .Take(3);
        }

        public IEnumerable<HouseCategoryServiceModel> AllCategories()
        {
            return this.data.Categories
                .ProjectTo<HouseCategoryServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
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
        
        public HouseQueryServiceModel All(
            string category = null,
            string searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var housesQuery = this.data.Houses.AsQueryable();
            if (!string.IsNullOrWhiteSpace(category))
            {
                housesQuery = this.data.Houses
                    .Where(h => h.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                housesQuery = housesQuery.Where(h =>
                    h.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Address.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            housesQuery = sorting switch
            {
                HouseSorting.Price => housesQuery
                    .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesQuery
                    .OrderBy(h => h.RenterId != null)
                    .ThenByDescending(h => h.Id),
                _ => housesQuery.OrderByDescending(h => h.Id)
            };

            var houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectTo<HouseServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            var totalHouses = housesQuery.Count();
            return new HouseQueryServiceModel()
            {
                TotalHousesCount = totalHouses,
                Houses = houses
            };
        }
        public IEnumerable<string> AllCategoryNames()
        {
            return this.data.Categories
                .Select(c => c.Name)
                .Distinct()
                .ToList();
        }

        public IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId)
        {
            var houses = this.data.Houses
                .Where(h => h.AgentId == agentId)
                .ProjectTo<HouseServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return houses;
        }

        public IEnumerable<HouseServiceModel> AllHousesByUserId(string userId)
        {
            var houses = this.data.Houses
                .Where(h => h.RenterId == userId)
                .ProjectTo<HouseServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return houses;
        }

        public bool Exists(int id)
        {
            return this.data.Houses.Any(h => h.Id == id);
        }

        public HouseDetailsServiceModel HouseDetailsById(int id)
        {
            return this.data.Houses
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                    Category = h.Category.Name,
                    Agent = new Agents.Models.AgentServiceModel()
                    {
                        FullName = this.userService.UserFullName(h.Agent.UserId),
                        PhoneNumber = h.Agent.PhoneNumber,
                        Email = h.Agent.User.Email
                    }
                })
                .FirstOrDefault();
        }

        public void Edit(int houseId, string title, string address,
            string description, string imageUrl, decimal price, int categoryId)
        {
            var house = this.data.Houses.Find(houseId);

            house.Title = title;
            house.Address = address;
            house.Description = description;
            house.ImageUrl = imageUrl;
            house.PricePerMonth = price;
            house.CategoryId = categoryId;

            this.data.SaveChanges();
        }

        public bool HasAgentWithId(int houseId, string currentUserId)
        {
            var house = this.data.Houses.Find(houseId);
            var agent = this.data.Agents.FirstOrDefault(a => a.Id == house.AgentId);

            if (agent != null)
            {
                return false;
            }
            
            if (agent.UserId != currentUserId)
            {
                return false;
            }

            return true;
        }

        public int GetHouseCategoryId(int houseId)
        {
            return this.data.Houses.Find(houseId).CategoryId;
        }

        public void Delete(int houseId)
        {
            var house = this.data.Houses.Find(houseId);
            this.data.Remove(house);
            this.data.SaveChanges();
        }

        public bool IsRented(int id)
        {
            return this.data.Houses.Find(id).RenterId != null;
        }

        public bool IsRentedByUserWithId(int houseId, string userId)
        {
            var house = this.data.Houses.Find(houseId);

            if (house == null)
            {
                return false;
            }

            if (house.RenterId != userId)
            {
                return false;
            }

            return true;
        }

        public void Rent(int houseId, string userId)
        {
            var house = this.data.Houses.Find(houseId);
            house.RenterId = userId;
            this.data.SaveChanges();
        }

        public void Leave(int houseId)
        {
            var house = this.data.Houses.Find(houseId);
            house.RenterId = null;
            this.data.SaveChanges();
        }
    }
}
