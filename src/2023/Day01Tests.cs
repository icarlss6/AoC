using Xunit;

public class Day01Tests
{
    [Fact]
    public void TestRunA_Fake()
    {
        // Arrange
        string[] input = ["123", "456", "789"];
        var day01 = new Day01(input);

        // Act
        var result = day01.RunA();

        // Assert
        Assert.Equal(138, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void TestRunA_Example()
    {
        // Arrange
        string[] input = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"];
        var day01 = new Day01(input);

        // Act
        var result = day01.RunA();

        // Assert
        Assert.Equal(142, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void TestRunA_MyInput()
    {
        // Arrange
        string inputFile = "Day01.input.txt";
        var input = File.ReadAllLines(inputFile);
        var day01 = new Day01(input);

        // Act
        var result = day01.RunA();

        // Assert
        Assert.Equal(55208, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void TestRunB_ReplaceStringDigits()
    {
        // Arrange
        string[] input =
        [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        ];
        string[] expected = ["219", "83", "123", "234", "49872", "1234", "76"];
        var day01 = new Day01(input);

        // Act
        var result = day01.ReplaceStringDigits(input);

        // Assert
        Assert.Equal(expected, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void TestRunB_Example()
    {
        // Arrange
        string[] input =
        [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        ];
        var day01 = new Day01(input);

        // Act
        var result = day01.RunB();

        // Assert
        Assert.Equal(281, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void TestRunB_MyInput()
    {
        // Arrange
        string inputFile = "Day01.input.txt";
        var input = File.ReadAllLines(inputFile);
        var day01 = new Day01(input);

        // Act
        var result = day01.RunB();

        // Assert
        Assert.Equal(54572, result); // The sum of all digits in the input is 45
    }
}
