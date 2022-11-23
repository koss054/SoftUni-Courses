namespace HouseRenting.Web.Models.Houses
{
    using System.ComponentModel.DataAnnotations;

    using Services.Houses.Models;

    using static Services.Data.DataConstants.House;

    public class HouseFormModel : IHouseModel
    {
        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; init; }

        [Required]
        [StringLength(MaxAddressLength, MinimumLength = MinAddressLength)]
        public string Address { get; init; }

        [Required]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [Range(MinPriceValue, MaxPriceValue,
            ErrorMessage = "Price per month must be more than 0 and less than {2} leva.")]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; }
            = new List<HouseCategoryServiceModel>();
    }
}
