namespace HouseRenting.Services.Agents
{
    using Data;

    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext _data)
        {
            data = _data;
        }

        public bool ExistsById(string userId)
        {
            return this.data.Agents
                .Any(a => a.UserId == userId);
        }
    }
}
