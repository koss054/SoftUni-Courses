namespace HouseRenting.Web.Models.Houses
{
    using System.ComponentModel.DataAnnotations;

    using Services;
    using Services.Houses.Models;

    public class AllHousesQueryModel
    {
        public const int HousesPerPage = 3;

        public string Category { get; init; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public HouseSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalHousesCount { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }
            = new List<HouseServiceModel>();
    }
}
