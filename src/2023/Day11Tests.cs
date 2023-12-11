using Xunit;

public class Day11Test
{
    [Theory]
    [InlineData("Day11.example.input.txt", 374)]
    [InlineData("Day11.input.txt", 1)]
    public void Test_RunA(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day11 = new Day11(input);

        // Act
        var result = day11.RunA();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test_GetCombinations()
    {
        // Arrange
        var listOf9 = Enumerable.Range(1, 9).ToList();

        // Act
        var result = Day11.GetCombinations<int>(listOf9);

        // Assert
        Assert.Equal(36, result.Count);
    }

    [Theory]
    [InlineData("Day11.example.input.txt", 1)]
    public void Test_ParseAndExpand(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day11 = new Day11(input);

        // Act
        var result = day11.ParseAndExpand();
        var verificationGrid = File.ReadAllLines("Day11.example.verification.input.txt")
            .Select(line => line.ToList())
            .ToList();

        // Assert
        Assert.Equal(verificationGrid, result);
    }

    [Fact]
    public void Test_GetShortestPathBetweenPoints()
    {
        // Arrange
        var point1 = (1, 6);
        var point2 = (5, 11);

        // Act

        var shortestPath = Day11.GetShortestPathBetweenPoints(point1, point2);

        // Assert
        Assert.Equal(9, shortestPath);
    }

    [Theory]
    [InlineData("Day11.example.input.txt", 1)]
    [InlineData("Day11.input.txt", 1)]
    public void Test_RunB(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day11 = new Day11(input);

        // Act
        // var result = day11.RunB();

        // Assert
        // Assert.Equal(expectedResult, result);
    }
}
