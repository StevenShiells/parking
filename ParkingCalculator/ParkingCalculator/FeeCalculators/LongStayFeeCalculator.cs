using ParkingCalculator.Utils;

namespace ParkingCalculator.FeeCalculators
{
    internal class LongStayFeeCalculator : FeeCalculator
    {
        public override decimal UnitFee => 7.5m;

        public override decimal GetChargableUnits(DateTime start, DateTime end)
        {
            return DateUtil.GetNumberOfDaysBetween(start, end);
        }
    }
}
