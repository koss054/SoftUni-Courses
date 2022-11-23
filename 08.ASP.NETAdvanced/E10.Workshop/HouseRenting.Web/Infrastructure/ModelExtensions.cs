namespace HouseRenting.Web.Infrastructure
{
    using System.Text.RegularExpressions;

    using Services.Houses.Models;

    public static class ModelExtensions
    {
        public static string GetInformation(this IHouseModel house)
        {
            return house.Title.Replace(" ", "-") + "-" + GetAddress(house.Address);
        }
        private static string GetAddress(string address)
        {
            address = string.Join("-", address.Split(" ").Take(3));
            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
