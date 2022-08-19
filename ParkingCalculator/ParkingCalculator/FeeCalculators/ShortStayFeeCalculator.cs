using ParkingCalculator.Utils;

namespace ParkingCalculator.FeeCalculators
{
    internal class ShortStayFeeCalculator : FeeCalculator
    {
        private TimeSpan From => new TimeSpan(8, 0, 0);

        private TimeSpan To => new TimeSpan(18, 0, 0);

        public override decimal UnitFee => 1.1m;

        public override decimal GetChargableUnits(DateTime start, DateTime end)
        {
            return DateUtil.GetNumberOfHoursBetween(start, end, From, To, true);
        }
    }
}
