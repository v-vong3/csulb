namespace Company.BankApp.DataAccess
{
    // Lecture: Sometimes you want to group up configurations that are constants
    // or values that you repeatedly need. Consolidating them into a "Constants" object
    // or a "Defaults" object is an option, but retrieving values from a configuration file
    // or some other external source would be more extensible and maintainable.
    public static class FormatDefaults
    {
        public static string UserFormat => "yyyyMMdd_hh_mm_ss_ms";

        public static string BankAccountFormat => "yyyyMMdd_hh_mm_ss_ms";
    }
}
