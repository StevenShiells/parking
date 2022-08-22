using ParkingCalculator.Utils;
namespace ParkingCalculatorTests.Utils
{
    public class DateUtilTests
    {
        private DateUtil _dateUtil;

        private TimeSpan EIGHT_AM = new TimeSpan(8, 0, 0);
        private TimeSpan SIX_PM = new TimeSpan(18, 0, 0);

        public DateUtilTests()
        {
            _dateUtil = new DateUtil();
        }

        #region GetNumberOfHoursBetween Tests

        [Fact]
        public void GetNumberOfHoursBetween_StartDateAfterEndDate_ExceptionThrown()
        {
            var startDate = new DateTime(2022, 8, 21);
            var endDate = new DateTime(2022, 8, 20);

            Assert.Throws<ArgumentException>(() => _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true));
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateBeforeWindow_EndDateAfterWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 7, 0, 0);
            var endDate = new DateTime(2022, 8, 22, 19, 0, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(10, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateAfterWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 9, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 19, 0, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(8.5m, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateAfterWindow_EndDateAfterWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 19, 0, 0);
            var endDate = new DateTime(2022, 8, 22, 19, 30, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(0m, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateBeforeWindow_EndDateInWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 7, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 11, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(3.25m, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateBeforeWindow_EndDateBeforeWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 7, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 7, 45, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(0m, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateInWindow_SameDay()
        {
            var startDate = new DateTime(2022, 8, 22, 9, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 11, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(1.75m, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateInWindow_SkipWeekends_OverWeekend()
        {
            var startDate = new DateTime(2022, 8, 19, 17, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 8, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, true);

            Assert.Equal(0.75m, actual);
        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateInWindow_NotSkipWeekends_OverWeekend()
        {
            var startDate = new DateTime(2022, 8, 19, 17, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 8, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursBetween(startDate, endDate, EIGHT_AM, SIX_PM, false);

            Assert.Equal(20.75m, actual);
        }

        #endregion GetNumberOfHoursBetween Tests

        #region GetNumberOfDaysBetween Tests

        [Fact]
        public void GetNumberOfDaysBetween_StartDateAfterEndDate_ExceptionThrown()
        {
            var startDate = new DateTime(2022, 8, 21);
            var endDate = new DateTime(2022, 8, 20);

            Assert.Throws<ArgumentException>(() => _dateUtil.GetNumberOfDaysBetween(startDate, endDate));
        }

        [Fact]
        public void GetNumberOfDaysBetween_StartDateSameDayAsEndDate()
        {
            var startDate = new DateTime(2022, 8, 21, 10, 0 , 0);
            var endDate = new DateTime(2022, 8, 21, 12, 0, 0);

            var actual = _dateUtil.GetNumberOfDaysBetween(startDate, endDate);

            Assert.Equal(1m, actual);
        }

        [Fact]
        public void GetNumberOfDaysBetween_StartDateDayBeforeEndDate()
        {
            var startDate = new DateTime(2022, 8, 21, 10, 0, 0);
            var endDate = new DateTime(2022, 8, 22, 12, 0, 0);

            var actual = _dateUtil.GetNumberOfDaysBetween(startDate, endDate);

            Assert.Equal(2m, actual);
        }

        [Fact]
        public void GetNumberOfDaysBetween_StartDate2DayBeforeEndDate()
        {
            var startDate = new DateTime(2022, 8, 21, 10, 0, 0);
            var endDate = new DateTime(2022, 8, 23, 12, 0, 0);

            var actual = _dateUtil.GetNumberOfDaysBetween(startDate, endDate);

            Assert.Equal(3m, actual);
        }

        #endregion GetNumberOfDaysBetween Tests

        #region GetNumberOfHoursInWindow Tests

        [Fact]
        public void GetNumberOfHoursInWindow_StartTimeAfterEndTime_ExceptionThrown()
        {
            var startDate = new DateTime(2022, 8, 20);
            var endDate = new DateTime(2022, 8, 20);

            Assert.Throws<ArgumentException>(() => _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, SIX_PM, EIGHT_AM));
        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateBeforeWindow_EndDateAfterWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 07, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 19, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, EIGHT_AM, SIX_PM);

            Assert.Equal(10m, actual);
        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateInWindow_EndDateAfterWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 08, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 19, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, EIGHT_AM, SIX_PM);

            Assert.Equal(9.5m, actual);
        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateAfterWindow_EndDateAfterWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 18, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 19, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, EIGHT_AM, SIX_PM);

            Assert.Equal(0m, actual);
        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateBeforeWindow_EndDateInWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 07, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 17, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, EIGHT_AM, SIX_PM);

            Assert.Equal(9.25m, actual);
        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateBeforeWindow_EndDateBeforeWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 07, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 7, 45, 0);

            var actual = _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, EIGHT_AM, SIX_PM);

            Assert.Equal(0m, actual);
        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateInWindow_EndDateInWindow()
        {
            var startDate = new DateTime(2022, 8, 22, 9, 30, 0);
            var endDate = new DateTime(2022, 8, 22, 10, 15, 0);

            var actual = _dateUtil.GetNumberOfHoursInWindow(startDate, endDate, EIGHT_AM, SIX_PM);

            Assert.Equal(0.75m, actual);
        }

        #endregion GetNumberOfHoursInWindow Tests

        #region ValidateDateArguments Tests

        [Fact]
        public void ValidateDateArguments_StartDateBeforeEndDate_NoExceptionThrown()
        {
            var startDate = new DateTime(2022, 8, 21);
            var endDate = new DateTime(2022, 8, 20);

            Assert.Throws<ArgumentException>(() => _dateUtil.ValidateDateArguments(startDate, endDate));
        }

        [Fact]
        public void ValidateDateArguments_StartDateEqualsEndDate_ExceptionThrown()
        {
            var startDate = new DateTime(2022, 8, 21);
            var endDate = new DateTime(2022, 8, 21);

            Assert.Throws<ArgumentException>(() => _dateUtil.ValidateDateArguments(startDate, endDate));
        }

        [Fact]
        public void ValidateDateArguments_StartDateAfterEndDate_ExceptionThrown()
        {
            var startDate = new DateTime(2022, 8, 20);
            var endDate = new DateTime(2022, 8, 21);

            var exception = Record.Exception(() => _dateUtil.ValidateDateArguments(startDate, endDate));
            Assert.Null(exception);
        }

        #endregion ValidateDateArguments Tests

        #region IncludeDate Tests


        [Fact]
        public void IncludeDate_Saturday_SkipWeekends_ReturnsFalse()
        {
            var date = new DateTime(2022, 8, 20);

            var actual = _dateUtil.IncludeDate(date, true);

            Assert.False(actual);
        }

        [Fact]
        public void IncludeDate_Sunday_SkipWeekends_ReturnsFalse()
        {
            var date = new DateTime(2022, 8, 21);

            var actual = _dateUtil.IncludeDate(date, true);

            Assert.False(actual);
        }

        [Fact]
        public void IncludeDate_Friday_SkipWeekends_ReturnsTrue()
        {
            var date = new DateTime(2022, 8, 19);

            var actual = _dateUtil.IncludeDate(date, true);

            Assert.True(actual);
        }

        [Fact]
        public void IncludeDate_Saturday_NotSkipWeekends_ReturnsTrue()
        {
            var date = new DateTime(2022, 8, 20);

            var actual = _dateUtil.IncludeDate(date, false);

            Assert.True(actual);
        }

        [Fact]
        public void IncludeDate_Sunday_NotSkipWeekends_ReturnsTrue()
        {
            var date = new DateTime(2022, 8, 21);

            var actual = _dateUtil.IncludeDate(date, false);

            Assert.True(actual);
        }

        [Fact]
        public void IncludeDate_Friday_NotSkipWeekends_ReturnsTrue()
        {
            var date = new DateTime(2022, 8, 19);

            var actual = _dateUtil.IncludeDate(date, false);

            Assert.True(actual);
        }

        #endregion IncludeDate Tests

        #region IncrementDate Tests


        [Fact]
        public void IncrementDate_ReturnsDateIncremented_TimeAsMidnight()
        {
            var date = new DateTime(2022, 8, 20, 7, 12, 45);

            var actual = _dateUtil.IncrementDate(date);
            var expected = new DateTime(2022, 8, 21);

            Assert.Equal(expected, actual);

        }

        #endregion IncrementDate Tests
    }
}
