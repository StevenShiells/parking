using System;

public interface IDateUtil
{
    decimal GetNumberOfHoursBetween(DateTime start, DateTime end, TimeSpan targetStartTime, TimeSpan targetEndTime, bool skipWeekends);
    decimal GetNumberOfDaysBetween(DateTime start, DateTime end);
}
