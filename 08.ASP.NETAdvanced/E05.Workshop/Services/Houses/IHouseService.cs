namespace HouseRenting.Services.Houses
{
    using Services.Models;

    public interface IHouseService
    {
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();
    }
}
