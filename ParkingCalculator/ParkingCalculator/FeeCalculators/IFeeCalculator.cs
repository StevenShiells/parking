namespace ParkingCalculator.FeeCalculators
{
    internal interface IFeeCalculator
    {
        decimal CalculateFee(DateTime start, DateTime end);
    }
}
