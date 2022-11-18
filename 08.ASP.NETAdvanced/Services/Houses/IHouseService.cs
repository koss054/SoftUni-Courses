namespace HouseRenting.Services.Houses
{
    using Models.Houses;

    public interface IHouseService
    {
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();
    }
}
