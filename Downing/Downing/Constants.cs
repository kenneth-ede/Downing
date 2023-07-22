namespace Downing
{
    public static class PageNames
    {
        public const string Companies = "/Companies/Index";
    }

    public static class Error
    {
        public const string Name = "Company name is required";
        public const string Code = "Company code is required";
        public const string Max10 = "Maximum code length is 10 characters";
        public const string CompanyExists = "Company already exists";
        public const string SharePrice = "Share price can have up to 5 decimals";
        public const string CodeAlphaNumeric = "Company code must be alpha-numeric";
    }

    public static class RegExes
    {
        public const string AlphaNumeric = @"^[a-zA-Z0-9\s,]*$";
        public const string SharePrice = "^(\\d{0,6})(\\.\\d{1,5})?$";
    }
}
