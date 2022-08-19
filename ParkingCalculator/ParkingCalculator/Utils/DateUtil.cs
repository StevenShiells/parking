namespace ParkingCalculator.Utils
{
    internal class DateUtil
    {
        private static TimeSpan DAY_START = new TimeSpan();
        private static TimeSpan DAY_END = new TimeSpan(23,59,59);

        public static decimal GetNumberOfHoursBetween(DateTime start, DateTime end, TimeSpan targetStartTime, TimeSpan targetEndTime, bool skipWeekends)
        {
            ValidateDateArguments(start, end);

            var workingDate = start;

            var total = 0.0m;

            while (workingDate < end)
            {
                // If we are skipping weekends and the working day is a Saturday or Sunday then ignore
                if (IncludeDate(workingDate, skipWeekends))
                {
                    total += GetNumberOfHoursInWindow(workingDate, workingDate.Date.AddDays(1), targetStartTime, targetEndTime);
                }
                
                workingDate = IncrementDate(workingDate);
            }

            return total;
        }

        public static decimal GetNumberOfDaysBetween(DateTime start, DateTime end)
        {
            ValidateDateArguments(start, end);

            var workingDate = start;

            var total = 0.0m;

            while(workingDate < end)
            {
                var partOfDay = GetNumberOfHoursInWindow(workingDate, workingDate.Date.AddDays(1), DAY_START, DAY_END);
                // if any part of the day falls within the window add 1 full day.
                if(partOfDay > 0)
                {
                    total += 1;
                }
                
                workingDate = IncrementDate(workingDate);
            }

            return total;
        }

        private static decimal GetNumberOfHoursInWindow(DateTime start, DateTime end, TimeSpan targetStartTime, TimeSpan targetEndTime)
        {
            // Calculate the start and end points of the target window.
            var targetStart = start.Date.Add(targetStartTime);
            var targetEnd = start.Date.Add(targetEndTime);

            // Validate or working window in case bad target times are supplied.
            ValidateDateArguments(targetStart, targetEnd);

             // Figure out if we are starting/ending at the start/end of the window or if
             // we are somehwere in the middle.
            var countingStart = targetStart > start ? targetStart : start;
            var countingEnd = targetEnd < end ? targetEnd : end;

            var diff = countingEnd - countingStart;

            var residualMinutes = diff.Minutes % 60;

            // Return difference in fractional parts of hours
            return diff.Hours + (residualMinutes / 60.0m);
        }

        private static void ValidateDateArguments(DateTime start, DateTime end)
        {
            if(start.CompareTo(end) >= 0)
            {
                // Depending on context we might not want to throw an exception.
                // It could be that it would be better to just switch the start
                // and end dates if needed
                throw new ArgumentException("start must be before end");
            }
        }

        private static bool IncludeDate(DateTime date, bool skipWeekends)
        {
            var skipDate =  skipWeekends && (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
            return !skipDate;
        }

        private static DateTime IncrementDate(DateTime date)
        {
            date = date.AddDays(1);
            // Resetting working date to be the start of the day so all iterations
            // except the first start from midnight.
            date = date.Date;
            return date;
        }
    }
}
