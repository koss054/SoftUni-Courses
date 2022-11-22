namespace HouseRenting.Services.Houses.Models
{
    using System.ComponentModel;

    public class HouseServiceModel : IHouseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }

        [DisplayName("Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [DisplayName("It's Rented")]
        public bool IsRented { get; set; }
    }
}
