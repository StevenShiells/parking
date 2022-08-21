using ParkingCalculator.Utils;

namespace ParkingCalculator.FeeCalculators
{
    public class ShortStayFeeCalculator : FeeCalculator
    {
        public TimeSpan From => new TimeSpan(8, 0, 0);

        public TimeSpan To => new TimeSpan(18, 0, 0);

        public override decimal UnitFee => 1.1m;

        private IDateUtil _dateUtil;

        public ShortStayFeeCalculator(IDateUtil dateUtil)
        {
            _dateUtil = dateUtil;
        }

        public override decimal GetChargableUnits(DateTime start, DateTime end)
        {
            return _dateUtil.GetNumberOfHoursBetween(start, end, From, To, true);
        }
    }
}
