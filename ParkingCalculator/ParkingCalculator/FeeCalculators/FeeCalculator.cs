namespace ParkingCalculator.FeeCalculators
{
    public abstract class FeeCalculator : IFeeCalculator
    {
        public abstract decimal UnitFee { get; }

        public abstract decimal GetChargableUnits(DateTime start, DateTime end);

        public decimal CalculateFee(DateTime start, DateTime end)
        {
            var chargableUnits = GetChargableUnits(start, end);

            // Round to 2 decimal places so we only charge in full pence.
            // (Though being a Scotsman I was very tempted to use Math.Ceiling
            // but that wouldn't fit the numbers in the example).
            return Math.Round(chargableUnits * UnitFee, 2);
        }
    }
}
