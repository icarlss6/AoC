using Xunit;

public class Day16Test
{
    [Theory]
    [InlineData("Day16.example.input.txt", 1)]
    [InlineData("Day16.input.txt", 1)]
    public void Test_RunA(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day16 = new Day16(input);

        // Act
        // var result = day16.RunA();

        // Assert
        // Assert.Equal(expectedResult, result); 
    }

    [Theory]
    [InlineData("Day16.example.input.txt", 1)]
    [InlineData("Day16.input.txt", 1)]
    public void Test_RunB(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day16 = new Day16(input);

        // Act
        // var result = day16.RunB();

        // Assert
        // Assert.Equal(expectedResult, result); 
    }
}
