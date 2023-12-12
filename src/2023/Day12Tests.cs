using Xunit;

public class Day12Test
{
    [Theory]
    [InlineData("Day12.example.input.txt", 21)]
    [InlineData("Day12.input.txt", 6871)]
    public void Test_RunA(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day12 = new Day12(input);

        // Act
        var result = day12.RunA();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("Day12.example.input.txt", 1)]
    [InlineData("Day12.input.txt", 1)]
    public void Test_RunB(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day12 = new Day12(input);

        // Act
        // var result = day12.RunB();

        // Assert
        // Assert.Equal(expectedResult, result);
    }
}
