using Moq;
using ParkingCalculator.FeeCalculators;

namespace ParkingCalculatorTests.FeeCalculators
{
    public class LongStayFeeCalculatorTests
    {
        private Mock<IDateUtil> _dateUtil;
        private LongStayFeeCalculator _longStayFeeCalculator;

        public LongStayFeeCalculatorTests()
        {
            _dateUtil = new Mock<IDateUtil>();
            _longStayFeeCalculator = new LongStayFeeCalculator(_dateUtil.Object);
        }

        [Fact]
        public void UnitFeeTest()
        {
            Assert.Equal(7.5m, _longStayFeeCalculator.UnitFee);
        }

        [Fact]
        public void GetChargeableUnitTest()
        {
            DateTime start = new DateTime(2022, 8, 21);
            DateTime end = new DateTime(2022, 8, 22);

            _dateUtil.Setup(x => x.GetNumberOfDaysBetween(start, end)).Returns(7);

            var actual = _longStayFeeCalculator.GetChargableUnits(start, end);

            Assert.Equal(7, actual);

            _dateUtil.Verify(x => x.GetNumberOfDaysBetween(start, end));
        }
    }
}
