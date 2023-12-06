using Xunit;

public class Day06Test
{
    [Fact]
    public void Test_GetNrOfWaysToBeatRecord()
    {
        // Arrange
        string inputFile = "Day06.example.input.txt";
        var input = File.ReadAllLines(inputFile);
        var day06 = new Day06(input);

        // Act
        var result = day06.GetNrOfWaysToBeatRecord(7,9);

        // Assert
        Assert.Equal(4, result); // The sum of all digits in the input is 45
    }

    [Theory]
    [InlineData("Day06.example.input.txt", 288)]
    [InlineData("Day06.input.txt", 128700)]
    public void TestRunA_Example(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day06 = new Day06(input);

        // Act
        var result = day06.RunA();

        // Assert
        Assert.Equal(expectedResult, result); 
    }

    [Theory]
    [InlineData("Day06.example.input.txt", 71503)]
    [InlineData("Day06.input.txt", 39594072)]
    public void TestRunB_Example(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var day06 = new Day06(input);

        // Act
        var result = day06.RunB();

        // Assert
        Assert.Equal(expectedResult, result); 
    }
}
