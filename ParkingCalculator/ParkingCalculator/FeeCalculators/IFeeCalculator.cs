namespace ParkingCalculator.FeeCalculators
{
    public interface IFeeCalculator
    {
        decimal CalculateFee(DateTime start, DateTime end);
    }
}
