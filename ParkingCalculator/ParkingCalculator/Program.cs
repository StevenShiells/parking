// See https://aka.ms/new-console-template for more information
using ParkingCalculator.FeeCalculators;

var shortStay = new ShortStayFeeCalculator();
var longStay = new LongStayFeeCalculator();

var test1 = shortStay.CalculateFee(new DateTime(2017, 9, 7, 16, 50, 0), new DateTime(2017, 9, 9, 19, 15, 0));
var test2 = longStay.CalculateFee(new DateTime(2017, 9, 7, 7, 50, 0), new DateTime(2017, 9, 9, 5, 20, 0));

Console.WriteLine($"Short stay test result: {test1}");
Console.WriteLine($"Long stay test result: {test2}");