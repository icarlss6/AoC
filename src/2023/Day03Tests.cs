using Xunit;

public class Day03Tests
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
        string inputFile = "Day03.example.input.txt";
        var input = File.ReadAllLines(inputFile);
        var day03 = new Day03(input);

        // Act
        var result = day03.RunA();

        // Assert
        Assert.Equal(4361, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void TestRunA_MyInput()
    {
        // Arrange
        string inputFile = "Day03.input.txt";
        var input = File.ReadAllLines(inputFile);
        var day03 = new Day03(input);

        // Act
        var result = day03.RunA();

        // Assert
        Assert.Equal(55208, result); // The sum of all digits in the input is 45
    }

    [Fact]
    public void Test_InputTo2dArray_FakeInput()
    {
        string[] input = ["4.", ".6"];
        var day03 = new Day03(input);
        var expected = new char[2, 2];
        expected[0, 0] = '4';
        expected[0, 1] = '.';
        expected[1, 0] = '.';
        expected[1, 1] = '6';

        var transformedInput = day03.InputTo2dArray(input);

        Assert.Equal(expected, transformedInput);
    }

    [Fact]
    public void Test_IsValidPosition_FakeInput()
    {
        string[] input = ["4.", ".6"];
        var day03 = new Day03(input);

        var transformedInput = day03.InputTo2dArray(input);

        Assert.True(day03.IsValidPosition(0, 0));
        Assert.True(day03.IsValidPosition(1, 1));
        Assert.False(day03.IsValidPosition(2, 0));
        Assert.False(day03.IsValidPosition(0, 2));
        Assert.False(day03.IsValidPosition(2, 2));
        Assert.False(day03.IsValidPosition(-1, 0));
        Assert.False(day03.IsValidPosition(0, -1));
    }
}
