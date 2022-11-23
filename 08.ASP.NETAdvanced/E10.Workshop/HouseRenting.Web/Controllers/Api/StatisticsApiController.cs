namespace HouseRenting.Web.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Statistics;
    using Services.Statistics.Models;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsApiController(IStatisticsService _statisticsService)
        {
            statisticsService = _statisticsService;
        }

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
        {
            return this.statisticsService.Total();
        }
    }
}
