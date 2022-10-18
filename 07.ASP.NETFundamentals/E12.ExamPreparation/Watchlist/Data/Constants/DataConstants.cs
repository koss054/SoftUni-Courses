namespace Watchlist.Data.Constants
{
    public class DataConstants
    {
        public class User
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public class Movie
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;

            public const double RatingMinValue = 0.00;
            public const double RatingMaxValue = 10.00;
        }

        public class Genre
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
