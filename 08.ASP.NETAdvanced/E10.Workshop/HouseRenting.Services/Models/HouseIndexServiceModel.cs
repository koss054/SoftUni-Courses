// This file is in an incorrect directory.
// Too lazy to change it right now.
namespace HouseRenting.Services.Models
{
    using Services.Houses.Models;

    public class HouseIndexServiceModel : IHouseModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;
    }
}
