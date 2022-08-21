using ParkingCalculator.Utils;

namespace ParkingCalculator.FeeCalculators
{
    public class LongStayFeeCalculator : FeeCalculator
    {
        private IDateUtil _dateUtil;

        public LongStayFeeCalculator(IDateUtil dateUtil)
        {
            _dateUtil = dateUtil;
        }

        public override decimal UnitFee => 7.5m;

        public override decimal GetChargableUnits(DateTime start, DateTime end)
        {
            return _dateUtil.GetNumberOfDaysBetween(start, end);
        }
    }
}
