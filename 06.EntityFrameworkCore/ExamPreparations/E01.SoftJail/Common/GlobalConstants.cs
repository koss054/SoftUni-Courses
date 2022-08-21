namespace SoftJail.Common
{
    public static class GlobalConstants
    {
        //Prisoner
        public const int PrisonerNameMinLength = 3;
        public const int PrisonerNameMaxLength = 20;
        public const double PrisonerAgeMinValue = 18;
        public const double PrisonerAgeMaxValue = 65;
        public const string PrisonerNicknameRegex = @"^The\s[A-Z][a-z]+$";

        //Officer
        public const int OfficerNameMinLength = 3;
        public const int OfficerNameMaxLength = 30;

        //Cell
        public const int CellNumberMinValue = 1;
        public const int CellNumberMaxValue = 1000;

        //Department
        public const int DepartmentNameMinLength = 3;
        public const int DepartmentNameMaxLength = 25;

        //Mail
        public const string MailAddressRegex = @"^([A-Za-z\s0-9]+?)\sstr\.$";

        //Decimal Range
        public const string MinDecimalValue = "0";
        public const string MaxDecimalValue = "79228162514264337593543950335";
    }
}
