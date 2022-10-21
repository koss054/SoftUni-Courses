namespace Watchlist.Data.Constants
{
    public class DataConstants
    {
        public class User
        {
            public const int MinUserNameLength = 5;
            public const int MaxUserNameLength = 20;

            public const int MinEmailLength = 10;
            public const int MaxEmailLength = 60;

            public const int MinPasswordLength = 5;
            public const int MaxPasswordLength = 20;
        }

        public class Movie
        {
            public const int MinTitleLength = 10;
            public const int MaxTitleLength = 50;

            public const int MinDirectorLength = 5;
            public const int MaxDirectorLength = 50;

            public const string MinRatingValue = "0.00";
            public const string MaxRatingValue = "10.00";
        }

        public class Genre
        {
            public const int MinNameLength = 5;
            public const int MaxNameLength = 50;
        }
    }
}
