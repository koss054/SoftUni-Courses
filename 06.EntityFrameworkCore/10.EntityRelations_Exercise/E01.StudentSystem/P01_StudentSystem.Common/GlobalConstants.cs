namespace P01_StudentSystem.Common
{
    public static class GlobalConstants
    {
        //Student
        public const string StudentNameMaxLengthAndColumnType = "NVARCHAR(100)";
        public const string StudentPhoneNumberMaxLengthAndColumnType = "VARCHAR(10)";
        public const int StudentPhoneNumberLength = 10;

        //Course
        public const string CourseNameMaxLengthAndColumnType = "NVARCHAR(80)";

        //Resource
        public const string RecourceNameMaxLengthAndColumnType = "NVARCHAR(50)";


        //Column types
        public const string VarcharDefault = "VARCHAR(255)";
        public const string NVarcharDefault = "NVARCHAR(255)";
    }
}
