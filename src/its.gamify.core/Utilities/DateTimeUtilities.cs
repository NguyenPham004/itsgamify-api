namespace its.gamify.core.Utilities
{
    public static class DateTimeUtilities
    {
        public static (DateTime StartDate, DateTime EndDate) GetQuarterDates(int year, int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

            // Determine the quarter number
            int quarter = (month - 1) / 3 + 1;

            // Calculate the starting month of the quarter
            int startMonth = (quarter - 1) * 3 + 1;

            // Calculate the ending month of the quarter
            int endMonth = startMonth + 2;

            // Create the start date as the first day of the starting month
            DateTime startDate = new DateTime(year, startMonth, 1);

            // Calculate the number of days in the ending month
            int daysInEndMonth = DateTime.DaysInMonth(year, endMonth);

            // Create the end date as the last day of the ending month
            DateTime endDate = new DateTime(year, endMonth, daysInEndMonth);

            return (startDate, endDate);
        }

        public static int GetQuarterNumber(int month)
        {
            return month switch
            {
                >= 1 and <= 3 => 1,
                >= 4 and <= 6 => 2,
                >= 7 and <= 9 => 3,
                >= 10 and <= 12 => 4,
                _ => throw new ArgumentException("Tháng không hợp lệ")
            };
        }

    }


}
