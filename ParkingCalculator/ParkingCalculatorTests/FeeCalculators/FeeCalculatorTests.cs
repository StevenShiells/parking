using ParkingCalculator.FeeCalculators;

namespace ParkingCalculatorTests.FeeCalculators
{
    public class FeeCalculatorTests
    {
        [Fact]
        public void CalculateFee_ReturnsFeeTimesUnits()
        {
            var feeCalculator = new TestFeeCalculator();
            var actual = feeCalculator.CalculateFee(new DateTime(2022, 8, 21), new DateTime(2022, 8, 22));
            Assert.Equal(20, actual);
        }

        private class TestFeeCalculator : FeeCalculator
        {
            public override decimal UnitFee => 4;

            public override decimal GetChargableUnits(DateTime start, DateTime end)
            {
                return 5;
            }
        }
    }
}