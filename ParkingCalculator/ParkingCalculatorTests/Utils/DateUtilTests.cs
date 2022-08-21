using ParkingCalculator.Utils;
namespace ParkingCalculatorTests.Utils
{
    public class DateUtilTests
    {
        private IDateUtil _dateUtil;

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

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateAfterWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateAfterWindow_EndDateAfterWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateBeforeWindow_EndDateInWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateBeforeWindow_EndDateBeforeWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateInWindow_SameDay()
        {

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateInWindow_SkipWeekends_OverWeekend()
        {

        }

        [Fact]
        public void GetNumberOfHoursBetween_StartDateInWindow_EndDateInWindow_NotSkipWeekends_OverWeekend()
        {

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
        public void GetNumberOfHoursInWindow_StartDateAfterEndDate_ExceptionThrown()
        {

        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateBeforeWindow_EndDateAfterWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateInWindow_EndDateAfterWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateAfterWindow_EndDateAfterWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateBeforeWindow_EndDateInWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateBeforeWindow_EndDateBeforeWindow()
        {

        }

        [Fact]
        public void GetNumberOfHoursInWindow_StartDateInWindow_EndDateInWindow()
        {

        }

        #endregion GetNumberOfHoursInWindow Tests

        #region ValidateDateArguments Tests

        [Fact]
        public void ValidateDateArguments_StartDateBeforeEndDate_NoExceptionThrown()
        {
        }

        [Fact]
        public void ValidateDateArguments_StartDateEqualsEndDate_ExceptionThrown()
        {

        }

        [Fact]
        public void ValidateDateArguments_StartDateAfterEndDate_ExceptionThrown()
        {

        }

        #endregion ValidateDateArguments Tests

        #region IncludeDate Tests


        [Fact]
        public void IncludeDate_Saturday_SkipWeekends_ReturnsFalse()
        {

        }

        [Fact]
        public void IncludeDate_Sunday_SkipWeekends_ReturnsFalse()
        {

        }

        [Fact]
        public void IncludeDate_Friday_SkipWeekends_ReturnsTrue()
        {

        }

        [Fact]
        public void IncludeDate_Saturday_NotSkipWeekends_ReturnsFalse()
        {

        }

        [Fact]
        public void IncludeDate_Sunday_NotSkipWeekends_ReturnsFalse()
        {

        }

        [Fact]
        public void IncludeDate_Friday_NotSkipWeekends_ReturnsTrue()
        {

        }

        #endregion IncludeDate Tests

        #region IncrementDate Tests


        [Fact]
        public void IncrementDate_ReturnsDateIncremented_TimeAsMidnight()
        {

        }

        #endregion IncrementDate Tests
    }
}
