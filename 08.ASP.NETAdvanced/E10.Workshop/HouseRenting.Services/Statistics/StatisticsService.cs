namespace HouseRenting.Services.Statistics
{
    using Data;
    using Models;

    public class StatisticsService : IStatisticsService
    {
        private readonly HouseRentingDbContext data;

        public StatisticsService(HouseRentingDbContext _data)
        {
            data = _data;
        }

        public StatisticsServiceModel Total()
        {
            var totalHouses = this.data.Houses.Count();
            var totalRents = this.data.Houses
                .Where(h => h.RenterId != null).Count();

            return new StatisticsServiceModel
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
