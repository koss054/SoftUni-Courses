namespace HouseRenting.Services.Agents
{
    using Data;
    using Data.Entities;

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

        public bool UserWithPhoneNumberExists(string phoneNumber)
        {
            return this.data.Agents
                .Any(a => a.PhoneNumber == phoneNumber);
        }

        public bool UserHasRents(string userId)
        {
            return this.data.Houses
                .Any(h => h.RenterId == userId);
        }

        public void Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            this.data.Agents.Add(agent);
            this.data.SaveChanges();
        }
    }
}
