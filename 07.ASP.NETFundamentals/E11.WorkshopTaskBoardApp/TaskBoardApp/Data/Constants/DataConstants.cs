namespace TaskBoardApp.Data.Constants
{
    public class DataConstants
    {
        public class User
        {
            public const int FirstNameMaxLength = 15;
            public const int LastNameMaxLength = 15;
        }

        public class Task
        {
            public const int TaskTitleMinLength = 5;
            public const int TaskTItleMaxLength = 70;

            public const int TaskDescriptionMinLength = 10;
            public const int TaskDescriptionMaxLength = 1000;
        }

        public class Board
        {
            public const int BoardNameMinLength = 3;
            public const int BoardNameMaxLength = 30;
        }
    }
}
