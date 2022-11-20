namespace HouseRenting.Services.Houses
{
    using Services.Models;
    using Services.Houses.Models;

    public interface IHouseService
    {
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();

        IEnumerable<HouseCategoryServiceModel> AllCategories();
    }
}
