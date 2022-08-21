using Moq;
using ParkingCalculator.FeeCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCalculatorTests.FeeCalculators
{
    public class ShortStayFeeCalculatorTests
    {
        private Mock<IDateUtil> _dateUtil;
        private ShortStayFeeCalculator _shortStayFeeCalculator;

        public ShortStayFeeCalculatorTests()
        {
            _dateUtil = new Mock<IDateUtil>();
            _shortStayFeeCalculator = new ShortStayFeeCalculator(_dateUtil.Object);
        }

        [Fact]
        public void FromTest()
        {
            Assert.Equal(0, _shortStayFeeCalculator.From.Days);
            Assert.Equal(8, _shortStayFeeCalculator.From.Hours);
            Assert.Equal(0, _shortStayFeeCalculator.From.Minutes);
            Assert.Equal(0, _shortStayFeeCalculator.From.Seconds);
        }

        [Fact]
        public void ToTest()
        {
            Assert.Equal(0, _shortStayFeeCalculator.To.Days);
            Assert.Equal(18, _shortStayFeeCalculator.To.Hours);
            Assert.Equal(0, _shortStayFeeCalculator.To.Minutes);
            Assert.Equal(0, _shortStayFeeCalculator.To.Seconds);
        }

        [Fact]
        public void UnitFeeTest()
        {
            Assert.Equal(1.1m, _shortStayFeeCalculator.UnitFee);
        }

        [Fact]
        public void GetChargeableUnitTest()
        {
            DateTime start = new DateTime(2022, 8, 21);
            DateTime end = new DateTime(2022, 8, 22);

            _dateUtil.Setup(x => x.GetNumberOfHoursBetween(start, end, _shortStayFeeCalculator.From, _shortStayFeeCalculator.To, true)).Returns(3.45m);

            var actual = _shortStayFeeCalculator.GetChargableUnits(start, end);

            Assert.Equal(3.45m, actual);

            _dateUtil.Verify(x => x.GetNumberOfHoursBetween(start, end, _shortStayFeeCalculator.From, _shortStayFeeCalculator.To, true));
        }
    }
}
