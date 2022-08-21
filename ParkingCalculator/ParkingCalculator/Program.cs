// See https://aka.ms/new-console-template for more information
using ParkingCalculator.FeeCalculators;
using ParkingCalculator.Utils;

// This would be injected in a real project

var _dateUtil = new DateUtil();

var shortStay = new ShortStayFeeCalculator(_dateUtil);
var longStay = new LongStayFeeCalculator(_dateUtil);

var shortStayTest1 = shortStay.CalculateFee(new DateTime(2017, 9, 7, 16, 50, 0), new DateTime(2017, 9, 9, 19, 15, 0));
var shortStayTest2 = shortStay.CalculateFee(new DateTime(2017, 9, 7, 16, 50, 0), new DateTime(2017, 9, 7, 19, 15, 0));
var shortStayTest3 = shortStay.CalculateFee(new DateTime(2017, 9, 7, 8, 0, 0), new DateTime(2017, 9, 8, 19, 15, 0));
var shortStayTest4 = shortStay.CalculateFee(new DateTime(2017, 9, 7, 20, 50, 0), new DateTime(2017, 9, 9, 17, 30, 0));
var shortStayTest5 = shortStay.CalculateFee(new DateTime(2017, 9, 7, 4, 50, 0), new DateTime(2017, 9, 9, 7, 15, 0));

var longStayTest1 = longStay.CalculateFee(new DateTime(2017, 9, 7, 7, 50, 0), new DateTime(2017, 9, 9, 5, 20, 0));
var longStayTest2 = longStay.CalculateFee(new DateTime(2017, 9, 7, 7, 50, 0), new DateTime(2017, 9, 8, 5, 20, 0));
var longStayTest3 = longStay.CalculateFee(new DateTime(2017, 9, 7, 7, 50, 0), new DateTime(2017, 9, 8, 5, 20, 0));
var longStayTest4 = longStay.CalculateFee(new DateTime(2017, 9, 7, 10, 50, 0), new DateTime(2017, 9, 9, 18, 0, 0));
var longStayTest5 = longStay.CalculateFee(new DateTime(2017, 9, 7, 8, 0, 0), new DateTime(2017, 9, 9, 23, 15, 0));

Console.WriteLine($"Short stay test result 1: {shortStayTest1}");
Console.WriteLine($"Short stay test result 2: {shortStayTest2}");
Console.WriteLine($"Short stay test result 3: {shortStayTest3}");
Console.WriteLine($"Short stay test result 4: {shortStayTest4}");
Console.WriteLine($"Short stay test result 5: {shortStayTest5}");

Console.WriteLine($"Long stay test result 1: {longStayTest1}");
Console.WriteLine($"Long stay test result 2: {longStayTest2}");
Console.WriteLine($"Long stay test result 3: {longStayTest3}");
Console.WriteLine($"Long stay test result 4: {longStayTest4}");
Console.WriteLine($"Long stay test result 5: {longStayTest5}");

Console.ReadLine();