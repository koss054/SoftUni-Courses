namespace HouseRenting.Data
{
    public class DataConstants
    {
        public static class Category
        {
            public const int MaxNameLength = 50;
        }

        public static class House
        {
            public const int MinTitleLength = 10;
            public const int MaxTitleLength = 50;

            public const int MinAddressLength = 30;
            public const int MaxAddressLength = 150;

            public const int MinDescriptionLength = 50;
            public const int MaxDescriptionLength = 500;

            public const double MinPriceValue = 0;
            public const double MaxPriceValue = 2000;
        }

        public static class Agent
        {
            public const int MinPhoneLength = 7;
            public const int MaxPhoneLength = 15; 
        }
    }
}
