using Xunit;

public class DayXYTest
{
    [Theory]
    [InlineData("DayXY.example.input.txt", 1)]
    [InlineData("DayXY.input.txt", 1)]
    public void Test_RunA(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var dayXY = new DayXY(input);

        // Act
        // var result = dayXY.RunA();

        // Assert
        // Assert.Equal(expectedResult, result); 
    }

    [Theory]
    [InlineData("DayXY.example.input.txt", 1)]
    [InlineData("DayXY.input.txt", 1)]
    public void Test_RunB(string inputFilename, int expectedResult)
    {
        // Arrange
        var input = File.ReadAllLines(inputFilename);
        var dayXY = new DayXY(input);

        // Act
        // var result = dayXY.RunB();

        // Assert
        // Assert.Equal(expectedResult, result); 
    }
}
