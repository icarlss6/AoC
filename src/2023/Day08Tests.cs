using Xunit;

public class Day08Test
{
    [Theory]
    [InlineData("Day08.example.input.txt", 2)]
    [InlineData("Day08.input.txt", 1)]
    public void Test_RunA(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day08 = new Day08(input);

        // Act
        var result = day08.RunA();

        // Assert
        Assert.Equal(expectedResult, result); 
    }

    [Theory]
    [InlineData("Day08b.example.input.txt", 6)]
    [InlineData("Day08.input.txt", 11188774513823)]
    public void Test_RunB(string inputFilename, long expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day08 = new Day08(input);

        // Act
        var result = day08.RunB();

        // Assert
        Assert.Equal(expectedResult, result); 
    }
}
