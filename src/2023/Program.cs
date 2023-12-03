// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string inputFile = "Day01.input.txt";
var input = File.ReadAllLines(inputFile);

var day01 = new Day01(input);
day01.RunA();